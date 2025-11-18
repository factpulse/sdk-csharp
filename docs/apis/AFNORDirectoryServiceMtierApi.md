# FactPulse.SDK.Api.AFNORDirectoryServiceMtierApi

All URIs are relative to *http://localhost*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetSirenMetierApiV1AfnorDirectorySirenSirenGet**](AFNORDirectoryServiceMtierApi.md#getsirenmetierapiv1afnordirectorysirensirenget) | **GET** /api/v1/afnor/directory/siren/{siren} | Récupérer une entreprise par SIREN (multi-tenant) |
| [**GetSiretMetierApiV1AfnorDirectorySiretSiretGet**](AFNORDirectoryServiceMtierApi.md#getsiretmetierapiv1afnordirectorysiretsiretget) | **GET** /api/v1/afnor/directory/siret/{siret} | Récupérer un établissement par SIRET (multi-tenant) |
| [**SearchSirenMetierApiV1AfnorDirectorySirenSearchPost**](AFNORDirectoryServiceMtierApi.md#searchsirenmetierapiv1afnordirectorysirensearchpost) | **POST** /api/v1/afnor/directory/siren/search | Rechercher des entreprises (multi-tenant) |
| [**SearchSiretMetierApiV1AfnorDirectorySiretSearchPost**](AFNORDirectoryServiceMtierApi.md#searchsiretmetierapiv1afnordirectorysiretsearchpost) | **POST** /api/v1/afnor/directory/siret/search | Rechercher des établissements (multi-tenant) |

<a id="getsirenmetierapiv1afnordirectorysirensirenget"></a>
# **GetSirenMetierApiV1AfnorDirectorySirenSirenGet**
> Object GetSirenMetierApiV1AfnorDirectorySirenSirenGet (string siren, PDPCredentials pDPCredentials = null)

Récupérer une entreprise par SIREN (multi-tenant)

Récupère les informations d'une entreprise dans le Directory Service AFNOR. Les credentials PDP sont récupérés automatiquement via le client_uid du JWT, ou peuvent être fournis directement dans le body (zero-storage).


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **siren** | **string** |  |  |
| **pDPCredentials** | [**PDPCredentials**](PDPCredentials.md) |  | [optional]  |

### Return type

**Object**

### Authorization

[HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Entreprise trouvée |  -  |
| **404** | Entreprise non trouvée |  -  |
| **400** | Aucune config PDP fournie |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getsiretmetierapiv1afnordirectorysiretsiretget"></a>
# **GetSiretMetierApiV1AfnorDirectorySiretSiretGet**
> Object GetSiretMetierApiV1AfnorDirectorySiretSiretGet (string siret, PDPCredentials pDPCredentials = null)

Récupérer un établissement par SIRET (multi-tenant)

Récupère les informations d'un établissement dans le Directory Service AFNOR. Les credentials PDP sont récupérés automatiquement via le client_uid du JWT, ou peuvent être fournis directement dans le body (zero-storage).


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **siret** | **string** |  |  |
| **pDPCredentials** | [**PDPCredentials**](PDPCredentials.md) |  | [optional]  |

### Return type

**Object**

### Authorization

[HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Établissement trouvé |  -  |
| **404** | Établissement non trouvé |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="searchsirenmetierapiv1afnordirectorysirensearchpost"></a>
# **SearchSirenMetierApiV1AfnorDirectorySirenSearchPost**
> Object SearchSirenMetierApiV1AfnorDirectorySirenSearchPost (BodySearchSirenMetierApiV1AfnorDirectorySirenSearchPost bodySearchSirenMetierApiV1AfnorDirectorySirenSearchPost)

Rechercher des entreprises (multi-tenant)

Recherche multi-critères d'entreprises dans le Directory Service AFNOR. Les credentials PDP sont récupérés automatiquement via le client_uid du JWT, ou peuvent être fournis directement dans le body (zero-storage).


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **bodySearchSirenMetierApiV1AfnorDirectorySirenSearchPost** | [**BodySearchSirenMetierApiV1AfnorDirectorySirenSearchPost**](BodySearchSirenMetierApiV1AfnorDirectorySirenSearchPost.md) |  |  |

### Return type

**Object**

### Authorization

[HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Résultats de recherche |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="searchsiretmetierapiv1afnordirectorysiretsearchpost"></a>
# **SearchSiretMetierApiV1AfnorDirectorySiretSearchPost**
> Object SearchSiretMetierApiV1AfnorDirectorySiretSearchPost (BodySearchSiretMetierApiV1AfnorDirectorySiretSearchPost bodySearchSiretMetierApiV1AfnorDirectorySiretSearchPost)

Rechercher des établissements (multi-tenant)

Recherche multi-critères d'établissements dans le Directory Service AFNOR. Les credentials PDP sont récupérés automatiquement via le client_uid du JWT, ou peuvent être fournis directement dans le body (zero-storage).


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **bodySearchSiretMetierApiV1AfnorDirectorySiretSearchPost** | [**BodySearchSiretMetierApiV1AfnorDirectorySiretSearchPost**](BodySearchSiretMetierApiV1AfnorDirectorySiretSearchPost.md) |  |  |

### Return type

**Object**

### Authorization

[HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Résultats de recherche |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

