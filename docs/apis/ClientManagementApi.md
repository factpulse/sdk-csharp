# FactPulse.SDK.Api.ClientManagementApi

All URIs are relative to *https://factpulse.fr*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ActivateClientApiV1ClientsUidActiverPost**](ClientManagementApi.md#activateclientapiv1clientsuidactiverpost) | **POST** /api/v1/clients/{uid}/activer | Activate a client |
| [**CreateClientApiV1ClientsPost**](ClientManagementApi.md#createclientapiv1clientspost) | **POST** /api/v1/clients | Create a client |
| [**DeactivateClientApiV1ClientsUidDesactiverPost**](ClientManagementApi.md#deactivateclientapiv1clientsuiddesactiverpost) | **POST** /api/v1/clients/{uid}/desactiver | Deactivate a client |
| [**GetClientApiV1ClientsUidGet**](ClientManagementApi.md#getclientapiv1clientsuidget) | **GET** /api/v1/clients/{uid} | Get client details |
| [**GetPdpConfigApiV1ClientsUidPdpConfigGet**](ClientManagementApi.md#getpdpconfigapiv1clientsuidpdpconfigget) | **GET** /api/v1/clients/{uid}/pdp-config | Get client PDP configuration |
| [**ListClientsApiV1ClientsGet**](ClientManagementApi.md#listclientsapiv1clientsget) | **GET** /api/v1/clients | List clients |
| [**UpdateClientApiV1ClientsUidPatch**](ClientManagementApi.md#updateclientapiv1clientsuidpatch) | **PATCH** /api/v1/clients/{uid} | Update a client |
| [**UpdatePdpConfigApiV1ClientsUidPdpConfigPut**](ClientManagementApi.md#updatepdpconfigapiv1clientsuidpdpconfigput) | **PUT** /api/v1/clients/{uid}/pdp-config | Configure client PDP |

<a id="activateclientapiv1clientsuidactiverpost"></a>
# **ActivateClientApiV1ClientsUidActiverPost**
> ClientActivateResponse ActivateClientApiV1ClientsUidActiverPost (Guid uid)

Activate a client

Activate a deactivated client.  **Scope**: Client level (JWT with client_uid that must match {uid})


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **uid** | **Guid** |  |  |

### Return type

[**ClientActivateResponse**](ClientActivateResponse.md)

### Authorization

[HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **400** | Invalid request |  -  |
| **401** | Missing or invalid JWT token |  -  |
| **403** | Access denied |  -  |
| **404** | Client not found |  -  |
| **500** | Server error |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="createclientapiv1clientspost"></a>
# **CreateClientApiV1ClientsPost**
> ClientDetail CreateClientApiV1ClientsPost (ClientCreateRequest clientCreateRequest)

Create a client

Create a new client for the account.  **Scope**: Account level (JWT without client_uid)  **Fields**: - `name`: Client name (required) - `description`: Optional description - `siret`: Optional SIRET (14 digits)


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **clientCreateRequest** | [**ClientCreateRequest**](ClientCreateRequest.md) |  |  |

### Return type

[**ClientDetail**](ClientDetail.md)

### Authorization

[HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Successful Response |  -  |
| **400** | Invalid request |  -  |
| **401** | Missing or invalid JWT token |  -  |
| **403** | Access denied |  -  |
| **404** | Client not found |  -  |
| **500** | Server error |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="deactivateclientapiv1clientsuiddesactiverpost"></a>
# **DeactivateClientApiV1ClientsUidDesactiverPost**
> ClientActivateResponse DeactivateClientApiV1ClientsUidDesactiverPost (Guid uid)

Deactivate a client

Deactivate an active client.  **Scope**: Client level (JWT with client_uid that must match {uid})  **Note**: A deactivated client cannot be used for API calls (AFNOR, Chorus Pro, etc.).


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **uid** | **Guid** |  |  |

### Return type

[**ClientActivateResponse**](ClientActivateResponse.md)

### Authorization

[HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **400** | Invalid request |  -  |
| **401** | Missing or invalid JWT token |  -  |
| **403** | Access denied |  -  |
| **404** | Client not found |  -  |
| **500** | Server error |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getclientapiv1clientsuidget"></a>
# **GetClientApiV1ClientsUidGet**
> ClientDetail GetClientApiV1ClientsUidGet (Guid uid)

Get client details

Get details of a client.  **Scope**: Client level (JWT with client_uid that must match {uid})  **Security**: If the JWT contains a client_uid, it must match the {uid} in the URL, otherwise a 403 error is returned.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **uid** | **Guid** |  |  |

### Return type

[**ClientDetail**](ClientDetail.md)

### Authorization

[HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **400** | Invalid request |  -  |
| **401** | Missing or invalid JWT token |  -  |
| **403** | Access denied |  -  |
| **404** | Client not found |  -  |
| **500** | Server error |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getpdpconfigapiv1clientsuidpdpconfigget"></a>
# **GetPdpConfigApiV1ClientsUidPdpConfigGet**
> PDPConfigResponse GetPdpConfigApiV1ClientsUidPdpConfigGet (Guid uid)

Get client PDP configuration

Get the PDP (PA/PDP) configuration for a client.  **Scope**: Client level (JWT with client_uid that must match {uid})  **Security**: The client secret is never returned. Only a status (`secretStatus`) indicates whether a secret is configured.  **Response**: - If configured: all config details (URLs, client_id, secret status) - If not configured: `isConfigured: false` with a message


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **uid** | **Guid** |  |  |

### Return type

[**PDPConfigResponse**](PDPConfigResponse.md)

### Authorization

[HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **400** | Invalid request |  -  |
| **401** | Missing or invalid JWT token |  -  |
| **403** | Access denied |  -  |
| **404** | Client not found |  -  |
| **500** | Server error |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="listclientsapiv1clientsget"></a>
# **ListClientsApiV1ClientsGet**
> ClientListResponse ListClientsApiV1ClientsGet (int page = null, int pageSize = null)

List clients

Paginated list of clients for the account.  **Scope**: Account level (JWT without client_uid)  **Pagination**: - `page`: Page number (default: 1) - `pageSize`: Page size (default: 20, max: 100)


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **page** | **int** | Page number | [optional] [default to 1] |
| **pageSize** | **int** | Page size | [optional] [default to 20] |

### Return type

[**ClientListResponse**](ClientListResponse.md)

### Authorization

[HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **400** | Invalid request |  -  |
| **401** | Missing or invalid JWT token |  -  |
| **403** | Access denied |  -  |
| **404** | Client not found |  -  |
| **500** | Server error |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="updateclientapiv1clientsuidpatch"></a>
# **UpdateClientApiV1ClientsUidPatch**
> ClientDetail UpdateClientApiV1ClientsUidPatch (Guid uid, ClientUpdateRequest clientUpdateRequest)

Update a client

Update client information (partial update).  **Scope**: Client level (JWT with client_uid that must match {uid})  **Updatable fields**: - `name`: Client name - `description`: Description - `siret`: SIRET (14 digits)  Only provided fields are updated.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **uid** | **Guid** |  |  |
| **clientUpdateRequest** | [**ClientUpdateRequest**](ClientUpdateRequest.md) |  |  |

### Return type

[**ClientDetail**](ClientDetail.md)

### Authorization

[HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **400** | Invalid request |  -  |
| **401** | Missing or invalid JWT token |  -  |
| **403** | Access denied |  -  |
| **404** | Client not found |  -  |
| **500** | Server error |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="updatepdpconfigapiv1clientsuidpdpconfigput"></a>
# **UpdatePdpConfigApiV1ClientsUidPdpConfigPut**
> PDPConfigResponse UpdatePdpConfigApiV1ClientsUidPdpConfigPut (Guid uid, PDPConfigUpdateRequest pDPConfigUpdateRequest)

Configure client PDP

Configure or update the PDP (PA/PDP) configuration for a client.  **Scope**: Client level (JWT with client_uid that must match {uid})  **Required fields**: - `flowServiceUrl`: PDP Flow Service URL - `tokenUrl`: PDP OAuth token URL - `oauthClientId`: OAuth Client ID - `clientSecret`: OAuth Client Secret (sent but NEVER returned)  **Optional fields**: - `isActive`: Enable/disable the config (default: true) - `modeSandbox`: Sandbox mode (default: false)  **Security**: The `clientSecret` is stored encrypted on Django side and is never returned in API responses.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **uid** | **Guid** |  |  |
| **pDPConfigUpdateRequest** | [**PDPConfigUpdateRequest**](PDPConfigUpdateRequest.md) |  |  |

### Return type

[**PDPConfigResponse**](PDPConfigResponse.md)

### Authorization

[HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **400** | Invalid request |  -  |
| **401** | Missing or invalid JWT token |  -  |
| **403** | Access denied |  -  |
| **404** | Client not found |  -  |
| **500** | Server error |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

