using System; using System.Collections.Generic; using System.Linq;
namespace FactPulse.SDK.Helpers {
    public class FactPulseException : Exception { public FactPulseException(string msg) : base(msg) { } }
    public class FactPulseAuthException : FactPulseException { public FactPulseAuthException(string msg = "Auth failed") : base(msg) { } }
    public class FactPulsePollingTimeoutException : FactPulseException {
        public string TaskId { get; } public long Timeout { get; }
        public FactPulsePollingTimeoutException(string taskId, long timeout) : base($"Timeout ({timeout}ms) pour {taskId}") { TaskId = taskId; Timeout = timeout; }
    }
    public class ValidationErrorDetail {
        public string Level { get; set; } = ""; public string Item { get; set; } = ""; public string Reason { get; set; } = "";
        public string? Source { get; set; } public string? Code { get; set; }
        public ValidationErrorDetail() { }
        public ValidationErrorDetail(string level, string item, string reason, string? source = null, string? code = null) {
            Level = level ?? ""; Item = item ?? ""; Reason = reason ?? ""; Source = source; Code = code;
        }
        public override string ToString() => $"[{(string.IsNullOrEmpty(Item) ? "unknown" : Item)}] {(string.IsNullOrEmpty(Reason) ? "Unknown error" : Reason)}";
        public static ValidationErrorDetail FromDictionary(Dictionary<string, object?> d) => new() {
            Level = d.TryGetValue("level", out var l) ? l?.ToString() ?? "" : "",
            Item = d.TryGetValue("item", out var i) ? i?.ToString() ?? "" : "",
            Reason = d.TryGetValue("reason", out var r) ? r?.ToString() ?? "" : "",
            Source = d.TryGetValue("source", out var s) ? s?.ToString() : null,
            Code = d.TryGetValue("code", out var c) ? c?.ToString() : null
        };
    }
    public class FactPulseValidationException : FactPulseException {
        public List<ValidationErrorDetail> Errors { get; }
        public FactPulseValidationException(string msg, List<ValidationErrorDetail>? errors = null)
            : base(errors?.Any() == true ? $"{msg}\n\nDétails:\n{string.Join("\n", errors.Select(e => $"  - {e}"))}" : msg) { Errors = errors ?? new(); }
    }
}
