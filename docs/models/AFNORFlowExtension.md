# FactPulse.SDK.Model.AFNORFlowExtension
Extension schema to build Flow schema

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**UpdatedAt** | **DateTime** | The last update date and time of the flow. When the flow is submitted updatedAt is equal to submittedAt. When the flow acknowledgment status is changed updatedAt date and time is updated.  | 
**FlowType** | **AFNORFlowType** |  | 
**ProcessingRuleSource** | **string** | Says whether the processing rule has been computed or the processing rule was an input parameter | 
**FlowDirection** | **AFNORFlowDirection** |  | 
**Acknowledgement** | [**AFNORAcknowledgement**](AFNORAcknowledgement.md) |  | 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

