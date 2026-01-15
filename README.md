# FactPulse SDK C#

Official C# client for the FactPulse API - French electronic invoicing.

## Features

- **Factur-X**: Generation and validation of electronic invoices (MINIMUM, BASIC, EN16931, EXTENDED profiles)
- **Chorus Pro**: Integration with the French public sector invoicing platform
- **AFNOR PDP/PA**: Submission of flows compliant with the XP Z12-013 standard
- **Electronic signature**: PDF signature (PAdES-B-B, PAdES-B-T, PAdES-B-LT)
- **Simplified client**: JWT authentication and integrated polling via `Helpers`

## Installation

```bash
dotnet add package FactPulse.SDK
```

Or via NuGet Package Manager:

```
Install-Package FactPulse.SDK
```

## Quick Start

The `Helpers` namespace provides a simplified API with automatic authentication and polling:

```csharp
using System.IO;
using FactPulse.SDK.Helpers;
using static FactPulse.SDK.Helpers.AmountHelpers;

// Create the client
var client = new FactPulseClient(
    "your_email@example.com",
    "your_password"
);

// Build the invoice with helpers
var invoiceData = new Dictionary<string, object>
{
    ["invoiceNumber"] = "INV-2025-001",
    ["issueDate"] = "2025-01-15",
    ["dueDate"] = "2025-02-15",
    ["currencyCode"] = "EUR",
    ["supplier"] = Supplier(
        "My Company SAS", "12345678901234",
        "123 Example Street", "75001", "Paris"
    ),
    ["recipient"] = Recipient(
        "Client SARL", "98765432109876",
        "456 Test Avenue", "69001", "Lyon"
    ),
    ["totals"] = TotalAmount(1000.00m, 200.00m, 1200.00m, 1200.00m),
    ["lines"] = new List<object>
    {
        InvoiceLine(1, "Consulting services", 10, 100.00m, 1000.00m)
    },
    ["vatLines"] = new List<object>
    {
        VatLine(1000.00m, 200.00m)
    }
};

// Generate the Factur-X PDF
var pdfBytes = await client.GenerateFacturxAsync(invoiceData, "source_invoice.pdf", "EN16931");

await File.WriteAllBytesAsync("invoice_facturx.pdf", pdfBytes);
```

## Available Helpers (AmountHelpers class)

### Amount(value)

Converts a value to a formatted string for monetary amounts.

```csharp
using static FactPulse.SDK.Helpers.AmountHelpers;

Amount(1234.5m);      // "1234.50"
Amount("1234.56");    // "1234.56"
Amount(null);         // "0.00"
```

### TotalAmount(excludingTax, vat, includingTax, due, ...)

Creates a complete TotalAmount object.

```csharp
var total = TotalAmount(
    1000.00m,               // excludingTax
    200.00m,                // vat
    1200.00m,               // includingTax
    1200.00m,               // due
    50.00m,                 // discountIncludingTax (optional)
    "Loyalty discount",     // discountReason (optional)
    100.00m                 // prepayment (optional)
);
```

### InvoiceLine(number, description, quantity, unitPrice, lineTotal, ...)

Creates an invoice line.

```csharp
var line = InvoiceLine(
    1,
    "Consulting services",
    5,
    200.00m,
    1000.00m,                 // lineTotal required
    vatRate: "VAT20",         // Or manualVatRate: "20.00"
    vatCategory: "S",         // S, Z, E, AE, K
    unit: "HOUR",             // FIXED, PIECE, HOUR, DAY...
    reference: "REF-001"
);
```

### VatLine(baseExcludingTax, vatAmount, ...)

Creates a VAT breakdown line.

```csharp
var vat = VatLine(
    1000.00m,               // baseExcludingTax
    200.00m,                // vatAmount
    rate: "VAT20",          // Or manualRate: "20.00"
    category: "S"           // S, Z, E, AE, K
);
```

### PostalAddress(line1, postalCode, city, ...)

Creates a structured postal address.

```csharp
var address = PostalAddress(
    "123 Republic Street",
    "75001",
    "Paris",
    country: "FR",          // Default: "FR"
    line2: "Building A"     // Optional
);
```

### Supplier(name, siret, addressLine1, postalCode, city, options)

Creates a complete supplier with automatic calculation of SIREN and intra-community VAT.

```csharp
var s = Supplier(
    "My Company SAS",
    "12345678901234",
    "123 Example Street",
    "75001",
    "Paris",
    iban: "FR7630006000011234567890189"
);
// SIREN and intra-community VAT automatically calculated
```

### Recipient(name, siret, addressLine1, postalCode, city, options)

Creates a recipient (customer) with automatic calculation of SIREN.

```csharp
var r = Recipient(
    "Client SARL",
    "98765432109876",
    "456 Test Avenue",
    "69001",
    "Lyon"
);
```

## Zero-Trust Mode (Chorus Pro / AFNOR)

To pass your own credentials without server-side storage:

```csharp
using FactPulse.SDK.Helpers;

var chorusCreds = new ChorusProCredentials(
    "your_client_id",
    "your_client_secret",
    "your_login",
    "your_password",
    sandbox: true
);

var afnorCreds = new AFNORCredentials(
    "https://api.pdp.fr/flow/v1",
    "https://auth.pdp.fr/oauth/token",
    "your_client_id",
    "your_client_secret"
);

var client = new FactPulseClient(
    "your_email@example.com",
    "your_password",
    chorusCredentials: chorusCreds,
    afnorCredentials: afnorCreds
);
```

## Resources

- **API Documentation**: https://factpulse.fr/api/facturation/documentation
- **Support**: contact@factpulse.fr

## License

MIT License - Copyright (c) 2025 FactPulse
