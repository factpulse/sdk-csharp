# FactPulse.SDK.Api.CDARCycleDeVieApi

All URIs are relative to *https://factpulse.fr*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GenerateCdarApiV1CdarGeneratePost**](CDARCycleDeVieApi.md#generatecdarapiv1cdargeneratepost) | **POST** /api/v1/cdar/generate | Générer un message CDAR |
| [**GetActionCodesApiV1CdarActionCodesGet**](CDARCycleDeVieApi.md#getactioncodesapiv1cdaractioncodesget) | **GET** /api/v1/cdar/action-codes | Liste des codes action CDAR |
| [**GetReasonCodesApiV1CdarReasonCodesGet**](CDARCycleDeVieApi.md#getreasoncodesapiv1cdarreasoncodesget) | **GET** /api/v1/cdar/reason-codes | Liste des codes motif CDAR |
| [**GetStatusCodesApiV1CdarStatusCodesGet**](CDARCycleDeVieApi.md#getstatuscodesapiv1cdarstatuscodesget) | **GET** /api/v1/cdar/status-codes | Liste des codes statut CDAR |
| [**SubmitCdarApiV1CdarSubmitPost**](CDARCycleDeVieApi.md#submitcdarapiv1cdarsubmitpost) | **POST** /api/v1/cdar/submit | Générer et soumettre un message CDAR |
| [**SubmitCdarXmlApiV1CdarSubmitXmlPost**](CDARCycleDeVieApi.md#submitcdarxmlapiv1cdarsubmitxmlpost) | **POST** /api/v1/cdar/submit-xml | Soumettre un XML CDAR pré-généré |
| [**ValidateCdarApiV1CdarValidatePost**](CDARCycleDeVieApi.md#validatecdarapiv1cdarvalidatepost) | **POST** /api/v1/cdar/validate | Valider des données CDAR |

<a id="generatecdarapiv1cdargeneratepost"></a>
# **GenerateCdarApiV1CdarGeneratePost**
> GenerateCDARResponse GenerateCdarApiV1CdarGeneratePost (CreateCDARRequest createCDARRequest)

Générer un message CDAR

Génère un message XML CDAR (Cross Domain Acknowledgement and Response) pour communiquer le statut d'une facture.  **Types de messages:** - **23** (Traitement): Message de cycle de vie standard - **305** (Transmission): Message de transmission entre plateformes  **Règles métier:** - BR-FR-CDV-14: Le statut 212 (ENCAISSEE) requiert un montant encaissé - BR-FR-CDV-15: Les statuts 206/207/208/210/213/501 requièrent un code motif


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **createCDARRequest** | [**CreateCDARRequest**](CreateCDARRequest.md) |  |  |

### Return type

[**GenerateCDARResponse**](GenerateCDARResponse.md)

### Authorization

[HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **400** | Requête invalide |  -  |
| **422** | Erreur de validation |  -  |
| **500** | Erreur serveur |  -  |
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getactioncodesapiv1cdaractioncodesget"></a>
# **GetActionCodesApiV1CdarActionCodesGet**
> ActionCodesResponse GetActionCodesApiV1CdarActionCodesGet ()

Liste des codes action CDAR

Retourne la liste complète des codes action (BR-FR-CDV-CL-10).  Ces codes indiquent l'action demandée sur la facture.


### Parameters
This endpoint does not need any parameter.
### Return type

[**ActionCodesResponse**](ActionCodesResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **400** | Requête invalide |  -  |
| **422** | Erreur de validation |  -  |
| **500** | Erreur serveur |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getreasoncodesapiv1cdarreasoncodesget"></a>
# **GetReasonCodesApiV1CdarReasonCodesGet**
> ReasonCodesResponse GetReasonCodesApiV1CdarReasonCodesGet ()

Liste des codes motif CDAR

Retourne la liste complète des codes motif de statut (BR-FR-CDV-CL-09).  Ces codes expliquent la raison d'un statut particulier.


### Parameters
This endpoint does not need any parameter.
### Return type

[**ReasonCodesResponse**](ReasonCodesResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **400** | Requête invalide |  -  |
| **422** | Erreur de validation |  -  |
| **500** | Erreur serveur |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getstatuscodesapiv1cdarstatuscodesget"></a>
# **GetStatusCodesApiV1CdarStatusCodesGet**
> StatusCodesResponse GetStatusCodesApiV1CdarStatusCodesGet ()

Liste des codes statut CDAR

Retourne la liste complète des codes statut de facture (BR-FR-CDV-CL-06).  Ces codes indiquent l'état du cycle de vie d'une facture.


### Parameters
This endpoint does not need any parameter.
### Return type

[**StatusCodesResponse**](StatusCodesResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **400** | Requête invalide |  -  |
| **422** | Erreur de validation |  -  |
| **500** | Erreur serveur |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="submitcdarapiv1cdarsubmitpost"></a>
# **SubmitCdarApiV1CdarSubmitPost**
> SubmitCDARResponse SubmitCdarApiV1CdarSubmitPost (int userId, BodySubmitCdarApiV1CdarSubmitPost bodySubmitCdarApiV1CdarSubmitPost, string jwtToken = null, string clientUid = null)

Générer et soumettre un message CDAR

Génère un message CDAR et le soumet à la plateforme PA/PDP.  Nécessite une authentification AFNOR valide.  **Types de flux (flowType):** - `CustomerInvoiceLC`: Cycle de vie côté client (acheteur) - `SupplierInvoiceLC`: Cycle de vie côté fournisseur (vendeur)


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **userId** | **int** |  |  |
| **bodySubmitCdarApiV1CdarSubmitPost** | [**BodySubmitCdarApiV1CdarSubmitPost**](BodySubmitCdarApiV1CdarSubmitPost.md) |  |  |
| **jwtToken** | **string** |  | [optional]  |
| **clientUid** | **string** |  | [optional]  |

### Return type

[**SubmitCDARResponse**](SubmitCDARResponse.md)

### Authorization

[HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **400** | Requête invalide |  -  |
| **422** | Erreur de validation |  -  |
| **500** | Erreur serveur |  -  |
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="submitcdarxmlapiv1cdarsubmitxmlpost"></a>
# **SubmitCdarXmlApiV1CdarSubmitXmlPost**
> SubmitCDARResponse SubmitCdarXmlApiV1CdarSubmitXmlPost (int userId, BodySubmitCdarXmlApiV1CdarSubmitXmlPost bodySubmitCdarXmlApiV1CdarSubmitXmlPost, string jwtToken = null, string clientUid = null)

Soumettre un XML CDAR pré-généré

Soumet un message XML CDAR pré-généré à la plateforme PA/PDP.  Utile pour soumettre des XML générés par d'autres systèmes.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **userId** | **int** |  |  |
| **bodySubmitCdarXmlApiV1CdarSubmitXmlPost** | [**BodySubmitCdarXmlApiV1CdarSubmitXmlPost**](BodySubmitCdarXmlApiV1CdarSubmitXmlPost.md) |  |  |
| **jwtToken** | **string** |  | [optional]  |
| **clientUid** | **string** |  | [optional]  |

### Return type

[**SubmitCDARResponse**](SubmitCDARResponse.md)

### Authorization

[HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **400** | Requête invalide |  -  |
| **422** | Erreur de validation |  -  |
| **500** | Erreur serveur |  -  |
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="validatecdarapiv1cdarvalidatepost"></a>
# **ValidateCdarApiV1CdarValidatePost**
> ValidateCDARResponse ValidateCdarApiV1CdarValidatePost (ValidateCDARRequest validateCDARRequest)

Valider des données CDAR

Valide les données CDAR sans générer le XML.  Vérifie: - Les formats des champs (SIREN, dates, etc.) - Les codes enums (statut, motif, action) - Les règles métier BR-FR-CDV-*


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **validateCDARRequest** | [**ValidateCDARRequest**](ValidateCDARRequest.md) |  |  |

### Return type

[**ValidateCDARResponse**](ValidateCDARResponse.md)

### Authorization

[HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **400** | Requête invalide |  -  |
| **422** | Erreur de validation |  -  |
| **500** | Erreur serveur |  -  |
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

