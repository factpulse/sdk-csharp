# FactPulse.SDK.Api.AFNORPDPPAApi

All URIs are relative to *https://factpulse.fr*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetAfnorCredentialsApiV1AfnorCredentialsGet**](AFNORPDPPAApi.md#getafnorcredentialsapiv1afnorcredentialsget) | **GET** /api/v1/afnor/credentials | Retrieve stored AFNOR credentials |
| [**GetFluxEntrantApiV1AfnorIncomingFlowsFlowIdGet**](AFNORPDPPAApi.md#getfluxentrantapiv1afnorincomingflowsflowidget) | **GET** /api/v1/afnor/incoming-flows/{flow_id} | Retrieve and extract an incoming invoice |
| [**OauthTokenProxyApiV1AfnorOauthTokenPost**](AFNORPDPPAApi.md#oauthtokenproxyapiv1afnoroauthtokenpost) | **POST** /api/v1/afnor/oauth/token | OAuth2 endpoint for AFNOR authentication |

<a id="getafnorcredentialsapiv1afnorcredentialsget"></a>
# **GetAfnorCredentialsApiV1AfnorCredentialsGet**
> Object GetAfnorCredentialsApiV1AfnorCredentialsGet ()

Retrieve stored AFNOR credentials

Retrieves stored AFNOR/PDP credentials for the JWT's client_uid. This endpoint is used by the SDK in 'stored' mode to retrieve credentials before performing AFNOR OAuth itself.


### Parameters
This endpoint does not need any parameter.
### Return type

**Object**

### Authorization

[HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | AFNOR credentials retrieved successfully |  -  |
| **400** | No client_uid in JWT |  -  |
| **401** | Not authenticated - Missing or invalid JWT token |  -  |
| **404** | Client not found or no AFNOR credentials configured |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getfluxentrantapiv1afnorincomingflowsflowidget"></a>
# **GetFluxEntrantApiV1AfnorIncomingFlowsFlowIdGet**
> IncomingInvoice GetFluxEntrantApiV1AfnorIncomingFlowsFlowIdGet (string flowId, bool includeDocument = null)

Retrieve and extract an incoming invoice

Downloads an incoming flow from the AFNOR PDP and extracts invoice metadata into a unified JSON format. Supports Factur-X, CII, and UBL formats.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **flowId** | **string** | AFNOR flow ID (UUID format) |  |
| **includeDocument** | **bool** | Include base64-encoded document in response | [optional] [default to false] |

### Return type

[**IncomingInvoice**](IncomingInvoice.md)

### Authorization

[HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Invoice extracted successfully |  -  |
| **400** | Unsupported or invalid invoice format |  -  |
| **401** | Not authenticated |  -  |
| **404** | Flow not found |  -  |
| **503** | PDP service unavailable |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="oauthtokenproxyapiv1afnoroauthtokenpost"></a>
# **OauthTokenProxyApiV1AfnorOauthTokenPost**
> Object OauthTokenProxyApiV1AfnorOauthTokenPost ()

OAuth2 endpoint for AFNOR authentication

OAuth2 proxy endpoint to obtain an AFNOR access token. Proxies to AFNOR mock (sandbox) or real PDP depending on MOCK_AFNOR_BASE_URL. This endpoint is public (no Django auth required) as it is called by the AFNOR SDK.


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
| **200** | OAuth2 token acquired successfully |  -  |
| **401** | Invalid credentials |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

