# FactPulse.SDK.Model.InvoiceLine
Represents a line item in an invoice.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**LineNumber** | **int** |  | 
**ItemName** | **string** |  | 
**Quantity** | [**Quantity**](Quantity.md) |  | 
**Unit** | **UnitOfMeasure** |  | 
**UnitNetPrice** | [**UnitNetPrice**](UnitNetPrice.md) |  | 
**Reference** | **string** |  | [optional] 
**AllowanceAmount** | [**InvoiceLineAllowanceAmount**](InvoiceLineAllowanceAmount.md) |  | [optional] 
**LineNetAmount** | [**LineNetAmount**](LineNetAmount.md) |  | [optional] 
**VatRate** | **string** |  | [optional] 
**ManualVatRate** | [**ManualVatRate**](ManualVatRate.md) |  | [optional] 
**VatCategory** | **VATCategory** |  | [optional] 
**PeriodStartDate** | **string** |  | [optional] 
**PeriodEndDate** | **string** |  | [optional] 
**AllowanceReasonCode** | **AllowanceReasonCode** |  | [optional] 
**AllowanceReason** | **string** |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

