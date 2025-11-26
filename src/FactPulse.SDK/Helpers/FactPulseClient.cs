using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FactPulse.SDK.Helpers
{
    public class FactPulseClient : IDisposable
    {
        private readonly string _apiUrl, _email, _password, _clientUid;
        private readonly long _pollingInterval, _pollingTimeout;
        private readonly int _maxRetries;
        private readonly HttpClient _httpClient = new() { Timeout = TimeSpan.FromSeconds(30) };
        private string? _accessToken, _refreshToken;
        private long _tokenExpiresAt;

        public FactPulseClient(string email, string password, string? apiUrl = null, string? clientUid = null,
            long pollingInterval = 2000, long pollingTimeout = 120000, int maxRetries = 1)
        {
            _email = email; _password = password;
            _apiUrl = (apiUrl ?? "https://factpulse.fr").TrimEnd('/');
            _clientUid = clientUid ?? ""; _pollingInterval = pollingInterval; _pollingTimeout = pollingTimeout; _maxRetries = maxRetries;
        }

        private async Task<(string Access, string Refresh)> ObtainTokenAsync()
        {
            var payload = new Dictionary<string, string> { ["username"] = _email, ["password"] = _password };
            if (!string.IsNullOrEmpty(_clientUid)) payload["client_uid"] = _clientUid;
            var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{_apiUrl}/api/token/", content);
            if (!response.IsSuccessStatusCode) throw new FactPulseAuthException("Impossible d'obtenir le token JWT");
            var tokens = JsonSerializer.Deserialize<Dictionary<string, string>>(await response.Content.ReadAsStringAsync());
            return (tokens!["access"], tokens["refresh"]);
        }

        public async Task EnsureAuthenticatedAsync(bool forceRefresh = false)
        {
            var now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            if (forceRefresh || string.IsNullOrEmpty(_accessToken) || now >= _tokenExpiresAt)
            {
                var (access, refresh) = await ObtainTokenAsync();
                _accessToken = access; _refreshToken = refresh; _tokenExpiresAt = now + (28 * 60 * 1000);
            }
        }

        public void ResetAuth() { _accessToken = _refreshToken = null; _tokenExpiresAt = 0; }

        public async Task<Dictionary<string, object?>> PollTaskAsync(string taskId, long? timeout = null, long? interval = null)
        {
            var timeoutMs = timeout ?? _pollingTimeout;
            var intervalMs = interval ?? _pollingInterval;
            var startTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            var currentInterval = (double)intervalMs;

            while (true)
            {
                if (DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - startTime > timeoutMs)
                    throw new FactPulsePollingTimeoutException(taskId, timeoutMs);
                await EnsureAuthenticatedAsync();
                var request = new HttpRequestMessage(HttpMethod.Get, $"{_apiUrl}/api/facturation/v1/traitement/taches/{taskId}/statut");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
                var response = await _httpClient.SendAsync(request);
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized) { ResetAuth(); continue; }
                var data = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(await response.Content.ReadAsStringAsync());
                var statut = data!.TryGetValue("statut", out var s) ? s.GetString() : null;
                if (statut == "SUCCESS") return data.TryGetValue("resultat", out var r) ? JsonSerializer.Deserialize<Dictionary<string, object?>>(r.GetRawText()) ?? new() : new();
                if (statut == "FAILURE")
                {
                    var errors = new List<ValidationErrorDetail>();
                    if (data.TryGetValue("resultat", out var fr))
                    {
                        var res = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(fr.GetRawText());
                        var msg = res?.TryGetValue("message_erreur", out var m) == true ? m.GetString() : "Erreur inconnue";
                        if (res?.TryGetValue("erreurs", out var e) == true && e.ValueKind == JsonValueKind.Array)
                            foreach (var err in e.EnumerateArray())
                            {
                                var d = JsonSerializer.Deserialize<Dictionary<string, object?>>(err.GetRawText());
                                if (d != null) errors.Add(ValidationErrorDetail.FromDictionary(d));
                            }
                        throw new FactPulseValidationException($"La tâche {taskId} a échoué: {msg}", errors);
                    }
                }
                await Task.Delay((int)currentInterval);
                currentInterval = Math.Min(currentInterval * 1.5, 10000);
            }
        }

        public async Task<byte[]> GenererFacturxAsync(object factureData, string pdfPath, string profil = "EN16931",
            string formatSortie = "pdf", bool sync = true, long? timeout = null)
        {
            var jsonData = factureData is string s ? s : JsonSerializer.Serialize(factureData);
            string? taskId = null;
            for (var attempt = 0; attempt <= _maxRetries; attempt++)
            {
                await EnsureAuthenticatedAsync();
                using var form = new MultipartFormDataContent();
                form.Add(new StringContent(jsonData), "donnees_facture");
                form.Add(new StringContent(profil), "profil");
                form.Add(new StringContent(formatSortie), "format_sortie");
                var fileContent = new ByteArrayContent(await File.ReadAllBytesAsync(pdfPath));
                fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
                form.Add(fileContent, "source_pdf", Path.GetFileName(pdfPath));
                using var client = new HttpClient { Timeout = TimeSpan.FromSeconds(60) };
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
                var response = await client.PostAsync($"{_apiUrl}/api/facturation/v1/traitement/generer-facture", form);
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized && attempt < _maxRetries) { ResetAuth(); continue; }
                var data = JsonSerializer.Deserialize<Dictionary<string, string>>(await response.Content.ReadAsStringAsync());
                taskId = data?.TryGetValue("id_tache", out var id) == true ? id : null;
                break;
            }
            if (string.IsNullOrEmpty(taskId)) throw new FactPulseValidationException("Pas d'ID de tâche");
            if (!sync) return Encoding.UTF8.GetBytes(taskId);
            var result = await PollTaskAsync(taskId, timeout);
            if (result.TryGetValue("contenu_b64", out var b64) && b64 is JsonElement el)
                return Convert.FromBase64String(el.GetString()!);
            throw new FactPulseValidationException("Pas de contenu");
        }

        public static string FormatMontant(object? m) => m switch {
            null => "0.00", decimal d => d.ToString("F2"), double dbl => dbl.ToString("F2"),
            float f => f.ToString("F2"), int i => i.ToString("F2"), long l => l.ToString("F2"),
            string str => str, _ => "0.00"
        };

        public void Dispose() { _httpClient?.Dispose(); GC.SuppressFinalize(this); }
    }
}
