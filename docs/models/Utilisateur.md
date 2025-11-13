# FactPulse.SDK.Model.Utilisateur
Modèle Pydantic représentant les données de l'utilisateur authentifié.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **int** |  | 
**Username** | **string** |  | 
**Email** | **string** |  | 
**IsActive** | **bool** |  | 
**IsSuperuser** | **bool** |  | [optional] [default to false]
**IsStaff** | **bool** |  | [optional] [default to false]
**BypassQuota** | **bool** |  | [optional] [default to false]
**TeamId** | **int** |  | [optional] 
**HasQuota** | **bool** |  | [optional] [default to true]
**QuotaInfo** | [**QuotaInfo**](QuotaInfo.md) |  | [optional] 
**IsTrial** | **bool** |  | [optional] [default to false]
**ClientUid** | **string** |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

