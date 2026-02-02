/**
 * FactPulse SDK - Thin HTTP wrapper with auto-polling.
 *
 * Usage:
 *   var client = new FactPulseClient("email", "password", "client_uid");
 *
 *   // POST /api/v1/processing/invoices/submit-complete-async
 *   var result = await client.PostAsync("processing/invoices/submit-complete-async", new {
 *       invoiceData = ...,
 *       destination = new { type = "afnor" }
 *   });
 *   var pdfBytes = (byte[])result["content"]; // auto-decoded, auto-polled
 */
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace FactPulse.SDK
{
    public class FactPulseError : Exception
    {
        public int? StatusCode { get; }
        public List<object> Details { get; }
        public FactPulseError(string message, int? statusCode = null, List<object> details = null) : base(message)
        {
            StatusCode = statusCode;
            Details = details ?? new List<object>();
        }
    }

    public class FactPulseClient : IDisposable
    {
        private const string DefaultApiUrl = "https://factpulse.fr";
        private readonly string _apiUrl, _email, _password, _clientUid;
        private readonly int _timeout, _pollingTimeout;
        private readonly HttpClient _httpClient;
        private readonly SemaphoreSlim _tokenLock = new(1, 1);
        private string _token;
        private DateTime _tokenExpiresAt;

        public FactPulseClient(string email, string password, string clientUid, string apiUrl = null, int timeout = 60, int pollingTimeout = 120)
        {
            _email = email;
            _password = password;
            _clientUid = clientUid;
            _apiUrl = (apiUrl ?? DefaultApiUrl).TrimEnd('/');
            _timeout = timeout;
            _pollingTimeout = pollingTimeout;
            _httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(timeout) };
        }

        /// <summary>POST request to /api/v1/{path}</summary>
        public async Task<Dictionary<string, object>> PostAsync(string path, object data)
            => await RequestAsync("POST", path, data, true);

        /// <summary>GET request to /api/v1/{path}</summary>
        public async Task<Dictionary<string, object>> GetAsync(string path)
            => await RequestAsync("GET", path, null, true);

        /// <summary>POST multipart request to /api/v1/{path}</summary>
        public async Task<Dictionary<string, object>> PostMultipartAsync(string path, Dictionary<string, string> formData, Dictionary<string, byte[]> files)
        {
            await EnsureAuthAsync();
            var url = $"{_apiUrl}/api/v1/{path}";

            using var content = new MultipartFormDataContent();

            // Add form fields
            if (formData != null)
            {
                foreach (var kvp in formData)
                    content.Add(new StringContent(kvp.Value), kvp.Key);
            }

            // Add files
            if (files != null)
            {
                foreach (var kvp in files)
                {
                    var fileContent = new ByteArrayContent(kvp.Value);
                    fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
                    content.Add(fileContent, kvp.Key, kvp.Key);
                }
            }

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            request.Content = content;

            var response = await _httpClient.SendAsync(request);

            if ((int)response.StatusCode == 401)
            {
                InvalidateToken();
                return await PostMultipartAsync(path, formData, files);
            }

            // Check if response is binary (PDF)
            var contentType = response.Content.Headers.ContentType?.MediaType ?? "";
            if (contentType.Contains("application/pdf") || contentType.Contains("application/octet-stream"))
            {
                var bytes = await response.Content.ReadAsByteArrayAsync();
                return new Dictionary<string, object> { { "content", bytes } };
            }

            return await ParseResponseAsync(response);
        }

        private async Task<Dictionary<string, object>> RequestAsync(string method, string path, object data, bool retryAuth)
        {
            await EnsureAuthAsync();
            var url = $"{_apiUrl}/api/v1/{path}";

            var request = new HttpRequestMessage(method == "GET" ? HttpMethod.Get : HttpMethod.Post, url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            if (method == "POST" && data != null)
                request.Content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request);

            if ((int)response.StatusCode == 401 && retryAuth)
            {
                InvalidateToken();
                return await RequestAsync(method, path, data, false);
            }

            var result = await ParseResponseAsync(response);

            // Auto-poll: support both taskId (camelCase) and task_id (snake_case)
            string taskId = null;
            if (result.TryGetValue("taskId", out var taskIdObj) && taskIdObj is JsonElement taskIdElem)
                taskId = taskIdElem.GetString();
            else if (result.TryGetValue("task_id", out var taskIdObj2) && taskIdObj2 is JsonElement taskIdElem2)
                taskId = taskIdElem2.GetString();
            if (taskId != null)
                return await PollAsync(taskId);

            // Auto-decode: support both content_b64 and contentB64
            string b64Content = null;
            if (result.TryGetValue("content_b64", out var b64Obj) && b64Obj is JsonElement b64Elem)
                b64Content = b64Elem.GetString();
            else if (result.TryGetValue("contentB64", out var b64Obj2) && b64Obj2 is JsonElement b64Elem2)
                b64Content = b64Elem2.GetString();
            if (b64Content != null)
            {
                result["content"] = Convert.FromBase64String(b64Content);
                result.Remove("content_b64");
                result.Remove("contentB64");
            }

            return result;
        }

        private async Task<Dictionary<string, object>> ParseResponseAsync(HttpResponseMessage response)
        {
            var body = await response.Content.ReadAsStringAsync();
            Dictionary<string, object> data = null;

            try { data = JsonSerializer.Deserialize<Dictionary<string, object>>(body); } catch { }

            if (response.IsSuccessStatusCode)
                return data ?? new Dictionary<string, object>();

            var msg = $"HTTP {(int)response.StatusCode}";
            var details = new List<object>();

            if (data != null)
            {
                if (data.TryGetValue("detail", out var detail) && detail is JsonElement detailElem)
                {
                    if (detailElem.ValueKind == JsonValueKind.Array)
                    {
                        var msgs = new List<string>();
                        foreach (var err in detailElem.EnumerateArray())
                        {
                            details.Add(err);
                            var loc = err.GetProperty("loc");
                            var lastLoc = loc.GetArrayLength() > 0 ? loc[loc.GetArrayLength() - 1].ToString() : "?";
                            msgs.Add($"{lastLoc}: {err.GetProperty("msg")}");
                        }
                        msg = "Validation error: " + string.Join("; ", msgs);
                    }
                    else if (detailElem.ValueKind == JsonValueKind.String)
                        msg = detailElem.GetString();
                }
                else if (data.TryGetValue("errorMessage", out var errMsg) && errMsg is JsonElement errElem)
                    msg = errElem.GetString();
            }

            throw new FactPulseError(msg, (int)response.StatusCode, details);
        }

        private async Task<Dictionary<string, object>> PollAsync(string taskId)
        {
            var start = DateTime.UtcNow;
            var interval = 1000.0;

            while (true)
            {
                var elapsed = (DateTime.UtcNow - start).TotalSeconds;
                if (elapsed >= _pollingTimeout)
                    throw new FactPulseError($"Polling timeout after {_pollingTimeout}s for task {taskId}");

                await EnsureAuthAsync();
                var request = new HttpRequestMessage(HttpMethod.Get, $"{_apiUrl}/api/v1/processing/tasks/{taskId}/status");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

                var response = await _httpClient.SendAsync(request);

                if ((int)response.StatusCode == 401)
                {
                    InvalidateToken();
                    continue;
                }

                var data = await ParseResponseAsync(response);
                var status = data.TryGetValue("status", out var s) && s is JsonElement se ? se.GetString() : null;

                if (status == "SUCCESS")
                {
                    var result = data.TryGetValue("result", out var r) && r is JsonElement re
                        ? JsonSerializer.Deserialize<Dictionary<string, object>>(re.GetRawText())
                        : new Dictionary<string, object>();

                    // Support both content_b64 and contentB64
                    string b64Content = null;
                    if (result.TryGetValue("content_b64", out var b64) && b64 is JsonElement b64Elem)
                        b64Content = b64Elem.GetString();
                    else if (result.TryGetValue("contentB64", out var b64_2) && b64_2 is JsonElement b64Elem2)
                        b64Content = b64Elem2.GetString();
                    if (b64Content != null)
                    {
                        result["content"] = Convert.FromBase64String(b64Content);
                        result.Remove("content_b64");
                        result.Remove("contentB64");
                    }
                    return result;
                }

                if (status == "FAILURE")
                {
                    var res = data.TryGetValue("result", out var r) && r is JsonElement re
                        ? JsonSerializer.Deserialize<Dictionary<string, object>>(re.GetRawText())
                        : new Dictionary<string, object>();
                    var errMsg = res.TryGetValue("errorMessage", out var m) && m is JsonElement me ? me.GetString() : "Task failed";
                    throw new FactPulseError(errMsg);
                }

                await Task.Delay((int)Math.Min(interval, (_pollingTimeout - elapsed) * 1000));
                interval = Math.Min(interval * 1.5, 10000);
            }
        }

        private async Task EnsureAuthAsync()
        {
            await _tokenLock.WaitAsync();
            try
            {
                if (DateTime.UtcNow >= _tokenExpiresAt)
                    await RefreshTokenAsync();
            }
            finally { _tokenLock.Release(); }
        }

        private async Task RefreshTokenAsync()
        {
            var content = new StringContent(
                JsonSerializer.Serialize(new { username = _email, password = _password, client_uid = _clientUid }),
                Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{_apiUrl}/api/token/", content);

            if (!response.IsSuccessStatusCode)
                throw new FactPulseError($"Authentication failed: HTTP {(int)response.StatusCode}", (int)response.StatusCode);

            var body = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<Dictionary<string, string>>(body);
            _token = data["access"];
            _tokenExpiresAt = DateTime.UtcNow.AddMinutes(28);
        }

        private void InvalidateToken()
        {
            _tokenLock.Wait();
            try { _tokenExpiresAt = DateTime.MinValue; }
            finally { _tokenLock.Release(); }
        }

        public void Dispose() => _httpClient?.Dispose();
    }
}
