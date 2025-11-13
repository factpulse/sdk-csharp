# FactPulse.SDK.Api.AFNORPDPPAFlowServiceApi

All URIs are relative to *http://localhost*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**DownloadFlowProxyApiV1AfnorFlowV1FlowsFlowIdGet**](AFNORPDPPAFlowServiceApi.md#downloadflowproxyapiv1afnorflowv1flowsflowidget) | **GET** /api/v1/afnor/flow/v1/flows/{flowId} | Télécharger un flux |
| [**FlowHealthcheckProxyApiV1AfnorFlowV1HealthcheckGet**](AFNORPDPPAFlowServiceApi.md#flowhealthcheckproxyapiv1afnorflowv1healthcheckget) | **GET** /api/v1/afnor/flow/v1/healthcheck | Healthcheck Flow Service |
| [**SearchFlowsProxyApiV1AfnorFlowV1FlowsSearchPost**](AFNORPDPPAFlowServiceApi.md#searchflowsproxyapiv1afnorflowv1flowssearchpost) | **POST** /api/v1/afnor/flow/v1/flows/search | Rechercher des flux |
| [**SubmitFlowProxyApiV1AfnorFlowV1FlowsPost**](AFNORPDPPAFlowServiceApi.md#submitflowproxyapiv1afnorflowv1flowspost) | **POST** /api/v1/afnor/flow/v1/flows | Soumettre un flux de facturation |

<a id="downloadflowproxyapiv1afnorflowv1flowsflowidget"></a>
# **DownloadFlowProxyApiV1AfnorFlowV1FlowsFlowIdGet**
> Object DownloadFlowProxyApiV1AfnorFlowV1FlowsFlowIdGet (string flowId)

Télécharger un flux

Télécharger le fichier PDF/A-3 d'un flux de facturation (utilise le client_uid du JWT)


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
| **200** | Fichier PDF/A-3 |  -  |
| **400** | Configuration PDP manquante |  -  |
| **401** | Non authentifié - Token JWT manquant ou invalide |  -  |
| **404** | Flux non trouvé ou client_uid invalide |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="flowhealthcheckproxyapiv1afnorflowv1healthcheckget"></a>
# **FlowHealthcheckProxyApiV1AfnorFlowV1HealthcheckGet**
> Object FlowHealthcheckProxyApiV1AfnorFlowV1HealthcheckGet ()

Healthcheck Flow Service

Vérifier la disponibilité du Flow Service


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
| **200** | Service opérationnel |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="searchflowsproxyapiv1afnorflowv1flowssearchpost"></a>
# **SearchFlowsProxyApiV1AfnorFlowV1FlowsSearchPost**
> Object SearchFlowsProxyApiV1AfnorFlowV1FlowsSearchPost ()

Rechercher des flux

Rechercher des flux de facturation selon des critères (utilise le client_uid du JWT)


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
| **200** | Résultats de recherche |  -  |
| **400** | Configuration PDP manquante |  -  |
| **401** | Non authentifié - Token JWT manquant ou invalide |  -  |
| **404** | Client PDP non trouvé (client_uid invalide) |  -  |
| **429** | Trop de requêtes - Rate limit atteint (60 recherches/minute) |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="submitflowproxyapiv1afnorflowv1flowspost"></a>
# **SubmitFlowProxyApiV1AfnorFlowV1FlowsPost**
> Object SubmitFlowProxyApiV1AfnorFlowV1FlowsPost ()

Soumettre un flux de facturation

Soumet une facture électronique à une Plateforme de Dématérialisation Partenaire (PDP) conformément à la norme AFNOR XP Z12-013


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
| **201** | Flux soumis avec succès |  -  |
| **400** | Requête invalide ou configuration PDP manquante |  -  |
| **401** | Non authentifié - Token JWT manquant ou invalide |  -  |
| **403** | Non autorisé - Quota dépassé ou permissions insuffisantes |  -  |
| **404** | Client PDP non trouvé (client_uid invalide) |  -  |
| **429** | Trop de requêtes - Rate limit atteint (30 soumissions/minute) |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

