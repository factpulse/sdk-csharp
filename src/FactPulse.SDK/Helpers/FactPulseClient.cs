using System; using System.Collections.Generic; using System.IO; using System.Net.Http; using System.Net.Http.Headers;
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

    /// <summary>Credentials AFNOR PDP pour le mode Zero-Trust. L'API FactPulse utilise ces credentials pour s'authentifier auprès de la PDP AFNOR.</summary>
    public class AFNORCredentials {
        public string FlowServiceUrl { get; }
        public string TokenUrl { get; }
        public string ClientId { get; }
        public string ClientSecret { get; }
        public string? DirectoryServiceUrl { get; }
        public AFNORCredentials(string flowServiceUrl, string tokenUrl, string clientId, string clientSecret, string? directoryServiceUrl = null) {
            FlowServiceUrl = flowServiceUrl; TokenUrl = tokenUrl; ClientId = clientId; ClientSecret = clientSecret; DirectoryServiceUrl = directoryServiceUrl;
        }
        public Dictionary<string, object> ToDict() {
            var dict = new Dictionary<string, object> {
                ["flow_service_url"] = FlowServiceUrl, ["token_url"] = TokenUrl,
                ["client_id"] = ClientId, ["client_secret"] = ClientSecret
            };
            if (DirectoryServiceUrl != null) dict["directory_service_url"] = DirectoryServiceUrl;
            return dict;
        }
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

        /// <summary>Crée une ligne de poste (aligné sur LigneDePoste de models.py).</summary>
        public static Dictionary<string, object> LigneDePoste(int numero, string denomination, object quantite,
            object montantUnitaireHt, object montantTotalLigneHt, string tauxTva = "20.00", string categorieTva = "S", string unite = "FORFAIT",
            string? reference = null, object? montantRemiseHt = null,
            string? codeRaisonReduction = null, string? raisonReduction = null,
            string? dateDebutPeriode = null, string? dateFinPeriode = null) {
            var result = new Dictionary<string, object> {
                ["numero"] = numero, ["denomination"] = denomination, ["quantite"] = Montant(quantite),
                ["montantUnitaireHt"] = Montant(montantUnitaireHt), ["montantTotalLigneHt"] = Montant(montantTotalLigneHt),
                ["tauxTva"] = Montant(tauxTva), ["categorieTva"] = categorieTva, ["unite"] = unite
            };
            if (reference != null) result["reference"] = reference;
            if (montantRemiseHt != null) result["montantRemiseHt"] = Montant(montantRemiseHt);
            if (codeRaisonReduction != null) result["codeRaisonReduction"] = codeRaisonReduction;
            if (raisonReduction != null) result["raisonReduction"] = raisonReduction;
            if (dateDebutPeriode != null) result["dateDebutPeriode"] = dateDebutPeriode;
            if (dateFinPeriode != null) result["dateFinPeriode"] = dateFinPeriode;
            return result;
        }

        /// <summary>Crée une ligne de TVA (aligné sur LigneDeTVA de models.py).</summary>
        public static Dictionary<string, object> LigneDeTva(object tauxManuel, object montantBaseHt, object montantTva, string categorie = "S") {
            return new Dictionary<string, object> {
                ["tauxManuel"] = Montant(tauxManuel), ["montantBaseHt"] = Montant(montantBaseHt),
                ["montantTva"] = Montant(montantTva), ["categorie"] = categorie
            };
        }

        /// <summary>Crée une adresse postale pour l'API FactPulse.</summary>
        public static Dictionary<string, object> AdressePostale(string ligne1, string codePostal, string ville, string pays = "FR", string? ligne2 = null, string? ligne3 = null) {
            var result = new Dictionary<string, object> { ["ligneUn"] = ligne1, ["codePostal"] = codePostal, ["nomVille"] = ville, ["paysCodeIso"] = pays };
            if (ligne2 != null) result["ligneDeux"] = ligne2;
            if (ligne3 != null) result["ligneTrois"] = ligne3;
            return result;
        }

        /// <summary>Crée une adresse électronique. schemeId: "0009"=SIREN, "0225"=SIRET</summary>
        public static Dictionary<string, object> AdresseElectronique(string identifiant, string schemeId = "0009") {
            return new Dictionary<string, object> { ["identifiant"] = identifiant, ["schemeId"] = schemeId };
        }

        /// <summary>Calcule le numéro TVA intracommunautaire français depuis un SIREN.</summary>
        private static string? CalculerTvaIntra(string siren) {
            if (siren.Length != 9 || !long.TryParse(siren, out var sirenNum)) return null;
            var cle = (12 + 3 * (sirenNum % 97)) % 97;
            return $"FR{cle:D2}{siren}";
        }

        /// <summary>Crée un fournisseur (émetteur) avec auto-calcul SIREN, TVA intracommunautaire et adresses.</summary>
        public static Dictionary<string, object> Fournisseur(string nom, string siret, string adresseLigne1, string codePostal, string ville,
            int idFournisseur = 0, string? siren = null, string? numeroTvaIntra = null, string? iban = null, string pays = "FR",
            string? adresseLigne2 = null, int? codeService = null, int? codeCoordonnesBancaires = null) {
            siren ??= siret.Length == 14 ? siret[..9] : null;
            numeroTvaIntra ??= siren != null ? CalculerTvaIntra(siren) : null;
            var result = new Dictionary<string, object> {
                ["nom"] = nom, ["idFournisseur"] = idFournisseur, ["siret"] = siret,
                ["adresseElectronique"] = AdresseElectronique(siret, "0225"),
                ["adressePostale"] = AdressePostale(adresseLigne1, codePostal, ville, pays, adresseLigne2)
            };
            if (siren != null) result["siren"] = siren;
            if (numeroTvaIntra != null) result["numeroTvaIntra"] = numeroTvaIntra;
            if (iban != null) result["iban"] = iban;
            if (codeService != null) result["idServiceFournisseur"] = codeService;
            if (codeCoordonnesBancaires != null) result["codeCoordonnesBancairesFournisseur"] = codeCoordonnesBancaires;
            return result;
        }

        /// <summary>Crée un destinataire (client) avec auto-calcul SIREN et adresses.</summary>
        public static Dictionary<string, object> Destinataire(string nom, string siret, string adresseLigne1, string codePostal, string ville,
            string? siren = null, string pays = "FR", string? adresseLigne2 = null, string? codeServiceExecutant = null) {
            siren ??= siret.Length == 14 ? siret[..9] : null;
            var result = new Dictionary<string, object> {
                ["nom"] = nom, ["siret"] = siret,
                ["adresseElectronique"] = AdresseElectronique(siret, "0225"),
                ["adressePostale"] = AdressePostale(adresseLigne1, codePostal, ville, pays, adresseLigne2)
            };
            if (siren != null) result["siren"] = siren;
            if (codeServiceExecutant != null) result["codeServiceExecutant"] = codeServiceExecutant;
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
                var request = new HttpRequestMessage(HttpMethod.Get, $"{_apiUrl}/api/v1/traitement/taches/{taskId}/statut");
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

        /// <summary>Génère une facture Factur-X à partir d'un dictionnaire et d'un PDF source.</summary>
        public async Task<byte[]> GenererFacturxAsync(object factureData, string pdfPath, string profil = "EN16931", string formatSortie = "pdf", bool sync = true, long? timeout = null) {
            // Conversion des données en JSON string
            string jsonData;
            if (factureData is string str) jsonData = str;
            else if (factureData is Dictionary<string, object> dict) jsonData = JsonSerializer.Serialize(dict);
            else jsonData = JsonSerializer.Serialize(factureData);

            // Lecture du fichier PDF
            var pdfContent = await File.ReadAllBytesAsync(pdfPath);
            var pdfFilename = Path.GetFileName(pdfPath);

            await EnsureAuthenticatedAsync();

            // Construire la requête multipart
            using var content = new MultipartFormDataContent();
            content.Add(new StringContent(jsonData), "donnees_facture");
            content.Add(new StringContent(profil), "profil");
            content.Add(new StringContent(formatSortie), "format_sortie");
            content.Add(new ByteArrayContent(pdfContent), "source_pdf", pdfFilename);

            var request = new HttpRequestMessage(HttpMethod.Post, $"{_apiUrl}/api/v1/traitement/generer-facture") { Content = content };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);

            var response = await _httpClient.SendAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized) {
                ResetAuth();
                await EnsureAuthenticatedAsync();
                request = new HttpRequestMessage(HttpMethod.Post, $"{_apiUrl}/api/v1/traitement/generer-facture") { Content = content };
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
                response = await _httpClient.SendAsync(request);
            }

            var responseBody = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode) throw new FactPulseValidationException($"Erreur API ({(int)response.StatusCode}): {responseBody}");

            var data = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(responseBody);

            if (sync && data!.TryGetValue("id_tache", out var taskIdElement)) {
                var taskId = taskIdElement.GetString()!;
                var result = await PollTaskAsync(taskId, timeout);
                if (result.TryGetValue("contenu_b64", out var contenuB64) && contenuB64 is string base64Str)
                    return Convert.FromBase64String(base64Str);
                if (result.TryGetValue("contenu_xml", out var xml) && xml is string xmlStr)
                    return Encoding.UTF8.GetBytes(xmlStr);
                throw new FactPulseValidationException("Résultat inattendu");
            }

            return Encoding.UTF8.GetBytes(responseBody);
        }

        public void Dispose() { _httpClient?.Dispose(); GC.SuppressFinalize(this); }
    }
}
