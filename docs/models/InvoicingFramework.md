# FactPulse.SDK.Model.InvoicingFramework
Defines the invoicing framework.  - invoicing_framework_code: Chorus Pro code (A1, A2, A9, A12) - used for B2G - operation_nature: Operation nature (B1, S1, M1, etc.) - priority for Factur-X  If operation_nature is provided, it will be used directly in Factur-X XML (BT-23). Otherwise, the code will be derived from invoicing_framework_code via automatic mapping.  Example:     >>> framework = InvoicingFramework(     ...     invoicing_framework_code=InvoicingFrameworkCode.A1_SUPPLIER_INVOICE,     ...     operation_nature=OperationNature.GOODS  # Forces B1 instead of S1     ... )

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**InvoicingFrameworkCode** | **InvoicingFrameworkCode** | Chorus Pro framework code (A1, A2, A9, A12) | 
**OperationNature** | **OperationNature** |  | [optional] 
**ApproverServiceCode** | **string** |  | [optional] 
**ApproverStructureCode** | **string** |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

