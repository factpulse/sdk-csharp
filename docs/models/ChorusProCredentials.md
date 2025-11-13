# FactPulse.SDK.Model.ChorusProCredentials
Credentials Chorus Pro pour mode Zero-Trust.  **Mode Zero-Trust** : Les credentials sont passés dans chaque requête et ne sont JAMAIS stockés.  **Sécurité** : - Les credentials ne sont jamais persistés dans la base de données - Ils sont utilisés uniquement pour la durée de la requête - Transmission sécurisée via HTTPS  **Cas d'usage** : - Environnements à haute sécurité (banques, administrations) - Conformité RGPD stricte - Tests avec credentials temporaires - Utilisateurs ne voulant pas stocker leurs credentials

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**PisteClientId** | **string** | Client ID PISTE (portail API gouvernement) | 
**PisteClientSecret** | **string** | Client Secret PISTE | 
**ChorusProLogin** | **string** | Login Chorus Pro | 
**ChorusProPassword** | **string** | Mot de passe Chorus Pro | 
**Sandbox** | **bool** | Utiliser l&#39;environnement sandbox (true) ou production (false) | [optional] [default to true]

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

