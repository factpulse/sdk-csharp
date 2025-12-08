# FactPulse.SDK.Model.NoteObligatoireSchema
Note obligatoire détectée avec localisation et comparaison XML/PDF.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CodeSujet** | **string** | Code sujet (PMT, PMD, AAB) | 
**Label** | **string** | Libellé (ex: Indemnité recouvrement) | 
**ValeurPdf** | **string** |  | [optional] 
**ValeurXml** | **string** |  | [optional] 
**Statut** | **StatutChampAPI** | Statut de conformité (CONFORME si XML trouvé dans PDF) | [optional] 
**Message** | **string** |  | [optional] 
**Bbox** | [**BoundingBoxSchema**](BoundingBoxSchema.md) |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

