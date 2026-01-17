# FactPulse.SDK.Model.SubmitCDARRequest
Requête de soumission CDAR (génération + envoi).

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**DocumentId** | **string** | Identifiant unique du message CDAR | 
**SenderSiren** | **string** | SIREN de l&#39;émetteur (9 chiffres) | 
**InvoiceId** | **string** | Identifiant de la facture (BT-1) | 
**InvoiceIssueDate** | **DateOnly** | Date d&#39;émission de la facture (YYYY-MM-DD) | 
**Status** | **string** | Code statut de la facture (200-601) | 
**BusinessProcess** | **string** | Code processus métier (REGULATED, B2C, B2BINT, etc.) | [optional] [default to "REGULATED"]
**TypeCode** | **string** | Type de message (23&#x3D;Traitement, 305&#x3D;Transmission) | [optional] [default to "23"]
**SenderRole** | **string** | Rôle de l&#39;émetteur (WK, SE, BY, etc.) | [optional] [default to "WK"]
**SenderName** | **string** |  | [optional] 
**SenderEmail** | **string** |  | [optional] 
**Recipients** | [**List&lt;RecipientInput&gt;**](RecipientInput.md) | Liste des destinataires | [optional] 
**InvoiceTypeCode** | **string** | Type de document (380&#x3D;Facture, 381&#x3D;Avoir) | [optional] [default to "380"]
**InvoiceSellerSiren** | **string** |  | [optional] 
**InvoiceBuyerSiren** | **string** |  | [optional] 
**ReasonCode** | **string** |  | [optional] 
**ReasonText** | **string** |  | [optional] 
**ActionCode** | **string** |  | [optional] 
**EncaisseAmount** | [**Encaisseamount**](Encaisseamount.md) |  | [optional] 
**FlowType** | **string** | Type de flux AFNOR (CustomerInvoiceLC, SupplierInvoiceLC, etc.) | [optional] [default to "CustomerInvoiceLC"]

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

