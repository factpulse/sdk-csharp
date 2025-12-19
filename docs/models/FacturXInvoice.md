# FactPulse.SDK.Model.FacturXInvoice
Data model for an invoice to be converted to Factur-X.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**InvoiceNumber** | **string** |  | 
**PaymentDueDate** | **string** |  | 
**SubmissionMode** | **SubmissionMode** |  | 
**Recipient** | [**Recipient**](Recipient.md) |  | 
**Supplier** | [**Supplier**](Supplier.md) |  | 
**InvoicingFramework** | [**InvoicingFramework**](InvoicingFramework.md) |  | 
**References** | [**InvoiceReferences**](InvoiceReferences.md) |  | 
**Totals** | [**InvoiceTotals**](InvoiceTotals.md) |  | 
**InvoiceDate** | **string** |  | [optional] 
**InvoiceLines** | [**List&lt;InvoiceLine&gt;**](InvoiceLine.md) |  | [optional] 
**VatLines** | [**List&lt;VATLine&gt;**](VATLine.md) |  | [optional] 
**Notes** | [**List&lt;InvoiceNote&gt;**](InvoiceNote.md) |  | [optional] 
**Comment** | **string** |  | [optional] 
**CurrentUserId** | **int** |  | [optional] 
**SupplementaryAttachments** | [**List&lt;SupplementaryAttachment&gt;**](SupplementaryAttachment.md) |  | [optional] 
**Payee** | [**Payee**](Payee.md) |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

