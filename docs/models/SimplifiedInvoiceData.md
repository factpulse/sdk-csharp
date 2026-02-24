# FactPulse.SDK.Model.SimplifiedInvoiceData
Simplified invoice data (minimal format for auto-enrichment).

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Number** | **string** | Unique invoice number | 
**Supplier** | **Dictionary&lt;string, Object&gt;** | Supplier information (siret, iban, ...) | 
**Recipient** | **Dictionary&lt;string, Object&gt;** | Recipient information (siret, ...) | 
**Lines** | **List&lt;Dictionary&lt;string, Object&gt;&gt;** | Invoice lines | 
**Date** | **string** |  | [optional] 
**DueDays** | **int** | Due date in days (default: 30) | [optional] [default to 30]
**Comment** | **string** |  | [optional] 
**PurchaseOrderReference** | **string** |  | [optional] 
**ContractReference** | **string** |  | [optional] 
**InvoiceType** | **InvoiceTypeCode** | Document type (UNTDID 1001). Default: 380 (Invoice). | [optional] 
**PrecedingInvoiceReference** | **string** |  | [optional] 
**OperationNature** | **OperationNature** |  | [optional] 
**InvoicingFramework** | **InvoicingFrameworkCode** |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

