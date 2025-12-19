# FactPulse.SDK.Model.VerifiedFieldSchema
A verified field with all its information (extraction + compliance + location).

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**BusinessTerm** | **string** | EN16931 Business Term (e.g., BT-1) | 
**Label** | **string** | Field label (e.g., Invoice Number) | 
**Status** | **FieldStatus** | Compliance status | 
**PdfValue** | **string** |  | [optional] 
**XmlValue** | **string** |  | [optional] 
**Message** | **string** |  | [optional] 
**Confidence** | **decimal** | Confidence score (0-1) | [optional] [default to 1.0M]
**Source** | **string** | Extraction source | [optional] [default to "native_pdf"]
**Bbox** | [**BoundingBoxSchema**](BoundingBoxSchema.md) |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

