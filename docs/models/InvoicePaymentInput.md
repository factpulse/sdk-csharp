# FactPulse.SDK.Model.InvoicePaymentInput
Payment linked to a specific invoice (flux 10.2).  Used for B2B international invoice payments.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**InvoiceId** | **string** | Invoice identifier | 
**InvoiceDate** | **DateOnly** | Original invoice date | 
**PaymentDate** | **DateOnly** | Payment date | 
**AmountsByRate** | [**List&lt;PaymentAmountByRate&gt;**](PaymentAmountByRate.md) | Payment amounts by VAT rate | 
**Currency** | [**Currency**](Currency.md) |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

