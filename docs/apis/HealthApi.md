# FactPulse.SDK.Api.HealthApi

All URIs are relative to *https://factpulse.fr*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetUserInfoApiV1MeGet**](HealthApi.md#getuserinfoapiv1meget) | **GET** /api/v1/me | Get current user information |
| [**HealthcheckHealthcheckGet**](HealthApi.md#healthcheckhealthcheckget) | **GET** /healthcheck | Docker healthcheck endpoint |
| [**RootGet**](HealthApi.md#rootget) | **GET** / | Check API status |

<a id="getuserinfoapiv1meget"></a>
# **GetUserInfoApiV1MeGet**
> Object GetUserInfoApiV1MeGet ()

Get current user information

Returns information about the authenticated user.  This endpoint allows you to: - Verify that authentication works - Get connected account details - Test JWT token validity - Check your consumption quota  **Requires valid authentication.**


### Parameters
This endpoint does not need any parameter.
### Return type

**Object**

### Authorization

[APIKeyHeader](../README.md#APIKeyHeader), [HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | User information |  -  |
| **401** | Missing or invalid JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="healthcheckhealthcheckget"></a>
# **HealthcheckHealthcheckGet**
> Object HealthcheckHealthcheckGet ()

Docker healthcheck endpoint

Healthcheck endpoint for Docker and load balancers.  Useful for: - Docker healthcheck - Kubernetes liveness/readiness probes - Load balancers (Nginx, HAProxy) - Availability monitoring - Zero downtime deployment  Returns a 200 code if the API is operational.


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
| **200** | API is healthy |  -  |
| **500** | Internal server error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="rootget"></a>
# **RootGet**
> Object RootGet ()

Check API status

Health check endpoint to verify the API is responding.  Useful for: - Availability monitoring - Integration tests - Load balancers


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
| **200** | API is operational |  -  |
| **500** | Internal server error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

