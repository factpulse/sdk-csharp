# FactPulse.SDK.Model.APIError
Standardized API error (aligned with AFNOR Error schema).  Unified format for all HTTP error responses.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ErrorCode** | **string** | Alphanumeric code precisely identifying the error | 
**ErrorMessage** | **string** | Message describing the error (not intended for end user) | 
**Details** | [**List&lt;ValidationErrorDetail&gt;**](ValidationErrorDetail.md) |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

