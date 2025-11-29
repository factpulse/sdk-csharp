# FactPulse.SDK.Model.FactureEntrante
Facture reçue d'un fournisseur via PDP/PA.  Ce modèle contient les métadonnées essentielles extraites des factures entrantes, quel que soit leur format source (CII, UBL, Factur-X).  Les montants sont en Decimal en Python mais seront sérialisés en string dans le JSON pour préserver la précision monétaire.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**FormatSource** | **FormatFacture** | Format source de la facture | 
**RefFournisseur** | **string** | Numéro de facture émis par le fournisseur (BT-1) | 
**Fournisseur** | [**FournisseurEntrant**](FournisseurEntrant.md) | Émetteur de la facture (SellerTradeParty) | 
**SiteFacturationNom** | **string** | Nom du destinataire / votre entreprise (BT-44) | 
**DateDePiece** | **string** | Date de la facture (BT-2) - YYYY-MM-DD | 
**MontantHt** | **string** | Montant HT total (BT-109) | 
**MontantTva** | **string** | Montant TVA total (BT-110) | 
**MontantTtc** | **string** | Montant TTC total (BT-112) | 
**FlowId** | **string** |  | [optional] 
**TypeDocument** | **TypeDocument** | Type de document (BT-3) | [optional] 
**SiteFacturationSiret** | **string** |  | [optional] 
**DateReglement** | **string** |  | [optional] 
**Devise** | **string** | Code devise ISO (BT-5) | [optional] [default to "EUR"]
**NumeroBonCommande** | **string** |  | [optional] 
**ReferenceContrat** | **string** |  | [optional] 
**ObjetFacture** | **string** |  | [optional] 
**DocumentBase64** | **string** |  | [optional] 
**DocumentContentType** | **string** |  | [optional] 
**DocumentFilename** | **string** |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

