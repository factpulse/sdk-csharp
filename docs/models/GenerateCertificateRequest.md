# FactPulse.SDK.Model.GenerateCertificateRequest
Requête pour générer un certificat X.509 auto-signé de test.  ⚠️ ATTENTION : Ce certificat est destiné uniquement aux TESTS. NE PAS utiliser en production ! Niveau eIDAS : SES (Simple Electronic Signature)

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Cn** | **string** | Common Name (CN) - Nom du certificat | [optional] [default to "Test Signature FactPulse"]
**Organisation** | **string** | Organisation (O) | [optional] [default to "FactPulse Test"]
**Pays** | **string** | Code pays ISO 2 lettres (C) | [optional] [default to "FR"]
**Ville** | **string** | Ville (L) | [optional] [default to "Paris"]
**Province** | **string** | Province/État (ST) | [optional] [default to "Ile-de-France"]
**Email** | **string** |  | [optional] 
**DureeJours** | **int** | Durée de validité en jours | [optional] [default to 365]
**TailleCle** | **int** | Taille de la clé RSA en bits | [optional] [default to 2048]
**PassphraseCle** | **string** |  | [optional] 
**GenererP12** | **bool** | Générer aussi un fichier PKCS#12 (.p12) | [optional] [default to false]
**PassphraseP12** | **string** | Passphrase pour le fichier PKCS#12 | [optional] [default to "changeme"]

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

