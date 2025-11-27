# FactPulse.SDK.Api.ChorusProApi

All URIs are relative to *http://localhost*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**AjouterFichierApiV1ChorusProTransversesAjouterFichierPost**](ChorusProApi.md#ajouterfichierapiv1chorusprotransversesajouterfichierpost) | **POST** /api/v1/chorus-pro/transverses/ajouter-fichier | Ajouter une pièce jointe |
| [**CompleterFactureApiV1ChorusProFacturesCompleterPost**](ChorusProApi.md#completerfactureapiv1chorusprofacturescompleterpost) | **POST** /api/v1/chorus-pro/factures/completer | Compléter une facture suspendue (Fournisseur) |
| [**ConsulterFactureApiV1ChorusProFacturesConsulterPost**](ChorusProApi.md#consulterfactureapiv1chorusprofacturesconsulterpost) | **POST** /api/v1/chorus-pro/factures/consulter | Consulter le statut d&#39;une facture |
| [**ConsulterStructureApiV1ChorusProStructuresConsulterPost**](ChorusProApi.md#consulterstructureapiv1chorusprostructuresconsulterpost) | **POST** /api/v1/chorus-pro/structures/consulter | Consulter les détails d&#39;une structure |
| [**ListerServicesStructureApiV1ChorusProStructuresIdStructureCppServicesGet**](ChorusProApi.md#listerservicesstructureapiv1chorusprostructuresidstructurecppservicesget) | **GET** /api/v1/chorus-pro/structures/{id_structure_cpp}/services | Lister les services d&#39;une structure |
| [**ObtenirIdChorusProDepuisSiretApiV1ChorusProStructuresObtenirIdDepuisSiretPost**](ChorusProApi.md#obteniridchorusprodepuissiretapiv1chorusprostructuresobteniriddepuissiretpost) | **POST** /api/v1/chorus-pro/structures/obtenir-id-depuis-siret | Utilitaire : Obtenir l&#39;ID Chorus Pro depuis un SIRET |
| [**RechercherFacturesDestinataireApiV1ChorusProFacturesRechercherDestinatairePost**](ChorusProApi.md#rechercherfacturesdestinataireapiv1chorusprofacturesrechercherdestinatairepost) | **POST** /api/v1/chorus-pro/factures/rechercher-destinataire | Rechercher factures reçues (Destinataire) |
| [**RechercherFacturesFournisseurApiV1ChorusProFacturesRechercherFournisseurPost**](ChorusProApi.md#rechercherfacturesfournisseurapiv1chorusprofacturesrechercherfournisseurpost) | **POST** /api/v1/chorus-pro/factures/rechercher-fournisseur | Rechercher factures émises (Fournisseur) |
| [**RechercherStructuresApiV1ChorusProStructuresRechercherPost**](ChorusProApi.md#rechercherstructuresapiv1chorusprostructuresrechercherpost) | **POST** /api/v1/chorus-pro/structures/rechercher | Rechercher des structures Chorus Pro |
| [**RecyclerFactureApiV1ChorusProFacturesRecyclerPost**](ChorusProApi.md#recyclerfactureapiv1chorusprofacturesrecyclerpost) | **POST** /api/v1/chorus-pro/factures/recycler | Recycler une facture (Fournisseur) |
| [**SoumettreFactureApiV1ChorusProFacturesSoumettrePost**](ChorusProApi.md#soumettrefactureapiv1chorusprofacturessoumettrepost) | **POST** /api/v1/chorus-pro/factures/soumettre | Soumettre une facture à Chorus Pro |
| [**TelechargerGroupeFacturesApiV1ChorusProFacturesTelechargerGroupePost**](ChorusProApi.md#telechargergroupefacturesapiv1chorusprofacturestelechargergroupepost) | **POST** /api/v1/chorus-pro/factures/telecharger-groupe | Télécharger un groupe de factures |
| [**TraiterFactureRecueApiV1ChorusProFacturesTraiterFactureRecuePost**](ChorusProApi.md#traiterfacturerecueapiv1chorusprofacturestraiterfacturerecuepost) | **POST** /api/v1/chorus-pro/factures/traiter-facture-recue | Traiter une facture reçue (Destinataire) |
| [**ValideurConsulterFactureApiV1ChorusProFacturesValideurConsulterPost**](ChorusProApi.md#valideurconsulterfactureapiv1chorusprofacturesvalideurconsulterpost) | **POST** /api/v1/chorus-pro/factures/valideur/consulter | Consulter une facture (Valideur) |
| [**ValideurRechercherFacturesApiV1ChorusProFacturesValideurRechercherPost**](ChorusProApi.md#valideurrechercherfacturesapiv1chorusprofacturesvalideurrechercherpost) | **POST** /api/v1/chorus-pro/factures/valideur/rechercher | Rechercher factures à valider (Valideur) |
| [**ValideurTraiterFactureApiV1ChorusProFacturesValideurTraiterPost**](ChorusProApi.md#valideurtraiterfactureapiv1chorusprofacturesvalideurtraiterpost) | **POST** /api/v1/chorus-pro/factures/valideur/traiter | Valider ou refuser une facture (Valideur) |

<a id="ajouterfichierapiv1chorusprotransversesajouterfichierpost"></a>
# **AjouterFichierApiV1ChorusProTransversesAjouterFichierPost**
> Object AjouterFichierApiV1ChorusProTransversesAjouterFichierPost (Dictionary<string, Object> requestBody)

Ajouter une pièce jointe

Ajoute une pièce jointe au compte utilisateur courant.      **Taille max** : 10 Mo par fichier      **Payload exemple** :     ```json     {       \"pieceJointeFichier\": \"JVBERi0xLjQKJeLjz9MKNSAwIG9iago8P...\",       \"pieceJointeNom\": \"bon_commande.pdf\",       \"pieceJointeTypeMime\": \"application/pdf\",       \"pieceJointeExtension\": \"PDF\"     }     ```      **Retour** : L'ID de la pièce jointe (`pieceJointeIdFichier`) à utiliser ensuite dans `/factures/completer`.      **Extensions acceptées** : PDF, JPG, PNG, ZIP, XML, etc.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **requestBody** | [**Dictionary&lt;string, Object&gt;**](Object.md) |  |  |

### Return type

**Object**

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

<a id="completerfactureapiv1chorusprofacturescompleterpost"></a>
# **CompleterFactureApiV1ChorusProFacturesCompleterPost**
> Object CompleterFactureApiV1ChorusProFacturesCompleterPost (Dictionary<string, Object> requestBody)

Compléter une facture suspendue (Fournisseur)

Complète une facture au statut SUSPENDUE en ajoutant des pièces jointes ou un commentaire.      **Statut requis** : SUSPENDUE      **Actions possibles** :     - Ajouter des pièces jointes (justificatifs, bons de commande, etc.)     - Modifier le commentaire      **Payload exemple** :     ```json     {       \"identifiantFactureCPP\": 12345,       \"commentaire\": \"Voici les justificatifs demandés\",       \"listePiecesJointes\": [         {           \"pieceJointeIdFichier\": 98765,           \"pieceJointeNom\": \"bon_commande.pdf\"         }       ]     }     ```      **Note** : Les pièces jointes doivent d'abord être uploadées via `/transverses/ajouter-fichier`.      **Après complétion** : La facture repasse au statut MISE_A_DISPOSITION.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **requestBody** | [**Dictionary&lt;string, Object&gt;**](Object.md) |  |  |

### Return type

**Object**

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

<a id="consulterfactureapiv1chorusprofacturesconsulterpost"></a>
# **ConsulterFactureApiV1ChorusProFacturesConsulterPost**
> ConsulterFactureResponse ConsulterFactureApiV1ChorusProFacturesConsulterPost (ConsulterFactureRequest consulterFactureRequest)

Consulter le statut d'une facture

Récupère les informations et le statut actuel d'une facture soumise à Chorus Pro.      **Retour** :     - Numéro et date de facture     - Montant TTC     - **Statut courant** : SOUMISE, VALIDEE, REJETEE, SUSPENDUE, MANDATEE, MISE_EN_PAIEMENT, etc.     - Structure destinataire      **Cas d'usage** :     - Suivre l'évolution du traitement d'une facture     - Vérifier si une facture a été validée ou rejetée     - Obtenir la date de mise en paiement      **Polling** : Appelez cet endpoint régulièrement pour suivre l'évolution du statut.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **consulterFactureRequest** | [**ConsulterFactureRequest**](ConsulterFactureRequest.md) |  |  |

### Return type

[**ConsulterFactureResponse**](ConsulterFactureResponse.md)

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

<a id="consulterstructureapiv1chorusprostructuresconsulterpost"></a>
# **ConsulterStructureApiV1ChorusProStructuresConsulterPost**
> ConsulterStructureResponse ConsulterStructureApiV1ChorusProStructuresConsulterPost (ConsulterStructureRequest consulterStructureRequest)

Consulter les détails d'une structure

Récupère les informations détaillées d'une structure Chorus Pro.       **Retour** :     - Raison sociale     - Numéro de TVA intracommunautaire     - Email de contact     - **Paramètres obligatoires** : Indique si le code service et/ou numéro d'engagement sont requis pour soumettre une facture      **Étape typique** : Appelée après `rechercher-structures` pour savoir quels champs sont obligatoires avant de soumettre une facture.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **consulterStructureRequest** | [**ConsulterStructureRequest**](ConsulterStructureRequest.md) |  |  |

### Return type

[**ConsulterStructureResponse**](ConsulterStructureResponse.md)

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

<a id="listerservicesstructureapiv1chorusprostructuresidstructurecppservicesget"></a>
# **ListerServicesStructureApiV1ChorusProStructuresIdStructureCppServicesGet**
> RechercherServicesResponse ListerServicesStructureApiV1ChorusProStructuresIdStructureCppServicesGet (int idStructureCpp)

Lister les services d'une structure

Récupère la liste des services actifs d'une structure publique.      **Cas d'usage** :     - Lister les services disponibles pour une administration     - Vérifier qu'un code service existe avant de soumettre une facture      **Retour** :     - Liste des services avec leur code, libellé et statut (actif/inactif)


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **idStructureCpp** | **int** |  |  |

### Return type

[**RechercherServicesResponse**](RechercherServicesResponse.md)

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

<a id="obteniridchorusprodepuissiretapiv1chorusprostructuresobteniriddepuissiretpost"></a>
# **ObtenirIdChorusProDepuisSiretApiV1ChorusProStructuresObtenirIdDepuisSiretPost**
> ObtenirIdChorusProResponse ObtenirIdChorusProDepuisSiretApiV1ChorusProStructuresObtenirIdDepuisSiretPost (ObtenirIdChorusProRequest obtenirIdChorusProRequest)

Utilitaire : Obtenir l'ID Chorus Pro depuis un SIRET

**Utilitaire pratique** pour obtenir l'ID Chorus Pro d'une structure à partir de son SIRET.       Cette fonction wrapper combine :     1. Recherche de la structure par SIRET     2. Extraction de l'`id_structure_cpp` si une seule structure est trouvée      **Retour** :     - `id_structure_cpp` : ID Chorus Pro (0 si non trouvé ou si plusieurs résultats)     - `designation_structure` : Nom de la structure (si trouvée)     - `message` : Message explicatif      **Cas d'usage** :     - Raccourci pour obtenir directement l'ID Chorus Pro avant de soumettre une facture     - Alternative simplifiée à `rechercher-structures` + extraction manuelle de l'ID      **Note** : Si plusieurs structures correspondent au SIRET (rare), retourne 0 et un message d'erreur.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **obtenirIdChorusProRequest** | [**ObtenirIdChorusProRequest**](ObtenirIdChorusProRequest.md) |  |  |

### Return type

[**ObtenirIdChorusProResponse**](ObtenirIdChorusProResponse.md)

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

<a id="rechercherfacturesdestinataireapiv1chorusprofacturesrechercherdestinatairepost"></a>
# **RechercherFacturesDestinataireApiV1ChorusProFacturesRechercherDestinatairePost**
> Object RechercherFacturesDestinataireApiV1ChorusProFacturesRechercherDestinatairePost (Dictionary<string, Object> requestBody)

Rechercher factures reçues (Destinataire)

Recherche les factures reçues par le destinataire connecté.      **Filtres** :     - Téléchargée / non téléchargée     - Dates de réception     - Statut (MISE_A_DISPOSITION, SUSPENDUE, etc.)     - Fournisseur      **Indicateur utile** : `factureTelechargeeParDestinataire` permet de savoir si la facture a déjà été téléchargée.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **requestBody** | [**Dictionary&lt;string, Object&gt;**](Object.md) |  |  |

### Return type

**Object**

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

<a id="rechercherfacturesfournisseurapiv1chorusprofacturesrechercherfournisseurpost"></a>
# **RechercherFacturesFournisseurApiV1ChorusProFacturesRechercherFournisseurPost**
> Object RechercherFacturesFournisseurApiV1ChorusProFacturesRechercherFournisseurPost (Dictionary<string, Object> requestBody)

Rechercher factures émises (Fournisseur)

Recherche les factures émises par le fournisseur connecté.      **Filtres disponibles** :     - Numéro de facture     - Dates (début/fin)     - Statut     - Structure destinataire     - Montant      **Cas d'usage** :     - Suivi des factures émises     - Vérification des statuts     - Export pour comptabilité


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **requestBody** | [**Dictionary&lt;string, Object&gt;**](Object.md) |  |  |

### Return type

**Object**

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

<a id="rechercherstructuresapiv1chorusprostructuresrechercherpost"></a>
# **RechercherStructuresApiV1ChorusProStructuresRechercherPost**
> RechercherStructureResponse RechercherStructuresApiV1ChorusProStructuresRechercherPost (RechercherStructureRequest rechercherStructureRequest)

Rechercher des structures Chorus Pro

Recherche des structures (entreprises, administrations) enregistrées sur Chorus Pro.      **Cas d'usage** :     - Trouver l'ID Chorus Pro d'une structure à partir de son SIRET     - Vérifier si une structure est enregistrée sur Chorus Pro     - Lister les structures correspondant à des critères      **Filtres disponibles** :     - Identifiant (SIRET, SIREN, etc.)     - Raison sociale     - Type d'identifiant     - Structures privées uniquement      **Étape typique** : Appelée avant `soumettre-facture` pour obtenir l'`id_structure_cpp` du destinataire.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **rechercherStructureRequest** | [**RechercherStructureRequest**](RechercherStructureRequest.md) |  |  |

### Return type

[**RechercherStructureResponse**](RechercherStructureResponse.md)

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

<a id="recyclerfactureapiv1chorusprofacturesrecyclerpost"></a>
# **RecyclerFactureApiV1ChorusProFacturesRecyclerPost**
> Object RecyclerFactureApiV1ChorusProFacturesRecyclerPost (Dictionary<string, Object> requestBody)

Recycler une facture (Fournisseur)

Recycle une facture au statut A_RECYCLER en modifiant les données d'acheminement.      **Statut requis** : A_RECYCLER      **Champs modifiables** :     - Destinataire (`idStructureCPP`)     - Code service     - Numéro d'engagement      **Cas d'usage** :     - Erreur de destinataire     - Changement de service facturation     - Mise à jour du numéro d'engagement      **Payload exemple** :     ```json     {       \"identifiantFactureCPP\": 12345,       \"idStructureCPP\": 67890,       \"codeService\": \"SERVICE_01\",       \"numeroEngagement\": \"ENG2024001\"     }     ```      **Note** : La facture conserve son numéro et ses montants, seuls les champs d'acheminement changent.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **requestBody** | [**Dictionary&lt;string, Object&gt;**](Object.md) |  |  |

### Return type

**Object**

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

<a id="soumettrefactureapiv1chorusprofacturessoumettrepost"></a>
# **SoumettreFactureApiV1ChorusProFacturesSoumettrePost**
> SoumettreFactureResponse SoumettreFactureApiV1ChorusProFacturesSoumettrePost (SoumettreFactureRequest soumettreFactureRequest)

Soumettre une facture à Chorus Pro

Soumet une facture électronique à une structure publique via Chorus Pro.       **📋 Workflow complet** :     1. **Uploader le PDF Factur-X** via `/transverses/ajouter-fichier` → récupérer `pieceJointeId`     2. **Obtenir l'ID structure** via `/structures/rechercher` ou `/structures/obtenir-id-depuis-siret`     3. **Vérifier les paramètres obligatoires** via `/structures/consulter`     4. **Soumettre la facture** avec le `piece_jointe_principale_id` obtenu à l'étape 1      **Pré-requis** :     1. Avoir l'`id_structure_cpp` du destinataire (via `/structures/rechercher`)     2. Connaître les paramètres obligatoires (via `/structures/consulter`) :        - Code service si `code_service_doit_etre_renseigne=true`        - Numéro d'engagement si `numero_ej_doit_etre_renseigne=true`     3. Avoir uploadé le PDF Factur-X (via `/transverses/ajouter-fichier`)      **Format attendu** :     - `piece_jointe_principale_id` : ID retourné par `/transverses/ajouter-fichier`     - Montants : Chaînes de caractères avec 2 décimales (ex: \"1250.50\")     - Dates : Format ISO 8601 (YYYY-MM-DD)      **Retour** :     - `identifiant_facture_cpp` : ID Chorus Pro de la facture créée     - `numero_flux_depot` : Numéro de suivi du dépôt      **Statuts possibles après soumission** :     - SOUMISE : En attente de validation     - VALIDEE : Validée par le destinataire     - REJETEE : Rejetée (erreur de données ou refus métier)     - SUSPENDUE : En attente d'informations complémentaires      **Note** : Utilisez `/factures/consulter` pour suivre l'évolution du statut.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **soumettreFactureRequest** | [**SoumettreFactureRequest**](SoumettreFactureRequest.md) |  |  |

### Return type

[**SoumettreFactureResponse**](SoumettreFactureResponse.md)

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

<a id="telechargergroupefacturesapiv1chorusprofacturestelechargergroupepost"></a>
# **TelechargerGroupeFacturesApiV1ChorusProFacturesTelechargerGroupePost**
> Object TelechargerGroupeFacturesApiV1ChorusProFacturesTelechargerGroupePost (Dictionary<string, Object> requestBody)

Télécharger un groupe de factures

Télécharge une ou plusieurs factures (max 10 recommandé) avec leurs pièces jointes.      **Formats disponibles** :     - PDF : Fichier PDF uniquement     - XML : Fichier XML uniquement     - ZIP : Archive contenant PDF + XML + pièces jointes      **Taille maximale** : 120 Mo par téléchargement      **Payload exemple** :     ```json     {       \"listeIdentifiantsFactureCPP\": [12345, 12346],       \"inclurePiecesJointes\": true,       \"formatFichier\": \"ZIP\"     }     ```      **Retour** : Le fichier est encodé en base64 dans le champ `fichierBase64`.      **Note** : Le flag `factureTelechargeeParDestinataire` est mis à jour automatiquement.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **requestBody** | [**Dictionary&lt;string, Object&gt;**](Object.md) |  |  |

### Return type

**Object**

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

<a id="traiterfacturerecueapiv1chorusprofacturestraiterfacturerecuepost"></a>
# **TraiterFactureRecueApiV1ChorusProFacturesTraiterFactureRecuePost**
> Object TraiterFactureRecueApiV1ChorusProFacturesTraiterFactureRecuePost (Dictionary<string, Object> requestBody)

Traiter une facture reçue (Destinataire)

Change le statut d'une facture reçue.      **Statuts possibles** :     - MISE_A_DISPOSITION : Facture acceptée     - SUSPENDUE : En attente d'informations complémentaires (motif obligatoire)     - REJETEE : Facture refusée (motif obligatoire)     - MANDATEE : Facture mandatée     - MISE_EN_PAIEMENT : Facture en cours de paiement     - COMPTABILISEE : Facture comptabilisée     - MISE_A_DISPOSITION_COMPTABLE : Mise à disposition comptable     - A_RECYCLER : À recycler     - COMPLETEE : Complétée     - SERVICE-FAIT : Service fait     - PRISE_EN_COMPTE_DESTINATAIRE : Prise en compte     - TRANSMISE_MOA : Transmise à la MOA      **Payload exemple** :     ```json     {       \"identifiantFactureCPP\": 12345,       \"nouveauStatut\": \"REJETEE\",       \"motifRejet\": \"Facture en double\",       \"commentaire\": \"Facture déjà reçue sous la référence ABC123\"     }     ```      **Règles** :     - Un motif est **obligatoire** pour SUSPENDUE et REJETEE     - Seuls certains statuts sont autorisés selon le statut actuel de la facture


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **requestBody** | [**Dictionary&lt;string, Object&gt;**](Object.md) |  |  |

### Return type

**Object**

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

<a id="valideurconsulterfactureapiv1chorusprofacturesvalideurconsulterpost"></a>
# **ValideurConsulterFactureApiV1ChorusProFacturesValideurConsulterPost**
> Object ValideurConsulterFactureApiV1ChorusProFacturesValideurConsulterPost (Dictionary<string, Object> requestBody)

Consulter une facture (Valideur)


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **requestBody** | [**Dictionary&lt;string, Object&gt;**](Object.md) |  |  |

### Return type

**Object**

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

<a id="valideurrechercherfacturesapiv1chorusprofacturesvalideurrechercherpost"></a>
# **ValideurRechercherFacturesApiV1ChorusProFacturesValideurRechercherPost**
> Object ValideurRechercherFacturesApiV1ChorusProFacturesValideurRechercherPost (Dictionary<string, Object> requestBody)

Rechercher factures à valider (Valideur)

Recherche les factures en attente de validation par le valideur connecté.      **Rôle** : Valideur dans le circuit de validation interne.      **Filtres** : Dates, structure, service, etc.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **requestBody** | [**Dictionary&lt;string, Object&gt;**](Object.md) |  |  |

### Return type

**Object**

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

<a id="valideurtraiterfactureapiv1chorusprofacturesvalideurtraiterpost"></a>
# **ValideurTraiterFactureApiV1ChorusProFacturesValideurTraiterPost**
> Object ValideurTraiterFactureApiV1ChorusProFacturesValideurTraiterPost (Dictionary<string, Object> requestBody)

Valider ou refuser une facture (Valideur)

Valide ou refuse une facture en attente de validation.      **Actions** :     - Valider : La facture passe au statut suivant du circuit     - Refuser : La facture est rejetée (motif obligatoire)


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **requestBody** | [**Dictionary&lt;string, Object&gt;**](Object.md) |  |  |

### Return type

**Object**

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

