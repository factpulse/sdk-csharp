# FactPulse.SDK.Model.GenerateCertificateResponse
Réponse après génération d'un certificat de test.  Contient le certificat PEM, la clé privée PEM, et optionnellement le PKCS#12.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CertificatPem** | **string** | Certificat X.509 au format PEM | 
**ClePriveePem** | **string** | Clé privée RSA au format PEM | 
**Info** | [**CertificateInfoResponse**](CertificateInfoResponse.md) | Informations sur le certificat généré | 
**Status** | **string** | Statut de l&#39;opération | [optional] [default to "success"]
**Pkcs12Base64** | **string** |  | [optional] 
**Avertissement** | **string** | Avertissement sur l&#39;utilisation du certificat | [optional] [default to "⚠️ Ce certificat est AUTO-SIGNÉ et destiné uniquement aux TESTS. Ne PAS utiliser en production. Niveau eIDAS : SES (Simple Electronic Signature)"]

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

