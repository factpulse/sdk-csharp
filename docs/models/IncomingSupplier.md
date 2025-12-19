# FactPulse.SDK.Model.IncomingSupplier
Supplier extracted from an incoming invoice.  Unlike the Supplier model in models.py, this model does not have a supplier_id field as this information is not available in Factur-X/CII/UBL XML files.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Name** | **string** | Supplier business name (BT-27) | 
**Siren** | **string** |  | [optional] 
**Siret** | **string** |  | [optional] 
**VatNumber** | **string** |  | [optional] 
**PostalAddress** | [**PostalAddress**](PostalAddress.md) |  | [optional] 
**ElectronicAddress** | [**ElectronicAddress**](ElectronicAddress.md) |  | [optional] 
**Email** | **string** |  | [optional] 
**Phone** | **string** |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

