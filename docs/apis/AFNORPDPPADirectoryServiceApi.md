# FactPulse.SDK.Api.AFNORPDPPADirectoryServiceApi

All URIs are relative to *https://factpulse.fr*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CreateDirectoryLineProxyApiV1AfnorDirectoryV1DirectoryLinePost**](AFNORPDPPADirectoryServiceApi.md#createdirectorylineproxyapiv1afnordirectoryv1directorylinepost) | **POST** /api/v1/afnor/directory/v1/directory-line | Creating a directory line |
| [**CreateRoutingCodeProxyApiV1AfnorDirectoryV1RoutingCodePost**](AFNORPDPPADirectoryServiceApi.md#createroutingcodeproxyapiv1afnordirectoryv1routingcodepost) | **POST** /api/v1/afnor/directory/v1/routing-code | Create a routing code |
| [**DeleteDirectoryLineProxyApiV1AfnorDirectoryV1DirectoryLineIdInstanceIdInstanceDelete**](AFNORPDPPADirectoryServiceApi.md#deletedirectorylineproxyapiv1afnordirectoryv1directorylineidinstanceidinstancedelete) | **DELETE** /api/v1/afnor/directory/v1/directory-line/id-instance:{id_instance} | Delete a directory line |
| [**DirectoryHealthcheckProxyApiV1AfnorDirectoryV1HealthcheckGet**](AFNORPDPPADirectoryServiceApi.md#directoryhealthcheckproxyapiv1afnordirectoryv1healthcheckget) | **GET** /api/v1/afnor/directory/v1/healthcheck | Healthcheck Directory Service |
| [**GetDirectoryLineByCodeProxyApiV1AfnorDirectoryV1DirectoryLineCodeAddressingIdentifierGet**](AFNORPDPPADirectoryServiceApi.md#getdirectorylinebycodeproxyapiv1afnordirectoryv1directorylinecodeaddressingidentifierget) | **GET** /api/v1/afnor/directory/v1/directory-line/code:{addressing_identifier} | Get a directory line. |
| [**GetDirectoryLineByIdInstanceProxyApiV1AfnorDirectoryV1DirectoryLineIdInstanceIdInstanceGet**](AFNORPDPPADirectoryServiceApi.md#getdirectorylinebyidinstanceproxyapiv1afnordirectoryv1directorylineidinstanceidinstanceget) | **GET** /api/v1/afnor/directory/v1/directory-line/id-instance:{id_instance} | Get a directory line. |
| [**GetRoutingCodeByIdInstanceProxyApiV1AfnorDirectoryV1RoutingCodeIdInstanceIdInstanceGet**](AFNORPDPPADirectoryServiceApi.md#getroutingcodebyidinstanceproxyapiv1afnordirectoryv1routingcodeidinstanceidinstanceget) | **GET** /api/v1/afnor/directory/v1/routing-code/id-instance:{id_instance} | Get a routing code by instance-id. |
| [**GetRoutingCodeBySiretAndCodeProxyApiV1AfnorDirectoryV1RoutingCodeSiretSiretCodeRoutingIdentifierGet**](AFNORPDPPADirectoryServiceApi.md#getroutingcodebysiretandcodeproxyapiv1afnordirectoryv1routingcodesiretsiretcoderoutingidentifierget) | **GET** /api/v1/afnor/directory/v1/routing-code/siret:{siret}/code:{routing_identifier} | Get a routing code by SIRET and routing identifier |
| [**GetSirenByCodeInseeProxyApiV1AfnorDirectoryV1SirenCodeInseeSirenGet**](AFNORPDPPADirectoryServiceApi.md#getsirenbycodeinseeproxyapiv1afnordirectoryv1sirencodeinseesirenget) | **GET** /api/v1/afnor/directory/v1/siren/code-insee:{siren} | Consult a siren (legal unit) by SIREN number |
| [**GetSirenByIdInstanceProxyApiV1AfnorDirectoryV1SirenIdInstanceIdInstanceGet**](AFNORPDPPADirectoryServiceApi.md#getsirenbyidinstanceproxyapiv1afnordirectoryv1sirenidinstanceidinstanceget) | **GET** /api/v1/afnor/directory/v1/siren/id-instance:{id_instance} | Gets a siren (legal unit) by instance ID |
| [**GetSiretByCodeInseeProxyApiV1AfnorDirectoryV1SiretCodeInseeSiretGet**](AFNORPDPPADirectoryServiceApi.md#getsiretbycodeinseeproxyapiv1afnordirectoryv1siretcodeinseesiretget) | **GET** /api/v1/afnor/directory/v1/siret/code-insee:{siret} | Gets a siret (facility) by SIRET number |
| [**GetSiretByIdInstanceProxyApiV1AfnorDirectoryV1SiretIdInstanceIdInstanceGet**](AFNORPDPPADirectoryServiceApi.md#getsiretbyidinstanceproxyapiv1afnordirectoryv1siretidinstanceidinstanceget) | **GET** /api/v1/afnor/directory/v1/siret/id-instance:{id_instance} | Gets a siret (facility) by id-instance |
| [**PatchDirectoryLineProxyApiV1AfnorDirectoryV1DirectoryLineIdInstanceIdInstancePatch**](AFNORPDPPADirectoryServiceApi.md#patchdirectorylineproxyapiv1afnordirectoryv1directorylineidinstanceidinstancepatch) | **PATCH** /api/v1/afnor/directory/v1/directory-line/id-instance:{id_instance} | Partially updates a directory line.. |
| [**PatchRoutingCodeProxyApiV1AfnorDirectoryV1RoutingCodeIdInstanceIdInstancePatch**](AFNORPDPPADirectoryServiceApi.md#patchroutingcodeproxyapiv1afnordirectoryv1routingcodeidinstanceidinstancepatch) | **PATCH** /api/v1/afnor/directory/v1/routing-code/id-instance:{id_instance} | Partially update a private routing code. |
| [**PutRoutingCodeProxyApiV1AfnorDirectoryV1RoutingCodeIdInstanceIdInstancePut**](AFNORPDPPADirectoryServiceApi.md#putroutingcodeproxyapiv1afnordirectoryv1routingcodeidinstanceidinstanceput) | **PUT** /api/v1/afnor/directory/v1/routing-code/id-instance:{id_instance} | Completely update a private routing code. |
| [**SearchDirectoryLineProxyApiV1AfnorDirectoryV1DirectoryLineSearchPost**](AFNORPDPPADirectoryServiceApi.md#searchdirectorylineproxyapiv1afnordirectoryv1directorylinesearchpost) | **POST** /api/v1/afnor/directory/v1/directory-line/search | Search for a directory line |
| [**SearchRoutingCodeProxyApiV1AfnorDirectoryV1RoutingCodeSearchPost**](AFNORPDPPADirectoryServiceApi.md#searchroutingcodeproxyapiv1afnordirectoryv1routingcodesearchpost) | **POST** /api/v1/afnor/directory/v1/routing-code/search | Search for a routing code |
| [**SearchSirenProxyApiV1AfnorDirectoryV1SirenSearchPost**](AFNORPDPPADirectoryServiceApi.md#searchsirenproxyapiv1afnordirectoryv1sirensearchpost) | **POST** /api/v1/afnor/directory/v1/siren/search | SIREN search (or legal unit) |
| [**SearchSiretProxyApiV1AfnorDirectoryV1SiretSearchPost**](AFNORPDPPADirectoryServiceApi.md#searchsiretproxyapiv1afnordirectoryv1siretsearchpost) | **POST** /api/v1/afnor/directory/v1/siret/search | Search for a SIRET (facility) |

<a id="createdirectorylineproxyapiv1afnordirectoryv1directorylinepost"></a>
# **CreateDirectoryLineProxyApiV1AfnorDirectoryV1DirectoryLinePost**
> Object CreateDirectoryLineProxyApiV1AfnorDirectoryV1DirectoryLinePost ()

Creating a directory line

Creation of a new directory line for a SIREN, a SIRET or a ROUTING CODE.


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
| **201** | A new resource has been created. |  -  |
| **400** | Bad request. The request is invalid or cannot be completed. |  -  |
| **401** | Unauthorized. The request requires user authentication. |  -  |
| **403** | Forbidden. The server understood the request but denied access or access is not authorized. |  -  |
| **404** | Not found. There is no resource at the given URI. |  -  |
| **408** | Request timeout exceeded. |  -  |
| **422** | Data validation error. |  -  |
| **429** | The client has issued too many calls within a given time frame. |  -  |
| **500** | Internal Server Error. |  -  |
| **501** | Not implemented. |  -  |
| **503** | Service unavailable. |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="createroutingcodeproxyapiv1afnordirectoryv1routingcodepost"></a>
# **CreateRoutingCodeProxyApiV1AfnorDirectoryV1RoutingCodePost**
> Object CreateRoutingCodeProxyApiV1AfnorDirectoryV1RoutingCodePost ()

Create a routing code

Creating a routing code.


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
| **201** | A new resource has been created. |  -  |
| **400** | Bad request. The request is invalid or cannot be completed. |  -  |
| **401** | Unauthorized. The request requires user authentication. |  -  |
| **403** | Forbidden. The server understood the request but denied access or access is not authorized. |  -  |
| **404** | Not found. There is no resource at the given URI. |  -  |
| **408** | Request timeout exceeded. |  -  |
| **422** | Data validation error. |  -  |
| **429** | The client has issued too many calls within a given time frame. |  -  |
| **500** | Internal Server Error. |  -  |
| **501** | Not implemented. |  -  |
| **503** | Service unavailable. |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="deletedirectorylineproxyapiv1afnordirectoryv1directorylineidinstanceidinstancedelete"></a>
# **DeleteDirectoryLineProxyApiV1AfnorDirectoryV1DirectoryLineIdInstanceIdInstanceDelete**
> Object DeleteDirectoryLineProxyApiV1AfnorDirectoryV1DirectoryLineIdInstanceIdInstanceDelete (string idInstance)

Delete a directory line

Delete a directory line.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **idInstance** | **string** | AFNOR instance ID (UUID) |  |

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
| **204** | OK. The resource has been deleted. |  -  |
| **400** | Bad request. The request is invalid or cannot be completed. |  -  |
| **401** | Unauthorized. The request requires user authentication. |  -  |
| **403** | Forbidden. The server understood the request but denied access or access is not authorized. |  -  |
| **404** | Not found. There is no resource at the given URI. |  -  |
| **408** | Request timeout exceeded. |  -  |
| **422** | Data validation error. |  -  |
| **429** | The client has issued too many calls within a given time frame. |  -  |
| **500** | Internal Server Error. |  -  |
| **501** | Not implemented. |  -  |
| **503** | Service unavailable. |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="directoryhealthcheckproxyapiv1afnordirectoryv1healthcheckget"></a>
# **DirectoryHealthcheckProxyApiV1AfnorDirectoryV1HealthcheckGet**
> Object DirectoryHealthcheckProxyApiV1AfnorDirectoryV1HealthcheckGet ()

Healthcheck Directory Service

Check Directory Service availability (AFNOR XP Z12-013 compliant)


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
| **500** | Internal Server Error. |  -  |
| **503** | Service unavailable. |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getdirectorylinebycodeproxyapiv1afnordirectoryv1directorylinecodeaddressingidentifierget"></a>
# **GetDirectoryLineByCodeProxyApiV1AfnorDirectoryV1DirectoryLineCodeAddressingIdentifierGet**
> AFNORDirectoryLinePayloadHistoryLegalUnitFacilityRoutingCode GetDirectoryLineByCodeProxyApiV1AfnorDirectoryV1DirectoryLineCodeAddressingIdentifierGet (string addressingIdentifier)

Get a directory line.

Retrieve the data from the directory line corresponding to the identifier passed in parameters.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **addressingIdentifier** | **string** | Addressing identifier (SIREN, SIRET or routing code) |  |

### Return type

[**AFNORDirectoryLinePayloadHistoryLegalUnitFacilityRoutingCode**](AFNORDirectoryLinePayloadHistoryLegalUnitFacilityRoutingCode.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Retourns a directory line. |  -  |
| **400** | Bad request. The request is invalid or cannot be completed. |  -  |
| **401** | Unauthorized. The request requires user authentication. |  -  |
| **403** | Forbidden. The server understood the request but denied access or access is not authorized. |  -  |
| **404** | Not found. There is no resource at the given URI. |  -  |
| **408** | Request timeout exceeded. |  -  |
| **422** | Data validation error. |  -  |
| **429** | The client has issued too many calls within a given time frame. |  -  |
| **500** | Internal Server Error. |  -  |
| **501** | Not implemented. |  -  |
| **503** | Service unavailable. |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getdirectorylinebyidinstanceproxyapiv1afnordirectoryv1directorylineidinstanceidinstanceget"></a>
# **GetDirectoryLineByIdInstanceProxyApiV1AfnorDirectoryV1DirectoryLineIdInstanceIdInstanceGet**
> AFNORDirectoryLinePayloadHistoryLegalUnitFacilityRoutingCode GetDirectoryLineByIdInstanceProxyApiV1AfnorDirectoryV1DirectoryLineIdInstanceIdInstanceGet (string idInstance)

Get a directory line.

Retrieve the data from the directory line corresponding to the identifier passed in parameters.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **idInstance** | **string** | AFNOR instance ID (UUID) |  |

### Return type

[**AFNORDirectoryLinePayloadHistoryLegalUnitFacilityRoutingCode**](AFNORDirectoryLinePayloadHistoryLegalUnitFacilityRoutingCode.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Returns a directory line. |  -  |
| **400** | Bad request. The request is invalid or cannot be completed. |  -  |
| **401** | Unauthorized. The request requires user authentication. |  -  |
| **403** | Forbidden. The server understood the request but denied access or access is not authorized. |  -  |
| **404** | Not found. There is no resource at the given URI. |  -  |
| **408** | Request timeout exceeded. |  -  |
| **422** | Data validation error. |  -  |
| **429** | The client has issued too many calls within a given time frame. |  -  |
| **500** | Internal Server Error. |  -  |
| **501** | Not implemented. |  -  |
| **503** | Service unavailable. |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getroutingcodebyidinstanceproxyapiv1afnordirectoryv1routingcodeidinstanceidinstanceget"></a>
# **GetRoutingCodeByIdInstanceProxyApiV1AfnorDirectoryV1RoutingCodeIdInstanceIdInstanceGet**
> AFNORRoutingCodePayloadHistoryLegalUnitFacility GetRoutingCodeByIdInstanceProxyApiV1AfnorDirectoryV1RoutingCodeIdInstanceIdInstanceGet (string idInstance)

Get a routing code by instance-id.

Retrieve the Routing Code data corresponding to the Instance ID.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **idInstance** | **string** | AFNOR instance ID (UUID) |  |

### Return type

[**AFNORRoutingCodePayloadHistoryLegalUnitFacility**](AFNORRoutingCodePayloadHistoryLegalUnitFacility.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Returns a routing code. |  -  |
| **400** | Bad request. The request is invalid or cannot be completed. |  -  |
| **401** | Unauthorized. The request requires user authentication. |  -  |
| **403** | Forbidden. The server understood the request but denied access or access is not authorized. |  -  |
| **404** | Not found. There is no resource at the given URI. |  -  |
| **408** | Request timeout exceeded. |  -  |
| **422** | Data validation error. |  -  |
| **429** | The client has issued too many calls within a given time frame. |  -  |
| **500** | Internal Server Error. |  -  |
| **501** | Not implemented. |  -  |
| **503** | Service unavailable. |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getroutingcodebysiretandcodeproxyapiv1afnordirectoryv1routingcodesiretsiretcoderoutingidentifierget"></a>
# **GetRoutingCodeBySiretAndCodeProxyApiV1AfnorDirectoryV1RoutingCodeSiretSiretCodeRoutingIdentifierGet**
> AFNORRoutingCodePayloadHistoryLegalUnitFacility GetRoutingCodeBySiretAndCodeProxyApiV1AfnorDirectoryV1RoutingCodeSiretSiretCodeRoutingIdentifierGet (string siret, string routingIdentifier)

Get a routing code by SIRET and routing identifier

Retrieve the Routing Code data corresponding to the identifier passed in parameters.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **siret** | **string** | 14-digit SIRET number (INSEE establishment identifier) |  |
| **routingIdentifier** | **string** | Routing code identifier |  |

### Return type

[**AFNORRoutingCodePayloadHistoryLegalUnitFacility**](AFNORRoutingCodePayloadHistoryLegalUnitFacility.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Returns a routing code. |  -  |
| **400** | Bad request. The request is invalid or cannot be completed. |  -  |
| **401** | Unauthorized. The request requires user authentication. |  -  |
| **403** | Forbidden. The server understood the request but denied access or access is not authorized. |  -  |
| **404** | Not found. There is no resource at the given URI. |  -  |
| **408** | Request timeout exceeded. |  -  |
| **422** | Data validation error. |  -  |
| **429** | The client has issued too many calls within a given time frame. |  -  |
| **500** | Internal Server Error. |  -  |
| **501** | Not implemented. |  -  |
| **503** | Service unavailable. |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getsirenbycodeinseeproxyapiv1afnordirectoryv1sirencodeinseesirenget"></a>
# **GetSirenByCodeInseeProxyApiV1AfnorDirectoryV1SirenCodeInseeSirenGet**
> AFNORLegalUnitPayloadHistory GetSirenByCodeInseeProxyApiV1AfnorDirectoryV1SirenCodeInseeSirenGet (string siren)

Consult a siren (legal unit) by SIREN number

Returns the details of a company (legal unit) identified by the SIREN number passed as a parameter.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **siren** | **string** | 9-digit SIREN number (INSEE company identifier) |  |

### Return type

[**AFNORLegalUnitPayloadHistory**](AFNORLegalUnitPayloadHistory.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Returns a company. |  -  |
| **400** | Bad request. The request is invalid or cannot be completed. |  -  |
| **401** | Unauthorized. The request requires user authentication. |  -  |
| **403** | Forbidden. The server understood the request but denied access or access is not authorized. |  -  |
| **404** | Not found. There is no resource at the given URI. |  -  |
| **408** | Request timeout exceeded. |  -  |
| **422** | Data validation error. |  -  |
| **429** | The client has issued too many calls within a given time frame. |  -  |
| **500** | Internal Server Error. |  -  |
| **501** | Not implemented. |  -  |
| **503** | Service unavailable. |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getsirenbyidinstanceproxyapiv1afnordirectoryv1sirenidinstanceidinstanceget"></a>
# **GetSirenByIdInstanceProxyApiV1AfnorDirectoryV1SirenIdInstanceIdInstanceGet**
> AFNORLegalUnitPayloadHistory GetSirenByIdInstanceProxyApiV1AfnorDirectoryV1SirenIdInstanceIdInstanceGet (string idInstance)

Gets a siren (legal unit) by instance ID

Returns the details of a company (legal unit) identified by the id-instance passed as a parameter.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **idInstance** | **string** | AFNOR instance ID (UUID) |  |

### Return type

[**AFNORLegalUnitPayloadHistory**](AFNORLegalUnitPayloadHistory.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Returns a routing code. |  -  |
| **400** | Bad request. The request is invalid or cannot be completed. |  -  |
| **401** | Unauthorized. The request requires user authentication. |  -  |
| **403** | Forbidden. The server understood the request but denied access or access is not authorized. |  -  |
| **404** | Not found. There is no resource at the given URI. |  -  |
| **408** | Request timeout exceeded. |  -  |
| **422** | Data validation error. |  -  |
| **429** | The client has issued too many calls within a given time frame. |  -  |
| **500** | Internal Server Error. |  -  |
| **501** | Not implemented. |  -  |
| **503** | Service unavailable. |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getsiretbycodeinseeproxyapiv1afnordirectoryv1siretcodeinseesiretget"></a>
# **GetSiretByCodeInseeProxyApiV1AfnorDirectoryV1SiretCodeInseeSiretGet**
> AFNORFacilityPayloadHistory GetSiretByCodeInseeProxyApiV1AfnorDirectoryV1SiretCodeInseeSiretGet (string siret)

Gets a siret (facility) by SIRET number

Returns the details of a facility associated to a SIRET.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **siret** | **string** | 14-digit SIRET number (INSEE establishment identifier) |  |

### Return type

[**AFNORFacilityPayloadHistory**](AFNORFacilityPayloadHistory.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Returns a facility. |  -  |
| **400** | Bad request. The request is invalid or cannot be completed. |  -  |
| **401** | Unauthorized. The request requires user authentication. |  -  |
| **403** | Forbidden. The server understood the request but denied access or access is not authorized. |  -  |
| **404** | Not found. There is no resource at the given URI. |  -  |
| **408** | Request timeout exceeded. |  -  |
| **422** | Data validation error. |  -  |
| **429** | The client has issued too many calls within a given time frame. |  -  |
| **500** | Internal Server Error. |  -  |
| **501** | Not implemented. |  -  |
| **503** | Service unavailable. |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getsiretbyidinstanceproxyapiv1afnordirectoryv1siretidinstanceidinstanceget"></a>
# **GetSiretByIdInstanceProxyApiV1AfnorDirectoryV1SiretIdInstanceIdInstanceGet**
> AFNORFacilityPayloadHistory GetSiretByIdInstanceProxyApiV1AfnorDirectoryV1SiretIdInstanceIdInstanceGet (string idInstance)

Gets a siret (facility) by id-instance

Returns the details of a facility according to an instance-id.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **idInstance** | **string** | AFNOR instance ID (UUID) |  |

### Return type

[**AFNORFacilityPayloadHistory**](AFNORFacilityPayloadHistory.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Returns a routing code. |  -  |
| **400** | Bad request. The request is invalid or cannot be completed. |  -  |
| **401** | Unauthorized. The request requires user authentication. |  -  |
| **403** | Forbidden. The server understood the request but denied access or access is not authorized. |  -  |
| **404** | Not found. There is no resource at the given URI. |  -  |
| **408** | Request timeout exceeded. |  -  |
| **422** | Data validation error. |  -  |
| **429** | The client has issued too many calls within a given time frame. |  -  |
| **500** | Internal Server Error. |  -  |
| **501** | Not implemented. |  -  |
| **503** | Service unavailable. |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="patchdirectorylineproxyapiv1afnordirectoryv1directorylineidinstanceidinstancepatch"></a>
# **PatchDirectoryLineProxyApiV1AfnorDirectoryV1DirectoryLineIdInstanceIdInstancePatch**
> AFNORDirectoryLinePost201Response PatchDirectoryLineProxyApiV1AfnorDirectoryV1DirectoryLineIdInstanceIdInstancePatch (string idInstance)

Partially updates a directory line..

Partially updates a directory line.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **idInstance** | **string** | AFNOR instance ID (UUID) |  |

### Return type

[**AFNORDirectoryLinePost201Response**](AFNORDirectoryLinePost201Response.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Request successful. |  -  |
| **400** | Bad request. The request is invalid or cannot be completed. |  -  |
| **401** | Unauthorized. The request requires user authentication. |  -  |
| **403** | Forbidden. The server understood the request but denied access or access is not authorized. |  -  |
| **404** | Not found. There is no resource at the given URI. |  -  |
| **408** | Request timeout exceeded. |  -  |
| **422** | Data validation error. |  -  |
| **429** | The client has issued too many calls within a given time frame. |  -  |
| **500** | Internal Server Error. |  -  |
| **501** | Not implemented. |  -  |
| **503** | Service unavailable. |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="patchroutingcodeproxyapiv1afnordirectoryv1routingcodeidinstanceidinstancepatch"></a>
# **PatchRoutingCodeProxyApiV1AfnorDirectoryV1RoutingCodeIdInstanceIdInstancePatch**
> AFNORRoutingCodePost201Response PatchRoutingCodeProxyApiV1AfnorDirectoryV1RoutingCodeIdInstanceIdInstancePatch (string idInstance)

Partially update a private routing code.

Partially update a private routing code.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **idInstance** | **string** | AFNOR instance ID (UUID) |  |

### Return type

[**AFNORRoutingCodePost201Response**](AFNORRoutingCodePost201Response.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Request successful. |  -  |
| **206** | Request processed without error, but the volume of information returned has been reduced. |  -  |
| **400** | Bad request. The request is invalid or cannot be completed. |  -  |
| **401** | Unauthorized. The request requires user authentication. |  -  |
| **403** | Forbidden. The server understood the request but denied access or access is not authorized. |  -  |
| **404** | Not found. There is no resource at the given URI. |  -  |
| **408** | Request timeout exceeded. |  -  |
| **422** | Data validation error. |  -  |
| **429** | The client has issued too many calls within a given time frame. |  -  |
| **500** | Internal Server Error. |  -  |
| **501** | Not implemented. |  -  |
| **503** | Service unavailable. |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="putroutingcodeproxyapiv1afnordirectoryv1routingcodeidinstanceidinstanceput"></a>
# **PutRoutingCodeProxyApiV1AfnorDirectoryV1RoutingCodeIdInstanceIdInstancePut**
> AFNORRoutingCodePost201Response PutRoutingCodeProxyApiV1AfnorDirectoryV1RoutingCodeIdInstanceIdInstancePut (string idInstance)

Completely update a private routing code.

Completely update a private routing code.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **idInstance** | **string** | AFNOR instance ID (UUID) |  |

### Return type

[**AFNORRoutingCodePost201Response**](AFNORRoutingCodePost201Response.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Request successful. |  -  |
| **206** | Request processed without error, but the volume of information returned has been reduced. |  -  |
| **400** | Bad request. The request is invalid or cannot be completed. |  -  |
| **401** | Unauthorized. The request requires user authentication. |  -  |
| **403** | Forbidden. The server understood the request but denied access or access is not authorized. |  -  |
| **404** | Not found. There is no resource at the given URI. |  -  |
| **408** | Request timeout exceeded. |  -  |
| **422** | Data validation error. |  -  |
| **429** | The client has issued too many calls within a given time frame. |  -  |
| **500** | Internal Server Error. |  -  |
| **501** | Not implemented. |  -  |
| **503** | Service unavailable. |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="searchdirectorylineproxyapiv1afnordirectoryv1directorylinesearchpost"></a>
# **SearchDirectoryLineProxyApiV1AfnorDirectoryV1DirectoryLineSearchPost**
> AFNORDirectoryLineSearchPost200Response SearchDirectoryLineProxyApiV1AfnorDirectoryV1DirectoryLineSearchPost ()

Search for a directory line

Search for directory lines that meet all the criteria passed as parameters and return the results in the desired format.


### Parameters
This endpoint does not need any parameter.
### Return type

[**AFNORDirectoryLineSearchPost200Response**](AFNORDirectoryLineSearchPost200Response.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | returns the directory line(s) matching the search criteria. |  -  |
| **206** | Request processed without error, but the volume of information returned has been reduced. |  -  |
| **400** | Bad request. The request is invalid or cannot be completed. |  -  |
| **401** | Unauthorized. The request requires user authentication. |  -  |
| **403** | Forbidden. The server understood the request but denied access or access is not authorized. |  -  |
| **404** | Not found. There is no resource at the given URI. |  -  |
| **408** | Request timeout exceeded. |  -  |
| **422** | Data validation error. |  -  |
| **429** | The client has issued too many calls within a given time frame. |  -  |
| **500** | Internal Server Error. |  -  |
| **501** | Not implemented. |  -  |
| **503** | Service unavailable. |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="searchroutingcodeproxyapiv1afnordirectoryv1routingcodesearchpost"></a>
# **SearchRoutingCodeProxyApiV1AfnorDirectoryV1RoutingCodeSearchPost**
> AFNORRoutingCodeSearchPost200Response SearchRoutingCodeProxyApiV1AfnorDirectoryV1RoutingCodeSearchPost ()

Search for a routing code

Search for routing codes that meet all the criteria passed as parameters and return the routing codes in the desired format.


### Parameters
This endpoint does not need any parameter.
### Return type

[**AFNORRoutingCodeSearchPost200Response**](AFNORRoutingCodeSearchPost200Response.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Returns the routing code(s) matching the search criteria. |  -  |
| **206** | Request processed without error, but the volume of information returned has been reduced. |  -  |
| **400** | Bad request. The request is invalid or cannot be completed. |  -  |
| **401** | Unauthorized. The request requires user authentication. |  -  |
| **403** | Forbidden. The server understood the request but denied access or access is not authorized. |  -  |
| **404** | Not found. There is no resource at the given URI. |  -  |
| **408** | Request timeout exceeded. |  -  |
| **422** | Data validation error. |  -  |
| **429** | The client has issued too many calls within a given time frame. |  -  |
| **500** | Internal Server Error. |  -  |
| **501** | Not implemented. |  -  |
| **503** | Service unavailable. |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="searchsirenproxyapiv1afnordirectoryv1sirensearchpost"></a>
# **SearchSirenProxyApiV1AfnorDirectoryV1SirenSearchPost**
> AFNORSirenSearchPost200Response SearchSirenProxyApiV1AfnorDirectoryV1SirenSearchPost ()

SIREN search (or legal unit)

Multi-criteria company search.


### Parameters
This endpoint does not need any parameter.
### Return type

[**AFNORSirenSearchPost200Response**](AFNORSirenSearchPost200Response.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Returns one or more companies. |  -  |
| **206** | Request processed without error, but the volume of information returned has been reduced. |  -  |
| **400** | Bad request. The request is invalid or cannot be completed. |  -  |
| **401** | Unauthorized. The request requires user authentication. |  -  |
| **403** | Forbidden. The server understood the request but denied access or access is not authorized. |  -  |
| **404** | Not found. There is no resource at the given URI. |  -  |
| **408** | Request timeout exceeded. |  -  |
| **422** | Data validation error. |  -  |
| **429** | The client has issued too many calls within a given time frame. |  -  |
| **500** | Internal Server Error. |  -  |
| **501** | Not implemented. |  -  |
| **503** | Service unavailable. |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="searchsiretproxyapiv1afnordirectoryv1siretsearchpost"></a>
# **SearchSiretProxyApiV1AfnorDirectoryV1SiretSearchPost**
> AFNORSiretSearchPost200Response SearchSiretProxyApiV1AfnorDirectoryV1SiretSearchPost ()

Search for a SIRET (facility)

Multi-criteria search for facilities.


### Parameters
This endpoint does not need any parameter.
### Return type

[**AFNORSiretSearchPost200Response**](AFNORSiretSearchPost200Response.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Returns an establishment as defined on a given observation date or as defined on the current date if the observation date is not specified. |  -  |
| **206** | Request processed without error, but the volume of information returned has been reduced. |  -  |
| **400** | Bad request. The request is invalid or cannot be completed. |  -  |
| **401** | Unauthorized. The request requires user authentication. |  -  |
| **403** | Forbidden. The server understood the request but denied access or access is not authorized. |  -  |
| **404** | Not found. There is no resource at the given URI. |  -  |
| **408** | Request timeout exceeded. |  -  |
| **422** | Data validation error. |  -  |
| **429** | The client has issued too many calls within a given time frame. |  -  |
| **500** | Internal Server Error. |  -  |
| **501** | Not implemented. |  -  |
| **503** | Service unavailable. |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

