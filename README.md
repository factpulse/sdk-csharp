# FactPulse SDK C#

Official C# / .NET client for the FactPulse API.

## Installation

```bash
dotnet add package FactPulse.SDK
```

Or via NuGet Package Manager:

```
Install-Package FactPulse.SDK
```

## Quick Start

```csharp
using FactPulse.SDK;
using FactPulse.SDK.Models;

var client = new FactPulseClient(
    email: "your_email@example.com",
    password: "your_password"
);

// Generate a Factur-X invoice
var sourcePdf = File.ReadAllBytes("source.pdf");

var pdfBytes = await client.GenerateFacturxAsync(new GenerateFacturxRequest
{
    InvoiceData = new InvoiceData
    {
        Number = "INV-2025-001",
        Supplier = new Supplier { Name = "My Company", Siret = "12345678901234" },
        Recipient = new Recipient { Name = "Client", Siret = "98765432109876" },
        Lines = new[] { new InvoiceLine { Description = "Service", Quantity = 1, UnitPrice = 1000 } }
    },
    PdfSource = sourcePdf,
    Profile = "EN16931"
});

File.WriteAllBytes("facturx.pdf", pdfBytes);
```

## License

MIT
