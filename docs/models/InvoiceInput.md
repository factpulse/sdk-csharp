# FactPulse.SDK.Model.InvoiceInput
Invoice for B2B international reporting (flux 10.1).  Used for unitary declaration of international B2B invoices.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**InvoiceId** | **string** | Invoice identifier | 
**IssueDate** | **DateOnly** | Invoice issue date | 
**SellerSiren** | **string** | Seller SIREN/SIRET | 
**BuyerCountry** | [**Buyercountry**](Buyercountry.md) |  | 
**TaxExclusiveAmount** | [**Taxexclusiveamount1**](Taxexclusiveamount1.md) |  | 
**TaxAmount** | [**Taxamount1**](Taxamount1.md) |  | 
**TaxBreakdown** | [**List&lt;TaxBreakdownInput&gt;**](TaxBreakdownInput.md) | VAT breakdown | 
**TypeCode** | **FactureElectroniqueRestApiSchemasEreportingInvoiceTypeCode** | Invoice type code | [optional] 
**Currency** | [**Currency**](Currency.md) |  | [optional] 
**DueDate** | **DateOnly** |  | [optional] 
**SellerVatId** | **string** |  | [optional] 
**SellerCountry** | [**Sellercountry**](Sellercountry.md) |  | [optional] 
**BuyerId** | **string** |  | [optional] 
**BuyerVatId** | **string** |  | [optional] 
**ReferencedInvoiceId** | **string** |  | [optional] 
**ReferencedInvoiceDate** | **DateOnly** |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

