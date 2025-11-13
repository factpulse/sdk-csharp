# FactPulse.SDK.Model.DonneesFactureSimplifiees
Données simplifiées de la facture (format minimal pour auto-enrichissement).

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Numero** | **string** | Numéro de facture unique | 
**Emetteur** | **Dictionary&lt;string, Object&gt;** | Informations sur l&#39;émetteur (siret, iban, ...) | 
**Destinataire** | **Dictionary&lt;string, Object&gt;** | Informations sur le destinataire (siret, ...) | 
**Lignes** | **List&lt;Dictionary&lt;string, Object&gt;&gt;** | Lignes de la facture | 
**Date** | **string** |  | [optional] 
**EcheanceJours** | **int** | Échéance en jours (défaut: 30) | [optional] [default to 30]
**Commentaire** | **string** |  | [optional] 
**NumeroBonCommande** | **string** |  | [optional] 
**NumeroMarche** | **string** |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

