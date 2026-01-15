# FactPulse.SDK.Model.CeleryStatus
Possible states of a Celery task during polling.  **Possible values:** - `PENDING`: Task waiting for processing - `STARTED`: Task currently executing - `SUCCESS`: Task completed successfully (check `result.status` for business result) - `FAILURE`: System error during execution (crash, unhandled exception) - `RETRY`: Retry attempt in progress (after temporary failure)

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

