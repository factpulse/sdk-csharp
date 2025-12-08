# FactPulse.SDK.Model.BoundingBoxSchema
Coordonnées d'une zone rectangulaire dans le PDF.  Les coordonnées sont en points PDF (1 point = 1/72 pouce). L'origine (0,0) est en bas à gauche de la page.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**X0** | **decimal** | Coordonnée X gauche | 
**Y0** | **decimal** | Coordonnée Y bas | 
**X1** | **decimal** | Coordonnée X droite | 
**Y1** | **decimal** | Coordonnée Y haut | 
**Width** | **decimal** | Largeur de la zone | 
**Height** | **decimal** | Hauteur de la zone | 
**Page** | **int** | Numéro de page (0-indexed) | [optional] [default to 0]

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

