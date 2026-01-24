# FactPulse.SDK.Api.Flux6InvoiceLifecycleCDARApi

All URIs are relative to *https://factpulse.fr*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GenerateCdarApiV1CdarGeneratePost**](Flux6InvoiceLifecycleCDARApi.md#generatecdarapiv1cdargeneratepost) | **POST** /api/v1/cdar/generate | Generate a CDAR message |
| [**GetActionCodesApiV1CdarActionCodesGet**](Flux6InvoiceLifecycleCDARApi.md#getactioncodesapiv1cdaractioncodesget) | **GET** /api/v1/cdar/action-codes | List of CDAR action codes |
| [**GetReasonCodesApiV1CdarReasonCodesGet**](Flux6InvoiceLifecycleCDARApi.md#getreasoncodesapiv1cdarreasoncodesget) | **GET** /api/v1/cdar/reason-codes | List of CDAR reason codes |
| [**GetStatusCodesApiV1CdarStatusCodesGet**](Flux6InvoiceLifecycleCDARApi.md#getstatuscodesapiv1cdarstatuscodesget) | **GET** /api/v1/cdar/status-codes | List of CDAR status codes |
| [**SubmitCdarApiV1CdarSubmitPost**](Flux6InvoiceLifecycleCDARApi.md#submitcdarapiv1cdarsubmitpost) | **POST** /api/v1/cdar/submit | Generate and submit a CDAR message |
| [**SubmitCdarXmlApiV1CdarSubmitXmlPost**](Flux6InvoiceLifecycleCDARApi.md#submitcdarxmlapiv1cdarsubmitxmlpost) | **POST** /api/v1/cdar/submit-xml | Submit a pre-generated CDAR XML |
| [**SubmitEncaisseeApiV1CdarEncaisseePost**](Flux6InvoiceLifecycleCDARApi.md#submitencaisseeapiv1cdarencaisseepost) | **POST** /api/v1/cdar/encaissee | [Simplified] Submit PAID status (212) - Issued invoice |
| [**SubmitRefuseeApiV1CdarRefuseePost**](Flux6InvoiceLifecycleCDARApi.md#submitrefuseeapiv1cdarrefuseepost) | **POST** /api/v1/cdar/refusee | [Simplified] Submit REFUSED status (210) - Received invoice |
| [**ValidateCdarApiV1CdarValidatePost**](Flux6InvoiceLifecycleCDARApi.md#validatecdarapiv1cdarvalidatepost) | **POST** /api/v1/cdar/validate | Validate CDAR structured data |
| [**ValidateXmlCdarApiV1CdarValidateXmlPost**](Flux6InvoiceLifecycleCDARApi.md#validatexmlcdarapiv1cdarvalidatexmlpost) | **POST** /api/v1/cdar/validate-xml | Validate CDAR XML against XSD and Schematron BR-FR-CDV |

<a id="generatecdarapiv1cdargeneratepost"></a>
# **GenerateCdarApiV1CdarGeneratePost**
> GenerateCDARResponse GenerateCdarApiV1CdarGeneratePost (CreateCDARRequest createCDARRequest)

Generate a CDAR message

Generate a CDAR XML message (Cross Domain Acknowledgement and Response) to communicate the status of an invoice.  **Message types:** - **23** (Processing): Standard lifecycle message - **305** (Transmission): Inter-platform transmission message  **Business rules:** - BR-FR-CDV-14: Status 212 (PAID) requires a paid amount - BR-FR-CDV-15: Statuses 206/207/208/210/213/501 require a reason code


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **createCDARRequest** | [**CreateCDARRequest**](CreateCDARRequest.md) |  |  |

### Return type

[**GenerateCDARResponse**](GenerateCDARResponse.md)

### Authorization

[HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **400** | Invalid request |  -  |
| **422** | Validation error |  -  |
| **500** | Server error |  -  |
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getactioncodesapiv1cdaractioncodesget"></a>
# **GetActionCodesApiV1CdarActionCodesGet**
> ActionCodesResponse GetActionCodesApiV1CdarActionCodesGet ()

List of CDAR action codes

Returns the complete list of action codes (BR-FR-CDV-CL-10).  These codes indicate the requested action on the invoice.


### Parameters
This endpoint does not need any parameter.
### Return type

[**ActionCodesResponse**](ActionCodesResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **400** | Invalid request |  -  |
| **422** | Validation error |  -  |
| **500** | Server error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getreasoncodesapiv1cdarreasoncodesget"></a>
# **GetReasonCodesApiV1CdarReasonCodesGet**
> ReasonCodesResponse GetReasonCodesApiV1CdarReasonCodesGet ()

List of CDAR reason codes

Returns the complete list of status reason codes (BR-FR-CDV-CL-09).  These codes explain the reason for a particular status.


### Parameters
This endpoint does not need any parameter.
### Return type

[**ReasonCodesResponse**](ReasonCodesResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **400** | Invalid request |  -  |
| **422** | Validation error |  -  |
| **500** | Server error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getstatuscodesapiv1cdarstatuscodesget"></a>
# **GetStatusCodesApiV1CdarStatusCodesGet**
> StatusCodesResponse GetStatusCodesApiV1CdarStatusCodesGet ()

List of CDAR status codes

Returns the complete list of invoice status codes (BR-FR-CDV-CL-06).  These codes indicate the lifecycle state of an invoice.


### Parameters
This endpoint does not need any parameter.
### Return type

[**StatusCodesResponse**](StatusCodesResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **400** | Invalid request |  -  |
| **422** | Validation error |  -  |
| **500** | Server error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="submitcdarapiv1cdarsubmitpost"></a>
# **SubmitCdarApiV1CdarSubmitPost**
> SubmitCDARResponse SubmitCdarApiV1CdarSubmitPost (SubmitCDARRequest submitCDARRequest)

Generate and submit a CDAR message

Generate a CDAR message and submit it to the PA/PDP platform.  **Authentication strategies:** 1. **JWT with client_uid** (recommended): PDP credentials retrieved from backend 2. **Zero-storage**: Provide pdpFlowServiceUrl, pdpClientId, pdpClientSecret in the request  **Flow types (flowType):** - `CustomerInvoiceLC`: Client-side lifecycle (buyer) - `SupplierInvoiceLC`: Supplier-side lifecycle (seller)


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **submitCDARRequest** | [**SubmitCDARRequest**](SubmitCDARRequest.md) |  |  |

### Return type

[**SubmitCDARResponse**](SubmitCDARResponse.md)

### Authorization

[HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **400** | Invalid request |  -  |
| **422** | Validation error |  -  |
| **500** | Server error |  -  |
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="submitcdarxmlapiv1cdarsubmitxmlpost"></a>
# **SubmitCdarXmlApiV1CdarSubmitXmlPost**
> SubmitCDARResponse SubmitCdarXmlApiV1CdarSubmitXmlPost (SubmitCDARXMLRequest submitCDARXMLRequest)

Submit a pre-generated CDAR XML

Submit a pre-generated CDAR XML message to the PA/PDP platform.  Useful for submitting XML generated by other systems.  **Validation:** The XML is validated against XSD and Schematron BR-FR-CDV rules BEFORE submission. Invalid XML will be rejected with detailed error messages.  **Authentication strategies:** 1. **JWT with client_uid** (recommended): PDP credentials retrieved from backend 2. **Zero-storage**: Provide pdpFlowServiceUrl, pdpClientId, pdpClientSecret in the request


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **submitCDARXMLRequest** | [**SubmitCDARXMLRequest**](SubmitCDARXMLRequest.md) |  |  |

### Return type

[**SubmitCDARResponse**](SubmitCDARResponse.md)

### Authorization

[HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **400** | Invalid request |  -  |
| **422** | Validation error |  -  |
| **500** | Server error |  -  |
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="submitencaisseeapiv1cdarencaisseepost"></a>
# **SubmitEncaisseeApiV1CdarEncaisseePost**
> SimplifiedCDARResponse SubmitEncaisseeApiV1CdarEncaisseePost (EncaisseeRequest encaisseeRequest)

[Simplified] Submit PAID status (212) - Issued invoice

**Simplified endpoint for OD** - Submit a PAID status (212) for an **ISSUED** invoice.  This status is **mandatory for PPF** (BR-FR-CDV-14 requires the paid amount).  **Use case:** The **seller** confirms payment receipt for an invoice they issued.  **Who issues this status?** - **Issuer (IssuerTradeParty):** The seller (SE = Seller) who received payment - **Recipient (RecipientTradeParty):** The buyer (BY = Buyer) who paid  **Reference:** XP Z12-014 Annex B, example UC1_F202500003_07-CDV-212_Encaissee.xml  **Authentication:** JWT Bearer (recommended) or PDP credentials in request.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **encaisseeRequest** | [**EncaisseeRequest**](EncaisseeRequest.md) |  |  |

### Return type

[**SimplifiedCDARResponse**](SimplifiedCDARResponse.md)

### Authorization

[HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **400** | Invalid request |  -  |
| **422** | Validation error |  -  |
| **500** | Server error |  -  |
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="submitrefuseeapiv1cdarrefuseepost"></a>
# **SubmitRefuseeApiV1CdarRefuseePost**
> SimplifiedCDARResponse SubmitRefuseeApiV1CdarRefuseePost (RefuseeRequest refuseeRequest)

[Simplified] Submit REFUSED status (210) - Received invoice

**Simplified endpoint for OD** - Submit a REFUSED status (210) for a **RECEIVED** invoice.  This status is **mandatory for PPF** (BR-FR-CDV-15 requires a reason code).  **Use case:** The **buyer** refuses an invoice they received.  **Who issues this status?** - **Issuer (IssuerTradeParty):** The buyer (BY = Buyer) refusing the invoice - **Recipient (RecipientTradeParty):** The seller (SE = Seller) who issued the invoice  **Reference:** XP Z12-014 Annex B, example UC3_F202500005_04-CDV-210_Refusee.xml  **Allowed reason codes (BR-FR-CDV-CL-09):** - `TX_TVA_ERR`: Incorrect VAT rate - `MONTANTTOTAL_ERR`: Incorrect total amount - `CALCUL_ERR`: Calculation error - `NON_CONFORME`: Non-compliant - `DOUBLON`: Duplicate - `DEST_ERR`: Wrong recipient - `TRANSAC_INC`: Incomplete transaction - `EMMET_INC`: Unknown issuer - `CONTRAT_TERM`: Contract terminated - `DOUBLE_FACT`: Double billing - `CMD_ERR`: Order error - `ADR_ERR`: Address error - `REF_CT_ABSENT`: Missing contract reference  **Authentication:** JWT Bearer (recommended) or PDP credentials in request.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **refuseeRequest** | [**RefuseeRequest**](RefuseeRequest.md) |  |  |

### Return type

[**SimplifiedCDARResponse**](SimplifiedCDARResponse.md)

### Authorization

[HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **400** | Invalid request |  -  |
| **422** | Validation error |  -  |
| **500** | Server error |  -  |
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="validatecdarapiv1cdarvalidatepost"></a>
# **ValidateCdarApiV1CdarValidatePost**
> ValidateCDARResponse ValidateCdarApiV1CdarValidatePost (ValidateCDARRequest validateCDARRequest)

Validate CDAR structured data

Validate CDAR structured data without generating XML.  **Note:** This endpoint validates structured data fields only. Use `/validate-xml` to validate a pre-generated CDAR XML file against XSD and Schematron.  Checks: - Field formats (SIREN, dates, etc.) - Enum codes (status, reason, action) - Business rules BR-FR-CDV-*


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **validateCDARRequest** | [**ValidateCDARRequest**](ValidateCDARRequest.md) |  |  |

### Return type

[**ValidateCDARResponse**](ValidateCDARResponse.md)

### Authorization

[HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **400** | Invalid request |  -  |
| **422** | Validation error |  -  |
| **500** | Server error |  -  |
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="validatexmlcdarapiv1cdarvalidatexmlpost"></a>
# **ValidateXmlCdarApiV1CdarValidateXmlPost**
> Dictionary&lt;string, Object&gt; ValidateXmlCdarApiV1CdarValidateXmlPost (System.IO.Stream xmlFile)

Validate CDAR XML against XSD and Schematron BR-FR-CDV

Validates a CDAR XML file against:  1. **XSD schema**: UN/CEFACT D22B CrossDomainAcknowledgementAndResponse 2. **Schematron BR-FR-CDV**: French business rules for invoice lifecycle  Returns validation status and detailed error messages if invalid.  **Note:** Use `/validate` to validate structured data fields (JSON).


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **xmlFile** | **System.IO.Stream****System.IO.Stream** | CDAR XML file to validate |  |

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
| **400** | Invalid request |  -  |
| **422** | Validation error |  -  |
| **500** | Server error |  -  |
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

