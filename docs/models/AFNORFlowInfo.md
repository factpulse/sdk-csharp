# FactPulse.SDK.Model.AFNORFlowInfo
Signaling of the flow

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Name** | **string** | Name of the file | 
**FlowSyntax** | **AFNORFlowSyntax** |  | 
**TrackingId** | **string** | The tracking id is an external identifier and is used to track the flow by the sender | [optional] 
**ProcessingRule** | **AFNORProcessingRule** |  | [optional] 
**FlowProfile** | **AFNORFlowProfile** |  | [optional] 
**Sha256** | **byte[]** | The sha256 is the fingerprint of the attached file: - if provided in the request: it should be checked once received - if not provided in the request: it may be computed and returned in the response  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

