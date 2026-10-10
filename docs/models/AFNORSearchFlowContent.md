# FactPulse.SDK.Model.AFNORSearchFlowContent
A set of flows matching criterias, provided into the request

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Limit** | **int** | Pagination, Maximum number of results that may be returned | [optional] [default to 25]
**NextCursor** | **string** | Pagination management: - If present, says where to start for next page, set nextCursor as the cursor in the next request - If omitted, says that pagination is finished  | [optional] 
**Filters** | [**AFNORSearchFlowFilters**](AFNORSearchFlowFilters.md) |  | [optional] 
**Results** | [**List&lt;AFNORFlow&gt;**](AFNORFlow.md) |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

