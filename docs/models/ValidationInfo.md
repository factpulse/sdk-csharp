# FactPulse.SDK.Model.ValidationInfo
Informations sur la validation.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Profile** | **string** | Profil Factur-X utilise | 
**SchematronRulesPassed** | **int** | Regles passees | 
**SchematronRulesTotal** | **int** | Total regles | 
**PdfaCompliant** | **bool** | PDF/A-3 conforme | [optional] [default to true]
**XmlEmbedded** | **bool** | XML embarque dans PDF | [optional] [default to true]
**Errors** | [**List&lt;SchematronValidationError&gt;**](SchematronValidationError.md) |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

