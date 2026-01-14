# FactPulse.SDK.Model.PDFValidationResultAPI
Complete result of a Factur-X PDF validation.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**IsCompliant** | **bool** | True if PDF complies with all criteria (XML, PDF/A, XMP) | 
**XmlPresent** | **bool** | True if a Factur-X XML is embedded in the PDF | 
**XmlCompliant** | **bool** | True if Factur-X XML complies with Schematron rules | 
**PdfaCompliant** | **bool** | True if PDF is PDF/A compliant | 
**XmpPresent** | **bool** | True if XMP metadata is present | 
**XmpFacturxCompliant** | **bool** | True if XMP metadata contains Factur-X information | 
**IsSigned** | **bool** | True if PDF contains at least one signature | 
**SummaryMessage** | **string** | Message summarizing the validation result | 
**DetectedProfile** | **string** |  | [optional] 
**XmlErrors** | **List&lt;string&gt;** | List of XML validation errors | [optional] 
**PdfaVersion** | **string** |  | [optional] 
**PdfaValidationMethod** | **string** | Method used for PDF/A validation (metadata or verapdf) | [optional] [default to "metadata"]
**ValidatedRules** | **int** |  | [optional] 
**FailedRules** | **int** |  | [optional] 
**PdfaErrors** | **List&lt;string&gt;** | List of PDF/A compliance errors | [optional] 
**PdfaWarnings** | **List&lt;string&gt;** | List of PDF/A warnings | [optional] 
**XmpProfile** | **string** |  | [optional] 
**XmpVersion** | **string** |  | [optional] 
**XmpErrors** | **List&lt;string&gt;** | List of XMP metadata errors | [optional] 
**XmpMetadata** | **Dictionary&lt;string, Object&gt;** | XMP metadata extracted from PDF | [optional] 
**SignatureCount** | **int** | Number of electronic signatures found | [optional] [default to 0]
**Signatures** | [**List&lt;SignatureInfoAPI&gt;**](SignatureInfoAPI.md) | List of found signatures with their information | [optional] 
**SignatureErrors** | **List&lt;string&gt;** | List of errors during signature analysis | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

