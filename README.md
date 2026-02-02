# FactPulse SDK C#

Official C# client for the FactPulse API - French electronic invoicing.

## Features

- **Factur-X**: Generation and validation of electronic invoices (MINIMUM, BASIC, EN16931, EXTENDED profiles)
- **Chorus Pro**: Integration with the French public invoicing platform
- **AFNOR PDP/PA**: Submission of flows compliant with XP Z12-013 standard
- **Electronic signature**: PDF signing (PAdES-B-B, PAdES-B-T, PAdES-B-LT)
- **Thin HTTP wrapper**: Generic `PostAsync()` and `GetAsync()` methods with automatic JWT auth and polling

## Installation

```bash
dotnet add package FactPulse.SDK
```

Or via NuGet Package Manager:

```powershell
Install-Package FactPulse.SDK
```

## Quick Start

```csharp
using System;
using System.IO;
using System.Collections.Generic;
using FactPulse.SDK;

// Create the client
var client = new FactPulseClient(
    "your_email@example.com",
    "your_password",
    "your-client-uuid"  // From dashboard: Configuration > Clients
);

// Read your source PDF
var pdfB64 = Convert.ToBase64String(File.ReadAllBytes("source_invoice.pdf"));

// Generate Factur-X and submit to PDP in one call
var result = await client.PostAsync("processing/invoices/submit-complete-async", new Dictionary<string, object>
{
    ["invoiceData"] = new Dictionary<string, object>
    {
        ["number"] = "INV-2025-001",
        ["supplier"] = new Dictionary<string, object>
        {
            ["name"] = "ACME Corporation",
            ["siret"] = "12345678901234",
            ["iban"] = "FR7630001007941234567890185",
            ["routing_address"] = "12345678901234"
        },
        ["recipient"] = new Dictionary<string, object>
        {
            ["name"] = "Client Company SA",
            ["siret"] = "98765432109876",
            ["routing_address"] = "98765432109876"
        },
        ["lines"] = new List<Dictionary<string, object>>
        {
            new Dictionary<string, object>
            {
                ["description"] = "Consulting services",
                ["quantity"] = 10,
                ["unitPrice"] = 100.0,
                ["vatRate"] = 20.0
            }
        }
    },
    ["sourcePdf"] = pdfB64,
    ["profile"] = "EN16931",
    ["destination"] = new Dictionary<string, object> { ["type"] = "afnor" }
});

// PDF is in result["content"] (auto-polled, auto-decoded)
var facturxPdf = (byte[])result["content"];
await File.WriteAllBytesAsync("facturx_invoice.pdf", facturxPdf);

var afnorResult = (Dictionary<string, object>)result["afnorResult"];
Console.WriteLine($"Flow ID: {afnorResult["flowId"]}");
```

## API Methods

The SDK provides two generic methods that map directly to API endpoints:

```csharp
// POST /api/v1/{path}
var result = await client.PostAsync("path/to/endpoint", data);

// GET /api/v1/{path}
var result = await client.GetAsync("path/to/endpoint", queryParams);
```

### Common Endpoints

| Endpoint | Method | Description |
|----------|--------|-------------|
| `processing/invoices/submit-complete-async` | POST | Generate Factur-X + submit to PDP |
| `processing/generate-invoice` | POST | Generate Factur-X XML or PDF |
| `processing/validate-xml` | POST | Validate Factur-X XML |
| `processing/validate-facturx-pdf` | POST | Validate Factur-X PDF |
| `processing/sign-pdf` | POST | Sign PDF with certificate |
| `afnor/flow/v1/flows` | POST | Submit flow to AFNOR PDP |
| `afnor/incoming-flows/{flow_id}` | GET | Get incoming invoice |
| `chorus-pro/factures/soumettre` | POST | Submit to Chorus Pro |

## Webhooks

Instead of polling, you can receive results via webhook by adding `callbackUrl`:

