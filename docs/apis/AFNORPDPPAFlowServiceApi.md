# FactPulse.SDK.Api.AFNORPDPPAFlowServiceApi

All URIs are relative to *https://factpulse.fr*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**DownloadFlowProxyApiV1AfnorFlowV1FlowsFlowIdGet**](AFNORPDPPAFlowServiceApi.md#downloadflowproxyapiv1afnorflowv1flowsflowidget) | **GET** /api/v1/afnor/flow/v1/flows/{flowId} | Download a flow |
| [**FlowHealthcheckProxyApiV1AfnorFlowV1HealthcheckGet**](AFNORPDPPAFlowServiceApi.md#flowhealthcheckproxyapiv1afnorflowv1healthcheckget) | **GET** /api/v1/afnor/flow/v1/healthcheck | Healthcheck Flow Service |
| [**SearchFlowsProxyApiV1AfnorFlowV1FlowsSearchPost**](AFNORPDPPAFlowServiceApi.md#searchflowsproxyapiv1afnorflowv1flowssearchpost) | **POST** /api/v1/afnor/flow/v1/flows/search | Search flows |
| [**SubmitFlowProxyApiV1AfnorFlowV1FlowsPost**](AFNORPDPPAFlowServiceApi.md#submitflowproxyapiv1afnorflowv1flowspost) | **POST** /api/v1/afnor/flow/v1/flows | Submit an invoicing flow |

<a id="downloadflowproxyapiv1afnorflowv1flowsflowidget"></a>
# **DownloadFlowProxyApiV1AfnorFlowV1FlowsFlowIdGet**
> AFNORFlow DownloadFlowProxyApiV1AfnorFlowV1FlowsFlowIdGet (string flowId, DocType docType = null)

Download a flow

Download a file related to a given flow (AFNOR XP Z12-013 compliant): - Metadata [Default]: provides the flow metadata as JSON - Original: the document initially sent by the emitter - Converted: the document optionally converted by the system - ReadableView: the document optionally generated as readable file


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **flowId** | **string** | AFNOR flow identifier (UUID) |  |
| **docType** | **DocType** | Type of file to download: Metadata (default, JSON), Original, Converted, or ReadableView | [optional]  |

### Return type

[**AFNORFlow**](AFNORFlow.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/pdf, application/xml


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK - Flow file or metadata returned |  -  |
| **400** | Bad request - Invalid input parameters |  -  |
| **401** | Authentication error - Missing or invalid token |  -  |
| **403** | Forbidden - Insufficient permissions |  -  |
| **404** | Resource not found |  -  |
| **429** | Too many requests - Rate limit exceeded |  -  |
| **500** | Internal server error |  -  |
| **503** | Service unavailable - PDP temporarily unavailable |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="flowhealthcheckproxyapiv1afnorflowv1healthcheckget"></a>
# **FlowHealthcheckProxyApiV1AfnorFlowV1HealthcheckGet**
> Object FlowHealthcheckProxyApiV1AfnorFlowV1HealthcheckGet ()

Healthcheck Flow Service

Check Flow Service availability (AFNOR XP Z12-013 compliant)


### Parameters
This endpoint does not need any parameter.
### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK - Service is operational |  -  |
| **500** | Internal server error |  -  |
| **503** | Service unavailable - PDP temporarily unavailable |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="searchflowsproxyapiv1afnorflowv1flowssearchpost"></a>
# **SearchFlowsProxyApiV1AfnorFlowV1FlowsSearchPost**
> AFNORSearchFlowContent SearchFlowsProxyApiV1AfnorFlowV1FlowsSearchPost (AFNORSearchFlowParams aFNORSearchFlowParams)

Search flows

Search invoicing flows by criteria (AFNOR XP Z12-013 compliant)


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **aFNORSearchFlowParams** | [**AFNORSearchFlowParams**](AFNORSearchFlowParams.md) |  |  |

### Return type

[**AFNORSearchFlowContent**](AFNORSearchFlowContent.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK - Search results returned |  -  |
| **400** | Bad request - Invalid input parameters |  -  |
| **401** | Authentication error - Missing or invalid token |  -  |
| **403** | Forbidden - Insufficient permissions |  -  |
| **429** | Too many requests - Rate limit exceeded |  -  |
| **500** | Internal server error |  -  |
| **503** | Service unavailable - PDP temporarily unavailable |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="submitflowproxyapiv1afnorflowv1flowspost"></a>
# **SubmitFlowProxyApiV1AfnorFlowV1FlowsPost**
> Object SubmitFlowProxyApiV1AfnorFlowV1FlowsPost (AFNORFlowInfo flowInfo, System.IO.Stream file)

Submit an invoicing flow

Submits an electronic invoice to a Partner Dematerialization Platform (PDP) in compliance with the AFNOR XP Z12-013 standard


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **flowInfo** | [**AFNORFlowInfo**](AFNORFlowInfo.md) |  |  |
| **file** | **System.IO.Stream****System.IO.Stream** | Flow file (PDF/A-3 with embedded XML or XML) |  |

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **202** | OK - Flow has been uploaded and accepted for processing |  -  |
| **400** | Bad request - Invalid input parameters |  -  |
| **401** | Authentication error - Missing or invalid token |  -  |
| **403** | Forbidden - Insufficient permissions |  -  |
| **404** | Resource not found |  -  |
| **413** | Payload too large - File exceeds maximum size |  -  |
| **422** | Unprocessable entity - Business rule validation failed |  -  |
| **429** | Too many requests - Rate limit exceeded |  -  |
| **500** | Internal server error |  -  |
| **503** | Service unavailable - PDP temporarily unavailable |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

