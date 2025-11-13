# FactPulse.SDK.Model.SoumettreFactureCompleteResponse
Réponse complète après soumission automatisée.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Succes** | **bool** | La facture a été soumise avec succès | 
**DestinationType** | **string** | Type de destination | 
**FactureEnrichie** | [**FactureEnrichieInfoOutput**](FactureEnrichieInfoOutput.md) | Données de la facture enrichie | 
**PdfFacturx** | [**PDFFacturXInfo**](PDFFacturXInfo.md) | Informations sur le PDF généré | 
**PdfBase64** | **string** | PDF Factur-X généré (et signé si demandé) encodé en base64 | 
**Message** | **string** | Message de retour | 
**ResultatChorus** | [**ResultatChorusPro**](ResultatChorusPro.md) |  | [optional] 
**ResultatAfnor** | [**ResultatAFNOR**](ResultatAFNOR.md) |  | [optional] 
**Signature** | [**SignatureInfo**](SignatureInfo.md) |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

