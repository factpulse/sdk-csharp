# FactPulse.SDK.Model.GenerateCertificateResponse
Response after generating a test certificate.  Contains certificate PEM, private key PEM, and optionally PKCS#12.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CertificatePem** | **string** | X.509 certificate in PEM format | 
**PrivateKeyPem** | **string** | RSA private key in PEM format | 
**Info** | [**CertificateInfoResponse**](CertificateInfoResponse.md) | Generated certificate information | 
**Status** | **string** | Operation status | [optional] [default to "success"]
**Pkcs12Base64** | **string** |  | [optional] 
**Warning** | **string** | Warning about certificate usage | [optional] [default to "WARNING: This certificate is SELF-SIGNED and intended for TESTING only. DO NOT use in production. eIDAS level: SES (Simple Electronic Signature)"]

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

