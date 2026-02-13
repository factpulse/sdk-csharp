# FactPulse.SDK.Api.AsyncTasksApi

All URIs are relative to *https://factpulse.fr*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetGenerationTaskStatusApiV1ProcessingTasksTaskIdGenerationStatusGet**](AsyncTasksApi.md#getgenerationtaskstatusapiv1processingtaskstaskidgenerationstatusget) | **GET** /api/v1/processing/tasks/{task_id}/generation-status | Get typed generation task status |
| [**GetSignatureTaskStatusApiV1ProcessingTasksTaskIdSignatureStatusGet**](AsyncTasksApi.md#getsignaturetaskstatusapiv1processingtaskstaskidsignaturestatusget) | **GET** /api/v1/processing/tasks/{task_id}/signature-status | Get typed signature task status |
| [**GetTaskStatusApiV1ProcessingTasksTaskIdStatusGet**](AsyncTasksApi.md#gettaskstatusapiv1processingtaskstaskidstatusget) | **GET** /api/v1/processing/tasks/{task_id}/status | Get task generation status |
| [**GetValidationTaskStatusApiV1ProcessingTasksTaskIdValidationStatusGet**](AsyncTasksApi.md#getvalidationtaskstatusapiv1processingtaskstaskidvalidationstatusget) | **GET** /api/v1/processing/tasks/{task_id}/validation-status | Get typed validation task status |

<a id="getgenerationtaskstatusapiv1processingtaskstaskidgenerationstatusget"></a>
# **GetGenerationTaskStatusApiV1ProcessingTasksTaskIdGenerationStatusGet**
> GenerationTaskStatus GetGenerationTaskStatusApiV1ProcessingTasksTaskIdGenerationStatusGet (string taskId)

Get typed generation task status

Typed status endpoint for invoice generation tasks.  Returns a strongly-typed `result` (discriminated on `result.status`): - **SUCCESS**: `GenerationSuccessResult` with `content_b64` / `xml_content` - **ERROR**: `TaskErrorResult` in AFNOR format


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **taskId** | **string** | Celery task ID returned by /generate-invoice |  |

### Return type

[**GenerationTaskStatus**](GenerationTaskStatus.md)

### Authorization

[APIKeyHeader](../README.md#APIKeyHeader), [HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **422** | Validation Error |  -  |
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getsignaturetaskstatusapiv1processingtaskstaskidsignaturestatusget"></a>
# **GetSignatureTaskStatusApiV1ProcessingTasksTaskIdSignatureStatusGet**
> SignatureTaskStatus GetSignatureTaskStatusApiV1ProcessingTasksTaskIdSignatureStatusGet (string taskId)

Get typed signature task status

Typed status endpoint for PDF signing tasks.  Returns a strongly-typed `result` (discriminated on `result.status`): - **SUCCESS**: `SignatureSuccessResult` with `content_b64`, `signer_cn`, etc. - **ERROR**: `TaskErrorResult` in AFNOR format


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **taskId** | **string** | Celery task ID returned by /sign-pdf-async |  |

### Return type

[**SignatureTaskStatus**](SignatureTaskStatus.md)

### Authorization

[APIKeyHeader](../README.md#APIKeyHeader), [HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **422** | Validation Error |  -  |
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

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

<a id="getvalidationtaskstatusapiv1processingtaskstaskidvalidationstatusget"></a>
# **GetValidationTaskStatusApiV1ProcessingTasksTaskIdValidationStatusGet**
> ValidationTaskStatus GetValidationTaskStatusApiV1ProcessingTasksTaskIdValidationStatusGet (string taskId)

Get typed validation task status

Typed status endpoint for Factur-X PDF validation tasks.  Returns a strongly-typed `result` (discriminated on `result.status`): - **SUCCESS**: `ValidationSuccessTaskResult` with `validation_result` - **ERROR**: `TaskErrorResult` in AFNOR format


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **taskId** | **string** | Celery task ID returned by /validate-pdf |  |

### Return type

[**ValidationTaskStatus**](ValidationTaskStatus.md)

### Authorization

[APIKeyHeader](../README.md#APIKeyHeader), [HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **422** | Validation Error |  -  |
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

