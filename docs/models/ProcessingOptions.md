# FactPulse.SDK.Model.ProcessingOptions
Processing options for generation and submission.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**FacturxProfile** | **FacturXProfile** | Factur-X profile to use | [optional] 
**AutoEnrich** | **bool** | Auto-enrich data (Company APIs, Chorus Pro, etc.) | [optional] [default to true]
**ValidateXml** | **bool** | Validate Factur-X XML with Schematron | [optional] [default to true]
**VerifyDestinationParameters** | **bool** | Verify required parameters for destination (e.g., service_code for Chorus) | [optional] [default to true]

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

