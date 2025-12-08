# FactPulse.SDK.Model.ReponseVerificationSucces
Réponse de vérification réussie avec données unifiées.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**EstConforme** | **bool** | True si aucun écart critique | 
**ScoreConformite** | **decimal** | Score de conformité (0-100%) | 
**ChampsVerifies** | **int** | Nombre de champs vérifiés | [optional] [default to 0]
**ChampsConformes** | **int** | Nombre de champs conformes | [optional] [default to 0]
**EstFacturx** | **bool** | True si le PDF contient du XML Factur-X | [optional] [default to false]
**ProfilFacturx** | **string** |  | [optional] 
**Champs** | [**List&lt;ChampVerifieSchema&gt;**](ChampVerifieSchema.md) | Liste des champs vérifiés avec valeurs, statuts et coordonnées PDF | [optional] 
**NotesObligatoires** | [**List&lt;NoteObligatoireSchema&gt;**](NoteObligatoireSchema.md) | Notes obligatoires (PMT, PMD, AAB) avec localisation PDF | [optional] 
**DimensionsPages** | [**List&lt;DimensionPageSchema&gt;**](DimensionPageSchema.md) | Dimensions de chaque page du PDF (largeur, hauteur) | [optional] 
**Avertissements** | **List&lt;string&gt;** | Avertissements non bloquants | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

