# FactPulse.SDK.Api.HealthApi

All URIs are relative to *https://factpulse.fr*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetUserInfoApiV1MeGet**](HealthApi.md#getuserinfoapiv1meget) | **GET** /api/v1/me | Get current user information |

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

