# FactPulse.SDK.Model.MandatoryNoteSchema
Mandatory note detected with location and XML/PDF comparison.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**SubjectCode** | **string** | Subject code (PMT, PMD, AAB) | 
**Label** | **string** | Label (e.g., Recovery indemnity) | 
**PdfValue** | **string** |  | [optional] 
**XmlValue** | **string** |  | [optional] 
**Status** | **FieldStatus** | Compliance status (COMPLIANT if XML found in PDF) | [optional] 
**Message** | **string** |  | [optional] 
**Bbox** | [**BoundingBoxSchema**](BoundingBoxSchema.md) |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

