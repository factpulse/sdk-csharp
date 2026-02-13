# FactPulse.SDK.Model.SubmitCompleteInvoiceResponse
Complete response after automated submission.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Success** | **bool** | Invoice was successfully submitted | 
**DestinationType** | **string** | Destination type | 
**EnrichedInvoice** | [**EnrichedInvoiceInfo**](EnrichedInvoiceInfo.md) | Enriched invoice data (summary) | 
**Invoice** | **Dictionary&lt;string, Object&gt;** | Complete enriched invoice data (FacturXInvoice format). Use this to regenerate the same invoice. | 
**FacturxPdf** | [**FacturXPDFInfo**](FacturXPDFInfo.md) | Generated PDF information | 
**ContentB64** | **string** | Generated Factur-X PDF (and signed if requested) base64-encoded | 
**Message** | **string** | Return message | 
**ChorusResult** | [**ChorusProResult**](ChorusProResult.md) |  | [optional] 
**AfnorResult** | [**AFNORResult**](AFNORResult.md) |  | [optional] 
**Signature** | [**SignatureInfo**](SignatureInfo.md) |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

