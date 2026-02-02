# FactPulse.SDK.Model.PDPConfigUpdateRequest
PDP configuration update request.  For encryption_mode='double', the X-Encryption-Key header must also be provided containing a base64-encoded AES-256 key (32 bytes).

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**FlowServiceUrl** | **string** | PDP Flow Service URL | 
**TokenUrl** | **string** | PDP OAuth token URL | 
**OauthClientId** | **string** | OAuth Client ID | 
**ClientSecret** | **string** | OAuth Client Secret (sent but never returned) | 
**IsActive** | **bool** | Whether config is active | [optional] [default to true]
**ModeSandbox** | **bool** | Sandbox mode | [optional] [default to false]
**EncryptionMode** | **string** |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

