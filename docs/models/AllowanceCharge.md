# FactPulse.SDK.Model.AllowanceCharge
Document-level or line-level allowance/charge.  Represents BG-20 (Document level allowances), BG-21 (Document level charges), BG-27 (Invoice line allowances), or BG-28 (Invoice line charges).

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**IsCharge** | **bool** | True for charge, False for allowance (ChargeIndicator). | 
**Amount** | [**Amount1**](Amount1.md) |  | 
**BaseAmount** | [**BaseAmount**](BaseAmount.md) |  | [optional] 
**Percentage** | [**Percentage**](Percentage.md) |  | [optional] 
**Reason** | **string** |  | [optional] 
**ReasonCode** | **AllowanceChargeReasonCode** |  | [optional] 
**VatCategory** | **VATCategory** |  | [optional] 
**VatRate** | [**VatRate**](VatRate.md) |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

