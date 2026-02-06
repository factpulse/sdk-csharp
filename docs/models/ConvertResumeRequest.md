# FactPulse.SDK.Model.ConvertResumeRequest
Requete de reprise de conversion avec corrections.  Le champ `overrides` accepte n'importe quel sous-ensemble de FacturXInvoice. Seuls les champs fournis seront mis a jour (merge profond).  Exemple:     {         \"overrides\": {             \"supplier\": {                 \"name\": \"Ma Société\",                 \"siret\": \"12345678901234\"             },             \"totals\": {                 \"total_net_amount\": 1000.00             }         },         \"callback_url\": \"https://example.com/webhook\",         \"webhook_mode\": \"inline\"     }

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Overrides** | **Dictionary&lt;string, Object&gt;** | Sous-ensemble de FacturXInvoice a mettre a jour (merge profond) | [optional] 
**CallbackUrl** | **string** |  | [optional] 
**WebhookMode** | **string** | Mode de livraison webhook: &#39;inline&#39; ou &#39;download_url&#39; | [optional] [default to "inline"]

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

