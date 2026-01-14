# FactPulse.SDK.Model.AFNORRoutingCodePayloadHistoryLegalUnitFacility

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**RoutingIdentifier** | **string** | Routing identifier od a routing code. | [optional] 
**Siret** | **string** | SIRET Number | [optional] 
**RoutingIdentifierType** | **string** | Routing Identifier type. | [optional] 
**RoutingCodeName** | **string** | Name of the directory line routing code. This attribute is only returned if the directory line is defined at the SIREN / SIRET / Routing code mesh. | [optional] 
**ManagesLegalCommitmentCode** | **bool** | Indicates whether the public structure requires a legal commitment number. This attribute is only returned if the directory line is defined for a public structure at the SIREN / SIRET or SIREN / SIRET / Routing code level. | [optional] 
**AdministrativeStatus** | **AFNORRoutingCodeAdministrativeStatus** |  | [optional] 
**Address** | [**AFNORAddressRead**](AFNORAddressRead.md) |  | [optional] 
**LegalUnit** | [**AFNORLegalUnitPayloadIncluded**](AFNORLegalUnitPayloadIncluded.md) |  | [optional] 
**Facility** | [**AFNORFacilityPayloadIncluded**](AFNORFacilityPayloadIncluded.md) |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

