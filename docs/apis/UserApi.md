# FactPulse.SDK.Api.UserApi

All URIs are relative to *http://localhost*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetUserInfoApiV1MeGet**](UserApi.md#getuserinfoapiv1meget) | **GET** /api/v1/me | Get current user information |

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

[HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | User information |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

