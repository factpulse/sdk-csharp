# FactPulse.SDK.Api.DocumentConversionApi

All URIs are relative to *https://factpulse.fr*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ConvertDocumentAsyncApiV1ConvertAsyncPost**](DocumentConversionApi.md#convertdocumentasyncapiv1convertasyncpost) | **POST** /api/v1/convert/async | Convertir un document en Factur-X (mode asynchrone) |
| [**DownloadFileApiV1ConvertConversionIdDownloadFilenameGet**](DocumentConversionApi.md#downloadfileapiv1convertconversioniddownloadfilenameget) | **GET** /api/v1/convert/{conversion_id}/download/{filename} | Télécharger un fichier généré |
| [**GetConversionStatusApiV1ConvertConversionIdStatusGet**](DocumentConversionApi.md#getconversionstatusapiv1convertconversionidstatusget) | **GET** /api/v1/convert/{conversion_id}/status | Vérifier le statut d&#39;une conversion |
| [**ResumeConversionApiV1ConvertConversionIdResumePost**](DocumentConversionApi.md#resumeconversionapiv1convertconversionidresumepost) | **POST** /api/v1/convert/{conversion_id}/resume | Reprendre une conversion avec corrections |

<a id="convertdocumentasyncapiv1convertasyncpost"></a>
# **ConvertDocumentAsyncApiV1ConvertAsyncPost**
> Object ConvertDocumentAsyncApiV1ConvertAsyncPost (System.IO.Stream file, string output = null, string callbackUrl = null, string webhookMode = null)

Convertir un document en Factur-X (mode asynchrone)

Lance une conversion asynchrone via Celery.  ## Workflow  1. **Upload** : Le document est envoyé en multipart/form-data 2. **Task Celery** : La tâche est mise en file d'attente 3. **Callback** : Notification par webhook à la fin  ## Réponses possibles  - **202** : Tâche acceptée, en cours de traitement - **400** : Fichier invalide


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **file** | **System.IO.Stream****System.IO.Stream** | Document à convertir (PDF, DOCX, XLSX, JPG, PNG) |  |
| **output** | **string** | Format de sortie: pdf, xml, both | [optional] [default to &quot;pdf&quot;] |
| **callbackUrl** | **string** |  | [optional]  |
| **webhookMode** | **string** | Mode de livraison du contenu: &#39;inline&#39; (base64 dans webhook) ou &#39;download_url&#39; (URL temporaire 1h) | [optional] [default to &quot;inline&quot;] |

### Return type

**Object**

### Authorization

[HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **202** | Tâche acceptée |  -  |
| **400** | Fichier invalide |  -  |
| **422** | Validation Error |  -  |
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="downloadfileapiv1convertconversioniddownloadfilenameget"></a>
# **DownloadFileApiV1ConvertConversionIdDownloadFilenameGet**
> Object DownloadFileApiV1ConvertConversionIdDownloadFilenameGet (string conversionId, string filename)

Télécharger un fichier généré

Télécharge le fichier Factur-X PDF ou XML généré.  ## Fichiers disponibles  - `facturx.pdf` : PDF/A-3 avec XML embarqué - `facturx.xml` : XML CII seul (Cross Industry Invoice)  Les fichiers sont disponibles pendant 24 heures après génération.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **conversionId** | **string** | Conversion ID returned by POST /convert (UUID format) |  |
| **filename** | **string** | File to download: &#39;facturx.pdf&#39; or &#39;facturx.xml&#39; |  |

### Return type

**Object**

### Authorization

[HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Fichier téléchargé |  -  |
| **404** | Fichier non trouvé ou expiré |  -  |
| **422** | Validation Error |  -  |
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getconversionstatusapiv1convertconversionidstatusget"></a>
# **GetConversionStatusApiV1ConvertConversionIdStatusGet**
> Dictionary&lt;string, Object&gt; GetConversionStatusApiV1ConvertConversionIdStatusGet (string conversionId)

Vérifier le statut d'une conversion

Retourne le statut actuel d'une conversion asynchrone.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **conversionId** | **string** | Conversion ID returned by POST /convert (UUID format) |  |

### Return type

**Dictionary<string, Object>**

### Authorization

[HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **422** | Validation Error |  -  |
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="resumeconversionapiv1convertconversionidresumepost"></a>
# **ResumeConversionApiV1ConvertConversionIdResumePost**
> ConvertSuccessResponse ResumeConversionApiV1ConvertConversionIdResumePost (string conversionId, ConvertResumeRequest convertResumeRequest)

Reprendre une conversion avec corrections

Reprend une conversion après complétion des données manquantes ou correction des erreurs.  L'extraction OCR est conservée, les données sont mises à jour avec les corrections, puis une nouvelle validation Schematron est effectuée.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **conversionId** | **string** | Conversion ID returned by POST /convert (UUID format) |  |
| **convertResumeRequest** | [**ConvertResumeRequest**](ConvertResumeRequest.md) |  |  |

### Return type

[**ConvertSuccessResponse**](ConvertSuccessResponse.md)

### Authorization

[HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **404** | Conversion non trouvée ou expirée |  -  |
| **422** | Validation toujours en échec |  -  |
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

