# FactPulse.SDK.Api.AFNORPDPPAApi

All URIs are relative to *http://localhost*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetAfnorCredentialsApiV1AfnorCredentialsGet**](AFNORPDPPAApi.md#getafnorcredentialsapiv1afnorcredentialsget) | **GET** /api/v1/afnor/credentials | Récupérer les credentials AFNOR stockés |
| [**GetFluxEntrantApiV1AfnorFluxEntrantsFlowIdGet**](AFNORPDPPAApi.md#getfluxentrantapiv1afnorfluxentrantsflowidget) | **GET** /api/v1/afnor/flux-entrants/{flow_id} | Récupérer et extraire une facture entrante |
| [**OauthTokenProxyApiV1AfnorOauthTokenPost**](AFNORPDPPAApi.md#oauthtokenproxyapiv1afnoroauthtokenpost) | **POST** /api/v1/afnor/oauth/token | Endpoint OAuth2 pour authentification AFNOR |

<a id="getafnorcredentialsapiv1afnorcredentialsget"></a>
# **GetAfnorCredentialsApiV1AfnorCredentialsGet**
> Object GetAfnorCredentialsApiV1AfnorCredentialsGet ()

Récupérer les credentials AFNOR stockés

Récupère les credentials AFNOR/PDP stockés pour le client_uid du JWT. Cet endpoint est utilisé par le SDK en mode 'stored' pour récupérer les credentials avant de faire l'OAuth AFNOR lui-même.


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
| **200** | Credentials AFNOR récupérés avec succès |  -  |
| **400** | Aucun client_uid dans le JWT |  -  |
| **401** | Non authentifié - Token JWT manquant ou invalide |  -  |
| **404** | Client non trouvé ou pas de credentials AFNOR configurés |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getfluxentrantapiv1afnorfluxentrantsflowidget"></a>
# **GetFluxEntrantApiV1AfnorFluxEntrantsFlowIdGet**
> FactureEntrante GetFluxEntrantApiV1AfnorFluxEntrantsFlowIdGet (string flowId)

Récupérer et extraire une facture entrante

Télécharge un flux entrant depuis la PDP AFNOR et extrait les métadonnées de la facture vers un format JSON unifié. Supporte les formats Factur-X, CII et UBL.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **flowId** | **string** |  |  |

### Return type

[**FactureEntrante**](FactureEntrante.md)

### Authorization

[HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Facture extraite avec succès |  -  |
| **400** | Format de facture non supporté ou invalide |  -  |
| **401** | Non authentifié |  -  |
| **404** | Flux non trouvé |  -  |
| **503** | Service PDP indisponible |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

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

