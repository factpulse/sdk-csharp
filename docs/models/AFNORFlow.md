# FactPulse.SDK.Model.AFNORFlow
The properties of a Flow resource

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Name** | **string** | Name of the file | 
**FlowSyntax** | **AFNORFlowSyntax** |  | 
**FlowId** | **string** | Unique identifier supporting UUID but not only, for flexibility purpose | 
**SubmittedAt** | **DateTime** | The flow submission date and time (the date and time when the flow was created on the system) This property should be used by the API consumer as a time reference to avoid clock synchronization issues  | 
**UpdatedAt** | **DateTime** | The last update date and time of the flow. When the flow is submitted updatedAt is equal to submittedAt. When the flow acknowledgment status is changed updatedAt date and time is updated.  | 
**FlowType** | **AFNORFlowType** |  | 
**ProcessingRuleSource** | **string** | Says whether the processing rule has been computed or the processing rule was an input parameter | 
**FlowDirection** | **AFNORFlowDirection** |  | 
**Acknowledgement** | [**AFNORAcknowledgement**](AFNORAcknowledgement.md) |  | 
**TrackingId** | **string** | The tracking id is an external identifier and is used to track the flow by the sender | [optional] 
**ProcessingRule** | **AFNORProcessingRule** |  | [optional] 
**FlowProfile** | **AFNORFlowProfile** |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

