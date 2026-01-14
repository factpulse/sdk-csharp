# FactPulse.SDK.Model.ConvertSuccessResponse
Reponse succes de conversion.  Le champ `invoice` contient les donnees de la facture au format FacturXInvoice (cf. facture_electronique.models.FacturXInvoice). Ce modele est le meme que celui utilise pour la generation Factur-X, garantissant une coherence totale.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ConversionId** | **string** | Identifiant unique de conversion | 
**DocumentType** | [**DocumentTypeInfo**](DocumentTypeInfo.md) |  | 
**Invoice** | **Dictionary&lt;string, Object&gt;** | Donnees facture au format FacturXInvoice (cf. models.py) | 
**Extraction** | [**ExtractionInfo**](ExtractionInfo.md) |  | 
**Validation** | [**ValidationInfo**](ValidationInfo.md) |  | 
**Files** | [**FilesInfo**](FilesInfo.md) |  | 
**ProcessingTimeMs** | **int** | Temps de traitement en ms | 
**Status** | **string** | Statut de la conversion | [optional] [default to "success"]
**PdfRegenerated** | **bool** | True si le PDF a ete regenere (source non exploitable) | [optional] [default to false]
**PdfRegeneratedReason** | **string** |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

