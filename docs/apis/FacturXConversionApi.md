# FactPulse.SDK.Api.FacturXConversionApi

All URIs are relative to *https://factpulse.fr*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ConvertDocumentAsyncApiV1ConvertAsyncPost**](FacturXConversionApi.md#convertdocumentasyncapiv1convertasyncpost) | **POST** /api/v1/convert/async | Convert a document to Factur-X (async mode) |
| [**DownloadFileApiV1ConvertConversionIdDownloadFilenameGet**](FacturXConversionApi.md#downloadfileapiv1convertconversioniddownloadfilenameget) | **GET** /api/v1/convert/{conversion_id}/download/{filename} | Download a generated file |
| [**GetConversionStatusApiV1ConvertConversionIdStatusGet**](FacturXConversionApi.md#getconversionstatusapiv1convertconversionidstatusget) | **GET** /api/v1/convert/{conversion_id}/status | Check conversion status |
| [**ResumeConversionApiV1ConvertConversionIdResumePost**](FacturXConversionApi.md#resumeconversionapiv1convertconversionidresumepost) | **POST** /api/v1/convert/{conversion_id}/resume | Resume a conversion with corrections |

<a id="convertdocumentasyncapiv1convertasyncpost"></a>
# **ConvertDocumentAsyncApiV1ConvertAsyncPost**
> Object ConvertDocumentAsyncApiV1ConvertAsyncPost (System.IO.Stream file, string output = null, string callbackUrl = null, string webhookMode = null)

Convert a document to Factur-X (async mode)

Launch an asynchronous conversion via Celery.  ## Workflow  1. **Upload**: Document is sent as multipart/form-data 2. **Celery Task**: Task is queued for processing 3. **Callback**: Webhook notification on completion  ## Possible responses  - **202**: Task accepted, processing - **400**: Invalid file


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **file** | **System.IO.Stream****System.IO.Stream** | Document to convert (PDF, DOCX, XLSX, JPG, PNG) |  |
| **output** | **string** | Output format: pdf, xml, both | [optional] [default to &quot;pdf&quot;] |
| **callbackUrl** | **string** |  | [optional]  |
| **webhookMode** | **string** | Content delivery mode: &#39;inline&#39; (base64 in webhook) or &#39;download_url&#39; (temporary URL, 1h TTL) | [optional] [default to &quot;inline&quot;] |

### Return type

**Object**

### Authorization

[APIKeyHeader](../README.md#APIKeyHeader), [HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **202** | Task accepted |  -  |
| **400** | Invalid file |  -  |
| **422** | Validation Error |  -  |
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="downloadfileapiv1convertconversioniddownloadfilenameget"></a>
# **DownloadFileApiV1ConvertConversionIdDownloadFilenameGet**
> Object DownloadFileApiV1ConvertConversionIdDownloadFilenameGet (string conversionId, string filename)

Download a generated file

Download the generated Factur-X PDF or XML file.  ## Available files  - `facturx.pdf`: PDF/A-3 with embedded XML - `facturx.xml`: XML CII only (Cross Industry Invoice)  Files are available for 24 hours after generation.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **conversionId** | **string** | Conversion ID returned by POST /convert (UUID format) |  |
| **filename** | **string** | File to download: &#39;facturx.pdf&#39; or &#39;facturx.xml&#39; |  |

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
| **200** | File downloaded |  -  |
| **404** | File not found or expired |  -  |
| **422** | Validation Error |  -  |
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getconversionstatusapiv1convertconversionidstatusget"></a>
# **GetConversionStatusApiV1ConvertConversionIdStatusGet**
> Dictionary&lt;string, Object&gt; GetConversionStatusApiV1ConvertConversionIdStatusGet (string conversionId)

Check conversion status

Returns the current status of an asynchronous conversion.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **conversionId** | **string** | Conversion ID returned by POST /convert (UUID format) |  |

### Return type

**Dictionary<string, Object>**

### Authorization

[APIKeyHeader](../README.md#APIKeyHeader), [HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **422** | Validation Error |  -  |
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="resumeconversionapiv1convertconversionidresumepost"></a>
# **ResumeConversionApiV1ConvertConversionIdResumePost**
> ConvertSuccessResponse ResumeConversionApiV1ConvertConversionIdResumePost (string conversionId, ConvertResumeRequest convertResumeRequest)

Resume a conversion with corrections

Resume a conversion after completing missing data or correcting errors.  The OCR extraction is preserved, data is updated with corrections, then a new Schematron validation is performed.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **conversionId** | **string** | Conversion ID returned by POST /convert (UUID format) |  |
| **convertResumeRequest** | [**ConvertResumeRequest**](ConvertResumeRequest.md) |  |  |

### Return type

[**ConvertSuccessResponse**](ConvertSuccessResponse.md)

### Authorization

[APIKeyHeader](../README.md#APIKeyHeader), [HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **404** | Conversion not found or expired |  -  |
| **422** | Validation still failing |  -  |
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

