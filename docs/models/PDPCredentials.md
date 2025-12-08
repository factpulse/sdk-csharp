# FactPulse.SDK.Model.PDPCredentials
Credentials PDP pour la stratégie zero-storage (Strategy B).  Permet de fournir directement les credentials PDP dans la requête au lieu de les stocker dans Django.  Utile pour : - Tests ponctuels sans persister les credentials - Intégrations temporaires - Environnements de développement

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**FlowServiceUrl** | **string** | URL de base du Flow Service AFNOR | 
**TokenUrl** | **string** | URL du serveur OAuth2 | 
**ClientId** | **string** | Client ID OAuth2 | 
**ClientSecret** | **string** | Client Secret OAuth2 (sensible) | 
**DirectoryServiceUrl** | **string** |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

