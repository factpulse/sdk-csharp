# FactPulse.SDK.Api.AFNORPDPPAFlowServiceApi

All URIs are relative to *http://localhost*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**DownloadFlowProxyApiV1AfnorFlowV1FlowsFlowIdGet**](AFNORPDPPAFlowServiceApi.md#downloadflowproxyapiv1afnorflowv1flowsflowidget) | **GET** /api/v1/afnor/flow/v1/flows/{flowId} | Download a flow |
| [**FlowHealthcheckProxyApiV1AfnorFlowV1HealthcheckGet**](AFNORPDPPAFlowServiceApi.md#flowhealthcheckproxyapiv1afnorflowv1healthcheckget) | **GET** /api/v1/afnor/flow/v1/healthcheck | Healthcheck Flow Service |
| [**SearchFlowsProxyApiV1AfnorFlowV1FlowsSearchPost**](AFNORPDPPAFlowServiceApi.md#searchflowsproxyapiv1afnorflowv1flowssearchpost) | **POST** /api/v1/afnor/flow/v1/flows/search | Search flows |
| [**SubmitFlowProxyApiV1AfnorFlowV1FlowsPost**](AFNORPDPPAFlowServiceApi.md#submitflowproxyapiv1afnorflowv1flowspost) | **POST** /api/v1/afnor/flow/v1/flows | Submit an invoicing flow |

<a id="downloadflowproxyapiv1afnorflowv1flowsflowidget"></a>
# **DownloadFlowProxyApiV1AfnorFlowV1FlowsFlowIdGet**
> Object DownloadFlowProxyApiV1AfnorFlowV1FlowsFlowIdGet (string flowId)

Download a flow

Download the PDF/A-3 file of an invoicing flow (uses JWT client_uid)


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **flowId** | **string** |  |  |

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/pdf


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | PDF/A-3 file |  -  |
| **400** | Missing PDP configuration |  -  |
| **401** | Not authenticated - Missing or invalid JWT token |  -  |
| **404** | Flow not found or invalid client_uid |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="flowhealthcheckproxyapiv1afnorflowv1healthcheckget"></a>
# **FlowHealthcheckProxyApiV1AfnorFlowV1HealthcheckGet**
> Object FlowHealthcheckProxyApiV1AfnorFlowV1HealthcheckGet ()

Healthcheck Flow Service

Check Flow Service availability


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
| **200** | Service operational |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="searchflowsproxyapiv1afnorflowv1flowssearchpost"></a>
# **SearchFlowsProxyApiV1AfnorFlowV1FlowsSearchPost**
> Object SearchFlowsProxyApiV1AfnorFlowV1FlowsSearchPost ()

Search flows

Search invoicing flows by criteria (uses JWT client_uid)


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
| **200** | Search results |  -  |
| **400** | Missing PDP configuration |  -  |
| **401** | Not authenticated - Missing or invalid JWT token |  -  |
| **404** | PDP client not found (invalid client_uid) |  -  |
| **429** | Too many requests - Rate limit reached (60 searches/minute) |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="submitflowproxyapiv1afnorflowv1flowspost"></a>
# **SubmitFlowProxyApiV1AfnorFlowV1FlowsPost**
> Object SubmitFlowProxyApiV1AfnorFlowV1FlowsPost ()

Submit an invoicing flow

Submits an electronic invoice to a Partner Dematerialization Platform (PDP) in compliance with the AFNOR XP Z12-013 standard


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
| **200** | Successful Response |  -  |
| **201** | Flow submitted successfully |  -  |
| **400** | Invalid request or missing PDP configuration |  -  |
| **401** | Not authenticated - Missing or invalid JWT token |  -  |
| **403** | Not authorized - Quota exceeded or insufficient permissions |  -  |
| **404** | PDP client not found (invalid client_uid) |  -  |
| **429** | Too many requests - Rate limit reached (30 submissions/minute) |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

