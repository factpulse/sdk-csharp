# FactPulse.SDK.Api.EReportingApi

All URIs are relative to *https://factpulse.fr*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GenerateAggregatedEreportingApiV1EreportingGenerateAggregatedPost**](EReportingApi.md#generateaggregatedereportingapiv1ereportinggenerateaggregatedpost) | **POST** /api/v1/ereporting/generate-aggregated | Generate aggregated e-reporting XML (PPF-compliant) |
| [**GenerateEreportingApiV1EreportingGeneratePost**](EReportingApi.md#generateereportingapiv1ereportinggeneratepost) | **POST** /api/v1/ereporting/generate | Generate e-reporting XML |
| [**GenerateEreportingDownloadApiV1EreportingGenerateDownloadPost**](EReportingApi.md#generateereportingdownloadapiv1ereportinggeneratedownloadpost) | **POST** /api/v1/ereporting/generate/download | Generate and download e-reporting XML |
| [**ListCategoryCodesApiV1EreportingCategoryCodesGet**](EReportingApi.md#listcategorycodesapiv1ereportingcategorycodesget) | **GET** /api/v1/ereporting/category-codes | List PPF-compliant category codes |
| [**ListFlowTypesApiV1EreportingFlowTypesGet**](EReportingApi.md#listflowtypesapiv1ereportingflowtypesget) | **GET** /api/v1/ereporting/flow-types | List available flow types |
| [**SubmitAggregatedEreportingApiV1EreportingSubmitAggregatedPost**](EReportingApi.md#submitaggregatedereportingapiv1ereportingsubmitaggregatedpost) | **POST** /api/v1/ereporting/submit-aggregated | Submit aggregated e-reporting to PA/PDP |
| [**SubmitEreportingApiV1EreportingSubmitPost**](EReportingApi.md#submitereportingapiv1ereportingsubmitpost) | **POST** /api/v1/ereporting/submit | Submit e-reporting to PA/PDP |
| [**SubmitXmlEreportingApiV1EreportingSubmitXmlPost**](EReportingApi.md#submitxmlereportingapiv1ereportingsubmitxmlpost) | **POST** /api/v1/ereporting/submit-xml | Submit pre-generated e-reporting XML |
| [**ValidateAggregatedEreportingApiV1EreportingValidateAggregatedPost**](EReportingApi.md#validateaggregatedereportingapiv1ereportingvalidateaggregatedpost) | **POST** /api/v1/ereporting/validate-aggregated | Validate aggregated e-reporting data |
| [**ValidateEreportingApiV1EreportingValidatePost**](EReportingApi.md#validateereportingapiv1ereportingvalidatepost) | **POST** /api/v1/ereporting/validate | Validate e-reporting data |
| [**ValidateXmlEreportingApiV1EreportingValidateXmlPost**](EReportingApi.md#validatexmlereportingapiv1ereportingvalidatexmlpost) | **POST** /api/v1/ereporting/validate-xml | Validate e-reporting XML against PPF XSD schemas and business rules |

<a id="generateaggregatedereportingapiv1ereportinggenerateaggregatedpost"></a>
# **GenerateAggregatedEreportingApiV1EreportingGenerateAggregatedPost**
> GenerateAggregatedReportResponse GenerateAggregatedEreportingApiV1EreportingGenerateAggregatedPost (CreateAggregatedReportRequest createAggregatedReportRequest)

Generate aggregated e-reporting XML (PPF-compliant)

Generate a PPF-compliant aggregated e-reporting XML containing multiple flux types in a single file.  This endpoint creates a Report XML that can contain: - **TransactionsReport**: Invoice (10.1) AND/OR Transactions (10.3) - **PaymentsReport**: Invoice payments (10.2) AND/OR Transaction payments (10.4)  The AFNOR FlowType is automatically determined based on content: - Single type → Specific FlowType (e.g., AggregatedCustomerTransactionReport) - Multiple types → MultiFlowReport  **CategoryCode (TT-81)** must use PPF-compliant values: - TLB1: Goods deliveries - TPS1: Service provisions - TNT1: Non-taxed transactions - TMA1: Mixed transactions


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **createAggregatedReportRequest** | [**CreateAggregatedReportRequest**](CreateAggregatedReportRequest.md) |  |  |

### Return type

[**GenerateAggregatedReportResponse**](GenerateAggregatedReportResponse.md)

### Authorization

[HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **400** | Invalid request data |  -  |
| **422** | Validation error |  -  |
| **500** | Internal server error |  -  |
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="generateereportingapiv1ereportinggeneratepost"></a>
# **GenerateEreportingApiV1EreportingGeneratePost**
> GenerateEReportingResponse GenerateEreportingApiV1EreportingGeneratePost (CreateEReportingRequest createEReportingRequest)

Generate e-reporting XML

Generate e-reporting XML (FRR format) from structured data.  Supports all four flow types: - **10.1**: Unitary B2B international transactions (use `invoices` field) - **10.2**: Payments for B2B international invoices (use `invoicePayments` field) - **10.3**: Aggregated B2C transactions (use `transactions` field) - **10.4**: Aggregated B2C payments (use `aggregatedPayments` field)  The generated XML is compliant with DGFIP specifications and ready for submission to a PA (Plateforme Agréée).


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **createEReportingRequest** | [**CreateEReportingRequest**](CreateEReportingRequest.md) |  |  |

### Return type

[**GenerateEReportingResponse**](GenerateEReportingResponse.md)

### Authorization

[HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **400** | Invalid request data |  -  |
| **422** | Validation error |  -  |
| **500** | Internal server error |  -  |
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="generateereportingdownloadapiv1ereportinggeneratedownloadpost"></a>
# **GenerateEreportingDownloadApiV1EreportingGenerateDownloadPost**
> void GenerateEreportingDownloadApiV1EreportingGenerateDownloadPost (CreateEReportingRequest createEReportingRequest, string filename = null)

Generate and download e-reporting XML

Generate e-reporting XML and return as downloadable file.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **createEReportingRequest** | [**CreateEReportingRequest**](CreateEReportingRequest.md) |  |  |
| **filename** | **string** | Output filename (default: ereporting_{reportId}.xml) | [optional]  |

### Return type

void (empty response body)

### Authorization

[HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **400** | Invalid request data |  -  |
| **422** | Validation error |  -  |
| **500** | Internal server error |  -  |
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="listcategorycodesapiv1ereportingcategorycodesget"></a>
# **ListCategoryCodesApiV1EreportingCategoryCodesGet**
> Dictionary&lt;string, Object&gt; ListCategoryCodesApiV1EreportingCategoryCodesGet ()

List PPF-compliant category codes

Returns the list of valid CategoryCode values (TT-81) for e-reporting transactions.  Source: Annexe 6 - Format sémantique FE e-reporting v1.9


### Parameters
This endpoint does not need any parameter.
### Return type

**Dictionary<string, Object>**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **400** | Invalid request data |  -  |
| **422** | Validation error |  -  |
| **500** | Internal server error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="listflowtypesapiv1ereportingflowtypesget"></a>
# **ListFlowTypesApiV1EreportingFlowTypesGet**
> Dictionary&lt;string, Object&gt; ListFlowTypesApiV1EreportingFlowTypesGet ()

List available flow types

Returns the list of supported e-reporting flow types with descriptions.


### Parameters
This endpoint does not need any parameter.
### Return type

**Dictionary<string, Object>**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **400** | Invalid request data |  -  |
| **422** | Validation error |  -  |
| **500** | Internal server error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="submitaggregatedereportingapiv1ereportingsubmitaggregatedpost"></a>
# **SubmitAggregatedEreportingApiV1EreportingSubmitAggregatedPost**
> SubmitEReportingResponse SubmitAggregatedEreportingApiV1EreportingSubmitAggregatedPost (SubmitAggregatedReportRequest submitAggregatedReportRequest)

Submit aggregated e-reporting to PA/PDP

Generate and submit a PPF-compliant aggregated e-reporting to a PA/PDP.  Combines generation and submission in a single call. Automatically determines the AFNOR FlowType based on content.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **submitAggregatedReportRequest** | [**SubmitAggregatedReportRequest**](SubmitAggregatedReportRequest.md) |  |  |

### Return type

[**SubmitEReportingResponse**](SubmitEReportingResponse.md)

### Authorization

[HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **400** | Invalid request data |  -  |
| **422** | Validation error |  -  |
| **500** | Internal server error |  -  |
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="submitereportingapiv1ereportingsubmitpost"></a>
# **SubmitEreportingApiV1EreportingSubmitPost**
> SubmitEReportingResponse SubmitEreportingApiV1EreportingSubmitPost (SubmitEReportingRequest submitEReportingRequest)

Submit e-reporting to PA/PDP

Generate and submit e-reporting to a PA (Plateforme Agréée).  Authentication strategies (same as invoices): 1. **JWT with client_uid** (recommended): PDP credentials fetched from backend 2. **Zero-storage**: Provide pdpFlowServiceUrl, pdpClientId, pdpClientSecret in request  The e-reporting is submitted using the AFNOR Flow Service API with syntax=FRR (FRench Reporting).


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **submitEReportingRequest** | [**SubmitEReportingRequest**](SubmitEReportingRequest.md) |  |  |

### Return type

[**SubmitEReportingResponse**](SubmitEReportingResponse.md)

### Authorization

[HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **400** | Invalid request data |  -  |
| **422** | Validation error |  -  |
| **500** | Internal server error |  -  |
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="submitxmlereportingapiv1ereportingsubmitxmlpost"></a>
# **SubmitXmlEreportingApiV1EreportingSubmitXmlPost**
> SubmitEReportingResponse SubmitXmlEreportingApiV1EreportingSubmitXmlPost (System.IO.Stream xmlFile, string trackingId = null, bool skipValidation = null, string pdpFlowServiceUrl = null, string pdpTokenUrl = null, string pdpClientId = null, string pdpClientSecret = null)

Submit pre-generated e-reporting XML

Submit a pre-generated e-reporting XML file directly to a PA/PDP.  This endpoint is designed for clients who generate their own PPF-compliant XML and only need FactPulse for the PDP submission.  **Process:** 1. Validates the XML against PPF XSD schemas 2. Determines the appropriate AFNOR FlowType 3. Submits to the configured PDP/PA 4. Returns the flowId for tracking  **Authentication:** Same strategies as /submit endpoint (JWT or zero-storage credentials).


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **xmlFile** | **System.IO.Stream****System.IO.Stream** | E-reporting XML file |  |
| **trackingId** | **string** |  | [optional]  |
| **skipValidation** | **bool** | Skip XSD validation | [optional] [default to false] |
| **pdpFlowServiceUrl** | **string** |  | [optional]  |
| **pdpTokenUrl** | **string** |  | [optional]  |
| **pdpClientId** | **string** |  | [optional]  |
| **pdpClientSecret** | **string** |  | [optional]  |

### Return type

[**SubmitEReportingResponse**](SubmitEReportingResponse.md)

### Authorization

[HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **400** | Invalid request data |  -  |
| **422** | Validation error |  -  |
| **500** | Internal server error |  -  |
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="validateaggregatedereportingapiv1ereportingvalidateaggregatedpost"></a>
# **ValidateAggregatedEreportingApiV1EreportingValidateAggregatedPost**
> Dictionary&lt;string, Object&gt; ValidateAggregatedEreportingApiV1EreportingValidateAggregatedPost (CreateAggregatedReportRequest createAggregatedReportRequest)

Validate aggregated e-reporting data

Validates aggregated e-reporting data without generating XML.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **createAggregatedReportRequest** | [**CreateAggregatedReportRequest**](CreateAggregatedReportRequest.md) |  |  |

### Return type

**Dictionary<string, Object>**

### Authorization

[HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **400** | Invalid request data |  -  |
| **422** | Validation error |  -  |
| **500** | Internal server error |  -  |
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="validateereportingapiv1ereportingvalidatepost"></a>
# **ValidateEreportingApiV1EreportingValidatePost**
> ValidateEReportingResponse ValidateEreportingApiV1EreportingValidatePost (ValidateEReportingRequest validateEReportingRequest)

Validate e-reporting data

Validate e-reporting data without generating or submitting.  Performs: - Schema validation - Business rule validation (correct flux type vs data) - Data consistency checks (tax totals, dates, etc.)  Returns validation errors and warnings.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **validateEReportingRequest** | [**ValidateEReportingRequest**](ValidateEReportingRequest.md) |  |  |

### Return type

[**ValidateEReportingResponse**](ValidateEReportingResponse.md)

### Authorization

[HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **400** | Invalid request data |  -  |
| **422** | Validation error |  -  |
| **500** | Internal server error |  -  |
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="validatexmlereportingapiv1ereportingvalidatexmlpost"></a>
# **ValidateXmlEreportingApiV1EreportingValidateXmlPost**
> Dictionary&lt;string, Object&gt; ValidateXmlEreportingApiV1EreportingValidateXmlPost (System.IO.Stream xmlFile, bool validateBusinessRules = null)

Validate e-reporting XML against PPF XSD schemas and business rules

Validates an e-reporting XML file against:  1. **XSD schemas**: Official PPF e-reporting XSD (structure, types, cardinality) 2. **Business rules**: ISO codes and enum validation    - Currency codes (ISO 4217: EUR, USD, GBP, etc.)    - Country codes (ISO 3166-1 alpha-2: FR, DE, US, etc.)    - Scheme IDs (0009=SIRET, 0002=SIREN, etc.)    - Role codes (UNCL 3035: SE=Seller, BY=Buyer, WK=Working party, etc.)  Returns validation status and detailed error messages if invalid.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **xmlFile** | **System.IO.Stream****System.IO.Stream** | E-reporting XML file to validate |  |
| **validateBusinessRules** | **bool** | Also validate business rules (ISO codes, enums) | [optional] [default to true] |

### Return type

**Dictionary<string, Object>**

### Authorization

[HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **400** | Invalid request data |  -  |
| **422** | Validation error |  -  |
| **500** | Internal server error |  -  |
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

