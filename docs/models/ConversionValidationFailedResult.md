# FactPulse.SDK.Model.ConversionValidationFailedResult
Conversion extracted data failed Schematron validation.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ConversionId** | **string** |  | 
**Message** | **string** |  | 
**ExtractedData** | **Dictionary&lt;string, Object&gt;** |  | 
**Profile** | **string** |  | 
**ProcessingTimeMs** | **int** |  | 
**Status** | **string** |  | [optional] [default to StatusEnum.VALIDATIONFAILED]
**Extraction** | [**ConversionExtractionInfo**](ConversionExtractionInfo.md) |  | [optional] 
**ValidationErrors** | **List&lt;Dictionary&lt;string, Object&gt;&gt;** |  | [optional] 
**CorrectionAttempted** | **bool** |  | [optional] [default to false]

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

