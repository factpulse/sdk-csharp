# FactPulse.SDK.Model.EncaisseeRequest
Requête simplifiée pour soumettre un statut ENCAISSÉE (212).  **Usage** : Pour une facture ÉMISE (vous êtes vendeur). Le vendeur confirme l'encaissement et envoie le statut à l'acheteur.  Statut obligatoire PPF - Le montant encaissé est OBLIGATOIRE (BR-FR-CDV-14).

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**InvoiceId** | **string** | Identifiant de la facture (BT-1) | 
**InvoiceIssueDate** | **DateOnly** | Date d&#39;émission de la facture (YYYY-MM-DD) | 
**InvoiceBuyerSiren** | **string** | SIREN de l&#39;acheteur (destinataire du statut) | 
**InvoiceBuyerElectronicAddress** | **string** | Adresse électronique de l&#39;acheteur (MDT-73) | 
**Amount** | [**Amount**](Amount.md) |  | 
**Currency** | **string** | Code devise ISO 4217 | [optional] [default to "EUR"]
**SenderSiren** | **string** |  | [optional] 
**FlowType** | **string** | Type de flux (CustomerInvoiceLC pour facture émise) | [optional] [default to "CustomerInvoiceLC"]
**PdpFlowServiceUrl** | **string** |  | [optional] 
**PdpTokenUrl** | **string** |  | [optional] 
**PdpClientId** | **string** |  | [optional] 
**PdpClientSecret** | **string** |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

