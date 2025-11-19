# FactPulse.SDK.Model.LigneDePoste
Représente une ligne de détail dans une facture.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Numero** | **int** |  | 
**Denomination** | **string** |  | 
**Quantite** | [**Quantite**](Quantite.md) |  | 
**Unite** | **Unite** |  | 
**MontantUnitaireHt** | [**MontantUnitaireHt**](MontantUnitaireHt.md) |  | 
**Reference** | **string** |  | [optional] 
**MontantRemiseHt** | **decimal** | Montant de la remise HT. | [optional] 
**MontantTotalLigneHt** | **decimal** | Montant total HT de la ligne (quantité × prix unitaire - remise). | [optional] 
**TauxTva** | **string** |  | [optional] 
**TauxTvaManuel** | **decimal** | Taux de TVA avec valeur manuelle. | [optional] 
**CategorieTva** | **CategorieTVA** |  | [optional] 
**DateDebutPeriode** | **string** |  | [optional] 
**DateFinPeriode** | **string** |  | [optional] 
**CodeRaisonReduction** | **CodeRaisonReduction** |  | [optional] 
**RaisonReduction** | **string** |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

