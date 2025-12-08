# FactPulse.SDK.Model.LigneDeTVA
Représente une ligne de totalisation par taux de TVA.  Pour les exonérations (catégories E, AE, K, G, O), les champs `motif_exoneration` et `code_vatex` sont requis selon EN16931.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**MontantBaseHt** | [**MontantBaseHt**](MontantBaseHt.md) |  | 
**MontantTva** | [**MontantTvaLigne**](MontantTvaLigne.md) |  | 
**Taux** | **string** |  | [optional] 
**TauxManuel** | [**Tauxmanuel**](Tauxmanuel.md) |  | [optional] 
**Categorie** | **CategorieTVA** |  | [optional] 
**MotifExoneration** | **string** |  | [optional] 
**CodeVatex** | **string** |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

