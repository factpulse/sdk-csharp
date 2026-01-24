# FactPulse.SDK.Api.AFNORPDPPAApi

All URIs are relative to *https://factpulse.fr*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetFluxEntrantApiV1AfnorIncomingFlowsFlowIdGet**](AFNORPDPPAApi.md#getfluxentrantapiv1afnorincomingflowsflowidget) | **GET** /api/v1/afnor/incoming-flows/{flow_id} | Retrieve and extract an incoming invoice |
| [**OauthTokenProxyApiV1AfnorOauthTokenPost**](AFNORPDPPAApi.md#oauthtokenproxyapiv1afnoroauthtokenpost) | **POST** /api/v1/afnor/oauth/token | Test PDP OAuth2 credentials |

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

Test PDP OAuth2 credentials

OAuth2 proxy to validate PDP credentials. Use this endpoint to verify that OAuth credentials (client_id, client_secret) are valid before saving a PDP configuration. This endpoint is public (no authentication required).


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
| **200** | OAuth2 token acquired successfully - credentials are valid |  -  |
| **401** | Invalid credentials - client_id or client_secret is wrong |  -  |
| **503** | PDP OAuth server unavailable |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

