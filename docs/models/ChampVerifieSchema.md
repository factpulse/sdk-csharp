# FactPulse.SDK.Model.ChampVerifieSchema
Un champ vérifié avec toutes ses informations (extraction + conformité + localisation).

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**BusinessTerm** | **string** | Business Term EN16931 (ex: BT-1) | 
**Label** | **string** | Libellé du champ (ex: N° Facture) | 
**Statut** | **StatutChampAPI** | Statut de conformité | 
**ValeurPdf** | **string** |  | [optional] 
**ValeurXml** | **string** |  | [optional] 
**Message** | **string** |  | [optional] 
**Confiance** | **decimal** | Score de confiance (0-1) | [optional] [default to 1.0M]
**Source** | **string** | Source d&#39;extraction | [optional] [default to "pdf_natif"]
**Bbox** | [**BoundingBoxSchema**](BoundingBoxSchema.md) |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

