# FactPulse.SDK.Model.ValidationErrorDetail
Validation error detail (aligned with AFNOR AcknowledgementDetail).  Unified format for all Factur-X validation errors, compatible with AFNOR XP Z12-013 standard.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Item** | **string** | Identifier of the concerned element (XPath, field, BR-FR rule, etc.) | 
**Reason** | **string** | Error description | 
**Level** | **ErrorLevel** | Severity level: &#39;Error&#39; or &#39;Warning&#39; | [optional] 
**Source** | **ErrorSource** |  | [optional] 
**Code** | **string** |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

