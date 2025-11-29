# FactPulse SDK C#

Client C# officiel pour l'API FactPulse - Facturation électronique française.

## Fonctionnalités

- **Factur-X** : Génération et validation de factures électroniques (profils MINIMUM, BASIC, EN16931, EXTENDED)
- **Chorus Pro** : Intégration avec la plateforme de facturation publique française
- **AFNOR PDP/PA** : Soumission de flux conformes à la norme XP Z12-013
- **Signature électronique** : Signature PDF (PAdES-B-B, PAdES-B-T, PAdES-B-LT)
- **Client simplifié** : Authentification JWT et polling intégrés via `Helpers`

## Installation

```bash
dotnet add package FactPulse.SDK
```

Ou via NuGet Package Manager :

```
Install-Package FactPulse.SDK
```

## Démarrage rapide

Le namespace `Helpers` offre une API simplifiée avec authentification et polling automatiques :

```csharp
using System.IO;
using FactPulse.SDK.Helpers;
using static FactPulse.SDK.Helpers.MontantHelpers;

// Créer le client
var client = new FactPulseClient(
    "votre_email@example.com",
    "votre_mot_de_passe"
);

// Construire la facture avec les helpers
var factureData = new Dictionary<string, object>
{
    ["numeroFacture"] = "FAC-2025-001",
    ["dateFacture"] = "2025-01-15",
    ["fournisseur"] = Fournisseur(
        "Mon Entreprise SAS", "12345678901234",
        "123 Rue Example", "75001", "Paris"
    ),
    ["destinataire"] = Destinataire(
        "Client SARL", "98765432109876",
        "456 Avenue Test", "69001", "Lyon"
    ),
    ["montantTotal"] = MontantTotal(1000.00m, 200.00m, 1200.00m, 1200.00m),
    ["lignesDePoste"] = new List<object>
    {
        LigneDePoste(1, "Prestation de conseil", 10, 100.00m, 1000.00m)
    },
    ["lignesDeTva"] = new List<object>
    {
        LigneDeTva(1000.00m, 200.00m)
    }
};

// Générer le PDF Factur-X
var pdfBytes = await client.GenererFacturxAsync(factureData, "facture_source.pdf", "EN16931");

await File.WriteAllBytesAsync("facture_facturx.pdf", pdfBytes);
```

## Helpers disponibles (classe MontantHelpers)

### Montant(value)

Convertit une valeur en string formaté pour les montants monétaires.

```csharp
using static FactPulse.SDK.Helpers.MontantHelpers;

Montant(1234.5m);      // "1234.50"
Montant("1234.56");    // "1234.56"
Montant(null);         // "0.00"
```

### MontantTotal(ht, tva, ttc, aPayer, ...)

Crée un objet MontantTotal complet.

```csharp
var total = MontantTotal(
    1000.00m,       // ht
    200.00m,        // tva
    1200.00m,       // ttc
    1200.00m,       // aPayer
    50.00m,         // remiseTtc (optionnel)
    "Fidélité",     // motifRemise (optionnel)
    100.00m         // acompte (optionnel)
);
```

### LigneDePoste(numero, denomination, quantite, montantUnitaireHt, montantTotalLigneHt, ...)

Crée une ligne de facturation.

```csharp
var ligne = LigneDePoste(
    1,
    "Prestation de conseil",
    5,
    200.00m,
    1000.00m,  // montantTotalLigneHt requis
    tauxTva: "TVA20",         // Ou tauxTvaManuel: "20.00"
    categorieTva: "S",        // S, Z, E, AE, K
    unite: "HEURE",           // FORFAIT, PIECE, HEURE, JOUR...
    reference: "REF-001"
);
```

### LigneDeTva(montantBaseHt, montantTva, ...)

Crée une ligne de ventilation TVA.

```csharp
var tva = LigneDeTva(
    1000.00m,       // montantBaseHt
    200.00m,        // montantTva
    taux: "TVA20",  // Ou tauxManuel: "20.00"
    categorie: "S"  // S, Z, E, AE, K
);
```

### AdressePostale(ligne1, codePostal, ville, ...)

Crée une adresse postale structurée.

```csharp
var adresse = AdressePostale(
    "123 Rue de la République",
    "75001",
    "Paris",
    pays: "FR",             // Défaut: "FR"
    ligne2: "Bâtiment A"    // Optionnel
);
```

### Fournisseur(nom, siret, adresseLigne1, codePostal, ville, options)

Crée un fournisseur complet avec calcul automatique du SIREN et TVA intra.

```csharp
var f = Fournisseur(
    "Ma Société SAS",
    "12345678901234",
    "123 Rue Example",
    "75001",
    "Paris",
    iban: "FR7630006000011234567890189"
);
// SIREN et TVA intracommunautaire calculés automatiquement
```

### Destinataire(nom, siret, adresseLigne1, codePostal, ville, options)

Crée un destinataire (client) avec calcul automatique du SIREN.

```csharp
var d = Destinataire(
    "Client SARL",
    "98765432109876",
    "456 Avenue Test",
    "69001",
    "Lyon"
);
```

## Mode Zero-Trust (Chorus Pro / AFNOR)

Pour passer vos propres credentials sans stockage côté serveur :

```csharp
using FactPulse.SDK.Helpers;

var chorusCreds = new ChorusProCredentials(
    "votre_client_id",
    "votre_client_secret",
    "votre_login",
    "votre_password",
    sandbox: true
);

var afnorCreds = new AFNORCredentials(
    "https://api.pdp.fr/flow/v1",
    "https://auth.pdp.fr/oauth/token",
    "votre_client_id",
    "votre_client_secret"
);

var client = new FactPulseClient(
    "votre_email@example.com",
    "votre_mot_de_passe",
    chorusCredentials: chorusCreds,
    afnorCredentials: afnorCreds
);
```

## Ressources

- **Documentation API** : https://factpulse.fr/api/facturation/documentation
- **Support** : contact@factpulse.fr

## Licence

MIT License - Copyright (c) 2025 FactPulse