```csharp
var result = await client.PostAsync("processing/invoices/submit-complete-async", new Dictionary<string, object>
{
    ["invoiceData"] = invoiceData,
    ["sourcePdf"] = pdfB64,
    ["destination"] = new Dictionary<string, object> { ["type"] = "afnor" },
    ["callbackUrl"] = "https://your-server.com/webhook/factpulse",
    ["webhookMode"] = "INLINE"  // or "DOWNLOAD_URL"
});

var taskId = (string)result["taskId"];
// Result will be POSTed to your webhook URL
```

### Webhook Receiver Example (ASP.NET Core)

```csharp
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

[ApiController]
[Route("webhook")]
public class WebhookController : ControllerBase
{
    private const string WebhookSecret = "your-shared-secret";

    [HttpPost("factpulse")]
    public IActionResult HandleWebhook()
    {
        using var reader = new StreamReader(Request.Body);
        var payload = reader.ReadToEndAsync().Result;
        var signature = Request.Headers["X-Webhook-Signature"].ToString();

        if (!VerifySignature(payload, signature))
        {
            return Unauthorized(new { error = "Invalid signature" });
        }

        var eventData = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(payload);
        var eventType = eventData["event_type"].GetString();
        var data = eventData["data"];

        switch (eventType)
        {
            case "submission.completed":
                var flowId = data.GetProperty("afnorResult").GetProperty("flowId").GetString();
                Console.WriteLine($"Invoice submitted: {flowId}");
                break;
            case "submission.failed":
                Console.WriteLine($"Submission failed: {data.GetProperty("error")}");
                break;
        }

        return Ok(new { status = "received" });
    }

    private static bool VerifySignature(string payload, string signature)
    {
        if (!signature.StartsWith("sha256=")) return false;

        using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(WebhookSecret));
        var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(payload));
        var expected = BitConverter.ToString(hash).Replace("-", "").ToLower();

        return expected == signature[7..];
    }
}
```

### Webhook Event Types

| Event | Description |
|-------|-------------|
| `generation.completed` | Factur-X generated successfully |
| `generation.failed` | Generation failed |
| `validation.completed` | Validation passed |
| `validation.failed` | Validation failed |
| `signature.completed` | PDF signed |
| `submission.completed` | Submitted to PDP/Chorus |
| `submission.failed` | Submission failed |

## Zero-Storage Mode

Pass PDP credentials directly in the request (no server-side storage):

```csharp
var result = await client.PostAsync("processing/invoices/submit-complete-async", new Dictionary<string, object>
{
    ["invoiceData"] = invoiceData,
    ["sourcePdf"] = pdfB64,
    ["destination"] = new Dictionary<string, object>
    {
        ["type"] = "afnor",
        ["flowServiceUrl"] = "https://api.pdp.example.com/flow/v1",
        ["tokenUrl"] = "https://auth.pdp.example.com/oauth/token",
        ["clientId"] = "your_pdp_client_id",
        ["clientSecret"] = "your_pdp_client_secret"
    }
});
```

## Error Handling

```csharp
using FactPulse.SDK;

try
{
    var result = await client.PostAsync("processing/validate-xml", data);
}
catch (FactPulseException e)
{
    Console.WriteLine($"Error: {e.Message}");
    Console.WriteLine($"Status code: {e.StatusCode}");
    Console.WriteLine($"Details: {string.Join(", ", e.Details)}");
}
```

## Available Helpers

The SDK provides the following helper classes:

- `FactPulseClient`: Main HTTP client with auto-auth and polling
- `FactPulseException`: Base exception class
- `FactPulseAuthException`: Authentication failure
- `FactPulseValidationException`: Validation errors with details
- `FactPulsePollingTimeoutException`: Task polling timeout

## Resources

- **API Documentation**: https://factpulse.fr/api/facturation/documentation
- **Support**: contact@factpulse.fr

## License

MIT License - Copyright (c) 2025 FactPulse
