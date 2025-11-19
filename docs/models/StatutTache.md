# FactPulse.SDK.Model.StatutTache
Description complète du statut d'une tâche asynchrone.  Le champ `statut` indique l'état Celery de la tâche. Quand `statut=\"SUCCESS\"`, consultez `resultat.statut` pour le résultat métier (\"SUCCES\" ou \"ERREUR\").

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**IdTache** | **string** |  | 
**Statut** | **StatutCelery** | Statut Celery de la tâche (PENDING, STARTED, SUCCESS, FAILURE, RETRY) | 
**Resultat** | **Dictionary&lt;string, Object&gt;** |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

