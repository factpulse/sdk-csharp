# FactPulse.SDK.Model.SubmitInvoiceRequest
Submit an invoice to Chorus Pro.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**InvoiceNumber** | **string** | Invoice number | 
**InvoiceDate** | **string** | Invoice date (ISO format: YYYY-MM-DD) | 
**StructureId** | **int** | Chorus Pro recipient structure ID | 
**TotalNetAmount** | [**SubmitNetAmount**](SubmitNetAmount.md) |  | 
**VatAmount** | [**SubmitVatAmount**](SubmitVatAmount.md) |  | 
**TotalGrossAmount** | [**SubmitGrossAmount**](SubmitGrossAmount.md) |  | 
**Credentials** | [**ChorusProCredentials**](ChorusProCredentials.md) |  | [optional] 
**PaymentDueDate** | **string** |  | [optional] 
**ServiceCode** | **string** |  | [optional] 
**EngagementNumber** | **string** |  | [optional] 
**MainAttachmentId** | **int** |  | [optional] 
**MainAttachmentLabel** | **string** |  | [optional] 
**Comment** | **string** |  | [optional] 
**PurchaseOrderReference** | **string** |  | [optional] 
**ContractReference** | **string** |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

