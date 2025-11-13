# FactPulse SDK C#

Client C# officiel pour l'API FactPulse - Facturation électronique française.

## 🎯 Fonctionnalités

- **Factur-X** : Génération et validation de factures électroniques (profils MINIMUM, BASIC, EN16931, EXTENDED)
- **Chorus Pro** : Intégration avec la plateforme de facturation publique française
- **AFNOR PDP/PA** : Soumission de flux conformes à la norme XP Z12-013
- **Signature électronique** : Signature PDF (PAdES-B-B, PAdES-B-T, PAdES-B-LT)
- **Traitement asynchrone** : Support Celery pour opérations longues
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

### 1. Authentification

```csharp
using FactPulse.SDK.Api;
using FactPulse.SDK.Client;

// Configuration du client
var config = new Configuration
{
    BasePath = "https://factpulse.fr/api/facturation"
};
config.AddApiKey("Authorization", "Bearer votre_token_jwt");

var apiInstance = new TraitementFactureApi(config);
```

### 2. Générer une facture Factur-X

```csharp
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

// Données de la facture
var factureData = new Dictionary<string, object>
{
    ["numero_facture"] = "FAC-2025-001",
    ["date_facture"] = "2025-01-15",
    ["montant_total_ht"] = "1000.00",
    ["montant_total_ttc"] = "1200.00",
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
    ["lignes_de_poste"] = new List<Dictionary<string, object>>
    {
        new Dictionary<string, object>
        {
            ["numero"] = 1,
            ["denomination"] = "Prestation de conseil",
            ["quantite"] = "10.00",
            ["montant_unitaire_ht"] = "100.00",
            ["montant_ligne_ht"] = "1000.00"
        }
    }
};

string jsonFacture = JsonConvert.SerializeObject(factureData);

// Générer le PDF Factur-X
var pdfBytes = apiInstance.GenererFactureApiV1TraitementGenererFacturePost(
    jsonFacture,
    "EN16931",
    "pdf"
);

// Sauvegarder
File.WriteAllBytes("facture.pdf", pdfBytes);
```

### 3. Soumettre une facture complète (Chorus Pro / AFNOR PDP)

```csharp
var requestBody = new Dictionary<string, object>
{
    ["facture"] = factureData,
    ["destination"] = new Dictionary<string, object>
    {
        ["type"] = "chorus_pro",
        ["credentials"] = new Dictionary<string, string>
        {
            ["login"] = "votre_login_chorus",
            ["password"] = "votre_password_chorus"
        }
    }
};

var response = apiInstance.SoumettreFactureCompleteApiV1TraitementFacturesSoumettreCompletePost(requestBody);

Console.WriteLine($"Facture soumise : {response.IdFactureChorus}");
```

## 🔑 Obtention du token JWT

### Via l'API

```csharp
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

var client = new HttpClient();
var credentials = new Dictionary<string, string>
{
    ["username"] = "votre_email@example.com",
    ["password"] = "votre_mot_de_passe"
};

var content = new StringContent(
    JsonConvert.SerializeObject(credentials),
    Encoding.UTF8,
    "application/json"
);

var response = await client.PostAsync("https://factpulse.fr/api/token/", content);
var result = JsonConvert.DeserializeObject<Dictionary<string, string>>(
    await response.Content.ReadAsStringAsync()
);
string token = result["access"];
```

**Accès aux credentials d'un client spécifique :**

Si vous gérez plusieurs clients et souhaitez accéder aux credentials (Chorus Pro, AFNOR PDP) d'un client particulier, ajoutez le champ `client_uid` :

```csharp
var credentials = new Dictionary<string, string>
{
    ["username"] = "votre_email@example.com",
    ["password"] = "votre_mot_de_passe",
    ["client_uid"] = "identifiant_client"  // UID du client cible
};
```

### Via le Dashboard

1. Connectez-vous sur https://factpulse.fr/api/dashboard/
2. Générez un token API
3. Copiez et utilisez le token dans votre configuration

## 📚 Ressources

- **Documentation API** : https://factpulse.fr/api/facturation/documentation
- **Code source** : https://github.com/factpulse/sdk-csharp
- **Issues** : https://github.com/factpulse/sdk-csharp/issues
- **Support** : contact@factpulse.fr

## 📄 Licence

MIT License - Copyright (c) 2025 FactPulse
