# FactPulse.SDK.Model.ConvertPendingInputResponse
Reponse donnees manquantes.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ConversionId** | **string** |  | 
**Extraction** | [**ExtractionInfo**](ExtractionInfo.md) |  | 
**ExtractedData** | **Dictionary&lt;string, Object&gt;** | Donnees extraites par OCR au format FacturXInvoice | 
**MissingFields** | [**List&lt;MissingField&gt;**](MissingField.md) |  | 
**ResumeUrl** | **string** |  | 
**ExpiresAt** | **DateTime** |  | 
**Status** | **string** |  | [optional] [default to "pending_input"]
**Message** | **string** |  | [optional] [default to "Donnees manquantes requises pour la conformite"]

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

