# FactPulse.SDK.Api.DownloadsApi

All URIs are relative to *https://factpulse.fr*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CheckFileApiV1DownloadDownloadIdHead**](DownloadsApi.md#checkfileapiv1downloaddownloadidhead) | **HEAD** /api/v1/download/{download_id} | Check if a file exists |
| [**DownloadFileApiV1DownloadDownloadIdGet**](DownloadsApi.md#downloadfileapiv1downloaddownloadidget) | **GET** /api/v1/download/{download_id} | Download a temporary file |

<a id="checkfileapiv1downloaddownloadidhead"></a>
# **CheckFileApiV1DownloadDownloadIdHead**
> Object CheckFileApiV1DownloadDownloadIdHead (string downloadId)

Check if a file exists

Check if a temporary file exists and get its metadata without downloading.  Useful for: - Verifying a download URL is still valid - Getting file size before downloading - Checking expiration time  **Security**: Requires authentication, only file owner can check.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **downloadId** | **string** |  |  |

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
| **200** | File exists |  -  |
| **401** | Authentication required |  -  |
| **403** | Access denied |  -  |
| **404** | File not found or expired |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="downloadfileapiv1downloaddownloadidget"></a>
# **DownloadFileApiV1DownloadDownloadIdGet**
> Object DownloadFileApiV1DownloadDownloadIdGet (string downloadId, bool deleteAfter = null)

Download a temporary file

Download a file stored temporarily after asynchronous processing.  **Usage**: - This URL is provided in webhook notifications when using `webhook_mode: \"download_url\"` - Files are automatically deleted after 1 hour - Each file can only be downloaded until it expires  **Security**: - Requires a valid JWT token - Only the user who initiated the task can download the file


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **downloadId** | **string** |  |  |
| **deleteAfter** | **bool** | If true, delete the file after download (one-time download) | [optional] [default to false] |

### Return type

**Object**

### Authorization

[APIKeyHeader](../README.md#APIKeyHeader), [HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/pdf, application/xml, application/octet-stream


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | File content |  -  |
| **401** | Authentication required |  -  |
| **403** | Access denied - file belongs to another user |  -  |
| **404** | File not found or expired |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

