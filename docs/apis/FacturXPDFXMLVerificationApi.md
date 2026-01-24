# FactPulse.SDK.Api.FacturXPDFXMLVerificationApi

All URIs are relative to *https://factpulse.fr*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetVerificationStatusApiV1VerificationVerifyAsyncTaskIdStatusGet**](FacturXPDFXMLVerificationApi.md#getverificationstatusapiv1verificationverifyasynctaskidstatusget) | **GET** /api/v1/verification/verify-async/{task_id}/status | Get status of an asynchronous verification |
| [**VerifyPdfAsyncApiV1VerificationVerifyAsyncPost**](FacturXPDFXMLVerificationApi.md#verifypdfasyncapiv1verificationverifyasyncpost) | **POST** /api/v1/verification/verify-async | Verify PDF/XML Factur-X compliance (asynchronous) |
| [**VerifyPdfSyncApiV1VerificationVerifyPost**](FacturXPDFXMLVerificationApi.md#verifypdfsyncapiv1verificationverifypost) | **POST** /api/v1/verification/verify | Verify PDF/XML Factur-X compliance (synchronous) |

<a id="getverificationstatusapiv1verificationverifyasynctaskidstatusget"></a>
# **GetVerificationStatusApiV1VerificationVerifyAsyncTaskIdStatusGet**
> AsyncTaskStatus GetVerificationStatusApiV1VerificationVerifyAsyncTaskIdStatusGet (string taskId)

Get status of an asynchronous verification

Retrieves the status and result of an asynchronous verification task.  **Possible statuses:** - `PENDING`: Task waiting in queue - `STARTED`: Task currently running - `SUCCESS`: Task completed successfully (see `result`) - `FAILURE`: System error (unhandled exception)  **Note:** The `result.status` field can be \"SUCCESS\" or \"ERROR\" independently of Celery status (which will always be SUCCESS if the task ran).


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **taskId** | **string** | Celery task ID returned by /verify-async endpoint |  |

### Return type

[**AsyncTaskStatus**](AsyncTaskStatus.md)

### Authorization

[HTTPBearer](../README.md#HTTPBearer)

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

<a id="verifypdfasyncapiv1verificationverifyasyncpost"></a>
# **VerifyPdfAsyncApiV1VerificationVerifyAsyncPost**
> TaskResponse VerifyPdfAsyncApiV1VerificationVerifyAsyncPost (System.IO.Stream pdfFile, bool forceOcr = null, string callbackUrl = null, string webhookMode = null)

Verify PDF/XML Factur-X compliance (asynchronous)

Verifies PDF/XML Factur-X compliance asynchronously.  **IMPORTANT**: Only Factur-X PDFs (with embedded XML) are accepted. PDFs without Factur-X XML will return a `NOT_FACTURX` error in the result.  This version uses a Celery task and can call the OCR service if the PDF is an image or if `force_ocr=true`.  **Returns immediately** a task ID. Use `/verify-async/{task_id}/status` to retrieve the result.  **Verification principle (Factur-X 1.08):** - Principle #2: XML can only contain info present in the PDF - Principle #4: All XML info must be present and compliant in the PDF  **Verified fields:** - Identification: BT-1 (invoice #), BT-2 (date), BT-3 (type), BT-5 (currency), BT-23 (framework) - Seller: BT-27 (name), BT-29 (SIRET), BT-30 (SIREN), BT-31 (VAT) - Buyer: BT-44 (name), BT-46 (SIRET), BT-47 (SIREN), BT-48 (VAT) - Amounts: BT-109 (excl. tax), BT-110 (VAT), BT-112 (incl. tax), BT-115 (amount due) - VAT breakdown: BT-116, BT-117, BT-118, BT-119 - Invoice lines: BT-153, BT-129, BT-146, BT-131 - Mandatory notes: PMT, PMD, AAB - Rule BR-FR-09: SIRET/SIREN consistency  **Advantages over synchronous version:** - OCR support for image PDFs (via DocTR service) - Longer timeout for large documents - Doesn't block the server  ## Webhook notification (recommended)  Instead of polling, you can receive a webhook notification when verification completes:  ``` callback_url=https://your-server.com/webhook ```  The webhook will POST a JSON payload with: - `event_type`: `verification.completed` or `verification.failed` - `data.is_compliant`: Whether the PDF/XML are consistent - `data.compliance_score`: Compliance score (0-1) - `X-Webhook-Signature` header for HMAC verification


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **pdfFile** | **System.IO.Stream****System.IO.Stream** | Factur-X PDF file to verify |  |
| **forceOcr** | **bool** | Force OCR usage even if PDF contains native text | [optional] [default to false] |
| **callbackUrl** | **string** |  | [optional]  |
| **webhookMode** | **string** | Webhook content delivery: &#39;inline&#39; (base64 in payload) or &#39;download_url&#39; (temporary URL, 1h TTL) | [optional] [default to &quot;inline&quot;] |

### Return type

[**TaskResponse**](TaskResponse.md)

### Authorization

[HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **202** | Successful Response |  -  |
| **422** | Validation Error |  -  |
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="verifypdfsyncapiv1verificationverifypost"></a>
# **VerifyPdfSyncApiV1VerificationVerifyPost**
> VerificationSuccessResponse VerifyPdfSyncApiV1VerificationVerifyPost (System.IO.Stream pdfFile)

Verify PDF/XML Factur-X compliance (synchronous)

Verifies compliance between the PDF and its embedded Factur-X XML.  **IMPORTANT**: Only Factur-X PDFs (with embedded XML) are accepted. PDFs without Factur-X XML will be rejected with a 400 error.  This synchronous version uses only native PDF extraction (pdfplumber). For image PDFs requiring OCR, use the `/verify-async` endpoint.  **Verification principle (Factur-X 1.08):** - Principle #2: XML can only contain info present in the PDF - Principle #4: All XML info must be present and compliant in the PDF  **Verified fields:** - Identification: BT-1 (invoice #), BT-2 (date), BT-3 (type), BT-5 (currency), BT-23 (framework) - Seller: BT-27 (name), BT-29 (SIRET), BT-30 (SIREN), BT-31 (VAT) - Buyer: BT-44 (name), BT-46 (SIRET), BT-47 (SIREN), BT-48 (VAT) - Amounts: BT-109 (excl. tax), BT-110 (VAT), BT-112 (incl. tax), BT-115 (amount due) - VAT breakdown: BT-116, BT-117, BT-118, BT-119 - Invoice lines: BT-153, BT-129, BT-146, BT-131 - Mandatory notes: PMT, PMD, AAB - Rule BR-FR-09: SIRET/SIREN consistency


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **pdfFile** | **System.IO.Stream****System.IO.Stream** | Factur-X PDF file to verify |  |

### Return type

[**VerificationSuccessResponse**](VerificationSuccessResponse.md)

### Authorization

[HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Verification successful |  -  |
| **400** | Verification error (non Factur-X PDF, invalid, etc.) |  -  |
| **413** | PDF too large or too many pages |  -  |
| **422** | Validation Error |  -  |
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

