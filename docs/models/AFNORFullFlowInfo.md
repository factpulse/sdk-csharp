# FactPulse.SDK.Model.AFNORFullFlowInfo
Identified Flow info: flow info + id + timestamp

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**FlowSyntax** | **AFNORFlowSyntax** |  | 
**TrackingId** | **string** | Unique identifier supporting UUID but not only, for flexibility purpose | [optional] 
**Name** | **string** | Name of the file | [optional] 
**ProcessingRule** | **AFNORProcessingRule** |  | [optional] 
**FlowProfile** | **AFNORFlowProfile** |  | [optional] 
**Sha256** | **string** |  | [optional] 
**FlowId** | **string** | Unique identifier supporting UUID but not only, for flexibility purpose | [optional] 
**SubmittedAt** | **DateTime** | The flow submission date and time (the date and time when the flow was created on the system) This property should be used by the API consumer as a time reference to avoid clock synchronization issues  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

