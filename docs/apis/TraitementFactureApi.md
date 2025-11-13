# FactPulse.SDK.Api.TraitementFactureApi

All URIs are relative to *http://localhost*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GenererCertificatTestApiV1TraitementGenererCertificatTestPost**](TraitementFactureApi.md#generercertificattestapiv1traitementgenerercertificattestpost) | **POST** /api/v1/traitement/generer-certificat-test | Générer un certificat X.509 auto-signé de test |
| [**GenererFactureApiV1TraitementGenererFacturePost**](TraitementFactureApi.md#genererfactureapiv1traitementgenererfacturepost) | **POST** /api/v1/traitement/generer-facture | Générer une facture Factur-X |
| [**ObtenirStatutTacheApiV1TraitementTachesIdTacheStatutGet**](TraitementFactureApi.md#obtenirstatuttacheapiv1traitementtachesidtachestatutget) | **GET** /api/v1/traitement/taches/{id_tache}/statut | Obtenir le statut d&#39;une tâche de génération |
| [**SignerPdfApiV1TraitementSignerPdfPost**](TraitementFactureApi.md#signerpdfapiv1traitementsignerpdfpost) | **POST** /api/v1/traitement/signer-pdf | Signer un PDF avec le certificat du client (PAdES-B-LT) |
| [**SignerPdfAsyncApiV1TraitementSignerPdfAsyncPost**](TraitementFactureApi.md#signerpdfasyncapiv1traitementsignerpdfasyncpost) | **POST** /api/v1/traitement/signer-pdf-async | Signer un PDF de manière asynchrone (Celery) |
| [**SoumettreFactureCompleteApiV1TraitementFacturesSoumettreCompletePost**](TraitementFactureApi.md#soumettrefacturecompleteapiv1traitementfacturessoumettrecompletepost) | **POST** /api/v1/traitement/factures/soumettre-complete | Soumettre une facture complète (génération + signature + soumission) |
| [**SoumettreFactureCompleteAsyncApiV1TraitementFacturesSoumettreCompleteAsyncPost**](TraitementFactureApi.md#soumettrefacturecompleteasyncapiv1traitementfacturessoumettrecompleteasyncpost) | **POST** /api/v1/traitement/factures/soumettre-complete-async | Soumettre une facture complète (asynchrone avec Celery) |
| [**ValiderPdfFacturxApiV1TraitementValiderPdfFacturxPost**](TraitementFactureApi.md#validerpdffacturxapiv1traitementvaliderpdffacturxpost) | **POST** /api/v1/traitement/valider-pdf-facturx | Valider un PDF Factur-X complet |
| [**ValiderPdfFacturxAsyncApiV1TraitementValiderFacturxAsyncPost**](TraitementFactureApi.md#validerpdffacturxasyncapiv1traitementvaliderfacturxasyncpost) | **POST** /api/v1/traitement/valider-facturx-async | Valider un PDF Factur-X (asynchrone avec polling) |
| [**ValiderSignaturePdfEndpointApiV1TraitementValiderSignaturePdfPost**](TraitementFactureApi.md#validersignaturepdfendpointapiv1traitementvalidersignaturepdfpost) | **POST** /api/v1/traitement/valider-signature-pdf | Valider les signatures électroniques d&#39;un PDF |
| [**ValiderXmlApiV1TraitementValiderXmlPost**](TraitementFactureApi.md#validerxmlapiv1traitementvaliderxmlpost) | **POST** /api/v1/traitement/valider-xml | Valider un XML Factur-X existant |

<a id="generercertificattestapiv1traitementgenerercertificattestpost"></a>
# **GenererCertificatTestApiV1TraitementGenererCertificatTestPost**
> GenerateCertificateResponse GenererCertificatTestApiV1TraitementGenererCertificatTestPost (GenerateCertificateRequest generateCertificateRequest)

Générer un certificat X.509 auto-signé de test

Génère un certificat X.509 auto-signé pour les tests de signature électronique PDF.      **⚠️ ATTENTION : Certificat de TEST uniquement !**      Ce certificat est :     - ✅ Adapté pour tests et développement     - ✅ Compatible signature PDF (PAdES)     - ✅ Conforme eIDAS niveau **SES** (Simple Electronic Signature)     - ❌ **JAMAIS utilisable en production**     - ❌ **Non reconnu** par les navigateurs et lecteurs PDF     - ❌ **Aucune valeur juridique**      ## Niveaux eIDAS      - **SES** (Simple) : Certificat auto-signé ← Généré par cet endpoint     - **AdES** (Advanced) : Certificat CA commerciale (Let's Encrypt, etc.)     - **QES** (Qualified) : Certificat qualifié PSCO (CertEurope, Universign, etc.)      ## Utilisation      Une fois généré, le certificat peut être :      1. **Enregistré dans Django** (recommandé) :        - Django Admin > Certificats de signature        - Upload `certificat_pem` et `cle_privee_pem`      2. **Utilisé directement** :        - Signer un PDF avec `/signer-pdf`        - Le certificat sera automatiquement utilisé      ## Exemple d'appel      ```bash     curl -X POST \"https://www.factpulse.fr/api/facturation/generer-certificat-test\" \\       -H \"Authorization: Bearer eyJ0eXAi...\" \\       -H \"Content-Type: application/json\" \\       -d '{         \"cn\": \"Test Client XYZ\",         \"organisation\": \"Client XYZ SARL\",         \"email\": \"contact@xyz.fr\",         \"duree_jours\": 365       }'     ```      ## Cas d'usage      - Tests de signature PDF en développement     - POC de signature électronique     - Formation et démos     - Tests d'intégration automatisés      ## Conformité technique      Certificat généré avec :     - Clé RSA 2048 ou 4096 bits     - Algorithme SHA-256     - Extensions Key Usage : `digitalSignature`, `contentCommitment` (non-repudiation)     - Extensions Extended Key Usage : `codeSigning`, `emailProtection`     - Validité : 1 jour à 10 ans (configurable)     - Format : PEM (certificat et clé)     - Optionnel : PKCS#12 (.p12)


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **generateCertificateRequest** | [**GenerateCertificateRequest**](GenerateCertificateRequest.md) |  |  |

### Return type

[**GenerateCertificateResponse**](GenerateCertificateResponse.md)

### Authorization

[HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Certificat généré avec succès |  -  |
| **400** | Requête invalide (paramètres incorrects) |  -  |
| **500** | Erreur serveur lors de la génération |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="genererfactureapiv1traitementgenererfacturepost"></a>
# **GenererFactureApiV1TraitementGenererFacturePost**
> ReponseTache GenererFactureApiV1TraitementGenererFacturePost (string donneesFacture, ProfilAPI profil = null, FormatSortie formatSortie = null, bool autoEnrichir = null, System.IO.Stream sourcePdf = null)

Générer une facture Factur-X

Génère une facture électronique au format Factur-X conforme aux normes européennes.  ## Normes appliquées  - **Factur-X** (France) : Norme FNFE-MPE (Forum National de la Facture Électronique) - **ZUGFeRD** (Allemagne) : Format allemand compatible Factur-X - **EN 16931** : Norme sémantique européenne pour la facturation électronique - **ISO 19005-3** (PDF/A-3) : Archivage électronique à long terme - **Cross Industry Invoice (CII)** : Syntaxe XML UN/CEFACT  ## 🆕 Nouveau : Format simplifié avec auto-enrichissement (P0.1)  Vous pouvez désormais créer une facture en fournissant uniquement : - Un numéro de facture - Un SIRET émetteur + **IBAN** (obligatoire) - Un SIRET destinataire - Les lignes de facture (description, quantité, prix HT)  **Exemple format simplifié** : ```json {   \"numero\": \"FACT-2025-001\",   \"emetteur\": {     \"siret\": \"92019522900017\",     \"iban\": \"FR7630001007941234567890185\"   },   \"destinataire\": {\"siret\": \"35600000000048\"},   \"lignes\": [     {\"description\": \"Prestation\", \"quantite\": 10, \"prix_ht\": 100.00, \"tva\": 20.0}   ] } ```  **⚠️ Champs obligatoires (format simplifié)** : - `numero` : Numéro de facture unique - `emetteur.siret` : SIRET de l'émetteur (14 chiffres) - `emetteur.iban` : IBAN du compte bancaire (pas d'API publique pour le récupérer) - `destinataire.siret` : SIRET du destinataire - `lignes[]` : Au moins une ligne de facture  **Ce qui se passe automatiquement avec `auto_enrichir=True`** : - ✅ Enrichissement des noms depuis API Chorus Pro - ✅ Enrichissement des adresses depuis API Recherche Entreprises (gratuite, publique) - ✅ Calcul automatique de la TVA intracommunautaire (FR + clé + SIREN) - ✅ Récupération de l'ID Chorus Pro pour la facturation électronique - ✅ Calcul des totaux HT/TVA/TTC - ✅ Génération des dates (aujourd'hui + échéance 30j) - ✅ Gestion multi-taux de TVA  **Identifiants supportés** : - SIRET (14 chiffres) : Établissement précis ⭐ Recommandé - SIREN (9 chiffres) : Entreprise (sélection auto du siège) - Types spéciaux : UE_HORS_FRANCE, RIDET, TAHITI, etc.  ## Contrôles effectués lors de la génération  ### 1. Validation des données (Pydantic) - Types de données (montants en Decimal, dates ISO 8601) - Formats (SIRET 14 chiffres, SIREN 9 chiffres, IBAN) - Champs obligatoires selon le profil - Cohérence des montants (HT + TVA = TTC)  ### 2. Génération XML conforme CII - Sérialisation selon schéma XSD Cross Industry Invoice - Namespaces UN/CEFACT corrects - Structure hiérarchique respectée - Encodage UTF-8 sans BOM  ### 3. Validation Schematron - Règles métier du profil sélectionné (MINIMUM, BASIC, EN16931, EXTENDED) - Cardinalité des éléments (obligatoire, optionnel, répétable) - Règles de calcul (totaux, TVA, remises) - Conformité européenne EN 16931  ### 4. Conversion PDF/A-3 (si format_sortie='pdf') - Conversion du PDF source en PDF/A-3 via Ghostscript - Embarquement du XML Factur-X dans le PDF - Métadonnées XMP conformes - Profil ICC sRGB pour les couleurs - Suppression des éléments interdits (JavaScript, formulaires)  ## Fonctionnement  1. **Soumission** : La facture est mise en file d'attente Celery pour traitement asynchrone 2. **Retour immédiat** : Vous recevez un `id_tache` (HTTP 202 Accepted) 3. **Suivi** : Utilisez l'endpoint `/taches/{id_tache}/statut` pour suivre l'avancement  ## Formats de sortie  - **xml** : Génère uniquement le XML Factur-X (recommandé pour les tests) - **pdf** : Génère un PDF/A-3 avec XML embarqué (nécessite `source_pdf`)  ## Profils Factur-X  - **MINIMUM** : Données minimales (facture simplifiée) - **BASIC** : Informations de base (PME) - **EN16931** : Standard européen (recommandé, conforme directive 2014/55/UE) - **EXTENDED** : Toutes les données disponibles (grands comptes)  ## Ce que vous obtenez  Après traitement réussi (statut `completed`) : - **XML seul** : Fichier XML encodé base64 conforme Factur-X - **PDF/A-3** : PDF avec XML embarqué, prêt pour envoi/archivage - **Métadonnées** : Profil, version Factur-X, taille fichier - **Validation** : Confirmation de conformité Schematron  ## Validation  Les données sont validées automatiquement selon le format détecté. En cas d'erreur, un statut 422 est retourné avec les détails des champs invalides.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **donneesFacture** | **string** | Données de la facture au format JSON.              Deux formats acceptés :             1. **Format classique** : Structure complète FactureFacturX (tous les champs)             2. **Format simplifié** (🆕 P0.1) : Structure minimale avec auto-enrichissement              Le format est détecté automatiquement !              |  |
| **profil** | **ProfilAPI** | Profil Factur-X : MINIMUM, BASIC, EN16931 ou EXTENDED. | [optional]  |
| **formatSortie** | **FormatSortie** | Format de sortie : &#39;xml&#39; (XML seul) ou &#39;pdf&#39; (PDF Factur-X avec XML embarqué). | [optional]  |
| **autoEnrichir** | **bool** | 🆕 Activer l&#39;auto-enrichissement depuis SIRET/SIREN (format simplifié uniquement) | [optional] [default to true] |
| **sourcePdf** | **System.IO.Stream****System.IO.Stream** |  | [optional]  |

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
| **400** | Données de facture invalides ou fichier PDF manquant |  -  |
| **422** | Erreur de validation des données de la facture |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="obtenirstatuttacheapiv1traitementtachesidtachestatutget"></a>
# **ObtenirStatutTacheApiV1TraitementTachesIdTacheStatutGet**
> StatutTache ObtenirStatutTacheApiV1TraitementTachesIdTacheStatutGet (string idTache)

Obtenir le statut d'une tâche de génération

Récupère l'état d'avancement d'une tâche de génération de facture.  ## États possibles  - **PENDING** : Tâche en attente de traitement - **STARTED** : Tâche en cours d'exécution - **SUCCESS** : Tâche terminée (vérifier `resultat.statut` pour le résultat réel) - **FAILURE** : Erreur système lors de l'exécution - **RETRY** : Tentative de ré-exécution en cours  ## Champ resultat  Quand la tâche est terminée (SUCCESS), le champ `resultat` contient : - `statut` : \"SUCCES\" ou \"ERREUR\" - `chemin_fichier` : Chemin du fichier généré (si succès) - `message_erreur` : Détails de l'erreur (si échec)  ## Usage  Appelez cet endpoint en boucle (polling) toutes les 2-3 secondes jusqu'à ce que le statut soit SUCCESS ou FAILURE.


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
| **200** | État actuel de la tâche |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="signerpdfapiv1traitementsignerpdfpost"></a>
# **SignerPdfApiV1TraitementSignerPdfPost**
> Object SignerPdfApiV1TraitementSignerPdfPost (System.IO.Stream fichierPdf, string raison = null, string localisation = null, string contact = null, string fieldName = null, bool usePadesLt = null, bool useTimestamp = null)

Signer un PDF avec le certificat du client (PAdES-B-LT)

Signe un PDF uploadé avec le certificat électronique configuré pour le client (via client_uid du JWT).      **Standards supportés** : PAdES-B-B, PAdES-B-T (horodatage), PAdES-B-LT (archivage long terme).      **Niveaux eIDAS** : SES (auto-signé), AdES (CA commerciale), QES (PSCO - hors scope).      **⚠️ Disclaimer légal** : Les signatures générées sont des cachets électroniques au sens     du règlement eIDAS. Le niveau de validité juridique dépend du certificat utilisé (SES/AdES/QES).     FactPulse ne fournit pas de certificats qualifiés QES - vous devez obtenir un certificat auprès     d'un PSCO (Prestataire de Services de Confiance qualifié) pour une validité juridique maximale.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **fichierPdf** | **System.IO.Stream****System.IO.Stream** | Fichier PDF à signer (sera traité puis retourné signé en base64) |  |
| **raison** | **string** |  | [optional]  |
| **localisation** | **string** |  | [optional]  |
| **contact** | **string** |  | [optional]  |
| **fieldName** | **string** | Nom du champ de signature PDF | [optional] [default to &quot;FactPulseSignature&quot;] |
| **usePadesLt** | **bool** | Activer PAdES-B-LT (archivage long terme avec données de validation embarquées). NÉCESSITE un certificat avec accès OCSP/CRL. | [optional] [default to false] |
| **useTimestamp** | **bool** | Activer l&#39;horodatage RFC 3161 avec FreeTSA (PAdES-B-T) | [optional] [default to true] |

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
| **200** | PDF signé avec succès |  -  |
| **400** | Certificat invalide ou expiré |  -  |
| **404** | Aucun certificat configuré pour ce client |  -  |
| **401** | Non authentifié - Token JWT manquant ou invalide |  -  |
| **503** | Service Django inaccessible |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="signerpdfasyncapiv1traitementsignerpdfasyncpost"></a>
# **SignerPdfAsyncApiV1TraitementSignerPdfAsyncPost**
> Object SignerPdfAsyncApiV1TraitementSignerPdfAsyncPost (System.IO.Stream fichierPdf, string raison = null, string localisation = null, string contact = null, string fieldName = null, bool usePadesLt = null, bool useTimestamp = null)

Signer un PDF de manière asynchrone (Celery)

Signe un PDF uploadé de manière asynchrone via une tâche Celery.      **Différence avec /signer-pdf** :     - `/signer-pdf` : Signature synchrone (blocage jusqu'à la fin)     - `/signer-pdf-async` : Signature asynchrone (retourne immédiatement un task_id)      **Avantages de l'async** :     - Pas de timeout pour les gros fichiers     - Pas de blocage du worker FastAPI     - Possibilité de suivre la progression via le task_id     - Idéal pour les traitements par lot      **Standards supportés** : PAdES-B-B, PAdES-B-T (horodatage), PAdES-B-LT (archivage long terme).      **⚠️ Disclaimer légal** : Identique à /signer-pdf (voir documentation de cet endpoint).


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **fichierPdf** | **System.IO.Stream****System.IO.Stream** | Fichier PDF à signer (traité de manière asynchrone) |  |
| **raison** | **string** |  | [optional]  |
| **localisation** | **string** |  | [optional]  |
| **contact** | **string** |  | [optional]  |
| **fieldName** | **string** | Nom du champ de signature PDF | [optional] [default to &quot;FactPulseSignature&quot;] |
| **usePadesLt** | **bool** | Activer PAdES-B-LT (archivage long terme avec données de validation embarquées). NÉCESSITE un certificat avec accès OCSP/CRL. | [optional] [default to false] |
| **useTimestamp** | **bool** | Activer l&#39;horodatage RFC 3161 avec FreeTSA (PAdES-B-T) | [optional] [default to true] |

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
| **202** | Tâche de signature créée avec succès |  -  |
| **400** | Paramètres invalides |  -  |
| **401** | Non authentifié - Token JWT manquant ou invalide |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="soumettrefacturecompleteapiv1traitementfacturessoumettrecompletepost"></a>
# **SoumettreFactureCompleteApiV1TraitementFacturesSoumettreCompletePost**
> SoumettreFactureCompleteResponse SoumettreFactureCompleteApiV1TraitementFacturesSoumettreCompletePost (SoumettreFactureCompleteRequest soumettreFactureCompleteRequest)

Soumettre une facture complète (génération + signature + soumission)

Endpoint unifié pour soumettre une facture complète vers différentes destinations.      **Workflow automatisé :**     1. **Auto-enrichissement** (optionnel) : récupère les données via APIs publiques et Chorus Pro/AFNOR     2. **Génération PDF Factur-X** : crée un PDF/A-3 avec XML embarqué     3. **Signature électronique** (optionnelle) : signe le PDF avec un certificat     4. **Soumission** : envoie vers la destination choisie (Chorus Pro ou AFNOR PDP)      **Destinations supportées :**     - **Chorus Pro** : plateforme B2G française (factures vers secteur public)     - **AFNOR PDP** : Plateformes de Dématérialisation Partenaires      **Credentials de destination - 2 modes disponibles :**      **Mode 1 - Récupération via JWT (recommandé) :**     - Les credentials sont récupérés automatiquement via le `client_uid` du JWT     - Ne pas fournir le champ `credentials` dans `destination`     - Architecture 0-trust : aucun secret dans le payload     - Exemple : `\"destination\": {\"type\": \"chorus_pro\"}`      **Mode 2 - Credentials dans le payload :**     - Fournir les credentials directement dans le payload     - Utile pour tests ou intégrations tierces     - Exemple : `\"destination\": {\"type\": \"chorus_pro\", \"credentials\": {...}}`       **Signature électronique (optionnelle) - 2 modes disponibles :**      **Mode 1 - Certificat stocké (recommandé) :**     - Le certificat est récupéré automatiquement via le `client_uid` du JWT     - Aucune clé à fournir dans le payload     - Signature PAdES-B-LT avec horodatage (conforme eIDAS)     - Exemple : `\"signature\": {\"raison\": \"Conformité Factur-X\"}`      **Mode 2 - Clés dans le payload (pour tests) :**     - Fournir `key_pem` et `cert_pem` directement     - Format PEM accepté : brut ou base64     - Utile pour tests ou cas spéciaux sans certificat stocké     - Exemple : `\"signature\": {\"key_pem\": \"- -- --BEGIN...\", \"cert_pem\": \"- -- --BEGIN...\"}`      Si `key_pem` et `cert_pem` sont fournis → Mode 2     Sinon → Mode 1 (certificat récupéré via `client_uid`)


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **soumettreFactureCompleteRequest** | [**SoumettreFactureCompleteRequest**](SoumettreFactureCompleteRequest.md) |  |  |

### Return type

[**SoumettreFactureCompleteResponse**](SoumettreFactureCompleteResponse.md)

### Authorization

[HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="soumettrefacturecompleteasyncapiv1traitementfacturessoumettrecompleteasyncpost"></a>
# **SoumettreFactureCompleteAsyncApiV1TraitementFacturesSoumettreCompleteAsyncPost**
> ReponseTache SoumettreFactureCompleteAsyncApiV1TraitementFacturesSoumettreCompleteAsyncPost (SoumettreFactureCompleteRequest soumettreFactureCompleteRequest)

Soumettre une facture complète (asynchrone avec Celery)

Version asynchrone de l'endpoint `/factures/soumettre-complete` utilisant Celery pour le traitement en arrière-plan.      **Workflow automatisé (identique à la version synchrone) :**     1. **Auto-enrichissement** (optionnel) : récupère les données via APIs publiques et Chorus Pro/AFNOR     2. **Génération PDF Factur-X** : crée un PDF/A-3 avec XML embarqué     3. **Signature électronique** (optionnelle) : signe le PDF avec un certificat     4. **Soumission** : envoie vers la destination choisie (Chorus Pro ou AFNOR PDP)      **Destinations supportées :**     - **Chorus Pro** : plateforme B2G française (factures vers secteur public)     - **AFNOR PDP** : Plateformes de Dématérialisation Partenaires      **Différences avec la version synchrone :**     - ✅ **Non-bloquant** : Retourne immédiatement un `id_tache` (HTTP 202 Accepted)     - ✅ **Traitement en arrière-plan** : La facture est traitée par un worker Celery     - ✅ **Suivi d'avancement** : Utilisez `/taches/{id_tache}/statut` pour suivre le statut     - ✅ **Idéal pour gros volumes** : Permet de traiter de nombreuses factures en parallèle      **Comment utiliser :**     1. **Soumission** : Appelez cet endpoint avec vos données de facture     2. **Retour immédiat** : Vous recevez un `id_tache` (ex: \"abc123-def456\")     3. **Suivi** : Appelez `/taches/{id_tache}/statut` pour vérifier l'avancement     4. **Résultat** : Quand `statut = \"SUCCESS\"`, le champ `resultat` contient la réponse complète      **Credentials et signature** : Mêmes modes que la version synchrone (JWT ou payload).


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **soumettreFactureCompleteRequest** | [**SoumettreFactureCompleteRequest**](SoumettreFactureCompleteRequest.md) |  |  |

### Return type

[**ReponseTache**](ReponseTache.md)

### Authorization

[HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **202** | Successful Response |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="validerpdffacturxapiv1traitementvaliderpdffacturxpost"></a>
# **ValiderPdfFacturxApiV1TraitementValiderPdfFacturxPost**
> ResultatValidationPDFAPI ValiderPdfFacturxApiV1TraitementValiderPdfFacturxPost (System.IO.Stream fichierPdf, ProfilAPI profil = null, bool useVerapdf = null)

Valider un PDF Factur-X complet

Valide un PDF Factur-X complet selon les normes européennes et françaises.  ## Normes de validation appliquées  - **EN 16931** : Norme sémantique européenne (directive 2014/55/UE) - **ISO 19005-3** (PDF/A-3) : Archivage électronique à long terme - **Factur-X / ZUGFeRD** : Spécification franco-allemande - **Schematron** : Validation des règles métier XML - **eIDAS** : Règlement européen sur l'identification électronique (signatures)  ## Contrôles effectués  ### 1. Extraction et validation du XML Factur-X **Contrôles réalisés :** - Présence d'un fichier XML embarqué (`factur-x.xml` ou `zugferd-invoice.xml`) - Détection automatique du profil (MINIMUM, BASIC, EN16931, EXTENDED) - Parsing XML avec validation UTF-8 - Extraction du GuidelineSpecifiedDocumentContextParameter/ID  **Validation Schematron :** - Règles métier du profil détecté (MINIMUM : 45 règles, EN16931 : 178 règles) - Cardinalité des éléments obligatoires - Cohérence des calculs (montants HT, TVA, TTC, remises) - Formats des identifiants (SIRET, TVA intracommunautaire, IBAN) - Codes normalisés (codes pays ISO, unités UN/ECE, codes TVA)  **Ce qui est vérifié :** - ✅ Structure XML conforme XSD Cross Industry Invoice - ✅ Namespace UN/CEFACT correct - ✅ Règles de gestion européennes (BR-xx) - ✅ Règles françaises spécifiques (FR-xx)  ### 2. Conformité PDF/A-3 **Validation de base (métadonnées) :** - Présence du champ `/Type` à `Catalog` - Métadonnée `pdfaid:part` = 3 (PDF/A-3) - Métadonnée `pdfaid:conformance` = B ou U - Version PDF >= 1.4  **Validation stricte VeraPDF (si use_verapdf=True) :** - 146+ règles ISO 19005-3 (PDF/A-3B) - Absence de contenu interdit (JavaScript, multimedia, formulaires dynamiques) - Polices embarquées et sous-ensembles corrects - Espaces colorimétriques conformes (sRGB, DeviceGray) - Structure de fichier valide (cross-reference table) - Métadonnées XMP conformes ISO 16684-1  **Ce qui est vérifié :** - ✅ Fichier archivable à long terme (20+ ans) - ✅ Lisibilité garantie (polices embarquées) - ✅ Conformité légale (France, Allemagne, UE)  ### 3. Métadonnées XMP (eXtensible Metadata Platform) **Contrôles réalisés :** - Présence du bloc `<?xpacket>` avec métadonnées XMP - Namespace `fx:` pour Factur-X : `urn:factur-x:pdfa:CrossIndustryDocument:invoice:1p0#` - Champs Factur-X obligatoires :   - `fx:ConformanceLevel` : Profil (MINIMUM, BASIC, EN16931, EXTENDED)   - `fx:DocumentFileName` : Nom du XML embarqué   - `fx:DocumentType` : \"INVOICE\"   - `fx:Version` : Version Factur-X (1.0.07)  **Ce qui est vérifié :** - ✅ Métadonnées conformes ISO 16684-1 - ✅ Profil Factur-X déclaré correct - ✅ Version Factur-X supportée  ### 4. Signatures électroniques **Détection et analyse :** - Présence de dictionnaires `/Sig` dans le PDF - Type de signature : PAdES (PDF Advanced Electronic Signature) - Extraction des informations :   - Nom du signataire (`/Name`)   - Date de signature (`/M`)   - Raison de la signature (`/Reason`)   - Lieu de signature (`/Location`)   - Type de signature (approval, certification)  **Ce qui est vérifié :** - ✅ Présence de signatures ou cachets - ✅ Nombre de signatures (mono ou multi-signature) - ℹ️ Pas de vérification cryptographique (nécessite certificats)  ## Paramètres  - **fichier_pdf** (requis) : Le fichier PDF Factur-X à valider - **profil** (optionnel) : Profil attendu. Si absent, détection automatique depuis le XML - **use_verapdf** (optionnel, défaut=false) : Active la validation stricte PDF/A avec VeraPDF   - `false` : Validation rapide par métadonnées (2-3 secondes)   - `true` : Validation complète ISO 19005-3 (15-30 secondes, **recommandé en production**)  ## Réponse détaillée  ```json {   \"est_conforme\": true,   \"xml\": {     \"present\": true,     \"conforme\": true,     \"profil\": \"EN16931\",     \"erreurs\": []   },   \"pdfa\": {     \"conforme\": true,     \"version\": \"PDF/A-3B\",     \"methode\": \"verapdf\",     \"erreurs\": []   },   \"xmp\": {     \"present\": true,     \"conforme\": true,     \"metadonnees\": {...}   },   \"signatures\": {     \"present\": true,     \"nombre\": 1,     \"details\": [...]   } } ```  ## Cas d'usage  - **Avant envoi** : Valider la facture générée avant transmission à un client - **À réception** : Vérifier la conformité d'une facture reçue d'un fournisseur - **Audit** : Contrôler la qualité de lots de factures - **Conformité légale** : S'assurer du respect des obligations B2B/B2G en France - **Debugging** : Identifier les problèmes dans le processus de génération - **Archivage** : Garantir la validité à long terme (PDF/A-3)  ## Temps de traitement  - Validation basique : 2-3 secondes - Validation VeraPDF : 15-30 secondes (dépend de la taille du PDF)


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **fichierPdf** | **System.IO.Stream****System.IO.Stream** | Fichier PDF Factur-X à valider (format .pdf). |  |
| **profil** | **ProfilAPI** |  | [optional]  |
| **useVerapdf** | **bool** | Active la validation stricte PDF/A avec VeraPDF (recommandé pour la production). Si False, utilise une validation basique par métadonnées. | [optional] [default to false] |

### Return type

[**ResultatValidationPDFAPI**](ResultatValidationPDFAPI.md)

### Authorization

[HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Validation effectuée avec succès (vérifier le champ est_conforme pour le résultat) |  -  |
| **400** | Fichier PDF invalide ou impossible à lire |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="validerpdffacturxasyncapiv1traitementvaliderfacturxasyncpost"></a>
# **ValiderPdfFacturxAsyncApiV1TraitementValiderFacturxAsyncPost**
> ReponseTache ValiderPdfFacturxAsyncApiV1TraitementValiderFacturxAsyncPost (System.IO.Stream fichierPdf, ProfilAPI profil = null, bool useVerapdf = null)

Valider un PDF Factur-X (asynchrone avec polling)

Valide un PDF Factur-X de manière asynchrone avec système de polling.  ## Fonctionnement  1. **Soumission** : Le PDF est mis en file d'attente pour validation asynchrone 2. **Retour immédiat** : Vous recevez un `id_tache` (HTTP 202) 3. **Suivi** : Utilisez l'endpoint `/taches/{id_tache}/statut` pour suivre l'avancement  ## Avantages du mode asynchrone  - **Pas de timeout** : Idéal pour les gros PDFs ou la validation VeraPDF (qui peut prendre plusieurs secondes) - **Scalabilité** : Les validations sont traitées par des workers Celery dédiés - **Suivi d'état** : Permet de suivre la progression de la validation - **Non-bloquant** : Votre client ne reste pas en attente pendant la validation  ## Quand utiliser ce mode ?  - **Validation VeraPDF activée** (`use_verapdf=True`) : La validation stricte peut prendre 2-10 secondes - **Gros fichiers PDF** : PDFs > 1 MB - **Traitement par lots** : Validation de multiples factures en parallèle - **Intégration asynchrone** : Votre système supporte le polling  ## Contrôles effectués  ### 1. Extraction et validation du XML Factur-X - Vérifie la présence d'un fichier XML embarqué conforme Factur-X - Détecte automatiquement le profil utilisé (MINIMUM, BASIC, EN16931, EXTENDED) - Valide le XML contre les règles Schematron du profil détecté  ### 2. Conformité PDF/A - **Sans VeraPDF** : Validation basique par métadonnées (rapide, ~100ms) - **Avec VeraPDF** : Validation stricte selon ISO 19005 (146+ règles, 2-10s)   - Détecte la version PDF/A (PDF/A-1, PDF/A-3, etc.)   - Rapports détaillés des non-conformités  ### 3. Métadonnées XMP - Vérifie la présence de métadonnées XMP dans le PDF - Valide la conformité des métadonnées Factur-X (profil, version) - Extrait toutes les métadonnées XMP disponibles  ### 4. Signatures électroniques - Détecte la présence de signatures ou cachets électroniques - Extrait les informations sur chaque signature (signataire, date, raison) - Compte le nombre de signatures présentes  ## Paramètres  - **fichier_pdf** : Le fichier PDF Factur-X à valider - **profil** : Le profil Factur-X attendu (optionnel). Si non spécifié, le profil   sera automatiquement détecté depuis le fichier XML embarqué. - **use_verapdf** : Active la validation stricte PDF/A avec VeraPDF.   ⚠️ **Attention** : VeraPDF peut prendre 2-10 secondes selon la taille du PDF.   Recommandé uniquement en mode asynchrone pour éviter les timeouts.  ## Récupération du résultat  Après soumission, utilisez l'endpoint `GET /taches/{id_tache}/statut` pour récupérer le résultat.  **Exemple de polling** : ```python import requests import time  # 1. Soumettre la tâche response = requests.post(\"/valider-facturx-async\", files={\"fichier_pdf\": pdf_file}) task_id = response.json()[\"id_tache\"]  # 2. Polling toutes les 2 secondes while True:     status_response = requests.get(f\"/taches/{task_id}/statut\")     status = status_response.json()      if status[\"statut\"] == \"SUCCESS\":         resultat = status[\"resultat\"][\"resultat_validation\"]         print(f\"Conforme: {resultat['est_conforme']}\")         break     elif status[\"statut\"] == \"FAILURE\":         print(f\"Erreur: {status['resultat']['message_erreur']}\")         break      time.sleep(2)  # Attendre 2 secondes avant le prochain check ```  ## Cas d'usage  - Valider des factures avant envoi avec VeraPDF (validation stricte) - Traiter des lots de factures en parallèle - Intégrer la validation dans un pipeline asynchrone - Valider des PDFs volumineux sans risque de timeout


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **fichierPdf** | **System.IO.Stream****System.IO.Stream** | Fichier PDF Factur-X à valider (format .pdf). |  |
| **profil** | **ProfilAPI** |  | [optional]  |
| **useVerapdf** | **bool** | Active la validation stricte PDF/A avec VeraPDF (recommandé pour la production). Peut prendre plusieurs secondes. | [optional] [default to false] |

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
| **400** | Fichier PDF invalide ou impossible à lire |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="validersignaturepdfendpointapiv1traitementvalidersignaturepdfpost"></a>
# **ValiderSignaturePdfEndpointApiV1TraitementValiderSignaturePdfPost**
> Object ValiderSignaturePdfEndpointApiV1TraitementValiderSignaturePdfPost (System.IO.Stream fichierPdf)

Valider les signatures électroniques d'un PDF

Valide les signatures électroniques présentes dans un PDF uploadé.      **Vérifications effectuées** :     - Présence de signatures     - Intégrité du document (non modifié depuis signature)     - Validité des certificats     - Chaîne de confiance (si disponible)     - Présence d'horodatage (PAdES-B-T)     - Données de validation (PAdES-B-LT)      **Standards supportés** : PAdES-B-B, PAdES-B-T, PAdES-B-LT, ISO 32000-2.      **⚠️ Note** : Cette validation est technique (intégrité cryptographique). La validité juridique     dépend du niveau eIDAS du certificat (SES/AdES/QES) et du contexte d'utilisation.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **fichierPdf** | **System.IO.Stream****System.IO.Stream** | Fichier PDF à valider (sera analysé pour détecter et valider les signatures) |  |

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
| **200** | Validation réussie |  -  |
| **400** | Fichier invalide ou non lisible |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="validerxmlapiv1traitementvaliderxmlpost"></a>
# **ValiderXmlApiV1TraitementValiderXmlPost**
> ReponseValidationSucces ValiderXmlApiV1TraitementValiderXmlPost (System.IO.Stream fichierXml, ProfilAPI profil = null)

Valider un XML Factur-X existant

Valide un fichier XML Factur-X contre les règles métier Schematron selon la norme EN 16931.  ## Norme appliquée  **Schematron ISO/IEC 19757-3** : Langage de validation de règles métier pour XML - Validation sémantique (au-delà de la syntaxe XSD) - Règles métier européennes EN 16931 - Règles françaises spécifiques Factur-X - Calculs arithmétiques et cohérence des données  ## Profils et règles validées  ### MINIMUM (45 règles) - Identifiant de facture unique - Dates (émission, échéance) - Identifiants parties (SIRET/SIREN) - Montant total TTC  ### BASIC (102 règles) - Toutes les règles MINIMUM - Lignes de facture détaillées - Calculs de TVA basiques - Modes de paiement - Références (commande, contrat)  ### EN16931 (178 règles) - Toutes les règles BASIC - **Règles européennes (BR-xx)** : 81 règles business - **Règles françaises (FR-xx)** : 12 règles spécifiques France - **Calculs avancés (CR-xx)** : 32 règles de calcul - **Codes normalisés (CL-xx)** : 52 listes de codes  ### EXTENDED (210+ règles) - Toutes les règles EN16931 - Informations logistiques - Données comptables avancées - Références externes multiples  ## Contrôles effectués  ### 1. Validation syntaxique - Parsing XML correct (UTF-8, bien formé) - Namespaces UN/CEFACT présents - Structure hiérarchique respectée  ### 2. Règles business (BR-xx) Exemples : - `BR-1` : Le total de la facture doit être égal à la somme des totaux de lignes + montants au niveau document - `BR-CO-10` : La somme des montants de base de TVA doit être égale au total net de la facture - `BR-16` : Le code de devise de la facture doit figurer dans la liste ISO 4217  ### 3. Règles françaises (FR-xx) Exemples : - `FR-1` : Le SIRET fournisseur doit avoir 14 chiffres - `FR-2` : Le SIRET client doit avoir 14 chiffres (si présent) - `FR-5` : Le numéro de TVA intracommunautaire doit être au format FRxx999999999  ### 4. Règles de calcul (CR-xx) - Montants HT + TVA = TTC - Somme des lignes = Total document - Remises et majorations correctement appliquées - Arrondis conformes (2 décimales pour les montants)  ### 5. Codes normalisés (CL-xx) - Codes pays ISO 3166-1 alpha-2 - Codes devises ISO 4217 - Unités de mesure UN/ECE Rec 20 - Codes TVA (types, catégories, exonérations) - SchemeID pour identifiants (0002=SIREN, 0009=SIRET, etc.)  ## Processus de validation  1. **Chargement XSLT** : Fichier Schematron converti en XSLT (Saxon-HE) 2. **Transformation** : Application des règles sur le XML 3. **Analyse résultats** : Extraction des erreurs (`failed-assert`) et avertissements (`successful-report`) 4. **Rapport** : Liste structurée des non-conformités  ## Réponses  **200 OK** : XML conforme ```json {   \"message\": \"Le XML est conforme au profil EN16931\" } ```  **400 Bad Request** : XML non conforme ```json {   \"detail\": [     \"[BR-1] Le total de la facture (120.00) ne correspond pas à la somme calculée (100.00 + 20.00)\",     \"[FR-1] Le SIRET fournisseur doit contenir exactement 14 chiffres\"   ] } ```  ## Cas d'usage  - **Pré-validation** : Vérifier un XML avant intégration dans un PDF/A - **Debugging** : Identifier précisément les erreurs de génération - **Tests** : Valider des XMLs de test ou d'exemple - **Conformité** : S'assurer du respect des règles européennes et françaises - **Développement** : Tester rapidement sans générer de PDF  ## Temps de traitement  - Profil MINIMUM : ~0.5 seconde - Profil EN16931 : ~1-2 secondes - Profil EXTENDED : ~2-3 secondes


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **fichierXml** | **System.IO.Stream****System.IO.Stream** | Fichier XML Factur-X à valider (format .xml). |  |
| **profil** | **ProfilAPI** | Profil de validation (MINIMUM, BASIC, EN16931, EXTENDED). | [optional]  |

### Return type

[**ReponseValidationSucces**](ReponseValidationSucces.md)

### Authorization

[HTTPBearer](../README.md#HTTPBearer)

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful Response |  -  |
| **400** | Le XML ne respecte pas les règles du profil Factur-X |  -  |
| **422** | Validation Error |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

