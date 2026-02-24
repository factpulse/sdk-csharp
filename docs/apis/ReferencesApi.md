# FactPulse.SDK.Api.ReferencesApi

All URIs are relative to *https://factpulse.fr*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetVatexCodesApiV1ReferencesVatexCodesGet**](ReferencesApi.md#getvatexcodesapiv1referencesvatexcodesget) | **GET** /api/v1/references/vatex-codes | VATEX exemption reason codes |

<a id="getvatexcodesapiv1referencesvatexcodesget"></a>
# **GetVatexCodesApiV1ReferencesVatexCodesGet**
> VATEXCodesResponse GetVatexCodesApiV1ReferencesVatexCodesGet (string category = null)

VATEX exemption reason codes

Returns the list of VATEX (VAT exemption reason) codes from the Peppol BIS Billing 3.0 code list. Source: https://docs.peppol.eu/poacc/billing/3.0/codelist/vatex/


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **category** | **string** | Filter by VAT category code (E, AE, K, G, O). | [optional]  |

### Return type

[**VATEXCodesResponse**](VATEXCodesResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | List of VATEX codes with their descriptions and associated VAT categories. |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

