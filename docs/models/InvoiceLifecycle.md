# FactPulse.SDK.Model.InvoiceLifecycle
Cycle de vie d'une facture specifique.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**InvoiceId** | **string** | Reference de la facture (IssuerAssignedID du CDAR) | 
**TotalEvents** | **int** | Nombre total d&#39;evenements | 
**SellerId** | **string** |  | [optional] 
**Events** | [**List&lt;LifecycleEvent&gt;**](LifecycleEvent.md) | Evenements de cycle de vie tries chronologiquement | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

