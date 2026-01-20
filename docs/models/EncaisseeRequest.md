# FactPulse.SDK.Model.EncaisseeRequest
Requête simplifiée pour soumettre un statut ENCAISSÉE (212).  Statut obligatoire PPF - Le paiement a été effectué. Le montant encaissé est OBLIGATOIRE (BR-FR-CDV-14).

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**InvoiceId** | **string** | Identifiant de la facture (BT-1) | 
**InvoiceIssueDate** | **DateOnly** | Date d&#39;émission de la facture (YYYY-MM-DD) | 
**Amount** | [**Amount**](Amount.md) |  | 
**SenderSiren** | **string** |  | [optional] 
**FlowType** | **string** | Type de flux: SupplierInvoiceLC (acheteur) ou CustomerInvoiceLC (vendeur) | [optional] [default to "SupplierInvoiceLC"]
**PdpFlowServiceUrl** | **string** |  | [optional] 
**PdpTokenUrl** | **string** |  | [optional] 
**PdpClientId** | **string** |  | [optional] 
**PdpClientSecret** | **string** |  | [optional] 
**Currency** | **string** | Code devise ISO 4217 | [optional] [default to "EUR"]

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

