# FactPulse.SDK.Model.AFNORFlow
The properties of a Flow resource

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**SubmittedAt** | **DateTime** | The flow submission date and time (the date and time when the flow was created on the system)  | [optional] 
**UpdatedAt** | **DateTime** | The last update date and time of the flow. When the flow is submitted updatedAt is equal to submittedAt. When the flow acknowledgment status is changed updatedAt date and time is updated.  | [optional] 
**FlowId** | **string** | Unique identifier supporting UUID but not only, for flexibility purpose | [optional] 
**TrackingId** | **string** | Unique identifier supporting UUID but not only, for flexibility purpose | [optional] 
**FlowType** | **AFNORFlowType** |  | [optional] 
**ProcessingRule** | **AFNORProcessingRule** |  | [optional] 
**ProcessingRuleSource** | **string** | Says whether the processing rule has been computed or the processing rule was an input parameter | [optional] 
**FlowDirection** | **AFNORFlowDirection** |  | [optional] 
**FlowSyntax** | **AFNORFlowSyntax** |  | [optional] 
**FlowProfile** | **AFNORFlowProfile** |  | [optional] 
**Acknowledgement** | [**AFNORAcknowledgement**](AFNORAcknowledgement.md) |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

