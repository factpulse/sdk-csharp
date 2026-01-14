# FactPulse.SDK.Model.AFNORCreateRoutingCodeBody

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**FacilityNature** | **AFNORFacilityNature** |  | 
**RoutingIdentifier** | **string** | Routing identifier od a routing code. | 
**Siret** | **string** | SIRET Number | 
**RoutingCodeName** | **string** | Name of the directory line routing code. This attribute is only returned if the directory line is defined at the SIREN / SIRET / Routing code mesh. | 
**AdministrativeStatus** | **AFNORRoutingCodeAdministrativeStatus** |  | 
**RoutingIdentifierType** | **string** | Routing Identifier type. | [optional] 
**ManagesLegalCommitmentCode** | **bool** | Indicates whether the public structure requires a legal commitment number. This attribute is only returned if the directory line is defined for a public structure at the SIREN / SIRET or SIREN / SIRET / Routing code level. | [optional] 
**Address** | [**AFNORAddressEdit**](AFNORAddressEdit.md) |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

