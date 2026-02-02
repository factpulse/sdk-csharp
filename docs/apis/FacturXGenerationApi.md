# FactPulse.SDK.Api.FacturXGenerationApi

All URIs are relative to *https://factpulse.fr*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GenerateInvoiceApiV1ProcessingGenerateInvoicePost**](FacturXGenerationApi.md#generateinvoiceapiv1processinggenerateinvoicepost) | **POST** /api/v1/processing/generate-invoice | Generate a Factur-X invoice |
| [**SubmitCompleteInvoiceApiV1ProcessingInvoicesSubmitCompletePost**](FacturXGenerationApi.md#submitcompleteinvoiceapiv1processinginvoicessubmitcompletepost) | **POST** /api/v1/processing/invoices/submit-complete | Submit a complete invoice (generation + signature + submission) |
| [**SubmitCompleteInvoiceAsyncApiV1ProcessingInvoicesSubmitCompleteAsyncPost**](FacturXGenerationApi.md#submitcompleteinvoiceasyncapiv1processinginvoicessubmitcompleteasyncpost) | **POST** /api/v1/processing/invoices/submit-complete-async | Submit a complete invoice (asynchronous with Celery) |

<a id="generateinvoiceapiv1processinggenerateinvoicepost"></a>
# **GenerateInvoiceApiV1ProcessingGenerateInvoicePost**
> TaskResponse GenerateInvoiceApiV1ProcessingGenerateInvoicePost (string invoiceData, APIProfile profile = null, OutputFormat outputFormat = null, bool autoEnrich = null, System.IO.Stream sourcePdf = null, string callbackUrl = null, string webhookMode = null, bool skipBrFr = null)

Generate a Factur-X invoice

Generates an electronic invoice in Factur-X format compliant with European standards.  ## Applied Standards  - **Factur-X** (France): FNFE-MPE standard (Forum National de la Facture Électronique) - **ZUGFeRD** (Germany): German format compatible with Factur-X - **EN 16931**: European semantic standard for electronic invoicing - **ISO 19005-3** (PDF/A-3): Long-term electronic archiving - **Cross Industry Invoice (CII)**: UN/CEFACT XML syntax  ## 🆕 New: Simplified format with auto-enrichment (P0.1)  You can now create an invoice by providing only: - An invoice number - A supplier SIRET + **IBAN** (required) - A recipient SIRET - Invoice lines (description, quantity, net price)  **Simplified format example**: ```json {   \"number\": \"FACT-2025-001\",   \"supplier\": {     \"siret\": \"92019522900017\",     \"iban\": \"FR7630001007941234567890185\"   },   \"recipient\": {\"siret\": \"35600000000048\"},   \"lines\": [     {\"description\": \"Service\", \"quantity\": 10, \"unitPrice\": 100.00, \"vatRate\": 20.0}   ] } ```  **⚠️ Required fields (simplified format)**: - `number`: Unique invoice number - `supplier.siret`: Supplier's SIRET (14 digits) - `supplier.iban`: Bank account IBAN (no public API to retrieve it) - `recipient.siret`: Recipient's SIRET - `lines[]`: At least one invoice line  **What happens automatically with `auto_enrich=True`**: - ✅ Name enrichment from Chorus Pro API - ✅ Address enrichment from Business Search API (free, public) - ✅ Automatic intra-EU VAT calculation (FR + key + SIREN) - ✅ Chorus Pro ID retrieval for electronic invoicing - ✅ Net/VAT/Gross totals calculation - ✅ Date generation (today + 30-day due date) - ✅ Multi-rate VAT handling  **Supported identifiers**: - SIRET (14 digits): Specific establishment ⭐ Recommended - SIREN (9 digits): Company (auto-selection of headquarters) - Special types: UE_HORS_FRANCE, RIDET, TAHITI, etc.  ## Checks performed during generation  ### 1. Data validation (Pydantic) - Data types (amounts as Decimal, ISO 8601 dates) - Formats (14-digit SIRET, 9-digit SIREN, IBAN) - Required fields per profile - Amount consistency (Net + VAT = Gross)  ### 2. CII-compliant XML generation - Serialization according to Cross Industry Invoice XSD schema - Correct UN/CEFACT namespaces - Hierarchical structure respected - UTF-8 encoding without BOM  ### 3. Schematron validation - Business rules for selected profile (MINIMUM, BASIC, EN16931, EXTENDED) - Element cardinality (required, optional, repeatable) - Calculation rules (totals, VAT, discounts) - European EN 16931 compliance  ### 4. PDF/A-3 conversion (if output_format='pdf') - Source PDF conversion to PDF/A-3 via Ghostscript - Factur-X XML embedding in PDF - Compliant XMP metadata - ICC sRGB color profile - Removal of forbidden elements (JavaScript, forms)  ## How it works  1. **Submission**: Invoice is queued in Celery for asynchronous processing 2. **Immediate return**: You receive a `task_id` (HTTP 202 Accepted) 3. **Tracking**: Use the `/tasks/{task_id}/status` endpoint to track progress  ## Webhook notification (recommended)  Instead of polling, you can receive a webhook notification when the task completes:  ``` callback_url=https://your-server.com/webhook ```  The webhook will POST a JSON payload with: - `event_type`: `generation.completed` or `generation.failed` - `data.task_id`: The Celery task ID - `data.content_b64` or `data.xml_content`: The generated content - `X-Webhook-Signature` header for HMAC verification  See `/docs/WEBHOOKS.md` for full documentation.  ## Output formats  - **xml**: Generates only Factur-X XML (recommended for testing) - **pdf**: Generates PDF/A-3 with embedded XML (requires `source_pdf`)  ## Factur-X profiles  - **MINIMUM**: Minimal data (simplified invoice) - **BASIC**: Basic information (SMEs) - **EN16931**: European standard (recommended, compliant with directive 2014/55/EU) - **EXTENDED**: All available data (large accounts)  ## What you get  After successful processing (status `completed`): - **XML only**: Base64-encoded Factur-X compliant XML file - **PDF/A-3**: PDF with embedded XML, ready for sending/archiving - **Metadata**: Profile, Factur-X version, file size - **Validation**: Schematron compliance confirmation  ## Validation  Data is automatically validated according to detected format. On error, a 422 status is returned with invalid field details.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **invoiceData** | **string** | Invoice data in JSON format.              Two formats accepted:             1. **Classic format**: Complete FacturXInvoice structure (all fields)             2. **Simplified format** (🆕 P0.1): Minimal structure with auto-enrichment              Format is detected automatically!              |  |
| **profile** | **APIProfile** | Factur-X profile: MINIMUM, BASIC, EN16931 or EXTENDED. | [optional]  |
| **outputFormat** | **OutputFormat** | Output format: &#39;xml&#39; (XML only) or &#39;pdf&#39; (Factur-X PDF with embedded XML). | [optional]  |
| **autoEnrich** | **bool** | 🆕 Enable auto-enrichment from SIRET/SIREN (simplified format only) | [optional] [default to true] |
| **sourcePdf** | **System.IO.Stream****System.IO.Stream** |  | [optional]  |
| **callbackUrl** | **string** |  | [optional]  |
| **webhookMode** | **string** | Webhook content delivery: &#39;inline&#39; (base64 in payload) or &#39;download_url&#39; (temporary URL, 1h TTL) | [optional] [default to &quot;inline&quot;] |
| **skipBrFr** | **bool** |  | [optional]  |

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
| **202** | Successful Response |  -  |
| **400** | Invalid invoice data or missing PDF file |  -  |
| **422** | Invoice data validation error |  -  |
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="submitcompleteinvoiceapiv1processinginvoicessubmitcompletepost"></a>
# **SubmitCompleteInvoiceApiV1ProcessingInvoicesSubmitCompletePost**
> SubmitCompleteInvoiceResponse SubmitCompleteInvoiceApiV1ProcessingInvoicesSubmitCompletePost (SubmitCompleteInvoiceRequest submitCompleteInvoiceRequest)

Submit a complete invoice (generation + signature + submission)

Unified endpoint to submit a complete invoice to different destinations.     **Facture prête pour Flux 2** - Génère une facture Factur-X complète avec signature optionnelle et soumission vers Chorus Pro ou PDP AFNOR.      **Automated workflow:**     1. **Auto-enrichment** (optional): retrieves data via public APIs and Chorus Pro/AFNOR     2. **Factur-X PDF generation**: creates a PDF/A-3 with embedded XML     3. **Electronic signature** (optional): signs the PDF with a certificate     4. **Submission**: sends to the chosen destination (Chorus Pro or AFNOR PDP)      **Supported destinations:**     - **Chorus Pro**: French B2G platform (invoices to public sector)     - **AFNOR PDP**: Partner Dematerialization Platforms      **Destination credentials - 2 modes available:**      **Mode 1 - Retrieval via JWT (recommended):**     - Credentials are retrieved automatically via the JWT `client_uid`     - Do not provide the `credentials` field in `destination`     - Zero-trust architecture: no secrets in the payload     - Example: `\"destination\": {\"type\": \"chorus_pro\"}`      **Mode 2 - Credentials in the payload:**     - Provide credentials directly in the payload     - Useful for tests or third-party integrations     - Example: `\"destination\": {\"type\": \"chorus_pro\", \"credentials\": {...}}`       **Electronic signature (optional) - 2 modes available:**      **Mode 1 - Stored certificate (recommended):**     - Certificate is retrieved automatically via the JWT `client_uid`     - No key to provide in the payload     - PAdES-B-LT signature with timestamp (eIDAS compliant)     - Example: `\"signature\": {\"reason\": \"Factur-X compliance\"}`      **Mode 2 - Keys in the payload (for tests):**     - Provide `key_pem` and `cert_pem` directly     - PEM format accepted: raw or base64     - Useful for tests or special cases without stored certificate     - Example: `\"signature\": {\"key_pem\": \"- -- --BEGIN...\", \"cert_pem\": \"- -- --BEGIN...\"}`      If `key_pem` and `cert_pem` are provided → Mode 2     Otherwise → Mode 1 (certificate retrieved via `client_uid`)


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **submitCompleteInvoiceRequest** | [**SubmitCompleteInvoiceRequest**](SubmitCompleteInvoiceRequest.md) |  |  |

### Return type

[**SubmitCompleteInvoiceResponse**](SubmitCompleteInvoiceResponse.md)

### Authorization

[APIKeyHeader](../README.md#APIKeyHeader), [HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **422** | Validation Error |  -  |
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="submitcompleteinvoiceasyncapiv1processinginvoicessubmitcompleteasyncpost"></a>
# **SubmitCompleteInvoiceAsyncApiV1ProcessingInvoicesSubmitCompleteAsyncPost**
> TaskResponse SubmitCompleteInvoiceAsyncApiV1ProcessingInvoicesSubmitCompleteAsyncPost (SubmitCompleteInvoiceRequest submitCompleteInvoiceRequest, string callbackUrl = null, string webhookMode = null)

Submit a complete invoice (asynchronous with Celery)

Asynchronous version of the `/invoices/submit-complete` endpoint using Celery for background processing.     **Facture prête pour Flux 2** - Génère une facture Factur-X complète de manière asynchrone.      **Automated workflow (same as synchronous version):**     1. **Auto-enrichment** (optional): retrieves data via public APIs and Chorus Pro/AFNOR     2. **Factur-X PDF generation**: creates a PDF/A-3 with embedded XML     3. **Electronic signature** (optional): signs the PDF with a certificate     4. **Submission**: sends to the chosen destination (Chorus Pro or AFNOR PDP)      **Supported destinations:**     - **Chorus Pro**: French B2G platform (invoices to public sector)     - **AFNOR PDP**: Partner Dematerialization Platforms      **Differences with synchronous version:**     - ✅ **Non-blocking**: Returns immediately with a `task_id` (HTTP 202 Accepted)     - ✅ **Background processing**: Invoice is processed by a Celery worker     - ✅ **Progress tracking**: Use `/tasks/{task_id}/status` to track status     - ✅ **Ideal for high volumes**: Allows processing many invoices in parallel      **How to use:**     1. **Submission**: Call this endpoint with your invoice data     2. **Immediate return**: You receive a `task_id` (e.g., \"abc123-def456\")     3. **Tracking**: Call `/tasks/{task_id}/status` to check progress     4. **Result**: When `status = \"SUCCESS\"`, the `result` field contains the complete response      **Webhook notification (recommended):**      Instead of polling, add `?callback_url=https://your-server.com/webhook` to receive automatic notification:     - `event_type`: `submission.completed`, `submission.failed`, or `submission.partial`     - `data.submission_result`: Complete submission result     - `X-Webhook-Signature` header for HMAC verification      **Credentials and signature**: Same modes as the synchronous version (JWT or payload).


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **submitCompleteInvoiceRequest** | [**SubmitCompleteInvoiceRequest**](SubmitCompleteInvoiceRequest.md) |  |  |
| **callbackUrl** | **string** | Webhook URL for async notification when submission completes. | [optional]  |
| **webhookMode** | **string** | Webhook content delivery: &#39;inline&#39; (base64 in payload) or &#39;download_url&#39; (temporary URL, 1h TTL) | [optional] [default to &quot;inline&quot;] |

### Return type

[**TaskResponse**](TaskResponse.md)

### Authorization

[APIKeyHeader](../README.md#APIKeyHeader), [HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **202** | Successful Response |  -  |
| **422** | Validation Error |  -  |
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

