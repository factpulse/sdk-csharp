# FactPulse.SDK.Model.IncomingInvoice
Invoice received from a supplier via PDP/PA.  This model contains essential metadata extracted from incoming invoices, regardless of their source format (CII, UBL, Factur-X).  Amounts are Decimal in Python but will be serialized as strings in JSON to preserve monetary precision.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**SourceFormat** | **InvoiceFormat** | Invoice source format | 
**SupplierReference** | **string** | Invoice number issued by the supplier (BT-1) | 
**Supplier** | [**IncomingSupplier**](IncomingSupplier.md) | Invoice issuer (SellerTradeParty) | 
**BillingSiteName** | **string** | Recipient name / your company (BT-44) | 
**IssueDate** | **string** | Invoice date (BT-2) - YYYY-MM-DD | 
**NetAmount** | **string** | Total net amount (BT-109) | 
**VatAmount** | **string** | Total VAT amount (BT-110) | 
**GrossAmount** | **string** | Total gross amount (BT-112) | 
**FlowId** | **string** |  | [optional] 
**DocumentType** | **InvoiceTypeCode** | Document type (BT-3) | [optional] 
**BillingSiteSiret** | **string** |  | [optional] 
**DueDate** | **string** |  | [optional] 
**Currency** | **string** | ISO currency code (BT-5) | [optional] [default to "EUR"]
**PurchaseOrderNumber** | **string** |  | [optional] 
**ContractReference** | **string** |  | [optional] 
**InvoiceSubject** | **string** |  | [optional] 
**DocumentBase64** | **string** |  | [optional] 
**DocumentContentType** | **string** |  | [optional] 
**DocumentFilename** | **string** |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

