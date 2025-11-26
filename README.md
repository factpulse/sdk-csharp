# FactPulse SDK C#

Client C# officiel pour l'API FactPulse - Facturation électronique française.

## 🎯 Fonctionnalités

- **Factur-X** : Génération et validation de factures électroniques (profils MINIMUM, BASIC, EN16931, EXTENDED)
- **Chorus Pro** : Intégration avec la plateforme de facturation publique française
- **AFNOR PDP/PA** : Soumission de flux conformes à la norme XP Z12-013
- **Signature électronique** : Signature PDF (PAdES-B-B, PAdES-B-T, PAdES-B-LT)
- **Client simplifié** : Authentification JWT et polling intégrés via `Helpers`
- **.NET 8.0+** : Compatible avec .NET 8.0 et versions supérieures

## 🚀 Installation

```bash
dotnet add package FactPulse.SDK
```

Ou via NuGet Package Manager :

```
Install-Package FactPulse.SDK
```

## 📖 Démarrage rapide

### Méthode recommandée : Client simplifié avec Helpers

Le namespace `Helpers` offre une API simplifiée avec authentification et polling automatiques :

```csharp
using System.Collections.Generic;
using System.IO;
using FactPulse.SDK.Helpers;

// Créer le client (authentification automatique)
var config = new FactPulseClientConfig(
    "votre_email@example.com",
    "votre_mot_de_passe"
);
var client = new FactPulseClient(config);

// Données de la facture
var factureData = new Dictionary<string, object>
{
    ["numero_facture"] = "FAC-2025-001",
    ["date_facture"] = "2025-01-15",
    ["fournisseur"] = new Dictionary<string, object>
    {
        ["nom"] = "Mon Entreprise SAS",
        ["siret"] = "12345678901234",
        ["adresse_postale"] = new Dictionary<string, string>
        {
            ["ligne_un"] = "123 Rue Example",
            ["code_postal"] = "75001",
            ["nom_ville"] = "Paris",
            ["pays_code_iso"] = "FR"
        }
    },
    ["destinataire"] = new Dictionary<string, object>
    {
        ["nom"] = "Client SARL",
        ["siret"] = "98765432109876",
        ["adresse_postale"] = new Dictionary<string, string>
        {
            ["ligne_un"] = "456 Avenue Test",
            ["code_postal"] = "69001",
            ["nom_ville"] = "Lyon",
            ["pays_code_iso"] = "FR"
        }
    },
    ["montant_total"] = new Dictionary<string, string>
    {
        ["montant_ht_total"] = "1000.00",
        ["montant_tva"] = "200.00",
        ["montant_ttc_total"] = "1200.00",
        ["montant_a_payer"] = "1200.00"
    },
    ["lignes_de_poste"] = new List<Dictionary<string, object>>
    {
        new Dictionary<string, object>
        {
            ["numero"] = 1,
            ["denomination"] = "Prestation de conseil",
            ["quantite"] = "10.00",
            ["unite"] = "PIECE",
            ["montant_unitaire_ht"] = "100.00"
        }
    }
};

// Lire le PDF source
var pdfSource = await File.ReadAllBytesAsync("facture_source.pdf");

// Générer le PDF Factur-X (polling automatique)
var pdfBytes = await client.GenererFacturxAsync(
    factureData,
    pdfSource,
    profil: "EN16931",
    formatSortie: "pdf",
    sync: true  // Attend le résultat automatiquement
);

// Sauvegarder
await File.WriteAllBytesAsync("facture_facturx.pdf", pdfBytes);
```

### Méthode alternative : SDK brut

Pour un contrôle total, utilisez le SDK généré directement :

```csharp
using System.Net.Http;
using System.Text;
using System.Text.Json;
using FactPulse.SDK.Api;
using FactPulse.SDK.Client;

// 1. Obtenir le token JWT
var httpClient = new HttpClient();
var credentials = new Dictionary<string, string>
{
    ["username"] = "votre_email@example.com",
    ["password"] = "votre_mot_de_passe"
};

var content = new StringContent(
    JsonSerializer.Serialize(credentials),
    Encoding.UTF8,
    "application/json"
);

var response = await httpClient.PostAsync("https://factpulse.fr/api/token/", content);
var result = JsonSerializer.Deserialize<Dictionary<string, string>>(
    await response.Content.ReadAsStringAsync()
);
var token = result["access"];

// 2. Configurer le client
var apiConfig = new Configuration
{
    BasePath = "https://factpulse.fr/api/facturation"
};
apiConfig.AccessToken = token;

// 3. Appeler l'API
var api = new TraitementFactureApi(apiConfig);
using var fileStream = File.OpenRead("facture_source.pdf");

var apiResponse = await api.GenererFactureApiV1TraitementGenererFacturePostAsync(
    JsonSerializer.Serialize(factureData),
    "EN16931",
    "pdf",
    fileStream
);

// 4. Polling manuel pour récupérer le résultat
var taskId = apiResponse.IdTache;
// ... (implémenter le polling)
```

## 🔧 Avantages des Helpers

| Fonctionnalité | SDK brut | Helpers |
|----------------|----------|---------|
| Authentification | Manuelle | Automatique |
| Refresh token | Manuel | Automatique |
| Polling tâches async | Manuel | Automatique (backoff) |
| Retry sur 401 | Manuel | Automatique |

## 🔑 Options d'authentification

### Client UID (multi-clients)

Si vous gérez plusieurs clients :

```csharp
var config = new FactPulseClientConfig(
    "votre_email@example.com",
    "votre_mot_de_passe"
)
{
    ClientUid = "identifiant_client"  // UID du client cible
};
```

### Configuration avancée

```csharp
var config = new FactPulseClientConfig(
    "votre_email@example.com",
    "votre_mot_de_passe"
)
{
    ApiUrl = "https://factpulse.fr",  // URL personnalisée
    PollingInterval = 2000,  // Intervalle de polling initial (ms)
    PollingTimeout = 120000,  // Timeout de polling (ms)
    MaxRetries = 2  // Tentatives en cas de 401
};
```

## 💡 Formats de montants acceptés

L'API accepte plusieurs formats pour les montants :

```csharp
// String (recommandé pour la précision)
var montant = "1234.56";

// Decimal
var montant = 1234.56m;

// Double
var montant = 1234.56;

// Integer
var montant = 1234;

// Helper de formatage
var montantFormate = FactPulseClient.FormatMontant(1234.5);  // "1234.50"
```

## 📚 Ressources

- **Documentation API** : https://factpulse.fr/api/facturation/documentation
- **Code source** : https://github.com/factpulse/sdk-csharp
- **Issues** : https://github.com/factpulse/sdk-csharp/issues
- **Support** : contact@factpulse.fr

## 📄 Licence

MIT License - Copyright (c) 2025 FactPulse
