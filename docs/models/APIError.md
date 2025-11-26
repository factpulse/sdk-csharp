# FactPulse.SDK.Model.APIError
Erreur API standardisée (alignée sur AFNOR Error schema).  Format unifié pour toutes les réponses d'erreur HTTP.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ErrorCode** | **string** | Code alphanumérique identifiant précisément l&#39;erreur | 
**ErrorMessage** | **string** | Message décrivant l&#39;erreur (non destiné à l&#39;utilisateur final) | 
**Details** | [**List&lt;ValidationErrorDetail&gt;**](ValidationErrorDetail.md) |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

