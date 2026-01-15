# FactPulse.SDK.Model.FactureElectroniqueRestApiSchemasProcessingChorusProCredentials
Optional Chorus Pro credentials.  **MODE 1 - JWT retrieval (recommended):** Do not provide this `credentials` field in the payload. Credentials will be automatically retrieved via client_uid from JWT (0-trust).  **MODE 2 - Credentials in payload:** Provide all required fields below. Useful for tests or third-party integrations.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**PisteClientId** | **string** |  | [optional] 
**PisteClientSecret** | **string** |  | [optional] 
**ChorusLogin** | **string** |  | [optional] 
**ChorusPassword** | **string** |  | [optional] 
**SandboxMode** | **bool** | [MODE 2] Use sandbox mode (default: True) | [optional] [default to true]

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

