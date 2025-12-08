# FactPulse.SDK.Model.CadreDeFacturation
Définit le cadre de facturation.  - code_cadre_facturation: Code Chorus Pro (A1, A2, A9, A12) - utilisé pour B2G - nature_operation: Nature de l'opération (B1, S1, M1, etc.) - prioritaire pour Factur-X  Si nature_operation est fourni, il sera utilisé directement dans le XML Factur-X (BT-23). Sinon, le code sera déduit de code_cadre_facturation via un mapping automatique.  Exemple:     >>> cadre = CadreDeFacturation(     ...     code_cadre_facturation=CodeCadreFacturation.A1_FACTURE_FOURNISSEUR,     ...     nature_operation=NatureOperation.BIENS  # Force B1 au lieu de S1     ... )

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CodeCadreFacturation** | **CodeCadreFacturation** |  | 
**NatureOperation** | **NatureOperation** |  | [optional] 
**CodeServiceValideur** | **string** |  | [optional] 
**CodeStructureValideur** | **string** |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

