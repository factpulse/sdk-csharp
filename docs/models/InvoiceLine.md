# FactPulse.SDK.Model.InvoiceLine
Represents an invoice line item (BG-25).

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**LineNumber** | **int** | Invoice line identifier (BT-126). | 
**ItemName** | **string** | Item name (BT-153). | 
**Quantity** | [**Quantity**](Quantity.md) |  | 
**Unit** | **UnitOfMeasure** | Invoiced quantity unit of measure code (BT-130). | 
**UnitNetPrice** | [**UnitNetPrice**](UnitNetPrice.md) |  | 
**LineNote** | **string** |  | [optional] 
**ParentLineId** | **string** |  | [optional] 
**LineSubType** | **LineSubType** |  | [optional] 
**Reference** | **string** |  | [optional] 
**BuyerAssignedId** | **string** |  | [optional] 
**ProductGlobalId** | **string** |  | [optional] 
**ProductGlobalIdScheme** | **string** |  | [optional] 
**ItemDescription** | **string** |  | [optional] 
**OriginCountry** | **string** |  | [optional] 
**Characteristics** | [**List&lt;ProductCharacteristic&gt;**](ProductCharacteristic.md) |  | [optional] 
**Classifications** | [**List&lt;ProductClassification&gt;**](ProductClassification.md) |  | [optional] 
**GrossUnitPrice** | [**GrossUnitPrice**](GrossUnitPrice.md) |  | [optional] 
**PriceBasisQuantity** | [**PriceBasisQuantity**](PriceBasisQuantity.md) |  | [optional] 
**PriceBasisUnit** | **string** |  | [optional] 
**PriceAllowanceAmount** | [**PriceAllowanceAmount**](PriceAllowanceAmount.md) |  | [optional] 
**LineNetAmount** | [**LineNetAmount**](LineNetAmount.md) |  | [optional] 
**AllowanceAmount** | [**InvoiceLineAllowanceAmount**](InvoiceLineAllowanceAmount.md) |  | [optional] 
**AllowanceReasonCode** | **AllowanceReasonCode** |  | [optional] 
**AllowanceReason** | **string** |  | [optional] 
**AllowancesCharges** | [**List&lt;AllowanceCharge&gt;**](AllowanceCharge.md) |  | [optional] 
**VatRate** | **string** |  | [optional] 
**ManualVatRate** | [**ManualVatRate**](ManualVatRate.md) |  | [optional] 
**VatCategory** | **VATCategory** |  | [optional] 
**PeriodStartDate** | **string** |  | [optional] 
**PeriodEndDate** | **string** |  | [optional] 
**PurchaseOrderLineRef** | **string** |  | [optional] 
**AccountingAccount** | **string** |  | [optional] 
**AdditionalDocuments** | [**List&lt;AdditionalDocument&gt;**](AdditionalDocument.md) |  | [optional] 
**LineNotes** | [**List&lt;InvoiceNote&gt;**](InvoiceNote.md) |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

