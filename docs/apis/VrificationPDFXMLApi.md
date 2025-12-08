# FactPulse.SDK.Api.VrificationPDFXMLApi

All URIs are relative to *http://localhost*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ObtenirStatutVerificationApiV1VerificationVerifierAsyncIdTacheStatutGet**](VrificationPDFXMLApi.md#obtenirstatutverificationapiv1verificationverifierasyncidtachestatutget) | **GET** /api/v1/verification/verifier-async/{id_tache}/statut | Obtenir le statut d&#39;une vérification asynchrone |
| [**ObtenirStatutVerificationApiV1VerificationVerifierAsyncIdTacheStatutGet_0**](VrificationPDFXMLApi.md#obtenirstatutverificationapiv1verificationverifierasyncidtachestatutget_0) | **GET** /api/v1/verification/verifier-async/{id_tache}/statut | Obtenir le statut d&#39;une vérification asynchrone |
| [**VerifierPdfAsyncApiV1VerificationVerifierAsyncPost**](VrificationPDFXMLApi.md#verifierpdfasyncapiv1verificationverifierasyncpost) | **POST** /api/v1/verification/verifier-async | Vérifier la conformité PDF/XML Factur-X (asynchrone) |
| [**VerifierPdfAsyncApiV1VerificationVerifierAsyncPost_0**](VrificationPDFXMLApi.md#verifierpdfasyncapiv1verificationverifierasyncpost_0) | **POST** /api/v1/verification/verifier-async | Vérifier la conformité PDF/XML Factur-X (asynchrone) |
| [**VerifierPdfSyncApiV1VerificationVerifierPost**](VrificationPDFXMLApi.md#verifierpdfsyncapiv1verificationverifierpost) | **POST** /api/v1/verification/verifier | Vérifier la conformité PDF/XML Factur-X (synchrone) |
| [**VerifierPdfSyncApiV1VerificationVerifierPost_0**](VrificationPDFXMLApi.md#verifierpdfsyncapiv1verificationverifierpost_0) | **POST** /api/v1/verification/verifier | Vérifier la conformité PDF/XML Factur-X (synchrone) |

<a id="obtenirstatutverificationapiv1verificationverifierasyncidtachestatutget"></a>
# **ObtenirStatutVerificationApiV1VerificationVerifierAsyncIdTacheStatutGet**
> StatutTache ObtenirStatutVerificationApiV1VerificationVerifierAsyncIdTacheStatutGet (string idTache)

Obtenir le statut d'une vérification asynchrone

Récupère le statut et le résultat d'une tâche de vérification asynchrone.  **Statuts possibles:** - `PENDING`: Tâche en attente dans la file - `STARTED`: Tâche en cours d'exécution - `SUCCESS`: Tâche terminée avec succès (voir `resultat`) - `FAILURE`: Erreur système (exception non gérée)  **Note:** Le champ `resultat.statut` peut être \"SUCCES\" ou \"ERREUR\" indépendamment du statut Celery (qui sera toujours SUCCESS si la tâche s'est exécutée).


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **idTache** | **string** |  |  |

### Return type

[**StatutTache**](StatutTache.md)

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

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="obtenirstatutverificationapiv1verificationverifierasyncidtachestatutget_0"></a>
# **ObtenirStatutVerificationApiV1VerificationVerifierAsyncIdTacheStatutGet_0**
> StatutTache ObtenirStatutVerificationApiV1VerificationVerifierAsyncIdTacheStatutGet_0 (string idTache)

Obtenir le statut d'une vérification asynchrone

Récupère le statut et le résultat d'une tâche de vérification asynchrone.  **Statuts possibles:** - `PENDING`: Tâche en attente dans la file - `STARTED`: Tâche en cours d'exécution - `SUCCESS`: Tâche terminée avec succès (voir `resultat`) - `FAILURE`: Erreur système (exception non gérée)  **Note:** Le champ `resultat.statut` peut être \"SUCCES\" ou \"ERREUR\" indépendamment du statut Celery (qui sera toujours SUCCESS si la tâche s'est exécutée).


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **idTache** | **string** |  |  |

### Return type

[**StatutTache**](StatutTache.md)

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

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="verifierpdfasyncapiv1verificationverifierasyncpost"></a>
# **VerifierPdfAsyncApiV1VerificationVerifierAsyncPost**
> ReponseTache VerifierPdfAsyncApiV1VerificationVerifierAsyncPost (System.IO.Stream fichierPdf, bool forcerOcr = null)

Vérifier la conformité PDF/XML Factur-X (asynchrone)

Vérifie la conformité PDF/XML Factur-X de manière asynchrone.  **IMPORTANT**: Seuls les PDF Factur-X (avec XML embarqué) sont acceptés. Les PDF sans XML Factur-X retourneront une erreur `NOT_FACTURX` dans le résultat.  Cette version utilise une tâche Celery et peut faire appel au service OCR si le PDF est une image ou si `forcer_ocr=true`.  **Retourne immédiatement** un ID de tâche. Utilisez `/verifier-async/{id_tache}/statut` pour récupérer le résultat.  **Principe de vérification (Factur-X 1.08):** - Principe n°2: Le XML ne peut contenir que des infos présentes dans le PDF - Principe n°4: Toute info XML doit être présente et conforme dans le PDF  **Champs vérifiés:** - Identification: BT-1 (n° facture), BT-2 (date), BT-3 (type), BT-5 (devise), BT-23 (cadre) - Vendeur: BT-27 (nom), BT-29 (SIRET), BT-30 (SIREN), BT-31 (TVA) - Acheteur: BT-44 (nom), BT-46 (SIRET), BT-47 (SIREN), BT-48 (TVA) - Montants: BT-109 (HT), BT-110 (TVA), BT-112 (TTC), BT-115 (à payer) - Ventilation TVA: BT-116, BT-117, BT-118, BT-119 - Lignes de facture: BT-153, BT-129, BT-146, BT-131 - Notes obligatoires: PMT, PMD, AAB - Règle BR-FR-09: cohérence SIRET/SIREN  **Avantages par rapport à la version synchrone:** - Support OCR pour les PDF images (via service DocTR) - Timeout plus long pour les gros documents - Ne bloque pas le serveur


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **fichierPdf** | **System.IO.Stream****System.IO.Stream** | Fichier PDF Factur-X à vérifier |  |
| **forcerOcr** | **bool** | Forcer l&#39;utilisation de l&#39;OCR même si le PDF contient du texte natif | [optional] [default to false] |

### Return type

[**ReponseTache**](ReponseTache.md)

### Authorization

[HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **202** | Successful Response |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="verifierpdfasyncapiv1verificationverifierasyncpost_0"></a>
# **VerifierPdfAsyncApiV1VerificationVerifierAsyncPost_0**
> ReponseTache VerifierPdfAsyncApiV1VerificationVerifierAsyncPost_0 (System.IO.Stream fichierPdf, bool forcerOcr = null)

Vérifier la conformité PDF/XML Factur-X (asynchrone)

Vérifie la conformité PDF/XML Factur-X de manière asynchrone.  **IMPORTANT**: Seuls les PDF Factur-X (avec XML embarqué) sont acceptés. Les PDF sans XML Factur-X retourneront une erreur `NOT_FACTURX` dans le résultat.  Cette version utilise une tâche Celery et peut faire appel au service OCR si le PDF est une image ou si `forcer_ocr=true`.  **Retourne immédiatement** un ID de tâche. Utilisez `/verifier-async/{id_tache}/statut` pour récupérer le résultat.  **Principe de vérification (Factur-X 1.08):** - Principe n°2: Le XML ne peut contenir que des infos présentes dans le PDF - Principe n°4: Toute info XML doit être présente et conforme dans le PDF  **Champs vérifiés:** - Identification: BT-1 (n° facture), BT-2 (date), BT-3 (type), BT-5 (devise), BT-23 (cadre) - Vendeur: BT-27 (nom), BT-29 (SIRET), BT-30 (SIREN), BT-31 (TVA) - Acheteur: BT-44 (nom), BT-46 (SIRET), BT-47 (SIREN), BT-48 (TVA) - Montants: BT-109 (HT), BT-110 (TVA), BT-112 (TTC), BT-115 (à payer) - Ventilation TVA: BT-116, BT-117, BT-118, BT-119 - Lignes de facture: BT-153, BT-129, BT-146, BT-131 - Notes obligatoires: PMT, PMD, AAB - Règle BR-FR-09: cohérence SIRET/SIREN  **Avantages par rapport à la version synchrone:** - Support OCR pour les PDF images (via service DocTR) - Timeout plus long pour les gros documents - Ne bloque pas le serveur


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **fichierPdf** | **System.IO.Stream****System.IO.Stream** | Fichier PDF Factur-X à vérifier |  |
| **forcerOcr** | **bool** | Forcer l&#39;utilisation de l&#39;OCR même si le PDF contient du texte natif | [optional] [default to false] |

### Return type

[**ReponseTache**](ReponseTache.md)

### Authorization

[HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **202** | Successful Response |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="verifierpdfsyncapiv1verificationverifierpost"></a>
# **VerifierPdfSyncApiV1VerificationVerifierPost**
> ReponseVerificationSucces VerifierPdfSyncApiV1VerificationVerifierPost (System.IO.Stream fichierPdf)

Vérifier la conformité PDF/XML Factur-X (synchrone)

Vérifie la conformité entre le PDF et son XML Factur-X embarqué.  **IMPORTANT**: Seuls les PDF Factur-X (avec XML embarqué) sont acceptés. Les PDF sans XML Factur-X seront rejetés avec une erreur 400.  Cette version synchrone utilise uniquement l'extraction PDF native (pdfplumber). Pour les PDF images nécessitant de l'OCR, utilisez l'endpoint `/verifier-async`.  **Principe de vérification (Factur-X 1.08):** - Principe n°2: Le XML ne peut contenir que des infos présentes dans le PDF - Principe n°4: Toute info XML doit être présente et conforme dans le PDF  **Champs vérifiés:** - Identification: BT-1 (n° facture), BT-2 (date), BT-3 (type), BT-5 (devise), BT-23 (cadre) - Vendeur: BT-27 (nom), BT-29 (SIRET), BT-30 (SIREN), BT-31 (TVA) - Acheteur: BT-44 (nom), BT-46 (SIRET), BT-47 (SIREN), BT-48 (TVA) - Montants: BT-109 (HT), BT-110 (TVA), BT-112 (TTC), BT-115 (à payer) - Ventilation TVA: BT-116, BT-117, BT-118, BT-119 - Lignes de facture: BT-153, BT-129, BT-146, BT-131 - Notes obligatoires: PMT, PMD, AAB - Règle BR-FR-09: cohérence SIRET/SIREN


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **fichierPdf** | **System.IO.Stream****System.IO.Stream** | Fichier PDF Factur-X à vérifier |  |

### Return type

[**ReponseVerificationSucces**](ReponseVerificationSucces.md)

### Authorization

[HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Vérification réussie |  -  |
| **400** | Erreur de vérification (PDF non Factur-X, invalide, etc.) |  -  |
| **413** | PDF trop volumineux ou trop de pages |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="verifierpdfsyncapiv1verificationverifierpost_0"></a>
# **VerifierPdfSyncApiV1VerificationVerifierPost_0**
> ReponseVerificationSucces VerifierPdfSyncApiV1VerificationVerifierPost_0 (System.IO.Stream fichierPdf)

Vérifier la conformité PDF/XML Factur-X (synchrone)

Vérifie la conformité entre le PDF et son XML Factur-X embarqué.  **IMPORTANT**: Seuls les PDF Factur-X (avec XML embarqué) sont acceptés. Les PDF sans XML Factur-X seront rejetés avec une erreur 400.  Cette version synchrone utilise uniquement l'extraction PDF native (pdfplumber). Pour les PDF images nécessitant de l'OCR, utilisez l'endpoint `/verifier-async`.  **Principe de vérification (Factur-X 1.08):** - Principe n°2: Le XML ne peut contenir que des infos présentes dans le PDF - Principe n°4: Toute info XML doit être présente et conforme dans le PDF  **Champs vérifiés:** - Identification: BT-1 (n° facture), BT-2 (date), BT-3 (type), BT-5 (devise), BT-23 (cadre) - Vendeur: BT-27 (nom), BT-29 (SIRET), BT-30 (SIREN), BT-31 (TVA) - Acheteur: BT-44 (nom), BT-46 (SIRET), BT-47 (SIREN), BT-48 (TVA) - Montants: BT-109 (HT), BT-110 (TVA), BT-112 (TTC), BT-115 (à payer) - Ventilation TVA: BT-116, BT-117, BT-118, BT-119 - Lignes de facture: BT-153, BT-129, BT-146, BT-131 - Notes obligatoires: PMT, PMD, AAB - Règle BR-FR-09: cohérence SIRET/SIREN


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **fichierPdf** | **System.IO.Stream****System.IO.Stream** | Fichier PDF Factur-X à vérifier |  |

### Return type

[**ReponseVerificationSucces**](ReponseVerificationSucces.md)

### Authorization

[HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Vérification réussie |  -  |
| **400** | Erreur de vérification (PDF non Factur-X, invalide, etc.) |  -  |
| **413** | PDF trop volumineux ou trop de pages |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

