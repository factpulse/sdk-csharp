# FactPulse.SDK.Model.SoumettreFactureRequest
Soumission d'une facture Chorus Pro.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**NumeroFacture** | **string** | Numéro de la facture | 
**DateFacture** | **string** | Date de facture (format ISO: YYYY-MM-DD) | 
**IdStructureCpp** | **int** | ID Chorus Pro de la structure destinataire | 
**MontantHtTotal** | [**MontantHtTotal1**](MontantHtTotal1.md) |  | 
**MontantTva** | [**MontantTva1**](MontantTva1.md) |  | 
**MontantTtcTotal** | [**MontantTtcTotal1**](MontantTtcTotal1.md) |  | 
**Credentials** | [**ChorusProCredentials**](ChorusProCredentials.md) |  | [optional] 
**DateEcheancePaiement** | **string** |  | [optional] 
**CodeService** | **string** |  | [optional] 
**NumeroEngagement** | **string** |  | [optional] 
**PieceJointePrincipaleId** | **int** |  | [optional] 
**PieceJointePrincipaleDesignation** | **string** |  | [optional] 
**Commentaire** | **string** |  | [optional] 
**NumeroBonCommande** | **string** |  | [optional] 
**NumeroMarche** | **string** |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

