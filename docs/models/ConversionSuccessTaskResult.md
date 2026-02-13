# FactPulse.SDK.Model.ConversionSuccessTaskResult
Successful result from task_convert_document.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ConversionId** | **string** |  | 
**DocumentTypeCode** | **int** |  | 
**Profile** | **string** |  | 
**Extraction** | [**ConversionExtractionInfo**](ConversionExtractionInfo.md) |  | 
**ProcessingTimeMs** | **int** |  | 
**Status** | **string** |  | [optional] [default to StatusEnum.SUCCESS]
**PdfRegenerated** | **bool** |  | [optional] [default to false]
**PdfRegeneratedReason** | **string** |  | [optional] 
**ContentB64** | **string** |  | [optional] 
**XmlContent** | **string** |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

