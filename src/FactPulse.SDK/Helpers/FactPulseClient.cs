using System; using System.Collections.Generic; using System.Net.Http; using System.Net.Http.Headers;
using System.Text; using System.Text.Json; using System.Threading.Tasks;
namespace FactPulse.SDK.Helpers {
    /// <summary>Credentials Chorus Pro pour le mode Zero-Trust.</summary>
    public class ChorusProCredentials {
        public string PisteClientId { get; }
        public string PisteClientSecret { get; }
        public string ChorusProLogin { get; }
        public string ChorusProPassword { get; }
        public bool Sandbox { get; }
        public ChorusProCredentials(string pisteClientId, string pisteClientSecret, string chorusProLogin, string chorusProPassword, bool sandbox = true) {
            PisteClientId = pisteClientId; PisteClientSecret = pisteClientSecret; ChorusProLogin = chorusProLogin; ChorusProPassword = chorusProPassword; Sandbox = sandbox;
        }
        public Dictionary<string, object> ToDict() => new() {
            ["piste_client_id"] = PisteClientId, ["piste_client_secret"] = PisteClientSecret,
            ["chorus_pro_login"] = ChorusProLogin, ["chorus_pro_password"] = ChorusProPassword, ["sandbox"] = Sandbox
        };
    }

    /// <summary>Credentials AFNOR PDP pour le mode Zero-Trust.</summary>
    public class AFNORCredentials {
        public string ClientId { get; }
        public string ClientSecret { get; }
        public string FlowServiceUrl { get; }
        public AFNORCredentials(string clientId, string clientSecret, string flowServiceUrl) {
            ClientId = clientId; ClientSecret = clientSecret; FlowServiceUrl = flowServiceUrl;
        }
        public Dictionary<string, object> ToDict() => new() {
            ["client_id"] = ClientId, ["client_secret"] = ClientSecret, ["flow_service_url"] = FlowServiceUrl
        };
    }

    /// <summary>Helpers pour créer des montants simplifiés.</summary>
    public static class MontantHelpers {
        public static string Montant(object? m) => m switch {
            null => "0.00", decimal d => d.ToString("F2"), double dbl => dbl.ToString("F2"),
            float f => f.ToString("F2"), int i => i.ToString("F2"), long l => l.ToString("F2"), string str => str, _ => "0.00"
        };

        public static Dictionary<string, object> MontantTotal(object ht, object tva, object ttc, object aPayer,
            object? remiseTtc = null, string? motifRemise = null, object? acompte = null) {
            var result = new Dictionary<string, object> {
                ["montantHtTotal"] = Montant(ht), ["montantTva"] = Montant(tva),
                ["montantTtcTotal"] = Montant(ttc), ["montantAPayer"] = Montant(aPayer)
            };
            if (remiseTtc != null) result["montantRemiseGlobaleTtc"] = Montant(remiseTtc);
            if (motifRemise != null) result["motifRemiseGlobaleTtc"] = motifRemise;
            if (acompte != null) result["acompte"] = Montant(acompte);
            return result;
        }

        public static Dictionary<string, object> LigneDePoste(int numero, string denomination, object quantite,
            object montantUnitaireHt, object montantLigneHt, string tauxTva = "20.00", string unite = "C62",
            object? montantTvaLigne = null, object? montantRemiseHt = null, string? codeRaisonRemise = null,
            string? motifRemise = null, string? description = null) {
            var result = new Dictionary<string, object> {
                ["numero"] = numero, ["denomination"] = denomination, ["quantite"] = Montant(quantite),
                ["montantUnitaireHt"] = Montant(montantUnitaireHt), ["montantTotalLigneHt"] = Montant(montantLigneHt),
                ["tauxTva"] = Montant(tauxTva), ["unite"] = unite
            };
            if (montantTvaLigne != null) result["montantTvaLigne"] = Montant(montantTvaLigne);
            if (montantRemiseHt != null) result["montantRemiseHt"] = Montant(montantRemiseHt);
            if (codeRaisonRemise != null) result["codeRaisonReduction"] = codeRaisonRemise;
            if (motifRemise != null) result["motifRemise"] = motifRemise;
            if (description != null) result["description"] = description;
            return result;
        }

        public static Dictionary<string, object> LigneDeTva(object taux, object baseHt, object montantTva,
            string categorie = "S", string? motifExoneration = null) {
            var result = new Dictionary<string, object> {
                ["tauxTva"] = Montant(taux), ["montantBaseHt"] = Montant(baseHt),
                ["montantTva"] = Montant(montantTva), ["categorieTva"] = categorie
            };
            if (motifExoneration != null) result["motifExoneration"] = motifExoneration;
            return result;
        }
    }

    public class FactPulseClient : IDisposable {
        private readonly string _apiUrl, _email, _password, _clientUid;
        private readonly long _pollingInterval, _pollingTimeout;
        private readonly HttpClient _httpClient = new() { Timeout = TimeSpan.FromSeconds(30) };
        private string? _accessToken; private long _tokenExpiresAt;
        public ChorusProCredentials? ChorusCredentials { get; }
        public AFNORCredentials? AfnorCredentials { get; }

        public FactPulseClient(string email, string password, string? apiUrl = null, string? clientUid = null,
            ChorusProCredentials? chorusCredentials = null, AFNORCredentials? afnorCredentials = null,
            long pollingInterval = 2000, long pollingTimeout = 120000) {
            _email = email; _password = password; _apiUrl = (apiUrl ?? "https://factpulse.fr").TrimEnd('/');
            _clientUid = clientUid ?? ""; _pollingInterval = pollingInterval; _pollingTimeout = pollingTimeout;
            ChorusCredentials = chorusCredentials; AfnorCredentials = afnorCredentials;
        }

        public Dictionary<string, object>? GetChorusCredentialsForApi() => ChorusCredentials?.ToDict();
        public Dictionary<string, object>? GetAfnorCredentialsForApi() => AfnorCredentials?.ToDict();
        // Alias plus courts
        public Dictionary<string, object>? GetChorusProCredentials() => GetChorusCredentialsForApi();
        public Dictionary<string, object>? GetAfnorCredentials() => GetAfnorCredentialsForApi();

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

        public static string FormatMontant(object? m) => MontantHelpers.Montant(m);

        public void Dispose() { _httpClient?.Dispose(); GC.SuppressFinalize(this); }
    }
}
