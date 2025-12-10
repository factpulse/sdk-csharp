# FactPulse.SDK.Model.Beneficiaire
Informations sur le bénéficiaire du paiement (BG-10 / PayeeTradeParty).  Le bénéficiaire est la partie qui reçoit le paiement. Ce bloc est utilisé uniquement si le bénéficiaire est différent du vendeur (fournisseur).  **Cas d'usage principal** : Affacturage (factoring) Quand une facture est affacturée, le factor (société d'affacturage) devient le bénéficiaire du paiement à la place du fournisseur.  **Business Terms (EN16931)** : - BT-59 : Nom du bénéficiaire (obligatoire) - BT-60 : Identifiant du bénéficiaire (SIRET avec schemeID 0009) - BT-61 : Identifiant légal du bénéficiaire (SIREN avec schemeID 0002)  **Référence** : docs/guide_affacturage.md

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Nom** | **string** | Nom du bénéficiaire (BT-59). Obligatoire. | 
**Siret** | **string** |  | [optional] 
**Siren** | **string** |  | [optional] 
**AdresseElectronique** | [**AdresseElectronique**](AdresseElectronique.md) |  | [optional] 
**Iban** | **string** |  | [optional] 
**Bic** | **string** |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

