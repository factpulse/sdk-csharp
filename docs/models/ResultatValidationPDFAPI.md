# FactPulse.SDK.Model.ResultatValidationPDFAPI
Résultat complet de la validation d'un PDF Factur-X.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**EstConforme** | **bool** | True si le PDF est conforme à tous les critères (XML, PDF/A, XMP) | 
**XmlPresent** | **bool** | True si un XML Factur-X est embarqué dans le PDF | 
**XmlConforme** | **bool** | True si le XML Factur-X est conforme aux règles Schematron | 
**PdfaConforme** | **bool** | True si le PDF est conforme PDF/A | 
**XmpPresent** | **bool** | True si des métadonnées XMP sont présentes | 
**XmpConformeFacturx** | **bool** | True si les métadonnées XMP contiennent des informations Factur-X | 
**EstSigne** | **bool** | True si le PDF contient au moins une signature | 
**MessageResume** | **string** | Message résumant le résultat de la validation | 
**ProfilDetecte** | **string** |  | [optional] 
**ErreursXml** | **List&lt;string&gt;** | Liste des erreurs de validation XML | [optional] 
**VersionPdfa** | **string** |  | [optional] 
**MethodeValidationPdfa** | **string** | Méthode utilisée pour la validation PDF/A (metadata ou verapdf) | [optional] [default to "metadata"]
**ReglesValidees** | **int** |  | [optional] 
**ReglesEchouees** | **int** |  | [optional] 
**ErreursPdfa** | **List&lt;string&gt;** | Liste des erreurs de conformité PDF/A | [optional] 
**AvertissementsPdfa** | **List&lt;string&gt;** | Liste des avertissements PDF/A | [optional] 
**ProfilXmp** | **string** |  | [optional] 
**VersionXmp** | **string** |  | [optional] 
**ErreursXmp** | **List&lt;string&gt;** | Liste des erreurs de métadonnées XMP | [optional] 
**MetadonneesXmp** | **Dictionary&lt;string, Object&gt;** | Métadonnées XMP extraites du PDF | [optional] 
**NombreSignatures** | **int** | Nombre de signatures électroniques trouvées | [optional] [default to 0]
**Signatures** | [**List&lt;InformationSignatureAPI&gt;**](InformationSignatureAPI.md) | Liste des signatures trouvées avec leurs informations | [optional] 
**ErreursSignatures** | **List&lt;string&gt;** | Liste des erreurs lors de l&#39;analyse des signatures | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

