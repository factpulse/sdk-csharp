# FactPulse.SDK.Model.GenerateCertificateRequest
Request to generate a self-signed X.509 test certificate.  WARNING: This certificate is intended for TESTING only. DO NOT use in production! eIDAS level: SES (Simple Electronic Signature)

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Cn** | **string** | Common Name (CN) - Certificate name | [optional] [default to "Test Signature FactPulse"]
**Organization** | **string** | Organization (O) | [optional] [default to "FactPulse Test"]
**Country** | **string** | ISO 2-letter country code (C) | [optional] [default to "FR"]
**City** | **string** | City (L) | [optional] [default to "Paris"]
**State** | **string** | State/Province (ST) | [optional] [default to "Ile-de-France"]
**Email** | **string** |  | [optional] 
**ValidityDays** | **int** | Validity duration in days | [optional] [default to 365]
**KeySize** | **int** | RSA key size in bits | [optional] [default to 2048]
**KeyPassphrase** | **string** |  | [optional] 
**GenerateP12** | **bool** | Also generate a PKCS#12 (.p12) file | [optional] [default to false]
**P12Passphrase** | **string** | Passphrase for PKCS#12 file | [optional] [default to "changeme"]

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

