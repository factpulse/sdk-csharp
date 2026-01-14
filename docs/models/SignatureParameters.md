# FactPulse.SDK.Model.SignatureParameters
Optional parameters to sign the generated PDF.  **MODE 1 - Stored certificate (recommended):** Only provide metadata (reason, location, etc.). The certificate will be automatically retrieved via client_uid from JWT. eIDAS compliant PAdES-B-LT signature.  **MODE 2 - Keys in payload (tests/special cases):** Provide key_pem + cert_pem directly in the payload. Accepted PEM format: raw (\"- -- --BEGIN...\") or base64.  **Selection rule:** - If key_pem AND cert_pem provided → Mode 2 (payload keys) - Otherwise → Mode 1 (stored certificate retrieved via client_uid)

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**KeyPem** | **string** |  | [optional] 
**CertPem** | **string** |  | [optional] 
**KeyPassphrase** | **string** |  | [optional] 
**Reason** | **string** |  | [optional] 
**Location** | **string** |  | [optional] 
**Contact** | **string** |  | [optional] 
**FieldName** | **string** | PDF signature field name | [optional] [default to "FactPulseSignature"]
**UsePadesLt** | **bool** | Enable PAdES-B-LT (long-term archival). REQUIRES certificate with OCSP/CRL access | [optional] [default to false]
**UseTimestamp** | **bool** | Enable RFC 3161 timestamping with FreeTSA (PAdES-B-T) | [optional] [default to true]

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

