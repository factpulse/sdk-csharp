# FactPulse.SDK.Model.ParametresSignature
Paramètres optionnels pour signer le PDF généré.  **MODE 1 - Certificat stocké (recommandé) :** Ne fournissez que les métadonnées (raison, localisation, etc.). Le certificat sera récupéré automatiquement via client_uid du JWT. Signature PAdES-B-LT conforme eIDAS.  **MODE 2 - Clés dans le payload (tests/cas spéciaux) :** Fournissez key_pem + cert_pem directement dans le payload. Format PEM accepté : brut (\"- -- --BEGIN...\") ou base64.  **Règle de sélection :** - Si key_pem ET cert_pem fournis → Mode 2 (clés payload) - Sinon → Mode 1 (certificat stocké récupéré via client_uid)

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**KeyPem** | **string** |  | [optional] 
**CertPem** | **string** |  | [optional] 
**KeyPassphrase** | **string** |  | [optional] 
**Raison** | **string** |  | [optional] 
**Localisation** | **string** |  | [optional] 
**Contact** | **string** |  | [optional] 
**FieldName** | **string** | Nom du champ de signature PDF | [optional] [default to "FactPulseSignature"]
**UsePadesLt** | **bool** | Activer PAdES-B-LT (archivage long terme). NÉCESSITE certificat avec accès OCSP/CRL | [optional] [default to false]
**UseTimestamp** | **bool** | Activer l&#39;horodatage RFC 3161 avec FreeTSA (PAdES-B-T) | [optional] [default to true]

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

