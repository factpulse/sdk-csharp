# FactPulse.SDK.Model.VATLine
Represents a VAT breakdown line by rate.  For exemptions (categories E, AE, K, G, O), the fields `exemption_reason` and `vatex_code` are required per EN16931.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**TaxableAmount** | [**TaxableAmount**](TaxableAmount.md) |  | 
**VatAmount** | [**VATAmount**](VATAmount.md) |  | 
**Rate** | **string** |  | [optional] 
**ManualRate** | [**ManualRate**](ManualRate.md) |  | [optional] 
**Category** | **VATCategory** |  | [optional] 
**ExemptionReason** | **string** |  | [optional] 
**VatexCode** | **string** |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

