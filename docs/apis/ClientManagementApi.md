# FactPulse.SDK.Api.ClientManagementApi

All URIs are relative to *https://factpulse.fr*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ActivateClientApiV1ClientsUidActiverPost**](ClientManagementApi.md#activateclientapiv1clientsuidactiverpost) | **POST** /api/v1/clients/{uid}/activer | Activate a client |
| [**CreateClientApiV1ClientsPost**](ClientManagementApi.md#createclientapiv1clientspost) | **POST** /api/v1/clients | Create a client |
| [**DeactivateClientApiV1ClientsUidDesactiverPost**](ClientManagementApi.md#deactivateclientapiv1clientsuiddesactiverpost) | **POST** /api/v1/clients/{uid}/desactiver | Deactivate a client |
| [**DeleteWebhookSecretApiV1ClientsUidWebhookSecretDelete**](ClientManagementApi.md#deletewebhooksecretapiv1clientsuidwebhooksecretdelete) | **DELETE** /api/v1/clients/{uid}/webhook-secret | Delete webhook secret |
| [**GenerateWebhookSecretApiV1ClientsUidWebhookSecretGeneratePost**](ClientManagementApi.md#generatewebhooksecretapiv1clientsuidwebhooksecretgeneratepost) | **POST** /api/v1/clients/{uid}/webhook-secret/generate | Generate webhook secret |
| [**GetClientApiV1ClientsUidGet**](ClientManagementApi.md#getclientapiv1clientsuidget) | **GET** /api/v1/clients/{uid} | Get client details |
| [**GetPdpConfigApiV1ClientsUidPdpConfigGet**](ClientManagementApi.md#getpdpconfigapiv1clientsuidpdpconfigget) | **GET** /api/v1/clients/{uid}/pdp-config | Get client PDP configuration |
| [**GetWebhookSecretStatusApiV1ClientsUidWebhookSecretStatusGet**](ClientManagementApi.md#getwebhooksecretstatusapiv1clientsuidwebhooksecretstatusget) | **GET** /api/v1/clients/{uid}/webhook-secret/status | Get webhook secret status |
| [**ListClientsApiV1ClientsGet**](ClientManagementApi.md#listclientsapiv1clientsget) | **GET** /api/v1/clients | List clients |
| [**RotateEncryptionKeyApiV1ClientsUidRotateEncryptionKeyPost**](ClientManagementApi.md#rotateencryptionkeyapiv1clientsuidrotateencryptionkeypost) | **POST** /api/v1/clients/{uid}/rotate-encryption-key | Rotate client encryption key |
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

[APIKeyHeader](../README.md#APIKeyHeader), [HTTPBearer](../README.md#HTTPBearer)

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

[APIKeyHeader](../README.md#APIKeyHeader), [HTTPBearer](../README.md#HTTPBearer)

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

[APIKeyHeader](../README.md#APIKeyHeader), [HTTPBearer](../README.md#HTTPBearer)

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

<a id="deletewebhooksecretapiv1clientsuidwebhooksecretdelete"></a>
# **DeleteWebhookSecretApiV1ClientsUidWebhookSecretDelete**
> WebhookSecretDeleteResponse DeleteWebhookSecretApiV1ClientsUidWebhookSecretDelete (Guid uid)

Delete webhook secret

Delete the webhook secret for a client.  **Scope**: Client level (JWT with client_uid that must match {uid})  **After deletion**: Webhooks for this client will use the global server key for HMAC signature instead of a client-specific key.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **uid** | **Guid** |  |  |

### Return type

[**WebhookSecretDeleteResponse**](WebhookSecretDeleteResponse.md)

### Authorization

[APIKeyHeader](../README.md#APIKeyHeader), [HTTPBearer](../README.md#HTTPBearer)

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

<a id="generatewebhooksecretapiv1clientsuidwebhooksecretgeneratepost"></a>
# **GenerateWebhookSecretApiV1ClientsUidWebhookSecretGeneratePost**
> WebhookSecretGenerateResponse GenerateWebhookSecretApiV1ClientsUidWebhookSecretGeneratePost (Guid uid)

Generate webhook secret

Generate or regenerate the webhook secret for a client.  **Scope**: Client level (JWT with client_uid that must match {uid})  **Important**: Save the returned secret immediately - it will never be shown again. The secret is used to sign webhooks sent by the server (HMAC-SHA256).  **If a secret already exists**: It will be replaced by the new one.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **uid** | **Guid** |  |  |

### Return type

[**WebhookSecretGenerateResponse**](WebhookSecretGenerateResponse.md)

### Authorization

[APIKeyHeader](../README.md#APIKeyHeader), [HTTPBearer](../README.md#HTTPBearer)

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

[APIKeyHeader](../README.md#APIKeyHeader), [HTTPBearer](../README.md#HTTPBearer)

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

[APIKeyHeader](../README.md#APIKeyHeader), [HTTPBearer](../README.md#HTTPBearer)

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

<a id="getwebhooksecretstatusapiv1clientsuidwebhooksecretstatusget"></a>
# **GetWebhookSecretStatusApiV1ClientsUidWebhookSecretStatusGet**
> WebhookSecretStatusResponse GetWebhookSecretStatusApiV1ClientsUidWebhookSecretStatusGet (Guid uid)

Get webhook secret status

Check if a webhook secret is configured for a client.  **Scope**: Client level (JWT with client_uid that must match {uid})  **Response**: - `hasSecret`: Whether a webhook secret is configured - `createdAt`: When the secret was created (if exists)  **Note**: The secret value is never returned, only its status.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **uid** | **Guid** |  |  |

### Return type

[**WebhookSecretStatusResponse**](WebhookSecretStatusResponse.md)

### Authorization

[APIKeyHeader](../README.md#APIKeyHeader), [HTTPBearer](../README.md#HTTPBearer)

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

[APIKeyHeader](../README.md#APIKeyHeader), [HTTPBearer](../README.md#HTTPBearer)

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

<a id="rotateencryptionkeyapiv1clientsuidrotateencryptionkeypost"></a>
# **RotateEncryptionKeyApiV1ClientsUidRotateEncryptionKeyPost**
> KeyRotationResponse RotateEncryptionKeyApiV1ClientsUidRotateEncryptionKeyPost (Guid uid, KeyRotationRequest keyRotationRequest)

Rotate client encryption key

Rotate the client encryption key for all secrets in double encryption mode.  **Scope**: Client level (JWT with client_uid that must match {uid})  **What this does**: 1. Decrypts all secrets (PDP, Chorus Pro) using the old key 2. Re-encrypts them using the new key 3. Saves to database  **Important notes**: - Both keys must be base64-encoded AES-256 keys (32 bytes each) - The old key becomes invalid immediately after rotation - Only secrets encrypted with `encryptionMode: \"double\"` are affected - If the client has no double-encrypted secrets, returns 404  **Security**: - The old key must be valid (decryption is verified) - If decryption fails, rotation is aborted (atomic operation) - Neither key is logged or stored by the server


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **uid** | **Guid** |  |  |
| **keyRotationRequest** | [**KeyRotationRequest**](KeyRotationRequest.md) |  |  |

### Return type

[**KeyRotationResponse**](KeyRotationResponse.md)

### Authorization

[APIKeyHeader](../README.md#APIKeyHeader), [HTTPBearer](../README.md#HTTPBearer)

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

[APIKeyHeader](../README.md#APIKeyHeader), [HTTPBearer](../README.md#HTTPBearer)

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
> PDPConfigResponse UpdatePdpConfigApiV1ClientsUidPdpConfigPut (Guid uid, PDPConfigUpdateRequest pDPConfigUpdateRequest, string xEncryptionKey = null)

Configure client PDP

Configure or update the PDP (PA/PDP) configuration for a client.  **Scope**: Client level (JWT with client_uid that must match {uid})  **Required fields**: - `flowServiceUrl`: PDP Flow Service URL - `tokenUrl`: PDP OAuth token URL - `oauthClientId`: OAuth Client ID - `clientSecret`: OAuth Client Secret (sent but NEVER returned)  **Optional fields**: - `isActive`: Enable/disable the config (default: true) - `modeSandbox`: Sandbox mode (default: false) - `encryptionMode`: Encryption mode (default: \"fernet\")   - \"fernet\": Server-side encryption only   - \"double\": Client AES-256-GCM + Server Fernet (requires X-Encryption-Key header)  **Double Encryption Mode**: When `encryptionMode` is set to \"double\", you MUST also provide the `X-Encryption-Key` header containing a base64-encoded AES-256 key (32 bytes). This key is used to encrypt the `clientSecret` on the client side before the server encrypts it again with Fernet. The server cannot decrypt the secret without the client key.  **Security**: The `clientSecret` is stored encrypted on Django side and is never returned in API responses.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **uid** | **Guid** |  |  |
| **pDPConfigUpdateRequest** | [**PDPConfigUpdateRequest**](PDPConfigUpdateRequest.md) |  |  |
| **xEncryptionKey** | **string** | Client encryption key for double encryption mode. Must be a base64-encoded AES-256 key (32 bytes). Required only when accessing resources encrypted with encryption_mode&#x3D;&#39;double&#39;. | [optional]  |

### Return type

[**PDPConfigResponse**](PDPConfigResponse.md)

### Authorization

[APIKeyHeader](../README.md#APIKeyHeader), [HTTPBearer](../README.md#HTTPBearer)

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

