# FactPulse.SDK.Api.AsyncTasksApi

All URIs are relative to *https://factpulse.fr*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetTaskStatusApiV1ProcessingTasksTaskIdStatusGet**](AsyncTasksApi.md#gettaskstatusapiv1processingtaskstaskidstatusget) | **GET** /api/v1/processing/tasks/{task_id}/status | Get task generation status |

<a id="gettaskstatusapiv1processingtaskstaskidstatusget"></a>
# **GetTaskStatusApiV1ProcessingTasksTaskIdStatusGet**
> AsyncTaskStatus GetTaskStatusApiV1ProcessingTasksTaskIdStatusGet (string taskId)

Get task generation status

Retrieves the progress status of an invoice generation task.  ## Possible states  The `status` field uses the `CeleryStatus` enum with values: - **PENDING, STARTED, SUCCESS, FAILURE, RETRY**  See the `CeleryStatus` schema documentation for details.  ## Business result  When `status=\"SUCCESS\"`, the `result` field contains: - `status`: \"SUCCESS\" or \"ERROR\" (business result) - `content_b64`: Base64 encoded content (if success) - `errorCode`, `errorMessage`, `details`: AFNOR format (if business error)  ## Usage  Poll this endpoint every 2-3 seconds until `status` is `SUCCESS` or `FAILURE`.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **taskId** | **string** | Celery task ID returned by async endpoints (UUID format) |  |

### Return type

[**AsyncTaskStatus**](AsyncTaskStatus.md)

### Authorization

[APIKeyHeader](../README.md#APIKeyHeader), [HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Current task state |  -  |
| **422** | Validation Error |  -  |
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

