# FactPulse.SDK.Model.FactureFacturX
Modèle de données pour une facture destinée à être convertie en Factur-X.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**NumeroFacture** | **string** |  | 
**DateEcheancePaiement** | **string** |  | 
**ModeDepot** | **ModeDepot** |  | 
**Destinataire** | [**Destinataire**](Destinataire.md) |  | 
**Fournisseur** | [**Fournisseur**](Fournisseur.md) |  | 
**CadreDeFacturation** | [**CadreDeFacturation**](CadreDeFacturation.md) |  | 
**References** | [**References**](References.md) |  | 
**MontantTotal** | [**MontantTotal**](MontantTotal.md) |  | 
**DateFacture** | **string** |  | [optional] 
**LignesDePoste** | [**List&lt;LigneDePoste&gt;**](LigneDePoste.md) |  | [optional] 
**LignesDeTva** | [**List&lt;LigneDeTVA&gt;**](LigneDeTVA.md) |  | [optional] 
**Notes** | [**List&lt;Note&gt;**](Note.md) |  | [optional] 
**Commentaire** | **string** |  | [optional] 
**IdUtilisateurCourant** | **int** |  | [optional] 
**PiecesJointesComplementaires** | [**List&lt;PieceJointeComplementaire&gt;**](PieceJointeComplementaire.md) |  | [optional] 
**Beneficiaire** | [**Beneficiaire**](Beneficiaire.md) |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

