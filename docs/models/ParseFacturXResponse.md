# FactPulse.SDK.Model.ParseFacturXResponse
Response from the /parse-facturx endpoint.  Contains the parsed invoice data, plus metadata about the detected format and profile.  **Response schema depends on source format:** - **CII / Factur-X**: ``invoice`` contains a ``FacturXInvoice`` dict — round-trip compatible   with ``/generate-invoice``. - **UBL**: ``invoice`` contains an ``IncomingInvoice`` dict (simplified extraction with   supplier, amounts, dates). Not directly compatible with ``/generate-invoice``.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Status** | **string** | Parsing status | 
**Invoice** | **Dictionary&lt;string, Object&gt;** | Parsed invoice data. For CII/Factur-X: FacturXInvoice format (round-trip with /generate-invoice). For UBL: IncomingInvoice format (summary extraction). | 
**DetectedFormat** | **string** |  | [optional] 
**DetectedProfile** | **string** |  | [optional] 
**Error** | **string** |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

