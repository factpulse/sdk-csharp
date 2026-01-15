# FactPulse.SDK.Model.FactureElectroniqueRestApiSchemasChorusProChorusProCredentials
Chorus Pro credentials for Zero-Trust mode.  **Zero-Trust Mode**: Credentials are passed in each request and are NEVER stored.  **Security**: - Credentials are never persisted in the database - They are used only for the duration of the request - Secure transmission via HTTPS  **Use cases**: - High-security environments (banks, administrations) - Strict GDPR compliance - Tests with temporary credentials - Users who don't want to store their credentials

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**PisteClientId** | **string** | PISTE Client ID (government API portal) | 
**PisteClientSecret** | **string** | PISTE Client Secret | 
**ChorusProLogin** | **string** | Chorus Pro login | 
**ChorusProPassword** | **string** | Chorus Pro password | 
**Sandbox** | **bool** | Use sandbox environment (true) or production (false) | [optional] [default to true]

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

