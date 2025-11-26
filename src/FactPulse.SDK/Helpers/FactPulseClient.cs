using System; using System.Collections.Generic; using System.Net.Http; using System.Net.Http.Headers;
using System.Text; using System.Text.Json; using System.Threading.Tasks;
namespace FactPulse.SDK.Helpers {
    public class FactPulseClient : IDisposable {
        private readonly string _apiUrl, _email, _password, _clientUid;
        private readonly long _pollingInterval, _pollingTimeout;
        private readonly HttpClient _httpClient = new() { Timeout = TimeSpan.FromSeconds(30) };
        private string? _accessToken; private long _tokenExpiresAt;

        public FactPulseClient(string email, string password, string? apiUrl = null, string? clientUid = null, long pollingInterval = 2000, long pollingTimeout = 120000) {
            _email = email; _password = password; _apiUrl = (apiUrl ?? "https://factpulse.fr").TrimEnd('/');
            _clientUid = clientUid ?? ""; _pollingInterval = pollingInterval; _pollingTimeout = pollingTimeout;
        }

        public async Task EnsureAuthenticatedAsync(bool forceRefresh = false) {
            var now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            if (forceRefresh || string.IsNullOrEmpty(_accessToken) || now >= _tokenExpiresAt) {
                var payload = new Dictionary<string, string> { ["username"] = _email, ["password"] = _password };
                if (!string.IsNullOrEmpty(_clientUid)) payload["client_uid"] = _clientUid;
                var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"{_apiUrl}/api/token/", content);
                if (!response.IsSuccessStatusCode) throw new FactPulseAuthException("Auth failed");
                var tokens = JsonSerializer.Deserialize<Dictionary<string, string>>(await response.Content.ReadAsStringAsync());
                _accessToken = tokens!["access"]; _tokenExpiresAt = now + (28 * 60 * 1000);
            }
        }

        public void ResetAuth() { _accessToken = null; _tokenExpiresAt = 0; }

        public async Task<Dictionary<string, object?>> PollTaskAsync(string taskId, long? timeout = null) {
            var timeoutMs = timeout ?? _pollingTimeout;
            var startTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            var currentInterval = (double)_pollingInterval;
            while (true) {
                if (DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - startTime > timeoutMs) throw new FactPulsePollingTimeoutException(taskId, timeoutMs);
                await EnsureAuthenticatedAsync();
                var request = new HttpRequestMessage(HttpMethod.Get, $"{_apiUrl}/api/facturation/v1/traitement/taches/{taskId}/statut");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
                var response = await _httpClient.SendAsync(request);
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized) { ResetAuth(); continue; }
                var data = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(await response.Content.ReadAsStringAsync());
                var statut = data!.TryGetValue("statut", out var s) ? s.GetString() : null;
                if (statut == "SUCCESS") return data.TryGetValue("resultat", out var r) ? JsonSerializer.Deserialize<Dictionary<string, object?>>(r.GetRawText()) ?? new() : new();
                if (statut == "FAILURE") throw new FactPulseValidationException("Task failed");
                await Task.Delay((int)currentInterval); currentInterval = Math.Min(currentInterval * 1.5, 10000);
            }
        }

        public static string FormatMontant(object? m) => m switch {
            null => "0.00", decimal d => d.ToString("F2"), double dbl => dbl.ToString("F2"),
            float f => f.ToString("F2"), int i => i.ToString("F2"), string str => str, _ => "0.00"
        };

        public void Dispose() { _httpClient?.Dispose(); GC.SuppressFinalize(this); }
    }
}
