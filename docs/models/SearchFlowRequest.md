# FactPulse.SDK.Model.SearchFlowRequest
Request to search submitted flows.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**UpdatedAfter** | **DateTime** |  | [optional] 
**UpdatedBefore** | **DateTime** |  | [optional] 
**FlowTypes** | [**List&lt;FlowType&gt;**](FlowType.md) |  | [optional] 
**FlowDirections** | [**List&lt;FlowDirection&gt;**](FlowDirection.md) |  | [optional] 
**TrackingId** | **string** |  | [optional] 
**FlowId** | **string** |  | [optional] 
**AcknowledgmentStatus** | **AcknowledgmentStatus** |  | [optional] 
**Offset** | **int** | Offset for pagination | [optional] [default to 0]
**Limit** | **int** | Maximum number of results (max 100) | [optional] [default to 25]

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

