# FactPulse.SDK.Api.ParseApi

All URIs are relative to *https://factpulse.fr*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ParseFacturxAsyncApiV1ProcessingParseFacturxAsyncPost**](ParseApi.md#parsefacturxasyncapiv1processingparsefacturxasyncpost) | **POST** /api/v1/processing/parse-facturx/async | Parse Factur-X XML or PDF (async) |
| [**ParseFacturxSyncApiV1ProcessingParseFacturxPost**](ParseApi.md#parsefacturxsyncapiv1processingparsefacturxpost) | **POST** /api/v1/processing/parse-facturx | Parse CII, UBL or Factur-X PDF (sync) |

<a id="parsefacturxasyncapiv1processingparsefacturxasyncpost"></a>
# **ParseFacturxAsyncApiV1ProcessingParseFacturxAsyncPost**
> TaskResponse ParseFacturxAsyncApiV1ProcessingParseFacturxAsyncPost (System.IO.Stream file, string callbackUrl = null)

Parse Factur-X XML or PDF (async)

Parse a Factur-X file asynchronously using a Celery task.  **Use case:** For large files or when you want non-blocking processing.  **Workflow:** 1. Submit file with this endpoint -> receive `task_id` 2. Poll `/tasks/{task_id}/status` for result 3. Result contains `invoice` and `detected_profile`  **Optional:** Provide `callback_url` to receive a webhook when parsing completes.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **file** | **System.IO.Stream****System.IO.Stream** | Factur-X PDF or XML file to parse |  |
| **callbackUrl** | **string** |  | [optional]  |

### Return type

[**TaskResponse**](TaskResponse.md)

### Authorization

[APIKeyHeader](../README.md#APIKeyHeader), [HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **202** | Task created |  -  |
| **422** | Validation Error |  -  |
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="parsefacturxsyncapiv1processingparsefacturxpost"></a>
# **ParseFacturxSyncApiV1ProcessingParseFacturxPost**
> ParseFacturXResponse ParseFacturxSyncApiV1ProcessingParseFacturxPost (System.IO.Stream file)

Parse CII, UBL or Factur-X PDF (sync)

Parse a CII XML, UBL XML, or Factur-X PDF and extract the invoice data as a FacturXInvoice model.  **Use cases:** - Extract invoice data from received invoices (any format) - Round-trip: parse an existing invoice, modify it, and regenerate in another format - Convert between CII and UBL via the FacturXInvoice pivot model  **Supported formats:** - Factur-X PDF (PDF/A-3 with embedded CII XML) - CII XML (UN/CEFACT Cross-Industry Invoice) - UBL 2.1 XML (OASIS Invoice or CreditNote)  **Returns:** - `invoice`: Complete FacturXInvoice data (can be used with /generate-invoice) - `detected_profile`: Factur-X profile (MINIMUM, BASIC, EN16931, EXTENDED)


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **file** | **System.IO.Stream****System.IO.Stream** | Factur-X PDF or XML file to parse |  |

### Return type

[**ParseFacturXResponse**](ParseFacturXResponse.md)

### Authorization

[APIKeyHeader](../README.md#APIKeyHeader), [HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Invoice successfully parsed |  -  |
| **400** | Invalid file format or parsing error |  -  |
| **422** | Validation Error |  -  |
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

