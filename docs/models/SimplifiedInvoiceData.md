# FactPulse.SDK.Model.SimplifiedInvoiceData
Simplified invoice data (minimal format for auto-enrichment).  Any field of the complete `FacturXInvoice` model may be added on top of the fields declared below (`deliveryDate` BT-72, `deliveryParty` BG-15, `paymentReference` BT-83, `payee` BG-10, ...): extra keys are kept and merged by `FacturXInvoice.create_from_simplified_dict`. Whatever the simplified format computes itself (totals, lines, addresses) always wins.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Number** | **string** | Unique invoice number | 
**Supplier** | **Dictionary&lt;string, Object&gt;** | Supplier information (siret, iban, bic, routingAddress, ...). For a seller without an intra-community VAT number (VAT franchise, article 293 B of the CGI), provide &#x60;taxRegistrationId&#x60; (BT-32, usually the SIREN): it satisfies BR-E-02 and prevents BT-31 from being auto-calculated. | 
**Recipient** | **Dictionary&lt;string, Object&gt;** | Recipient information (siret, vatNumber for BT-48, ...) | 
**Lines** | **List&lt;Dictionary&lt;string, Object&gt;&gt;** | Invoice lines | 
**Date** | **string** |  | [optional] 
**DueDays** | **int** | Due date in days (default: 30) | [optional] [default to 30]
**Comment** | **string** |  | [optional] 
**PurchaseOrderReference** | **string** |  | [optional] 
**ContractReference** | **string** |  | [optional] 
**InvoiceType** | **FactureElectroniqueModelsInvoiceTypeCode** | Document type (UNTDID 1001). Default: 380 (Invoice). | [optional] 
**PrecedingInvoiceReference** | **string** |  | [optional] 
**OperationNature** | **OperationNature** |  | [optional] 
**InvoicingFramework** | **InvoicingFrameworkCode** |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

