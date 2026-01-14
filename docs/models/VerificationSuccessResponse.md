# FactPulse.SDK.Model.VerificationSuccessResponse
Successful verification response with unified data.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**IsCompliant** | **bool** | True if no critical discrepancy | 
**ComplianceScore** | **decimal** | Compliance score (0-100%) | 
**VerifiedFieldsCount** | **int** | Number of verified fields | [optional] [default to 0]
**CompliantFieldsCount** | **int** | Number of compliant fields | [optional] [default to 0]
**IsFacturx** | **bool** | True if PDF contains Factur-X XML | [optional] [default to false]
**FacturxProfile** | **string** |  | [optional] 
**Fields** | [**List&lt;VerifiedFieldSchema&gt;**](VerifiedFieldSchema.md) | List of verified fields with values, statuses and PDF coordinates | [optional] 
**MandatoryNotes** | [**List&lt;MandatoryNoteSchema&gt;**](MandatoryNoteSchema.md) | Mandatory notes (PMT, PMD, AAB) with PDF location | [optional] 
**PageDimensions** | [**List&lt;PageDimensionsSchema&gt;**](PageDimensionsSchema.md) | Dimensions of each PDF page (width, height) | [optional] 
**Warnings** | **List&lt;string&gt;** | Non-blocking warnings | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

