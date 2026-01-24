# FactPulse.SDK.Model.ReportIssuer
Report issuer/declarant information (TT-12 to TT-16).  The issuer is the French company declaring the transactions. The role_code determines whether the company is: - SE (Seller): B2Bi case - French company sells to foreign buyer - BY (Buyer): Bi2B case - French company buys from foreign seller  Source: Annexe 6 v1.9, bloc Issuer

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Siren** | **string** | SIREN or SIRET of the declarant (French company) | 
**Name** | **string** |  | [optional] 
**VatId** | **string** |  | [optional] 
**RoleCode** | **IssuerRoleCode** | Role of the declarant (TT-15). SE&#x3D;Seller (B2Bi: French seller to foreign buyer). BY&#x3D;Buyer (Bi2B: French buyer from foreign seller). | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

