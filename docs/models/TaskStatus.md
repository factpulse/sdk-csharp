# FactPulse.SDK.Model.TaskStatus
Complete description of an async task status.  The `status` field indicates the Celery state of the task. When `status=\"SUCCESS\"`, check `result.status` for the business result (\"SUCCESS\" or \"ERROR\").

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**TaskId** | **string** | Unique task identifier | 
**Status** | **CeleryStatus** | Celery task status (PENDING, STARTED, SUCCESS, FAILURE, RETRY) | 
**Result** | **Dictionary&lt;string, Object&gt;** |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

