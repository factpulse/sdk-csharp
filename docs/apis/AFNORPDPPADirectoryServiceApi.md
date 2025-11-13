# FactPulse.SDK.Api.AFNORPDPPADirectoryServiceApi

All URIs are relative to *http://localhost*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**DirectoryHealthcheckProxyApiV1AfnorDirectoryV1HealthcheckGet**](AFNORPDPPADirectoryServiceApi.md#directoryhealthcheckproxyapiv1afnordirectoryv1healthcheckget) | **GET** /api/v1/afnor/directory/v1/healthcheck | Healthcheck Directory Service |
| [**GetCompanyProxyApiV1AfnorDirectoryV1CompaniesSirenGet**](AFNORPDPPADirectoryServiceApi.md#getcompanyproxyapiv1afnordirectoryv1companiessirenget) | **GET** /api/v1/afnor/directory/v1/companies/{siren} | Récupérer une entreprise |
| [**SearchCompaniesProxyApiV1AfnorDirectoryV1CompaniesSearchPost**](AFNORPDPPADirectoryServiceApi.md#searchcompaniesproxyapiv1afnordirectoryv1companiessearchpost) | **POST** /api/v1/afnor/directory/v1/companies/search | Rechercher des entreprises |

<a id="directoryhealthcheckproxyapiv1afnordirectoryv1healthcheckget"></a>
# **DirectoryHealthcheckProxyApiV1AfnorDirectoryV1HealthcheckGet**
> Object DirectoryHealthcheckProxyApiV1AfnorDirectoryV1HealthcheckGet ()

Healthcheck Directory Service

Vérifier la disponibilité du Directory Service


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

<a id="getcompanyproxyapiv1afnordirectoryv1companiessirenget"></a>
# **GetCompanyProxyApiV1AfnorDirectoryV1CompaniesSirenGet**
> Object GetCompanyProxyApiV1AfnorDirectoryV1CompaniesSirenGet (string siren)

Récupérer une entreprise

Récupérer les informations d'une entreprise par son SIREN


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **siren** | **string** |  |  |

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
| **200** | Informations de l&#39;entreprise |  -  |
| **404** | Entreprise non trouvée |  -  |
| **401** | Non authentifié |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="searchcompaniesproxyapiv1afnordirectoryv1companiessearchpost"></a>
# **SearchCompaniesProxyApiV1AfnorDirectoryV1CompaniesSearchPost**
> Object SearchCompaniesProxyApiV1AfnorDirectoryV1CompaniesSearchPost ()

Rechercher des entreprises

Rechercher des entreprises dans l'annuaire AFNOR


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
| **401** | Non authentifié |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

