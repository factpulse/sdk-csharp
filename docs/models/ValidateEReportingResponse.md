# FactPulse.SDK.Model.ValidateEReportingResponse
Response after validating e-reporting data.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Valid** | **bool** | Whether the data is valid | 
**ReportId** | **string** | Report identifier | 
**FlowType** | **string** | Flux type | 
**Message** | **string** | Status message | 
**Errors** | [**List&lt;EReportingValidationError&gt;**](EReportingValidationError.md) | List of validation errors (if any) | [optional] 
**Warnings** | [**List&lt;EReportingValidationError&gt;**](EReportingValidationError.md) | List of validation warnings (if any) | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

