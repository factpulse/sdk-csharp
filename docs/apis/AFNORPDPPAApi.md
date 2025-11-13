# FactPulse.SDK.Api.AFNORPDPPAApi

All URIs are relative to *http://localhost*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**OauthTokenProxyApiV1AfnorOauthTokenPost**](AFNORPDPPAApi.md#oauthtokenproxyapiv1afnoroauthtokenpost) | **POST** /api/v1/afnor/oauth/token | Endpoint OAuth2 pour authentification AFNOR |

<a id="oauthtokenproxyapiv1afnoroauthtokenpost"></a>
# **OauthTokenProxyApiV1AfnorOauthTokenPost**
> Object OauthTokenProxyApiV1AfnorOauthTokenPost ()

Endpoint OAuth2 pour authentification AFNOR

Endpoint proxy OAuth2 pour obtenir un token d'accès AFNOR. Fait proxy vers le mock AFNOR (sandbox) ou la vraie PDP selon MOCK_AFNOR_BASE_URL. Cet endpoint est public (pas d'auth Django requise) car il est appelé par le SDK AFNOR.


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
| **200** | Token OAuth2 acquis avec succès |  -  |
| **401** | Credentials invalides |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

