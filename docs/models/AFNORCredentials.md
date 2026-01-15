# FactPulse.SDK.Model.AFNORCredentials
Optional AFNOR PDP credentials.  **MODE 1 - JWT retrieval (recommended):** Do not provide this `credentials` field in the payload. PDP credentials will be automatically retrieved via client_uid from JWT (0-trust).  **MODE 2 - Credentials in payload (zero-storage):** Provide all required fields below. Useful for tests or third-party integrations.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ClientId** | **string** |  | [optional] 
**ClientSecret** | **string** |  | [optional] 
**FlowServiceUrl** | **string** |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

