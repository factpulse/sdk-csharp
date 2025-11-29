# FactPulse.SDK.Model.FournisseurEntrant
Fournisseur extrait d'une facture entrante.  Contrairement au modèle Fournisseur de models.py, ce modèle n'a pas de champ id_fournisseur car cette information n'est pas disponible dans les XML Factur-X/CII/UBL.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Nom** | **string** | Raison sociale du fournisseur (BT-27) | 
**Siren** | **string** |  | [optional] 
**Siret** | **string** |  | [optional] 
**NumeroTvaIntra** | **string** |  | [optional] 
**AdressePostale** | [**AdressePostale**](AdressePostale.md) |  | [optional] 
**AdresseElectronique** | [**AdresseElectronique**](AdresseElectronique.md) |  | [optional] 
**Email** | **string** |  | [optional] 
**Telephone** | **string** |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

