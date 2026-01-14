# FactPulse.SDK.Model.GenerateAggregatedReportResponse
Response after generating an aggregated e-reporting XML.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ReportId** | **string** | Report identifier | 
**TransmissionType** | **string** | Transmission type (IN or RE) | 
**FlowType** | **string** | AFNOR FlowType determined from content | 
**Xml** | **string** | Generated XML content | 
**XmlSize** | **int** | XML size in bytes | 
**ContentSummary** | **Dictionary&lt;string, Object&gt;** | Summary of content (counts by flux type) | 
**Message** | **string** | Status message | 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

