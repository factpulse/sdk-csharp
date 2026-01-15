# FactPulse.SDK.Model.PDPCredentials
PDP credentials for zero-storage strategy (Strategy B).  Allows providing PDP credentials directly in the request instead of storing them in Django.  Useful for: - Ad-hoc tests without persisting credentials - Temporary integrations - Development environments

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**FlowServiceUrl** | **string** | Base URL of the AFNOR Flow Service | 
**TokenUrl** | **string** | OAuth2 server URL | 
**ClientId** | **string** | OAuth2 Client ID | 
**ClientSecret** | **string** | OAuth2 Client Secret (sensitive) | 
**DirectoryServiceUrl** | **string** |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

