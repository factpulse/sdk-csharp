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

    /// <summary>Chorus Pro credentials for Zero-Trust mode.</summary>
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

    /// <summary>AFNOR PDP credentials for Zero-Trust mode.</summary>
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
    // Amount helpers
    // =============================================================================

    public static class AmountHelpers
    {
        public static string Amount(object value)
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

        public static Dictionary<string, object> TotalAmount(object exclTax, object vat, object inclTax, object amountDue,
            object globalAllowanceAmount = null, string globalAllowanceReason = null, object prepayment = null)
        {
            var result = new Dictionary<string, object> {
                ["totalNetAmount"] = Amount(exclTax), ["vatAmount"] = Amount(vat),
                ["totalGrossAmount"] = Amount(inclTax), ["amountDue"] = Amount(amountDue)
            };
            if (globalAllowanceAmount != null) result["globalAllowanceAmount"] = Amount(globalAllowanceAmount);
            if (globalAllowanceReason != null) result["globalAllowanceReason"] = globalAllowanceReason;
            if (prepayment != null) result["prepayment"] = Amount(prepayment);
            return result;
        }

        /// <summary>Creates an invoice line (aligned with InvoiceLine in models.py).</summary>
        public static Dictionary<string, object> InvoiceLine(int lineNumber, string itemName, object quantity,
            object unitNetPrice, object lineNetAmount, string vatRate = "20.00",
            string vatCategory = "S", string unit = "LUMP_SUM", Dictionary<string, object> options = null)
        {
            var result = new Dictionary<string, object> {
                ["lineNumber"] = lineNumber, ["itemName"] = itemName, ["quantity"] = Amount(quantity),
                ["unitNetPrice"] = Amount(unitNetPrice), ["lineNetAmount"] = Amount(lineNetAmount),
                ["manualVatRate"] = Amount(vatRate), ["vatCategory"] = vatCategory, ["unit"] = unit
            };
            if (options != null)
            {
                if (options.TryGetValue("reference", out var r)) result["reference"] = r;
                if (options.TryGetValue("lineAllowanceAmount", out var m)) result["lineAllowanceAmount"] = Amount(m);
                if (options.TryGetValue("allowanceReasonCode", out var c)) result["allowanceReasonCode"] = c;
                if (options.TryGetValue("allowanceReason", out var rr)) result["allowanceReason"] = rr;
                if (options.TryGetValue("periodStartDate", out var dd)) result["periodStartDate"] = dd;
                if (options.TryGetValue("periodEndDate", out var df)) result["periodEndDate"] = df;
            }
            return result;
        }

        /// <summary>Creates a VAT line (aligned with VATLine in models.py).</summary>
        public static Dictionary<string, object> VatLine(object manualRate, object taxableAmount, object vatAmount, string category = "S")
            => new Dictionary<string, object> {
                ["manualRate"] = Amount(manualRate), ["taxableAmount"] = Amount(taxableAmount),
                ["vatAmount"] = Amount(vatAmount), ["category"] = category
            };

        /// <summary>Creates a postal address for the FactPulse API.</summary>
        public static Dictionary<string, object> PostalAddress(string lineOne, string postalCode, string city,
            string countryCode = "FR", string lineTwo = null, string lineThree = null)
        {
            var result = new Dictionary<string, object> { ["lineOne"] = lineOne, ["postalCode"] = postalCode, ["city"] = city, ["countryCode"] = countryCode };
            if (lineTwo != null) result["lineTwo"] = lineTwo;
            if (lineThree != null) result["lineThree"] = lineThree;
            return result;
        }

        /// <summary>Creates an electronic address. schemeId: "0009"=SIREN, "0225"=SIRET</summary>
        public static Dictionary<string, object> ElectronicAddress(string identifier, string schemeId = "0009")
            => new Dictionary<string, object> { ["identifier"] = identifier, ["schemeId"] = schemeId };

        /// <summary>Computes the French intra-community VAT number from a SIREN.</summary>
        public static string ComputeVatIntra(string siren)
        {
            if (string.IsNullOrEmpty(siren) || siren.Length != 9 || !siren.All(char.IsDigit)) return null;
            var cle = (12 + 3 * (long.Parse(siren) % 97)) % 97;
            return $"FR{cle:D2}{siren}";
        }

        /// <summary>Creates a supplier (issuer) with auto-computed SIREN, intra-EU VAT number and addresses.</summary>
        public static Dictionary<string, object> Supplier(string name, string siret, string addressLine1,
            string postalCode, string city, Dictionary<string, object> options = null)
        {
            options ??= new Dictionary<string, object>();
            var siren = options.TryGetValue("siren", out var s) ? s?.ToString() : (siret.Length == 14 ? siret.Substring(0, 9) : null);
            var vatNumber = options.TryGetValue("vatNumber", out var t) ? t?.ToString() : (siren != null ? ComputeVatIntra(siren) : null);
            var countryCode = options.TryGetValue("countryCode", out var p) ? p?.ToString() : "FR";
            var addressLine2 = options.TryGetValue("addressLine2", out var a2) ? a2?.ToString() : null;

            var result = new Dictionary<string, object> {
                ["name"] = name, ["supplierId"] = options.ContainsKey("supplierId") ? options["supplierId"] : 0, ["siret"] = siret,
                ["electronicAddress"] = ElectronicAddress(siret, "0225"),
                ["postalAddress"] = PostalAddress(addressLine1, postalCode, city, countryCode, addressLine2)
            };
            if (siren != null) result["siren"] = siren;
            if (vatNumber != null) result["vatNumber"] = vatNumber;
            if (options.TryGetValue("iban", out var iban)) result["iban"] = iban;
            if (options.TryGetValue("supplierServiceId", out var cs)) result["supplierServiceId"] = cs;
            if (options.TryGetValue("supplierBankDetailsCode", out var ccb)) result["supplierBankDetailsCode"] = ccb;
            return result;
        }

        /// <summary>Creates a recipient (customer) with auto-computed SIREN and addresses.</summary>
        public static Dictionary<string, object> Recipient(string name, string siret, string addressLine1,
            string postalCode, string city, Dictionary<string, object> options = null)
        {
            options ??= new Dictionary<string, object>();
            var siren = options.TryGetValue("siren", out var s) ? s?.ToString() : (siret.Length == 14 ? siret.Substring(0, 9) : null);
            var countryCode = options.TryGetValue("countryCode", out var p) ? p?.ToString() : "FR";
            var addressLine2 = options.TryGetValue("addressLine2", out var a2) ? a2?.ToString() : null;

            var result = new Dictionary<string, object> {
                ["name"] = name, ["siret"] = siret,
                ["electronicAddress"] = ElectronicAddress(siret, "0225"),
                ["postalAddress"] = PostalAddress(addressLine1, postalCode, city, countryCode, addressLine2)
            };
            if (siren != null) result["siren"] = siren;
            if (options.TryGetValue("executingServiceCode", out var cse)) result["executingServiceCode"] = cse;
            return result;
        }

        /// <summary>
        /// Creates a beneficiary (factor) for factoring.
        ///
        /// The beneficiary (BG-10 / PayeeTradeParty) is used when payment
        /// must be made to a third party different from the supplier, typically
        /// a factor (factoring company).
        ///
        /// For factored invoices, you also need to:
        /// - Use a factored document type (393, 396, 501, 502, 472, 473)
        /// - Add an ACC note with the subrogation mention
        /// - The beneficiary's IBAN will be used for payment
        /// </summary>
        /// <param name="name">Factor's business name (BT-59)</param>
        /// <param name="options">Options: siret (BT-60), siren (BT-61), iban, bic</param>
        /// <returns>Dictionary ready to be used in a factored invoice</returns>
        public static Dictionary<string, object> Beneficiary(string name, Dictionary<string, object> options = null)
        {
            options ??= new Dictionary<string, object>();
            var siret = options.TryGetValue("siret", out var si) ? si?.ToString() : null;
            // Auto-compute SIREN from SIRET
            var siren = options.TryGetValue("siren", out var sr) ? sr?.ToString()
                : (siret != null && siret.Length == 14 ? siret.Substring(0, 9) : null);

            var result = new Dictionary<string, object> { ["name"] = name };
            if (siret != null) result["siret"] = siret;
            if (siren != null) result["siren"] = siren;
            if (options.TryGetValue("iban", out var iban)) result["iban"] = iban;
            if (options.TryGetValue("bic", out var bic)) result["bic"] = bic;
            return result;
        }
    }

    // =============================================================================
    // Main client
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
                var request = new HttpRequestMessage(HttpMethod.Get, $"{_apiUrl}/api/v1/processing/tasks/{taskId}/status");
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

        public static string FormatAmount(object m) => AmountHelpers.Amount(m);

        public async Task<byte[]> GenerateFacturxAsync(object invoiceData, string pdfPath, string profile = "EN16931",
            string outputFormat = "pdf", bool sync = true, int? timeout = null)
        {
            var jsonData = invoiceData is string s ? s : JsonSerializer.Serialize(invoiceData);
            var pdfContent = await File.ReadAllBytesAsync(pdfPath);

            await EnsureAuthenticatedAsync();
            using var content = new MultipartFormDataContent();
            content.Add(new StringContent(jsonData), "invoice_data");
            content.Add(new StringContent(profile), "profile");
            content.Add(new StringContent(outputFormat), "output_format");
            content.Add(new ByteArrayContent(pdfContent), "source_pdf", Path.GetFileName(pdfPath));

            var request = new HttpRequestMessage(HttpMethod.Post, $"{_apiUrl}/api/v1/processing/generate-invoice") { Content = content };
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
                // Extract error details from response body
                var errorMsg = $"API Error ({(int)response.StatusCode})";
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
                            errorMsg = "Validation error";
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

                Console.Error.WriteLine($"API Error {(int)response.StatusCode}: {json}");
                throw new FactPulseValidationException(errorMsg, errors);
            }

            var data = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(json);
            if (sync && data.TryGetValue("task_id", out var taskIdElem))
            {
                var result = await PollTaskAsync(taskIdElem.GetString(), timeout);
                if (result.TryGetValue("content_b64", out var b64)) return Convert.FromBase64String(b64.ToString());
                if (result.TryGetValue("content_xml", out var xml)) return Encoding.UTF8.GetBytes(xml.ToString());
                throw new FactPulseValidationException("Unexpected result", null);
            }
            return Encoding.UTF8.GetBytes(json);
        }

        // =========================================================================
        // AFNOR PDP - Authentication and internal helpers
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

        public async Task<Dictionary<string, object>> SubmitInvoiceAfnorAsync(string pdfPath, string flowName,
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

        public async Task<Dictionary<string, object>> SearchFlowsAfnorAsync(int offset = 0, int limit = 25,
            string trackingId = null, string status = null)
        {
            var searchBody = new Dictionary<string, object> { ["offset"] = offset, ["limit"] = limit, ["where"] = new Dictionary<string, object>() };
            var where = (Dictionary<string, object>)searchBody["where"];
            if (!string.IsNullOrEmpty(trackingId)) where["trackingId"] = trackingId;
            if (!string.IsNullOrEmpty(status)) where["status"] = status;
            return await MakeAfnorRequestAsync(HttpMethod.Post, "/flow/v1/flows/search", searchBody);
        }

        public async Task<byte[]> DownloadFlowAfnorAsync(string flowId)
        {
            var result = await MakeAfnorRequestAsync(HttpMethod.Get, $"/flow/v1/flows/{flowId}");
            return result.TryGetValue("_raw", out var raw) ? (byte[])raw : Array.Empty<byte>();
        }

        public async Task<Dictionary<string, object>> HealthcheckAfnorAsync()
            => await MakeAfnorRequestAsync(HttpMethod.Get, "/flow/v1/healthcheck");

        // ==================== AFNOR Directory ====================

        public async Task<Dictionary<string, object>> SearchSiretAfnorAsync(string siret)
            => await MakeAfnorRequestAsync(HttpMethod.Get, $"/directory/siret/{siret}");

        public async Task<Dictionary<string, object>> SearchSirenAfnorAsync(string siren)
            => await MakeAfnorRequestAsync(HttpMethod.Get, $"/directory/siren/{siren}");

        public async Task<Dictionary<string, object>> ListRoutingCodesAfnorAsync(string siren)
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

        public async Task<Dictionary<string, object>> SearchStructureChorusAsync(string structureIdentifier = null,
            string businessName = null, string identifierType = "SIRET", bool restrictPrivate = true)
        {
            var body = new Dictionary<string, object> { ["restrict_private_structures"] = restrictPrivate };
            if (!string.IsNullOrEmpty(structureIdentifier)) body["structure_identifier"] = structureIdentifier;
            if (!string.IsNullOrEmpty(businessName)) body["structure_business_name"] = businessName;
            if (!string.IsNullOrEmpty(identifierType)) body["structure_identifier_type"] = identifierType;
            return await MakeChorusRequestAsync(HttpMethod.Post, "/structures/search", body);
        }

        public async Task<Dictionary<string, object>> GetStructureChorusAsync(int cppStructureId)
            => await MakeChorusRequestAsync(HttpMethod.Post, "/structures/get", new Dictionary<string, object> { ["cpp_structure_id"] = cppStructureId });

        public async Task<Dictionary<string, object>> GetChorusIdFromSiretAsync(string siret, string identifierType = "SIRET")
            => await MakeChorusRequestAsync(HttpMethod.Post, "/structures/get-id-from-siret", new Dictionary<string, object> { ["siret"] = siret, ["identifier_type"] = identifierType });

        public async Task<Dictionary<string, object>> ListStructureServicesChorusAsync(int cppStructureId)
            => await MakeChorusRequestAsync(HttpMethod.Get, $"/structures/{cppStructureId}/services");

        public async Task<Dictionary<string, object>> SubmitInvoiceChorusAsync(Dictionary<string, object> invoiceData)
            => await MakeChorusRequestAsync(HttpMethod.Post, "/invoices/submit", invoiceData);

        public async Task<Dictionary<string, object>> GetInvoiceChorusAsync(int cppInvoiceIdentifier)
            => await MakeChorusRequestAsync(HttpMethod.Post, "/invoices/get", new Dictionary<string, object> { ["cpp_invoice_identifier"] = cppInvoiceIdentifier });

        // =========================================================================
        // Validation
        // =========================================================================

        /// <summary>
        /// Validates a Factur-X PDF.
        /// </summary>
        /// <param name="pdfPath">Path to the PDF file</param>
        /// <param name="profile">Factur-X profile (MINIMUM, BASIC, EN16931, EXTENDED). If null, auto-detected.</param>
        /// <param name="useVerapdf">Enable strict PDF/A validation with VeraPDF (default: false)</param>
        public async Task<Dictionary<string, object>> ValidateFacturxPdfAsync(string pdfPath, string? profile = null, bool useVerapdf = false)
        {
            await EnsureAuthenticatedAsync();
            var pdfContent = await File.ReadAllBytesAsync(pdfPath);
            using var content = new MultipartFormDataContent();
            content.Add(new ByteArrayContent(pdfContent), "pdf_file", Path.GetFileName(pdfPath));
            if (profile != null)
            {
                content.Add(new StringContent(profile), "profile");
            }
            content.Add(new StringContent(useVerapdf.ToString().ToLower()), "use_verapdf");

            var request = new HttpRequestMessage(HttpMethod.Post, $"{_apiUrl}/api/v1/processing/validate-facturx-pdf") { Content = content };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
            var response = await _httpClient.SendAsync(request);
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Dictionary<string, object>>(json) ?? new Dictionary<string, object>();
        }

        public async Task<Dictionary<string, object>> ValidateFacturxXmlAsync(string xmlContent, string profile = "EN16931")
        {
            await EnsureAuthenticatedAsync();
            using var content = new MultipartFormDataContent();
            content.Add(new StringContent(xmlContent), "xml_file", "invoice.xml");
            content.Add(new StringContent(profile), "profile");

            var request = new HttpRequestMessage(HttpMethod.Post, $"{_apiUrl}/api/v1/processing/validate-xml") { Content = content };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
            var response = await _httpClient.SendAsync(request);
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Dictionary<string, object>>(json) ?? new Dictionary<string, object>();
        }

        public async Task<Dictionary<string, object>> ValidatePdfSignatureAsync(string pdfPath)
        {
            await EnsureAuthenticatedAsync();
            var pdfContent = await File.ReadAllBytesAsync(pdfPath);
            using var content = new MultipartFormDataContent();
            content.Add(new ByteArrayContent(pdfContent), "pdf_file", Path.GetFileName(pdfPath));

            var request = new HttpRequestMessage(HttpMethod.Post, $"{_apiUrl}/api/v1/processing/validate-pdf-signature") { Content = content };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
            var response = await _httpClient.SendAsync(request);
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Dictionary<string, object>>(json) ?? new Dictionary<string, object>();
        }

        // =========================================================================
        // Signature
        // =========================================================================

        public async Task<byte[]> SignPdfAsync(string pdfPath, string reason = null, string location = null,
            string contact = null, bool usePadesLt = false, bool useTimestamp = true)
        {
            await EnsureAuthenticatedAsync();
            var pdfContent = await File.ReadAllBytesAsync(pdfPath);
            using var content = new MultipartFormDataContent();
            content.Add(new ByteArrayContent(pdfContent), "pdf_file", Path.GetFileName(pdfPath));
            if (!string.IsNullOrEmpty(reason)) content.Add(new StringContent(reason), "reason");
            if (!string.IsNullOrEmpty(location)) content.Add(new StringContent(location), "location");
            if (!string.IsNullOrEmpty(contact)) content.Add(new StringContent(contact), "contact");
            content.Add(new StringContent(usePadesLt.ToString().ToLower()), "use_pades_lt");
            content.Add(new StringContent(useTimestamp.ToString().ToLower()), "use_timestamp");

            var request = new HttpRequestMessage(HttpMethod.Post, $"{_apiUrl}/api/v1/processing/sign-pdf") { Content = content };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
            var response = await _httpClient.SendAsync(request);
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(json);
            if (result.TryGetValue("signed_pdf_base64", out var b64)) return Convert.FromBase64String(b64.GetString());
            throw new FactPulseValidationException("Invalid signature response", null);
        }

        public async Task<Dictionary<string, object>> GenerateTestCertificateAsync(string cn = "Test Organisation",
            string organisation = "Test Organisation", string email = "test@example.com", int validityDays = 365, int keySize = 2048)
        {
            await EnsureAuthenticatedAsync();
            var body = new Dictionary<string, object> { ["cn"] = cn, ["organisation"] = organisation, ["email"] = email, ["validity_days"] = validityDays, ["key_size"] = keySize };
            var request = new HttpRequestMessage(HttpMethod.Post, $"{_apiUrl}/api/v1/processing/generate-test-certificate") {
                Content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json")
            };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
            var response = await _httpClient.SendAsync(request);
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Dictionary<string, object>>(json) ?? new Dictionary<string, object>();
        }

        // =========================================================================
        // Complete workflow
        // =========================================================================

        public async Task<Dictionary<string, object>> GenerateFacturxCompleteAsync(Dictionary<string, object> invoice, string pdfSourcePath,
            string profile = "EN16931", bool validate = true, bool sign = false, bool submitAfnor = false,
            string outputPath = null, string afnorFlowName = null, string afnorTrackingId = null, int timeout = 120000)
        {
            var result = new Dictionary<string, object>();

            // 1. Generation
            var pdfBytes = await GenerateFacturxAsync(invoice, pdfSourcePath, profile, "pdf", true, timeout);
            result["pdfBytes"] = pdfBytes;

            // Create temporary file
            var tempPath = Path.GetTempFileName() + ".pdf";
            try
            {
                await File.WriteAllBytesAsync(tempPath, pdfBytes);

                // 2. Validation
                if (validate)
                {
                    var validation = await ValidateFacturxPdfAsync(tempPath, profile);
                    result["validation"] = validation;
                    if (validation.TryGetValue("is_compliant", out var ec) && ec is bool isCompliant && !isCompliant)
                    {
                        if (!string.IsNullOrEmpty(outputPath)) { await File.WriteAllBytesAsync(outputPath, pdfBytes); result["pdfPath"] = outputPath; }
                        return result;
                    }
                }

                // 3. Signature
                if (sign)
                {
                    pdfBytes = await SignPdfAsync(tempPath);
                    result["pdfBytes"] = pdfBytes;
                    result["signature"] = new Dictionary<string, object> { ["signed"] = true };
                    await File.WriteAllBytesAsync(tempPath, pdfBytes);
                }

                // 4. AFNOR submission
                if (submitAfnor)
                {
                    var invoiceNumber = invoice.TryGetValue("number", out var nf) ? nf?.ToString() :
                        (invoice.TryGetValue("invoice_number", out var nf2) ? nf2?.ToString() : "INVOICE");
                    var flowName = !string.IsNullOrEmpty(afnorFlowName) ? afnorFlowName : $"Invoice {invoiceNumber}";
                    var trackingId = !string.IsNullOrEmpty(afnorTrackingId) ? afnorTrackingId : invoiceNumber;
                    var afnorResult = await SubmitInvoiceAfnorAsync(tempPath, flowName, trackingId: trackingId);
                    result["afnor"] = afnorResult;
                }

                // Final save
                if (!string.IsNullOrEmpty(outputPath)) { await File.WriteAllBytesAsync(outputPath, pdfBytes); result["pdfPath"] = outputPath; }
            }
            finally { if (File.Exists(tempPath)) File.Delete(tempPath); }

            return result;
        }

        public void Dispose() => _httpClient?.Dispose();
    }
}
