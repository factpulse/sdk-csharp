# FactPulse.SDK.Model.SubmitCompleteInvoiceRequest
Request to submit a complete invoice (generation + submission).  Workflow: 1. Auto-enrichment (optional) 2. Factur-X PDF generation 3. Signature (optional) 4. Submission to destination

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**InvoiceData** | [**SimplifiedInvoiceData**](SimplifiedInvoiceData.md) | Invoice data in simplified format (see examples) | 
**SourcePdf** | **string** | Base64-encoded source PDF (will be transformed to Factur-X) | 
**Destination** | [**Destination**](Destination.md) |  | 
**Signature** | [**SignatureParameters**](SignatureParameters.md) |  | [optional] 
**Options** | [**ProcessingOptions**](ProcessingOptions.md) | Processing options | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

