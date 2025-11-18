# FactPulse.SDK.Api.AFNORPDPPADirectoryServiceApi

All URIs are relative to *http://localhost*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CreateDirectoryLineProxyApiV1AfnorDirectoryV1DirectoryLinePost**](AFNORPDPPADirectoryServiceApi.md#createdirectorylineproxyapiv1afnordirectoryv1directorylinepost) | **POST** /api/v1/afnor/directory/v1/directory-line | Creating a directory line |
| [**CreateRoutingCodeProxyApiV1AfnorDirectoryV1RoutingCodePost**](AFNORPDPPADirectoryServiceApi.md#createroutingcodeproxyapiv1afnordirectoryv1routingcodepost) | **POST** /api/v1/afnor/directory/v1/routing-code | Create a routing code |
| [**DeleteDirectoryLineProxyApiV1AfnorDirectoryV1DirectoryLineIdInstanceIdInstanceDelete**](AFNORPDPPADirectoryServiceApi.md#deletedirectorylineproxyapiv1afnordirectoryv1directorylineidinstanceidinstancedelete) | **DELETE** /api/v1/afnor/directory/v1/directory-line/id-instance:{id_instance} | Delete a directory line |
| [**DirectoryHealthcheckProxyApiV1AfnorDirectoryV1HealthcheckGet**](AFNORPDPPADirectoryServiceApi.md#directoryhealthcheckproxyapiv1afnordirectoryv1healthcheckget) | **GET** /api/v1/afnor/directory/v1/healthcheck | Healthcheck Directory Service |
| [**GetDirectoryLineByCodeProxyApiV1AfnorDirectoryV1DirectoryLineCodeAddressingIdentifierGet**](AFNORPDPPADirectoryServiceApi.md#getdirectorylinebycodeproxyapiv1afnordirectoryv1directorylinecodeaddressingidentifierget) | **GET** /api/v1/afnor/directory/v1/directory-line/code:{addressing_identifier} | Get a directory line |
| [**GetDirectoryLineByIdInstanceProxyApiV1AfnorDirectoryV1DirectoryLineIdInstanceIdInstanceGet**](AFNORPDPPADirectoryServiceApi.md#getdirectorylinebyidinstanceproxyapiv1afnordirectoryv1directorylineidinstanceidinstanceget) | **GET** /api/v1/afnor/directory/v1/directory-line/id-instance:{id_instance} | Get a directory line |
| [**GetRoutingCodeByIdInstanceProxyApiV1AfnorDirectoryV1RoutingCodeIdInstanceIdInstanceGet**](AFNORPDPPADirectoryServiceApi.md#getroutingcodebyidinstanceproxyapiv1afnordirectoryv1routingcodeidinstanceidinstanceget) | **GET** /api/v1/afnor/directory/v1/routing-code/id-instance:{id_instance} | Get a routing code by instance-id |
| [**GetRoutingCodeBySiretAndCodeProxyApiV1AfnorDirectoryV1RoutingCodeSiretSiretCodeRoutingIdentifierGet**](AFNORPDPPADirectoryServiceApi.md#getroutingcodebysiretandcodeproxyapiv1afnordirectoryv1routingcodesiretsiretcoderoutingidentifierget) | **GET** /api/v1/afnor/directory/v1/routing-code/siret:{siret}/code:{routing_identifier} | Get a routing code by SIRET and routing identifier |
| [**GetSirenByCodeInseeProxyApiV1AfnorDirectoryV1SirenCodeInseeSirenGet**](AFNORPDPPADirectoryServiceApi.md#getsirenbycodeinseeproxyapiv1afnordirectoryv1sirencodeinseesirenget) | **GET** /api/v1/afnor/directory/v1/siren/code-insee:{siren} | Consult a siren (legal unit) by SIREN number |
| [**GetSirenByIdInstanceProxyApiV1AfnorDirectoryV1SirenIdInstanceIdInstanceGet**](AFNORPDPPADirectoryServiceApi.md#getsirenbyidinstanceproxyapiv1afnordirectoryv1sirenidinstanceidinstanceget) | **GET** /api/v1/afnor/directory/v1/siren/id-instance:{id_instance} | Gets a siren (legal unit) by instance ID |
| [**GetSiretByCodeInseeProxyApiV1AfnorDirectoryV1SiretCodeInseeSiretGet**](AFNORPDPPADirectoryServiceApi.md#getsiretbycodeinseeproxyapiv1afnordirectoryv1siretcodeinseesiretget) | **GET** /api/v1/afnor/directory/v1/siret/code-insee:{siret} | Gets a siret (facility) by SIRET number |
| [**GetSiretByIdInstanceProxyApiV1AfnorDirectoryV1SiretIdInstanceIdInstanceGet**](AFNORPDPPADirectoryServiceApi.md#getsiretbyidinstanceproxyapiv1afnordirectoryv1siretidinstanceidinstanceget) | **GET** /api/v1/afnor/directory/v1/siret/id-instance:{id_instance} | Gets a siret (facility) by id-instance |
| [**PatchDirectoryLineProxyApiV1AfnorDirectoryV1DirectoryLineIdInstanceIdInstancePatch**](AFNORPDPPADirectoryServiceApi.md#patchdirectorylineproxyapiv1afnordirectoryv1directorylineidinstanceidinstancepatch) | **PATCH** /api/v1/afnor/directory/v1/directory-line/id-instance:{id_instance} | Partially updates a directory line |
| [**PatchRoutingCodeProxyApiV1AfnorDirectoryV1RoutingCodeIdInstanceIdInstancePatch**](AFNORPDPPADirectoryServiceApi.md#patchroutingcodeproxyapiv1afnordirectoryv1routingcodeidinstanceidinstancepatch) | **PATCH** /api/v1/afnor/directory/v1/routing-code/id-instance:{id_instance} | Partially update a private routing code |
| [**PutRoutingCodeProxyApiV1AfnorDirectoryV1RoutingCodeIdInstanceIdInstancePut**](AFNORPDPPADirectoryServiceApi.md#putroutingcodeproxyapiv1afnordirectoryv1routingcodeidinstanceidinstanceput) | **PUT** /api/v1/afnor/directory/v1/routing-code/id-instance:{id_instance} | Completely update a private routing code |
| [**SearchDirectoryLineProxyApiV1AfnorDirectoryV1DirectoryLineSearchPost**](AFNORPDPPADirectoryServiceApi.md#searchdirectorylineproxyapiv1afnordirectoryv1directorylinesearchpost) | **POST** /api/v1/afnor/directory/v1/directory-line/search | Search for a directory line |
| [**SearchRoutingCodeProxyApiV1AfnorDirectoryV1RoutingCodeSearchPost**](AFNORPDPPADirectoryServiceApi.md#searchroutingcodeproxyapiv1afnordirectoryv1routingcodesearchpost) | **POST** /api/v1/afnor/directory/v1/routing-code/search | Search for a routing code |
| [**SearchSirenProxyApiV1AfnorDirectoryV1SirenSearchPost**](AFNORPDPPADirectoryServiceApi.md#searchsirenproxyapiv1afnordirectoryv1sirensearchpost) | **POST** /api/v1/afnor/directory/v1/siren/search | SIREN search (or legal unit) |
| [**SearchSiretProxyApiV1AfnorDirectoryV1SiretSearchPost**](AFNORPDPPADirectoryServiceApi.md#searchsiretproxyapiv1afnordirectoryv1siretsearchpost) | **POST** /api/v1/afnor/directory/v1/siret/search | Search for a SIRET (facility) |

<a id="createdirectorylineproxyapiv1afnordirectoryv1directorylinepost"></a>
# **CreateDirectoryLineProxyApiV1AfnorDirectoryV1DirectoryLinePost**
> Object CreateDirectoryLineProxyApiV1AfnorDirectoryV1DirectoryLinePost ()

Creating a directory line

Créer une ligne dans l'annuaire


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
| **200** | Successful Response |  -  |
| **201** | Ligne d&#39;annuaire créée avec succès |  -  |
| **400** | Requête invalide |  -  |
| **401** | Non authentifié |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="createroutingcodeproxyapiv1afnordirectoryv1routingcodepost"></a>
# **CreateRoutingCodeProxyApiV1AfnorDirectoryV1RoutingCodePost**
> Object CreateRoutingCodeProxyApiV1AfnorDirectoryV1RoutingCodePost ()

Create a routing code

Créer un code de routage dans l'annuaire


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
| **200** | Successful Response |  -  |
| **201** | Code de routage créé avec succès |  -  |
| **400** | Requête invalide |  -  |
| **401** | Non authentifié |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="deletedirectorylineproxyapiv1afnordirectoryv1directorylineidinstanceidinstancedelete"></a>
# **DeleteDirectoryLineProxyApiV1AfnorDirectoryV1DirectoryLineIdInstanceIdInstanceDelete**
> Object DeleteDirectoryLineProxyApiV1AfnorDirectoryV1DirectoryLineIdInstanceIdInstanceDelete (string idInstance)

Delete a directory line

Supprimer une ligne d'annuaire


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **idInstance** | **string** |  |  |

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
| **200** | Successful Response |  -  |
| **204** | Ligne d&#39;annuaire supprimée |  -  |
| **404** | Ligne d&#39;annuaire non trouvée |  -  |
| **401** | Non authentifié |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

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

<a id="getdirectorylinebycodeproxyapiv1afnordirectoryv1directorylinecodeaddressingidentifierget"></a>
# **GetDirectoryLineByCodeProxyApiV1AfnorDirectoryV1DirectoryLineCodeAddressingIdentifierGet**
> Object GetDirectoryLineByCodeProxyApiV1AfnorDirectoryV1DirectoryLineCodeAddressingIdentifierGet (string addressingIdentifier)

Get a directory line

Obtenir une ligne d'annuaire identifiée par un identifiant d'adressage


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **addressingIdentifier** | **string** |  |  |

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
| **200** | Détails de la ligne d&#39;annuaire |  -  |
| **404** | Ligne d&#39;annuaire non trouvée |  -  |
| **401** | Non authentifié |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getdirectorylinebyidinstanceproxyapiv1afnordirectoryv1directorylineidinstanceidinstanceget"></a>
# **GetDirectoryLineByIdInstanceProxyApiV1AfnorDirectoryV1DirectoryLineIdInstanceIdInstanceGet**
> Object GetDirectoryLineByIdInstanceProxyApiV1AfnorDirectoryV1DirectoryLineIdInstanceIdInstanceGet (string idInstance)

Get a directory line

Obtenir une ligne d'annuaire identifiée par son idInstance


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **idInstance** | **string** |  |  |

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
| **200** | Détails de la ligne d&#39;annuaire |  -  |
| **404** | Ligne d&#39;annuaire non trouvée |  -  |
| **401** | Non authentifié |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getroutingcodebyidinstanceproxyapiv1afnordirectoryv1routingcodeidinstanceidinstanceget"></a>
# **GetRoutingCodeByIdInstanceProxyApiV1AfnorDirectoryV1RoutingCodeIdInstanceIdInstanceGet**
> Object GetRoutingCodeByIdInstanceProxyApiV1AfnorDirectoryV1RoutingCodeIdInstanceIdInstanceGet (string idInstance)

Get a routing code by instance-id

Obtenir un code de routage identifié par son idInstance


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **idInstance** | **string** |  |  |

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
| **200** | Détails du code de routage |  -  |
| **404** | Code de routage non trouvé |  -  |
| **401** | Non authentifié |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getroutingcodebysiretandcodeproxyapiv1afnordirectoryv1routingcodesiretsiretcoderoutingidentifierget"></a>
# **GetRoutingCodeBySiretAndCodeProxyApiV1AfnorDirectoryV1RoutingCodeSiretSiretCodeRoutingIdentifierGet**
> Object GetRoutingCodeBySiretAndCodeProxyApiV1AfnorDirectoryV1RoutingCodeSiretSiretCodeRoutingIdentifierGet (string siret, string routingIdentifier)

Get a routing code by SIRET and routing identifier

Consulter un code de routage identifié par SIRET et identifiant de routage


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **siret** | **string** |  |  |
| **routingIdentifier** | **string** |  |  |

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
| **200** | Détails du code de routage |  -  |
| **404** | Code de routage non trouvé |  -  |
| **401** | Non authentifié |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getsirenbycodeinseeproxyapiv1afnordirectoryv1sirencodeinseesirenget"></a>
# **GetSirenByCodeInseeProxyApiV1AfnorDirectoryV1SirenCodeInseeSirenGet**
> Object GetSirenByCodeInseeProxyApiV1AfnorDirectoryV1SirenCodeInseeSirenGet (string siren)

Consult a siren (legal unit) by SIREN number

Retourne les détails d'une entreprise (unité légale) identifiée par son numéro SIREN


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **siren** | **string** |  |  |

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
| **200** | Informations de l&#39;entreprise |  -  |
| **404** | Entreprise non trouvée |  -  |
| **401** | Non authentifié |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getsirenbyidinstanceproxyapiv1afnordirectoryv1sirenidinstanceidinstanceget"></a>
# **GetSirenByIdInstanceProxyApiV1AfnorDirectoryV1SirenIdInstanceIdInstanceGet**
> Object GetSirenByIdInstanceProxyApiV1AfnorDirectoryV1SirenIdInstanceIdInstanceGet (string idInstance)

Gets a siren (legal unit) by instance ID

Obtenir une entreprise (unité légale) identifiée par son idInstance


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **idInstance** | **string** |  |  |

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
| **200** | Informations de l&#39;entreprise |  -  |
| **404** | Entreprise non trouvée |  -  |
| **401** | Non authentifié |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getsiretbycodeinseeproxyapiv1afnordirectoryv1siretcodeinseesiretget"></a>
# **GetSiretByCodeInseeProxyApiV1AfnorDirectoryV1SiretCodeInseeSiretGet**
> Object GetSiretByCodeInseeProxyApiV1AfnorDirectoryV1SiretCodeInseeSiretGet (string siret)

Gets a siret (facility) by SIRET number

Obtenir un établissement identifié par son numéro SIRET


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **siret** | **string** |  |  |

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
| **200** | Informations de l&#39;établissement |  -  |
| **404** | Établissement non trouvé |  -  |
| **401** | Non authentifié |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getsiretbyidinstanceproxyapiv1afnordirectoryv1siretidinstanceidinstanceget"></a>
# **GetSiretByIdInstanceProxyApiV1AfnorDirectoryV1SiretIdInstanceIdInstanceGet**
> Object GetSiretByIdInstanceProxyApiV1AfnorDirectoryV1SiretIdInstanceIdInstanceGet (string idInstance)

Gets a siret (facility) by id-instance

Obtenir un établissement identifié par son idInstance


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **idInstance** | **string** |  |  |

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
| **200** | Informations de l&#39;établissement |  -  |
| **404** | Établissement non trouvé |  -  |
| **401** | Non authentifié |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="patchdirectorylineproxyapiv1afnordirectoryv1directorylineidinstanceidinstancepatch"></a>
# **PatchDirectoryLineProxyApiV1AfnorDirectoryV1DirectoryLineIdInstanceIdInstancePatch**
> Object PatchDirectoryLineProxyApiV1AfnorDirectoryV1DirectoryLineIdInstanceIdInstancePatch (string idInstance)

Partially updates a directory line

Mettre à jour partiellement une ligne d'annuaire


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **idInstance** | **string** |  |  |

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
| **200** | Ligne d&#39;annuaire mise à jour |  -  |
| **404** | Ligne d&#39;annuaire non trouvée |  -  |
| **401** | Non authentifié |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="patchroutingcodeproxyapiv1afnordirectoryv1routingcodeidinstanceidinstancepatch"></a>
# **PatchRoutingCodeProxyApiV1AfnorDirectoryV1RoutingCodeIdInstanceIdInstancePatch**
> Object PatchRoutingCodeProxyApiV1AfnorDirectoryV1RoutingCodeIdInstanceIdInstancePatch (string idInstance)

Partially update a private routing code

Mettre à jour partiellement un code de routage privé


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **idInstance** | **string** |  |  |

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
| **200** | Code de routage mis à jour |  -  |
| **404** | Code de routage non trouvé |  -  |
| **401** | Non authentifié |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="putroutingcodeproxyapiv1afnordirectoryv1routingcodeidinstanceidinstanceput"></a>
# **PutRoutingCodeProxyApiV1AfnorDirectoryV1RoutingCodeIdInstanceIdInstancePut**
> Object PutRoutingCodeProxyApiV1AfnorDirectoryV1RoutingCodeIdInstanceIdInstancePut (string idInstance)

Completely update a private routing code

Mettre à jour complètement un code de routage privé


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **idInstance** | **string** |  |  |

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
| **200** | Code de routage mis à jour |  -  |
| **404** | Code de routage non trouvé |  -  |
| **401** | Non authentifié |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="searchdirectorylineproxyapiv1afnordirectoryv1directorylinesearchpost"></a>
# **SearchDirectoryLineProxyApiV1AfnorDirectoryV1DirectoryLineSearchPost**
> Object SearchDirectoryLineProxyApiV1AfnorDirectoryV1DirectoryLineSearchPost ()

Search for a directory line

Rechercher des lignes d'annuaire selon des critères


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
| **200** | Résultats de recherche |  -  |
| **401** | Non authentifié |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="searchroutingcodeproxyapiv1afnordirectoryv1routingcodesearchpost"></a>
# **SearchRoutingCodeProxyApiV1AfnorDirectoryV1RoutingCodeSearchPost**
> Object SearchRoutingCodeProxyApiV1AfnorDirectoryV1RoutingCodeSearchPost ()

Search for a routing code

Rechercher des codes de routage selon des critères


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
| **200** | Résultats de recherche |  -  |
| **401** | Non authentifié |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="searchsirenproxyapiv1afnordirectoryv1sirensearchpost"></a>
# **SearchSirenProxyApiV1AfnorDirectoryV1SirenSearchPost**
> Object SearchSirenProxyApiV1AfnorDirectoryV1SirenSearchPost ()

SIREN search (or legal unit)

Recherche multi-critères d'entreprises (unités légales)


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
| **200** | Retourne une ou plusieurs entreprises |  -  |
| **401** | Non authentifié |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="searchsiretproxyapiv1afnordirectoryv1siretsearchpost"></a>
# **SearchSiretProxyApiV1AfnorDirectoryV1SiretSearchPost**
> Object SearchSiretProxyApiV1AfnorDirectoryV1SiretSearchPost ()

Search for a SIRET (facility)

Recherche multi-critères d'établissements


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
| **200** | Retourne un ou plusieurs établissements |  -  |
| **401** | Non authentifié |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

