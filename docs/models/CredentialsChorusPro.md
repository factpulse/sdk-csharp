# FactPulse.SDK.Model.CredentialsChorusPro
Credentials Chorus Pro optionnels.  **MODE 1 - Récupération via JWT (recommandé) :** Ne pas fournir ce champ `credentials` dans le payload. Les credentials seront récupérés automatiquement via client_uid du JWT (0-trust).  **MODE 2 - Credentials dans le payload :** Fournir tous les champs requis ci-dessous. Utile pour tests ou intégrations tierces.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**PisteClientId** | **string** |  | [optional] 
**PisteClientSecret** | **string** |  | [optional] 
**ChorusLogin** | **string** |  | [optional] 
**ChorusPassword** | **string** |  | [optional] 
**ModeSandbox** | **bool** | [MODE 2] Utiliser le mode sandbox (défaut: True) | [optional] [default to true]

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

