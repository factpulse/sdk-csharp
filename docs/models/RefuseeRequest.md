# FactPulse.SDK.Model.RefuseeRequest
Requête simplifiée pour soumettre un statut REFUSÉE (210).  **Usage** : Pour une facture REÇUE (vous êtes acheteur). L'acheteur refuse la facture et envoie le statut au vendeur.  Statut obligatoire PPF - Un code motif est OBLIGATOIRE (BR-FR-CDV-15).  Codes motif autorisés (BR-FR-CDV-CL-09_MDT-113_210): - TX_TVA_ERR, MONTANTTOTAL_ERR, CALCUL_ERR, NON_CONFORME, DOUBLON, - DEST_ERR, TRANSAC_INC, EMMET_INC, CONTRAT_TERM, DOUBLE_FACT, - CMD_ERR, ADR_ERR, REF_CT_ABSENT

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**InvoiceId** | **string** | Identifiant de la facture (BT-1) | 
**InvoiceIssueDate** | **DateOnly** | Date d&#39;émission de la facture (YYYY-MM-DD) | 
**InvoiceSellerSiren** | **string** | SIREN du vendeur (destinataire du statut, MDT-129) | 
**InvoiceSellerElectronicAddress** | **string** | Adresse électronique du vendeur (MDT-73) | 
**ReasonCode** | **string** | Code motif du refus (obligatoire). Valeurs: TX_TVA_ERR, MONTANTTOTAL_ERR, CALCUL_ERR, NON_CONFORME, DOUBLON, DEST_ERR, TRANSAC_INC, EMMET_INC, CONTRAT_TERM, DOUBLE_FACT, CMD_ERR, ADR_ERR, REF_CT_ABSENT | 
**ReasonText** | **string** |  | [optional] 
**SenderSiren** | **string** |  | [optional] 
**FlowType** | **string** | Type de flux (SupplierInvoiceLC pour facture reçue) | [optional] [default to "SupplierInvoiceLC"]
**PdpFlowServiceUrl** | **string** |  | [optional] 
**PdpTokenUrl** | **string** |  | [optional] 
**PdpClientId** | **string** |  | [optional] 
**PdpClientSecret** | **string** |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

