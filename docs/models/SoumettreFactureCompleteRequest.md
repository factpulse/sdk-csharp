# FactPulse.SDK.Model.SoumettreFactureCompleteRequest
Requête pour soumettre une facture complète (génération + soumission).  Workflow : 1. Auto-enrichissement (optionnel) 2. Génération PDF Factur-X 3. Signature (optionnelle) 4. Soumission vers la destination

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**DonneesFacture** | [**DonneesFactureSimplifiees**](DonneesFactureSimplifiees.md) | Données de la facture au format simplifié (voir exemples) | 
**PdfSource** | **string** | PDF source encodé en base64 (sera transformé en Factur-X) | 
**Destination** | [**Destination**](Destination.md) |  | 
**Signature** | [**ParametresSignature**](ParametresSignature.md) |  | [optional] 
**Options** | [**OptionsProcessing**](OptionsProcessing.md) | Options de traitement | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

