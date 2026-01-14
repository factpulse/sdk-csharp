# FactPulse.SDK.Model.ConvertValidationFailedResponse
Reponse echec de validation - inclut les donnees extraites pour correction.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ConversionId** | **string** | Identifiant unique de conversion | 
**Extraction** | [**ExtractionInfo**](ExtractionInfo.md) | Informations sur l&#39;extraction OCR | 
**ExtractedData** | **Dictionary&lt;string, Object&gt;** | Donnees extraites par OCR au format FacturXInvoice (a completer/corriger) | 
**Validation** | [**ValidationInfo**](ValidationInfo.md) | Resultat de la validation Factur-X | 
**ResumeUrl** | **string** | URL pour reprendre la conversion avec corrections | 
**ExpiresAt** | **DateTime** | Expiration de la conversion (1h) | 
**Status** | **string** | Statut de la conversion | [optional] [default to "validation_failed"]
**Message** | **string** | Message explicatif | [optional] [default to "Donnees extraites avec erreurs de validation. Completez le formulaire et appelez /resume."]
**MissingFields** | [**List&lt;MissingField&gt;**](MissingField.md) | Champs manquants pour conformite Factur-X | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

