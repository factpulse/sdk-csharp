# FactPulse.SDK.Model.AggregatedTransactionInput
Aggregated transaction for B2C reporting (flux 10.3).  Represents daily aggregation by category (TLB1, TPS1, etc.). Each occurrence corresponds to one day + one currency + one category.  Source: Annexe 6 v1.9, bloc TG-31 \"Transactions\"

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Date** | **DateOnly** | Transaction date (TT-77) | 
**CategoryCode** | **TransactionCategory** | Transaction category code (TT-81). Use TLB1 for goods, TPS1 for services. | 
**TaxExclusiveAmount** | [**Taxexclusiveamount**](Taxexclusiveamount.md) |  | 
**TaxAmount** | [**Taxamount**](Taxamount.md) |  | 
**TaxBreakdown** | [**List&lt;TaxBreakdownInput&gt;**](TaxBreakdownInput.md) | VAT breakdown by rate | 
**Currency** | [**Currency**](Currency.md) |  | [optional] 
**TransactionCount** | **int** |  | [optional] 
**TaxDueType** | **TaxDueDateType** |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

