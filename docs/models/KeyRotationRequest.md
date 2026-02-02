# FactPulse.SDK.Model.KeyRotationRequest
Request to rotate the client encryption key.  This operation re-encrypts all secrets from the old key to the new key. Both keys must be base64-encoded AES-256 keys (32 bytes each).

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**OldKey** | **string** | Current encryption key (base64-encoded AES-256) | 
**NewKey** | **string** | New encryption key (base64-encoded AES-256) | 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

