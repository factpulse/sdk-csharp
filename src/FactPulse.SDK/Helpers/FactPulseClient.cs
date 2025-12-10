using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FactPulse.SDK.Helpers
{
    // =============================================================================
    // Credentials classes
    // =============================================================================

    /// <summary>Credentials Chorus Pro pour le mode Zero-Trust.</summary>
    public class ChorusProCredentials
    {
        public string PisteClientId { get; set; }
        public string PisteClientSecret { get; set; }
        public string ChorusProLogin { get; set; }
        public string ChorusProPassword { get; set; }
        public bool Sandbox { get; set; } = true;

        public ChorusProCredentials(string pisteClientId, string pisteClientSecret, string chorusProLogin, string chorusProPassword, bool sandbox = true)
        {
            PisteClientId = pisteClientId; PisteClientSecret = pisteClientSecret;
            ChorusProLogin = chorusProLogin; ChorusProPassword = chorusProPassword; Sandbox = sandbox;
        }

        public Dictionary<string, object> ToDict() => new Dictionary<string, object> {
            ["piste_client_id"] = PisteClientId, ["piste_client_secret"] = PisteClientSecret,
            ["chorus_pro_login"] = ChorusProLogin, ["chorus_pro_password"] = ChorusProPassword, ["sandbox"] = Sandbox
        };
    }

    /// <summary>Credentials AFNOR PDP pour le mode Zero-Trust.</summary>
    public class AFNORCredentials
    {
        public string FlowServiceUrl { get; set; }
        public string TokenUrl { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string DirectoryServiceUrl { get; set; }

        public AFNORCredentials(string flowServiceUrl, string tokenUrl, string clientId, string clientSecret, string directoryServiceUrl = null)
        {
            FlowServiceUrl = flowServiceUrl; TokenUrl = tokenUrl;
            ClientId = clientId; ClientSecret = clientSecret; DirectoryServiceUrl = directoryServiceUrl;
        }

        public Dictionary<string, object> ToDict()
        {
            var result = new Dictionary<string, object> {
                ["flow_service_url"] = FlowServiceUrl, ["token_url"] = TokenUrl,
                ["client_id"] = ClientId, ["client_secret"] = ClientSecret
            };
            if (!string.IsNullOrEmpty(DirectoryServiceUrl)) result["directory_service_url"] = DirectoryServiceUrl;
            return result;
        }
    }

    // =============================================================================
    // Helpers pour les montants
    // =============================================================================

    public static class MontantHelpers
    {
        public static string Montant(object value)
        {
            if (value == null) return "0.00";
            if (value is decimal d) return d.ToString("F2");
            if (value is double dbl) return dbl.ToString("F2");
            if (value is float f) return f.ToString("F2");
            if (value is int i) return i.ToString("F2");
            if (value is long l) return l.ToString("F2");
            if (value is string s) return s;
            return "0.00";
        }

        public static Dictionary<string, object> MontantTotal(object ht, object tva, object ttc, object aPayer,
            object remiseTtc = null, string motifRemise = null, object acompte = null)
        {
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
            object montantUnitaireHt, object montantTotalLigneHt, string tauxTva = "20.00",
            string categorieTva = "S", string unite = "FORFAIT", Dictionary<string, object> options = null)
        {
            var result = new Dictionary<string, object> {
                ["numero"] = numero, ["denomination"] = denomination, ["quantite"] = Montant(quantite),
                ["montantUnitaireHt"] = Montant(montantUnitaireHt), ["montantTotalLigneHt"] = Montant(montantTotalLigneHt),
                ["tauxTvaManuel"] = Montant(tauxTva), ["categorieTva"] = categorieTva, ["unite"] = unite
            };
            if (options != null)
            {
                if (options.TryGetValue("reference", out var r)) result["reference"] = r;
                if (options.TryGetValue("montantRemiseHt", out var m)) result["montantRemiseHt"] = Montant(m);
                if (options.TryGetValue("codeRaisonReduction", out var c)) result["codeRaisonReduction"] = c;
                if (options.TryGetValue("raisonReduction", out var rr)) result["raisonReduction"] = rr;
                if (options.TryGetValue("dateDebutPeriode", out var dd)) result["dateDebutPeriode"] = dd;
                if (options.TryGetValue("dateFinPeriode", out var df)) result["dateFinPeriode"] = df;
            }
            return result;
        }

        /// <summary>Crée une ligne de TVA (aligné sur LigneDeTVA de models.py).</summary>
        public static Dictionary<string, object> LigneDeTva(object tauxManuel, object montantBaseHt, object montantTva, string categorie = "S")
            => new Dictionary<string, object> {
                ["tauxManuel"] = Montant(tauxManuel), ["montantBaseHt"] = Montant(montantBaseHt),
                ["montantTva"] = Montant(montantTva), ["categorie"] = categorie
            };

        /// <summary>Crée une adresse postale pour l'API FactPulse.</summary>
        public static Dictionary<string, object> AdressePostale(string ligne1, string codePostal, string ville,
            string pays = "FR", string ligne2 = null, string ligne3 = null)
        {
            var result = new Dictionary<string, object> { ["ligneUn"] = ligne1, ["codePostal"] = codePostal, ["nomVille"] = ville, ["paysCodeIso"] = pays };
            if (ligne2 != null) result["ligneDeux"] = ligne2;
            if (ligne3 != null) result["ligneTrois"] = ligne3;
            return result;
        }

        /// <summary>Crée une adresse électronique. schemeId: "0009"=SIREN, "0225"=SIRET</summary>
        public static Dictionary<string, object> AdresseElectronique(string identifiant, string schemeId = "0009")
            => new Dictionary<string, object> { ["identifiant"] = identifiant, ["schemeId"] = schemeId };

        /// <summary>Calcule le numéro TVA intracommunautaire français depuis un SIREN.</summary>
        public static string CalculerTvaIntra(string siren)
        {
            if (string.IsNullOrEmpty(siren) || siren.Length != 9 || !siren.All(char.IsDigit)) return null;
            var cle = (12 + 3 * (long.Parse(siren) % 97)) % 97;
            return $"FR{cle:D2}{siren}";
        }

        /// <summary>Crée un fournisseur (émetteur) avec auto-calcul SIREN, TVA intracommunautaire et adresses.</summary>
        public static Dictionary<string, object> Fournisseur(string nom, string siret, string adresseLigne1,
            string codePostal, string ville, Dictionary<string, object> options = null)
        {
            options ??= new Dictionary<string, object>();
            var siren = options.TryGetValue("siren", out var s) ? s?.ToString() : (siret.Length == 14 ? siret.Substring(0, 9) : null);
            var numeroTvaIntra = options.TryGetValue("numeroTvaIntra", out var t) ? t?.ToString() : (siren != null ? CalculerTvaIntra(siren) : null);
            var pays = options.TryGetValue("pays", out var p) ? p?.ToString() : "FR";
            var adresseLigne2 = options.TryGetValue("adresseLigne2", out var a2) ? a2?.ToString() : null;

            var result = new Dictionary<string, object> {
                ["nom"] = nom, ["idFournisseur"] = options.ContainsKey("idFournisseur") ? options["idFournisseur"] : 0, ["siret"] = siret,
                ["adresseElectronique"] = AdresseElectronique(siret, "0225"),
                ["adressePostale"] = AdressePostale(adresseLigne1, codePostal, ville, pays, adresseLigne2)
            };
            if (siren != null) result["siren"] = siren;
            if (numeroTvaIntra != null) result["numeroTvaIntra"] = numeroTvaIntra;
            if (options.TryGetValue("iban", out var iban)) result["iban"] = iban;
            if (options.TryGetValue("codeService", out var cs)) result["idServiceFournisseur"] = cs;
            if (options.TryGetValue("codeCoordonnesBancaires", out var ccb)) result["codeCoordonnesBancairesFournisseur"] = ccb;
            return result;
        }

        /// <summary>Crée un destinataire (client) avec auto-calcul SIREN et adresses.</summary>
        public static Dictionary<string, object> Destinataire(string nom, string siret, string adresseLigne1,
            string codePostal, string ville, Dictionary<string, object> options = null)
        {
            options ??= new Dictionary<string, object>();
            var siren = options.TryGetValue("siren", out var s) ? s?.ToString() : (siret.Length == 14 ? siret.Substring(0, 9) : null);
            var pays = options.TryGetValue("pays", out var p) ? p?.ToString() : "FR";
            var adresseLigne2 = options.TryGetValue("adresseLigne2", out var a2) ? a2?.ToString() : null;

            var result = new Dictionary<string, object> {
                ["nom"] = nom, ["siret"] = siret,
                ["adresseElectronique"] = AdresseElectronique(siret, "0225"),
                ["adressePostale"] = AdressePostale(adresseLigne1, codePostal, ville, pays, adresseLigne2)
            };
            if (siren != null) result["siren"] = siren;
            if (options.TryGetValue("codeServiceExecutant", out var cse)) result["codeServiceExecutant"] = cse;
            return result;
        }

        /// <summary>
        /// Crée un bénéficiaire (factor) pour l'affacturage.
        ///
        /// Le bénéficiaire (BG-10 / PayeeTradeParty) est utilisé lorsque le paiement
        /// doit être effectué à un tiers différent du fournisseur, typiquement un
        /// factor (société d'affacturage).
        ///
        /// Pour les factures affacturées, il faut aussi:
        /// - Utiliser un type de document affacturé (393, 396, 501, 502, 472, 473)
        /// - Ajouter une note ACC avec la mention de subrogation
        /// - L'IBAN du bénéficiaire sera utilisé pour le paiement
        /// </summary>
        /// <param name="nom">Raison sociale du factor (BT-59)</param>
        /// <param name="options">Options: siret (BT-60), siren (BT-61), iban, bic</param>
        /// <returns>Dict prêt à être utilisé dans une facture affacturée</returns>
        public static Dictionary<string, object> Beneficiaire(string nom, Dictionary<string, object> options = null)
        {
            options ??= new Dictionary<string, object>();
            var siret = options.TryGetValue("siret", out var si) ? si?.ToString() : null;
            // Auto-calcul SIREN depuis SIRET
            var siren = options.TryGetValue("siren", out var sr) ? sr?.ToString()
                : (siret != null && siret.Length == 14 ? siret.Substring(0, 9) : null);

            var result = new Dictionary<string, object> { ["nom"] = nom };
            if (siret != null) result["siret"] = siret;
            if (siren != null) result["siren"] = siren;
            if (options.TryGetValue("iban", out var iban)) result["iban"] = iban;
            if (options.TryGetValue("bic", out var bic)) result["bic"] = bic;
            return result;
        }
    }

    // =============================================================================
    // Client principal
    // =============================================================================

    public class FactPulseClient : IDisposable
    {
        private const string DefaultApiUrl = "https://factpulse.fr";
        private readonly string _email, _password, _apiUrl, _clientUid;
        private readonly int _pollingInterval, _pollingTimeout, _maxRetries;
        private readonly HttpClient _httpClient;
        public ChorusProCredentials ChorusCredentials { get; }
        public AFNORCredentials AfnorCredentials { get; }
        private string _accessToken, _refreshToken;
        private DateTime? _tokenExpiresAt;

        public FactPulseClient(string email, string password, string apiUrl = null, string clientUid = null,
            ChorusProCredentials chorusCredentials = null, AFNORCredentials afnorCredentials = null,
            int pollingInterval = 2000, int pollingTimeout = 120000, int maxRetries = 1)
        {
            _email = email; _password = password;
            _apiUrl = (apiUrl ?? DefaultApiUrl).TrimEnd('/');
            _clientUid = clientUid;
            ChorusCredentials = chorusCredentials;
            AfnorCredentials = afnorCredentials;
            _pollingInterval = pollingInterval; _pollingTimeout = pollingTimeout; _maxRetries = maxRetries;
            _httpClient = new HttpClient { Timeout = TimeSpan.FromMinutes(2) };
        }

        public Dictionary<string, object> GetChorusCredentialsForApi() => ChorusCredentials?.ToDict();
        public Dictionary<string, object> GetAfnorCredentialsForApi() => AfnorCredentials?.ToDict();
        // Alias plus courts
        public Dictionary<string, object> GetChorusProCredentials() => GetChorusCredentialsForApi();
        public Dictionary<string, object> GetAfnorCredentials() => GetAfnorCredentialsForApi();

        public async Task EnsureAuthenticatedAsync(bool forceRefresh = false)
        {
            if (forceRefresh || string.IsNullOrEmpty(_accessToken) || (_tokenExpiresAt.HasValue && DateTime.UtcNow >= _tokenExpiresAt))
            {
                var payload = new Dictionary<string, string> { ["username"] = _email, ["password"] = _password };
                if (!string.IsNullOrEmpty(_clientUid)) payload["client_uid"] = _clientUid;
                var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"{_apiUrl}/api/token/", content);
                if (!response.IsSuccessStatusCode) throw new FactPulseAuthException("Auth failed");
                var json = await response.Content.ReadAsStringAsync();
                var tokens = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
                _accessToken = tokens["access"]; _refreshToken = tokens["refresh"];
                _tokenExpiresAt = DateTime.UtcNow.AddMinutes(28);
            }
        }

        public void ResetAuth() { _accessToken = _refreshToken = null; _tokenExpiresAt = null; }

        public async Task<Dictionary<string, object>> PollTaskAsync(string taskId, int? timeout = null, int? interval = null)
        {
            var timeoutMs = timeout ?? _pollingTimeout;
            var intervalMs = interval ?? _pollingInterval;
            var startTime = DateTime.UtcNow;
            var currentInterval = (double)intervalMs;

            while (true)
            {
                if ((DateTime.UtcNow - startTime).TotalMilliseconds > timeoutMs)
                    throw new FactPulsePollingTimeoutException(taskId, timeoutMs);

                await EnsureAuthenticatedAsync();
                var request = new HttpRequestMessage(HttpMethod.Get, $"{_apiUrl}/api/v1/traitement/taches/{taskId}/statut");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
                var response = await _httpClient.SendAsync(request);

                if ((int)response.StatusCode == 401) { ResetAuth(); continue; }

                var json = await response.Content.ReadAsStringAsync();
                var data = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(json);
                var statut = data["statut"].GetString();

                if (statut == "SUCCESS")
                    return data.TryGetValue("resultat", out var r) ? JsonSerializer.Deserialize<Dictionary<string, object>>(r.GetRawText()) : new Dictionary<string, object>();

                if (statut == "FAILURE")
                    throw new FactPulseValidationException($"Task {taskId} failed", null);

                await Task.Delay((int)currentInterval);
                currentInterval = Math.Min(currentInterval * 1.5, 10000);
            }
        }

        public static string FormatMontant(object m) => MontantHelpers.Montant(m);

        public async Task<byte[]> GenererFacturxAsync(object factureData, string pdfPath, string profil = "EN16931",
            string formatSortie = "pdf", bool sync = true, int? timeout = null)
        {
            var jsonData = factureData is string s ? s : JsonSerializer.Serialize(factureData);
            var pdfContent = await File.ReadAllBytesAsync(pdfPath);

            await EnsureAuthenticatedAsync();
            using var content = new MultipartFormDataContent();
            content.Add(new StringContent(jsonData), "donnees_facture");
            content.Add(new StringContent(profil), "profil");
            content.Add(new StringContent(formatSortie), "format_sortie");
            content.Add(new ByteArrayContent(pdfContent), "source_pdf", Path.GetFileName(pdfPath));

            var request = new HttpRequestMessage(HttpMethod.Post, $"{_apiUrl}/api/v1/traitement/generer-facture") { Content = content };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
            var response = await _httpClient.SendAsync(request);

            if ((int)response.StatusCode == 401)
            {
                ResetAuth(); await EnsureAuthenticatedAsync();
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
                response = await _httpClient.SendAsync(request);
            }

            var json = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                // Extraire les détails d'erreur du corps de la réponse
                var errorMsg = $"Erreur API ({(int)response.StatusCode})";
                var errors = new List<ValidationErrorDetail>();

                try
                {
                    using var doc = JsonDocument.Parse(json);
                    var root = doc.RootElement;

                    // Format FastAPI/Pydantic: {"detail": [{"loc": [...], "msg": "...", "type": "..."}]}
                    if (root.TryGetProperty("detail", out var detail))
                    {
                        if (detail.ValueKind == JsonValueKind.Array)
                        {
                            errorMsg = "Erreur de validation";
                            foreach (var err in detail.EnumerateArray())
                            {
                                var loc = "";
                                if (err.TryGetProperty("loc", out var locArray) && locArray.ValueKind == JsonValueKind.Array)
                                {
                                    loc = string.Join(" -> ", locArray.EnumerateArray().Select(l => l.ToString()));
                                }
                                var reason = err.TryGetProperty("msg", out var msg) ? msg.GetString() ?? "" : "";
                                var code = err.TryGetProperty("type", out var type) ? type.GetString() : null;
                                errors.Add(new ValidationErrorDetail("ERROR", loc, reason, "validation", code));
                            }
                        }
                        else if (detail.ValueKind == JsonValueKind.String)
                        {
                            errorMsg = detail.GetString() ?? errorMsg;
                        }
                    }
                    else if (root.TryGetProperty("errorMessage", out var errMsg))
                    {
                        errorMsg = errMsg.GetString() ?? errorMsg;
                    }
                }
                catch { /* ignore parsing errors */ }

                Console.Error.WriteLine($"Erreur API {(int)response.StatusCode}: {json}");
                throw new FactPulseValidationException(errorMsg, errors);
            }

            var data = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(json);
            if (sync && data.TryGetValue("id_tache", out var taskIdElem))
            {
                var result = await PollTaskAsync(taskIdElem.GetString(), timeout);
                if (result.TryGetValue("contenu_b64", out var b64)) return Convert.FromBase64String(b64.ToString());
                if (result.TryGetValue("contenu_xml", out var xml)) return Encoding.UTF8.GetBytes(xml.ToString());
                throw new FactPulseValidationException("Unexpected result", null);
            }
            return Encoding.UTF8.GetBytes(json);
        }

        // =========================================================================
        // AFNOR PDP - Authentication et helpers internes
        // =========================================================================

        private async Task<AFNORCredentials> GetAfnorCredentialsInternalAsync()
        {
            if (AfnorCredentials != null) return AfnorCredentials;

            await EnsureAuthenticatedAsync();
            var request = new HttpRequestMessage(HttpMethod.Get, $"{_apiUrl}/api/v1/afnor/credentials");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
            var response = await _httpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode) throw new FactPulseAuthException("Failed to get AFNOR credentials");

            var json = await response.Content.ReadAsStringAsync();
            var creds = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
            return new AFNORCredentials(creds["flow_service_url"], creds["token_url"], creds["client_id"], creds["client_secret"],
                creds.TryGetValue("directory_service_url", out var dsu) ? dsu : null);
        }

        private async Task<(string Token, string PdpBaseUrl)> GetAfnorTokenAndUrlAsync()
        {
            var credentials = await GetAfnorCredentialsInternalAsync();
            var content = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("grant_type", "client_credentials"),
                new KeyValuePair<string, string>("client_id", credentials.ClientId),
                new KeyValuePair<string, string>("client_secret", credentials.ClientSecret)
            });
            var request = new HttpRequestMessage(HttpMethod.Post, $"{_apiUrl}/api/v1/afnor/oauth/token") { Content = content };
            request.Headers.Add("X-PDP-Token-URL", credentials.TokenUrl);
            var response = await _httpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode) throw new FactPulseAuthException("AFNOR OAuth2 failed");

            var json = await response.Content.ReadAsStringAsync();
            var tokenData = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(json);
            if (!tokenData.TryGetValue("access_token", out var tokenElem)) throw new FactPulseAuthException("Invalid AFNOR OAuth2 response");
            return (tokenElem.GetString(), credentials.FlowServiceUrl);
        }

        private async Task<Dictionary<string, object>> MakeAfnorRequestAsync(HttpMethod method, string endpoint,
            Dictionary<string, object> jsonData = null, MultipartFormDataContent multipartContent = null)
        {
            var (afnorToken, pdpBaseUrl) = await GetAfnorTokenAndUrlAsync();
            var url = $"{_apiUrl}/api/v1/afnor{endpoint}";

            var request = new HttpRequestMessage(method, url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", afnorToken);
            request.Headers.Add("X-PDP-Base-URL", pdpBaseUrl);

            if (multipartContent != null) request.Content = multipartContent;
            else if (jsonData != null) request.Content = new StringContent(JsonSerializer.Serialize(jsonData), Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request);
            var body = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode) throw new FactPulseValidationException($"AFNOR error ({(int)response.StatusCode}): {body}", null);

            if (response.Content.Headers.ContentType?.MediaType == "application/json")
                return JsonSerializer.Deserialize<Dictionary<string, object>>(body) ?? new Dictionary<string, object>();
            return new Dictionary<string, object> { ["_raw"] = Encoding.UTF8.GetBytes(body) };
        }

        // ==================== AFNOR Flow Service ====================

        public async Task<Dictionary<string, object>> SoumettreFactureAfnorAsync(string pdfPath, string flowName,
            string flowSyntax = "CII", string flowProfile = "EN16931", string trackingId = null)
        {
            var pdfContent = await File.ReadAllBytesAsync(pdfPath);
            using var sha256 = SHA256.Create();
            var sha256Hash = BitConverter.ToString(sha256.ComputeHash(pdfContent)).Replace("-", "").ToLowerInvariant();

            var flowInfo = new Dictionary<string, object> {
                ["name"] = flowName, ["flowSyntax"] = flowSyntax, ["flowProfile"] = flowProfile, ["sha256"] = sha256Hash
            };
            if (!string.IsNullOrEmpty(trackingId)) flowInfo["trackingId"] = trackingId;

            using var content = new MultipartFormDataContent();
            content.Add(new ByteArrayContent(pdfContent), "file", Path.GetFileName(pdfPath));
            var flowInfoContent = new StringContent(JsonSerializer.Serialize(flowInfo), Encoding.UTF8, "application/json");
            content.Add(flowInfoContent, "flowInfo");

            return await MakeAfnorRequestAsync(HttpMethod.Post, "/flow/v1/flows", multipartContent: content);
        }

        public async Task<Dictionary<string, object>> RechercherFluxAfnorAsync(int offset = 0, int limit = 25,
            string trackingId = null, string status = null)
        {
            var searchBody = new Dictionary<string, object> { ["offset"] = offset, ["limit"] = limit, ["where"] = new Dictionary<string, object>() };
            var where = (Dictionary<string, object>)searchBody["where"];
            if (!string.IsNullOrEmpty(trackingId)) where["trackingId"] = trackingId;
            if (!string.IsNullOrEmpty(status)) where["status"] = status;
            return await MakeAfnorRequestAsync(HttpMethod.Post, "/flow/v1/flows/search", searchBody);
        }

        public async Task<byte[]> TelechargerFluxAfnorAsync(string flowId)
        {
            var result = await MakeAfnorRequestAsync(HttpMethod.Get, $"/flow/v1/flows/{flowId}");
            return result.TryGetValue("_raw", out var raw) ? (byte[])raw : Array.Empty<byte>();
        }

        public async Task<Dictionary<string, object>> HealthcheckAfnorAsync()
            => await MakeAfnorRequestAsync(HttpMethod.Get, "/flow/v1/healthcheck");

        // ==================== AFNOR Directory ====================

        public async Task<Dictionary<string, object>> RechercherSiretAfnorAsync(string siret)
            => await MakeAfnorRequestAsync(HttpMethod.Get, $"/directory/siret/{siret}");

        public async Task<Dictionary<string, object>> RechercherSirenAfnorAsync(string siren)
            => await MakeAfnorRequestAsync(HttpMethod.Get, $"/directory/siren/{siren}");

        public async Task<Dictionary<string, object>> ListerCodesRoutageAfnorAsync(string siren)
            => await MakeAfnorRequestAsync(HttpMethod.Get, $"/directory/siren/{siren}/routing-codes");

        // =========================================================================
        // Chorus Pro
        // =========================================================================

        private async Task<Dictionary<string, object>> MakeChorusRequestAsync(HttpMethod method, string endpoint, Dictionary<string, object> jsonData = null)
        {
            await EnsureAuthenticatedAsync();
            var url = $"{_apiUrl}/api/v1/chorus-pro{endpoint}";

            var body = jsonData ?? new Dictionary<string, object>();
            if (ChorusCredentials != null) body["credentials"] = ChorusCredentials.ToDict();

            var request = new HttpRequestMessage(method, url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
            if (method != HttpMethod.Get) request.Content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request);
            var responseBody = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode) throw new FactPulseValidationException($"Chorus Pro error ({(int)response.StatusCode}): {responseBody}", null);
            return JsonSerializer.Deserialize<Dictionary<string, object>>(responseBody) ?? new Dictionary<string, object>();
        }

        public async Task<Dictionary<string, object>> RechercherStructureChorusAsync(string identifiantStructure = null,
            string raisonSociale = null, string typeIdentifiant = "SIRET", bool restreindrePrivees = true)
        {
            var body = new Dictionary<string, object> { ["restreindre_structures_privees"] = restreindrePrivees };
            if (!string.IsNullOrEmpty(identifiantStructure)) body["identifiant_structure"] = identifiantStructure;
            if (!string.IsNullOrEmpty(raisonSociale)) body["raison_sociale_structure"] = raisonSociale;
            if (!string.IsNullOrEmpty(typeIdentifiant)) body["type_identifiant_structure"] = typeIdentifiant;
            return await MakeChorusRequestAsync(HttpMethod.Post, "/structures/rechercher", body);
        }

        public async Task<Dictionary<string, object>> ConsulterStructureChorusAsync(int idStructureCpp)
            => await MakeChorusRequestAsync(HttpMethod.Post, "/structures/consulter", new Dictionary<string, object> { ["id_structure_cpp"] = idStructureCpp });

        public async Task<Dictionary<string, object>> ObtenirIdChorusDepuisSiretAsync(string siret, string typeIdentifiant = "SIRET")
            => await MakeChorusRequestAsync(HttpMethod.Post, "/structures/obtenir-id-depuis-siret", new Dictionary<string, object> { ["siret"] = siret, ["type_identifiant"] = typeIdentifiant });

        public async Task<Dictionary<string, object>> ListerServicesStructureChorusAsync(int idStructureCpp)
            => await MakeChorusRequestAsync(HttpMethod.Get, $"/structures/{idStructureCpp}/services");

        public async Task<Dictionary<string, object>> SoumettreFactureChorusAsync(Dictionary<string, object> factureData)
            => await MakeChorusRequestAsync(HttpMethod.Post, "/factures/soumettre", factureData);

        public async Task<Dictionary<string, object>> ConsulterFactureChorusAsync(int identifiantFactureCpp)
            => await MakeChorusRequestAsync(HttpMethod.Post, "/factures/consulter", new Dictionary<string, object> { ["identifiant_facture_cpp"] = identifiantFactureCpp });

        // =========================================================================
        // Validation
        // =========================================================================

        public async Task<Dictionary<string, object>> ValiderPdfFacturxAsync(string pdfPath, string profil = "EN16931")
        {
            await EnsureAuthenticatedAsync();
            var pdfContent = await File.ReadAllBytesAsync(pdfPath);
            using var content = new MultipartFormDataContent();
            content.Add(new ByteArrayContent(pdfContent), "fichier_pdf", Path.GetFileName(pdfPath));
            content.Add(new StringContent(profil), "profil");

            var request = new HttpRequestMessage(HttpMethod.Post, $"{_apiUrl}/api/v1/traitement/valider-pdf-facturx") { Content = content };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
            var response = await _httpClient.SendAsync(request);
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Dictionary<string, object>>(json) ?? new Dictionary<string, object>();
        }

        public async Task<Dictionary<string, object>> ValiderXmlFacturxAsync(string xmlContent, string profil = "EN16931")
        {
            await EnsureAuthenticatedAsync();
            using var content = new MultipartFormDataContent();
            content.Add(new StringContent(xmlContent), "fichier_xml", "facture.xml");
            content.Add(new StringContent(profil), "profil");

            var request = new HttpRequestMessage(HttpMethod.Post, $"{_apiUrl}/api/v1/traitement/valider-xml") { Content = content };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
            var response = await _httpClient.SendAsync(request);
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Dictionary<string, object>>(json) ?? new Dictionary<string, object>();
        }

        public async Task<Dictionary<string, object>> ValiderSignaturePdfAsync(string pdfPath)
        {
            await EnsureAuthenticatedAsync();
            var pdfContent = await File.ReadAllBytesAsync(pdfPath);
            using var content = new MultipartFormDataContent();
            content.Add(new ByteArrayContent(pdfContent), "fichier_pdf", Path.GetFileName(pdfPath));

            var request = new HttpRequestMessage(HttpMethod.Post, $"{_apiUrl}/api/v1/traitement/valider-signature-pdf") { Content = content };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
            var response = await _httpClient.SendAsync(request);
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Dictionary<string, object>>(json) ?? new Dictionary<string, object>();
        }

        // =========================================================================
        // Signature
        // =========================================================================

        public async Task<byte[]> SignerPdfAsync(string pdfPath, string raison = null, string localisation = null,
            string contact = null, bool usePadesLt = false, bool useTimestamp = true)
        {
            await EnsureAuthenticatedAsync();
            var pdfContent = await File.ReadAllBytesAsync(pdfPath);
            using var content = new MultipartFormDataContent();
            content.Add(new ByteArrayContent(pdfContent), "fichier_pdf", Path.GetFileName(pdfPath));
            if (!string.IsNullOrEmpty(raison)) content.Add(new StringContent(raison), "raison");
            if (!string.IsNullOrEmpty(localisation)) content.Add(new StringContent(localisation), "localisation");
            if (!string.IsNullOrEmpty(contact)) content.Add(new StringContent(contact), "contact");
            content.Add(new StringContent(usePadesLt.ToString().ToLower()), "use_pades_lt");
            content.Add(new StringContent(useTimestamp.ToString().ToLower()), "use_timestamp");

            var request = new HttpRequestMessage(HttpMethod.Post, $"{_apiUrl}/api/v1/traitement/signer-pdf") { Content = content };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
            var response = await _httpClient.SendAsync(request);
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(json);
            if (result.TryGetValue("pdf_signe_base64", out var b64)) return Convert.FromBase64String(b64.GetString());
            throw new FactPulseValidationException("Invalid signature response", null);
        }

        public async Task<Dictionary<string, object>> GenererCertificatTestAsync(string cn = "Test Organisation",
            string organisation = "Test Organisation", string email = "test@example.com", int dureeJours = 365, int tailleCle = 2048)
        {
            await EnsureAuthenticatedAsync();
            var body = new Dictionary<string, object> { ["cn"] = cn, ["organisation"] = organisation, ["email"] = email, ["duree_jours"] = dureeJours, ["taille_cle"] = tailleCle };
            var request = new HttpRequestMessage(HttpMethod.Post, $"{_apiUrl}/api/v1/traitement/generer-certificat-test") {
                Content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json")
            };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
            var response = await _httpClient.SendAsync(request);
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Dictionary<string, object>>(json) ?? new Dictionary<string, object>();
        }

        // =========================================================================
        // Workflow complet
        // =========================================================================

        public async Task<Dictionary<string, object>> GenererFacturxCompletAsync(Dictionary<string, object> facture, string pdfSourcePath,
            string profil = "EN16931", bool valider = true, bool signer = false, bool soumettreAfnor = false,
            string outputPath = null, string afnorFlowName = null, string afnorTrackingId = null, int timeout = 120000)
        {
            var result = new Dictionary<string, object>();

            // 1. Génération
            var pdfBytes = await GenererFacturxAsync(facture, pdfSourcePath, profil, "pdf", true, timeout);
            result["pdfBytes"] = pdfBytes;

            // Créer un fichier temporaire
            var tempPath = Path.GetTempFileName() + ".pdf";
            try
            {
                await File.WriteAllBytesAsync(tempPath, pdfBytes);

                // 2. Validation
                if (valider)
                {
                    var validation = await ValiderPdfFacturxAsync(tempPath, profil);
                    result["validation"] = validation;
                    if (validation.TryGetValue("est_conforme", out var ec) && ec is bool estConforme && !estConforme)
                    {
                        if (!string.IsNullOrEmpty(outputPath)) { await File.WriteAllBytesAsync(outputPath, pdfBytes); result["pdfPath"] = outputPath; }
                        return result;
                    }
                }

                // 3. Signature
                if (signer)
                {
                    pdfBytes = await SignerPdfAsync(tempPath);
                    result["pdfBytes"] = pdfBytes;
                    result["signature"] = new Dictionary<string, object> { ["signe"] = true };
                    await File.WriteAllBytesAsync(tempPath, pdfBytes);
                }

                // 4. Soumission AFNOR
                if (soumettreAfnor)
                {
                    var numeroFacture = facture.TryGetValue("numeroFacture", out var nf) ? nf?.ToString() :
                        (facture.TryGetValue("numero_facture", out var nf2) ? nf2?.ToString() : "FACTURE");
                    var flowName = !string.IsNullOrEmpty(afnorFlowName) ? afnorFlowName : $"Facture {numeroFacture}";
                    var trackingId = !string.IsNullOrEmpty(afnorTrackingId) ? afnorTrackingId : numeroFacture;
                    var afnorResult = await SoumettreFactureAfnorAsync(tempPath, flowName, trackingId: trackingId);
                    result["afnor"] = afnorResult;
                }

                // Sauvegarde finale
                if (!string.IsNullOrEmpty(outputPath)) { await File.WriteAllBytesAsync(outputPath, pdfBytes); result["pdfPath"] = outputPath; }
            }
            finally { if (File.Exists(tempPath)) File.Delete(tempPath); }

            return result;
        }

        public void Dispose() => _httpClient?.Dispose();
    }
}
