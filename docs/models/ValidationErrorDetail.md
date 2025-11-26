# FactPulse.SDK.Model.ValidationErrorDetail
Détail d'une erreur de validation (aligné sur AFNOR AcknowledgementDetail).  Format unifié pour toutes les erreurs de validation Factur-X, compatible avec la norme AFNOR XP Z12-013.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Item** | **string** | Identifiant de l&#39;élément concerné (XPath, champ, règle BR-FR, etc.) | 
**Reason** | **string** | Description de l&#39;erreur | 
**Level** | **ErrorLevel** | Niveau de gravité : &#39;Error&#39; ou &#39;Warning&#39; | [optional] 
**Source** | **ErrorSource** |  | [optional] 
**Code** | **string** |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

