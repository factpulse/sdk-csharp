# FactPulse.SDK.Model.AFNORFlowInfo
Signaling of the flow: - The tracking id is an external identifier and is used to track the flow by the sender - The sha256 is the fingerprint of the attached file:   - if provided in the request: it should be checked once received   - if not provided in the request: it should be computed and returned in the response 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**FlowSyntax** | **AFNORFlowSyntax** |  | 
**TrackingId** | **string** | Unique identifier supporting UUID but not only, for flexibility purpose | [optional] 
**Name** | **string** | Name of the file | [optional] 
**ProcessingRule** | **AFNORProcessingRule** |  | [optional] 
**FlowProfile** | **AFNORFlowProfile** |  | [optional] 
**Sha256** | **string** |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

