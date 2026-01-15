# FactPulse.SDK.Api.ChorusProApi

All URIs are relative to *https://factpulse.fr*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**AjouterFichierApiV1ChorusProTransversesAjouterFichierPost**](ChorusProApi.md#ajouterfichierapiv1chorusprotransversesajouterfichierpost) | **POST** /api/v1/chorus-pro/transverses/ajouter-fichier | Add an attachment |
| [**CompleterFactureApiV1ChorusProFacturesCompleterPost**](ChorusProApi.md#completerfactureapiv1chorusprofacturescompleterpost) | **POST** /api/v1/chorus-pro/factures/completer | Complete a suspended invoice (Supplier) |
| [**ConsulterFactureApiV1ChorusProFacturesConsulterPost**](ChorusProApi.md#consulterfactureapiv1chorusprofacturesconsulterpost) | **POST** /api/v1/chorus-pro/factures/consulter | Consult invoice status |
| [**ConsulterStructureApiV1ChorusProStructuresConsulterPost**](ChorusProApi.md#consulterstructureapiv1chorusprostructuresconsulterpost) | **POST** /api/v1/chorus-pro/structures/consulter | Consult structure details |
| [**ListerServicesStructureApiV1ChorusProStructuresIdStructureCppServicesGet**](ChorusProApi.md#listerservicesstructureapiv1chorusprostructuresidstructurecppservicesget) | **GET** /api/v1/chorus-pro/structures/{id_structure_cpp}/services | List structure services |
| [**ObtenirIdChorusProDepuisSiretApiV1ChorusProStructuresObtenirIdDepuisSiretPost**](ChorusProApi.md#obteniridchorusprodepuissiretapiv1chorusprostructuresobteniriddepuissiretpost) | **POST** /api/v1/chorus-pro/structures/obtenir-id-depuis-siret | Utility: Get Chorus Pro ID from SIRET |
| [**RechercherFacturesDestinataireApiV1ChorusProFacturesRechercherDestinatairePost**](ChorusProApi.md#rechercherfacturesdestinataireapiv1chorusprofacturesrechercherdestinatairepost) | **POST** /api/v1/chorus-pro/factures/rechercher-destinataire | Search received invoices (Recipient) |
| [**RechercherFacturesFournisseurApiV1ChorusProFacturesRechercherFournisseurPost**](ChorusProApi.md#rechercherfacturesfournisseurapiv1chorusprofacturesrechercherfournisseurpost) | **POST** /api/v1/chorus-pro/factures/rechercher-fournisseur | Search issued invoices (Supplier) |
| [**RechercherStructuresApiV1ChorusProStructuresRechercherPost**](ChorusProApi.md#rechercherstructuresapiv1chorusprostructuresrechercherpost) | **POST** /api/v1/chorus-pro/structures/rechercher | Search Chorus Pro structures |
| [**RecyclerFactureApiV1ChorusProFacturesRecyclerPost**](ChorusProApi.md#recyclerfactureapiv1chorusprofacturesrecyclerpost) | **POST** /api/v1/chorus-pro/factures/recycler | Recycle an invoice (Supplier) |
| [**SoumettreFactureApiV1ChorusProFacturesSoumettrePost**](ChorusProApi.md#soumettrefactureapiv1chorusprofacturessoumettrepost) | **POST** /api/v1/chorus-pro/factures/soumettre | Submit an invoice to Chorus Pro |
| [**TelechargerGroupeFacturesApiV1ChorusProFacturesTelechargerGroupePost**](ChorusProApi.md#telechargergroupefacturesapiv1chorusprofacturestelechargergroupepost) | **POST** /api/v1/chorus-pro/factures/telecharger-groupe | Download a group of invoices |
| [**TraiterFactureRecueApiV1ChorusProFacturesTraiterFactureRecuePost**](ChorusProApi.md#traiterfacturerecueapiv1chorusprofacturestraiterfacturerecuepost) | **POST** /api/v1/chorus-pro/factures/traiter-facture-recue | Process a received invoice (Recipient) |
| [**ValideurConsulterFactureApiV1ChorusProFacturesValideurConsulterPost**](ChorusProApi.md#valideurconsulterfactureapiv1chorusprofacturesvalideurconsulterpost) | **POST** /api/v1/chorus-pro/factures/valideur/consulter | Consult an invoice (Validator) |
| [**ValideurRechercherFacturesApiV1ChorusProFacturesValideurRechercherPost**](ChorusProApi.md#valideurrechercherfacturesapiv1chorusprofacturesvalideurrechercherpost) | **POST** /api/v1/chorus-pro/factures/valideur/rechercher | Search invoices to validate (Validator) |
| [**ValideurTraiterFactureApiV1ChorusProFacturesValideurTraiterPost**](ChorusProApi.md#valideurtraiterfactureapiv1chorusprofacturesvalideurtraiterpost) | **POST** /api/v1/chorus-pro/factures/valideur/traiter | Validate or reject an invoice (Validator) |

<a id="ajouterfichierapiv1chorusprotransversesajouterfichierpost"></a>
# **AjouterFichierApiV1ChorusProTransversesAjouterFichierPost**
> Object AjouterFichierApiV1ChorusProTransversesAjouterFichierPost (Dictionary<string, Object> requestBody)

Add an attachment

Add an attachment to the current user account.      **Max size**: 10 MB per file      **Example payload**:     ```json     {       \"pieceJointeFichier\": \"JVBERi0xLjQKJeLjz9MKNSAwIG9iago8P...\",       \"pieceJointeNom\": \"purchase_order.pdf\",       \"pieceJointeTypeMime\": \"application/pdf\",       \"pieceJointeExtension\": \"PDF\"     }     ```      **Returns**: The attachment ID (`pieceJointeIdFichier`) to use in `/factures/completer`.      **Accepted extensions**: PDF, JPG, PNG, ZIP, XML, etc.


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
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="completerfactureapiv1chorusprofacturescompleterpost"></a>
# **CompleterFactureApiV1ChorusProFacturesCompleterPost**
> Object CompleterFactureApiV1ChorusProFacturesCompleterPost (Dictionary<string, Object> requestBody)

Complete a suspended invoice (Supplier)

Complete a SUSPENDUE status invoice by adding attachments or a comment.      **Required status**: SUSPENDUE      **Possible actions**:     - Add attachments (supporting documents, purchase orders, etc.)     - Modify comment      **Example payload**:     ```json     {       \"identifiantFactureCPP\": 12345,       \"commentaire\": \"Here are the requested documents\",       \"listePiecesJointes\": [         {           \"pieceJointeIdFichier\": 98765,           \"pieceJointeNom\": \"purchase_order.pdf\"         }       ]     }     ```      **Note**: Attachments must first be uploaded via `/transverses/ajouter-fichier`.      **After completion**: The invoice returns to MISE_A_DISPOSITION status.


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
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="consulterfactureapiv1chorusprofacturesconsulterpost"></a>
# **ConsulterFactureApiV1ChorusProFacturesConsulterPost**
> GetInvoiceResponse ConsulterFactureApiV1ChorusProFacturesConsulterPost (GetInvoiceRequest getInvoiceRequest)

Consult invoice status

Retrieves the information and current status of an invoice submitted to Chorus Pro.      **Returns**:     - Invoice number and date     - Total gross amount     - **Current status**: SOUMISE, VALIDEE, REJETEE, SUSPENDUE, MANDATEE, MISE_EN_PAIEMENT, etc.     - Recipient structure      **Use cases**:     - Track the processing progress of an invoice     - Check if an invoice has been validated or rejected     - Get the payment date      **Polling**: Call this endpoint regularly to track status changes.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **getInvoiceRequest** | [**GetInvoiceRequest**](GetInvoiceRequest.md) |  |  |

### Return type

[**GetInvoiceResponse**](GetInvoiceResponse.md)

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
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="consulterstructureapiv1chorusprostructuresconsulterpost"></a>
# **ConsulterStructureApiV1ChorusProStructuresConsulterPost**
> GetStructureResponse ConsulterStructureApiV1ChorusProStructuresConsulterPost (GetStructureRequest getStructureRequest)

Consult structure details

Retrieves detailed information about a Chorus Pro structure.       **Returns**:     - Company name     - Intra-EU VAT number     - Contact email     - **Required parameters**: Indicates if service code and/or engagement number are required to submit an invoice      **Typical step**: Called after `search-structures` to know which fields are mandatory before submitting an invoice.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **getStructureRequest** | [**GetStructureRequest**](GetStructureRequest.md) |  |  |

### Return type

[**GetStructureResponse**](GetStructureResponse.md)

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
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="listerservicesstructureapiv1chorusprostructuresidstructurecppservicesget"></a>
# **ListerServicesStructureApiV1ChorusProStructuresIdStructureCppServicesGet**
> SearchServicesResponse ListerServicesStructureApiV1ChorusProStructuresIdStructureCppServicesGet (int idStructureCpp)

List structure services

Retrieves the list of active services for a public structure.      **Use cases**:     - List available services for an administration     - Verify that a service code exists before submitting an invoice      **Returns**:     - List of services with their code, label, and status (active/inactive)


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **idStructureCpp** | **int** | Chorus Pro structure ID (idStructureCPP) |  |

### Return type

[**SearchServicesResponse**](SearchServicesResponse.md)

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

<a id="obteniridchorusprodepuissiretapiv1chorusprostructuresobteniriddepuissiretpost"></a>
# **ObtenirIdChorusProDepuisSiretApiV1ChorusProStructuresObtenirIdDepuisSiretPost**
> GetChorusProIdResponse ObtenirIdChorusProDepuisSiretApiV1ChorusProStructuresObtenirIdDepuisSiretPost (GetChorusProIdRequest getChorusProIdRequest)

Utility: Get Chorus Pro ID from SIRET

**Convenient utility** to get a structure's Chorus Pro ID from its SIRET.       This wrapper function combines:     1. Searching for the structure by SIRET     2. Extracting the `id_structure_cpp` if a single structure is found      **Returns**:     - `id_structure_cpp`: Chorus Pro ID (0 if not found or multiple results)     - `designation_structure`: Structure name (if found)     - `message`: Explanatory message      **Use cases**:     - Shortcut to directly get the Chorus Pro ID before submitting an invoice     - Simplified alternative to `search-structures` + manual ID extraction      **Note**: If multiple structures match the SIRET (rare), returns 0 and an error message.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **getChorusProIdRequest** | [**GetChorusProIdRequest**](GetChorusProIdRequest.md) |  |  |

### Return type

[**GetChorusProIdResponse**](GetChorusProIdResponse.md)

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
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="rechercherfacturesdestinataireapiv1chorusprofacturesrechercherdestinatairepost"></a>
# **RechercherFacturesDestinataireApiV1ChorusProFacturesRechercherDestinatairePost**
> Object RechercherFacturesDestinataireApiV1ChorusProFacturesRechercherDestinatairePost (Dictionary<string, Object> requestBody)

Search received invoices (Recipient)

Search invoices received by the connected recipient.      **Filters**:     - Downloaded / not downloaded     - Reception dates     - Status (MISE_A_DISPOSITION, SUSPENDUE, etc.)     - Supplier      **Useful indicator**: `factureTelechargeeParDestinataire` indicates whether the invoice has already been downloaded.


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
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="rechercherfacturesfournisseurapiv1chorusprofacturesrechercherfournisseurpost"></a>
# **RechercherFacturesFournisseurApiV1ChorusProFacturesRechercherFournisseurPost**
> Object RechercherFacturesFournisseurApiV1ChorusProFacturesRechercherFournisseurPost (Dictionary<string, Object> requestBody)

Search issued invoices (Supplier)

Search invoices issued by the connected supplier.      **Available filters**:     - Invoice number     - Dates (start/end)     - Status     - Recipient structure     - Amount      **Use cases**:     - Track issued invoices     - Verify statuses     - Export for accounting


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
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="rechercherstructuresapiv1chorusprostructuresrechercherpost"></a>
# **RechercherStructuresApiV1ChorusProStructuresRechercherPost**
> SearchStructureResponse RechercherStructuresApiV1ChorusProStructuresRechercherPost (SearchStructureRequest searchStructureRequest)

Search Chorus Pro structures

Search for structures (companies, administrations) registered on Chorus Pro.      **Use cases**:     - Find the Chorus Pro ID of a structure from its SIRET     - Check if a structure is registered on Chorus Pro     - List structures matching criteria      **Available filters**:     - Identifier (SIRET, SIREN, etc.)     - Company name     - Identifier type     - Private structures only      **Typical step**: Called before `submit-invoice` to get the recipient's `id_structure_cpp`.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **searchStructureRequest** | [**SearchStructureRequest**](SearchStructureRequest.md) |  |  |

### Return type

[**SearchStructureResponse**](SearchStructureResponse.md)

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
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="recyclerfactureapiv1chorusprofacturesrecyclerpost"></a>
# **RecyclerFactureApiV1ChorusProFacturesRecyclerPost**
> Object RecyclerFactureApiV1ChorusProFacturesRecyclerPost (Dictionary<string, Object> requestBody)

Recycle an invoice (Supplier)

Recycle an invoice with A_RECYCLER status by modifying routing data.      **Required status**: A_RECYCLER      **Modifiable fields**:     - Recipient (`idStructureCPP`)     - Service code     - Engagement number      **Use cases**:     - Wrong recipient     - Change of billing service     - Update engagement number      **Example payload**:     ```json     {       \"identifiantFactureCPP\": 12345,       \"idStructureCPP\": 67890,       \"codeService\": \"SERVICE_01\",       \"numeroEngagement\": \"ENG2024001\"     }     ```      **Note**: The invoice keeps its number and amounts, only routing fields change.


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
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="soumettrefactureapiv1chorusprofacturessoumettrepost"></a>
# **SoumettreFactureApiV1ChorusProFacturesSoumettrePost**
> SubmitInvoiceResponse SoumettreFactureApiV1ChorusProFacturesSoumettrePost (SubmitInvoiceRequest submitInvoiceRequest)

Submit an invoice to Chorus Pro

Submits an electronic invoice to a public structure via Chorus Pro.       **Complete workflow**:     1. **Upload the Factur-X PDF** via `/transverses/ajouter-fichier` → retrieve `pieceJointeId`     2. **Get the structure ID** via `/structures/rechercher` or `/structures/obtenir-id-depuis-siret`     3. **Check mandatory parameters** via `/structures/consulter`     4. **Submit the invoice** with the `piece_jointe_principale_id` obtained in step 1      **Prerequisites**:     1. Have the recipient's `id_structure_cpp` (via `/structures/rechercher`)     2. Know the mandatory parameters (via `/structures/consulter`):        - Service code if `code_service_doit_etre_renseigne=true`        - Engagement number if `numero_ej_doit_etre_renseigne=true`     3. Have uploaded the Factur-X PDF (via `/transverses/ajouter-fichier`)      **Expected format**:     - `piece_jointe_principale_id`: ID returned by `/transverses/ajouter-fichier`     - Amounts: Strings with 2 decimals (e.g., \"1250.50\")     - Dates: ISO 8601 format (YYYY-MM-DD)      **Returns**:     - `identifiant_facture_cpp`: Chorus Pro ID of the created invoice     - `numero_flux_depot`: Deposit tracking number      **Possible statuses after submission**:     - SOUMISE: Pending validation     - VALIDEE: Validated by recipient     - REJETEE: Rejected (data error or business refusal)     - SUSPENDUE: Pending additional information      **Note**: Use `/factures/consulter` to track status changes.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **submitInvoiceRequest** | [**SubmitInvoiceRequest**](SubmitInvoiceRequest.md) |  |  |

### Return type

[**SubmitInvoiceResponse**](SubmitInvoiceResponse.md)

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
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="telechargergroupefacturesapiv1chorusprofacturestelechargergroupepost"></a>
# **TelechargerGroupeFacturesApiV1ChorusProFacturesTelechargerGroupePost**
> Object TelechargerGroupeFacturesApiV1ChorusProFacturesTelechargerGroupePost (Dictionary<string, Object> requestBody)

Download a group of invoices

Download one or more invoices (max 10 recommended) with their attachments.      **Available formats**:     - PDF: PDF file only     - XML: XML file only     - ZIP: Archive containing PDF + XML + attachments      **Maximum size**: 120 MB per download      **Example payload**:     ```json     {       \"listeIdentifiantsFactureCPP\": [12345, 12346],       \"inclurePiecesJointes\": true,       \"formatFichier\": \"ZIP\"     }     ```      **Returns**: The file is base64-encoded in the `fichierBase64` field.      **Note**: The `factureTelechargeeParDestinataire` flag is automatically updated.


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
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="traiterfacturerecueapiv1chorusprofacturestraiterfacturerecuepost"></a>
# **TraiterFactureRecueApiV1ChorusProFacturesTraiterFactureRecuePost**
> Object TraiterFactureRecueApiV1ChorusProFacturesTraiterFactureRecuePost (Dictionary<string, Object> requestBody)

Process a received invoice (Recipient)

Change the status of a received invoice.      **Possible statuses**:     - MISE_A_DISPOSITION: Invoice accepted     - SUSPENDUE: Pending additional information (reason required)     - REJETEE: Invoice refused (reason required)     - MANDATEE: Invoice mandated     - MISE_EN_PAIEMENT: Invoice being paid     - COMPTABILISEE: Invoice accounted     - MISE_A_DISPOSITION_COMPTABLE: Made available to accounting     - A_RECYCLER: To be recycled     - COMPLETEE: Completed     - SERVICE-FAIT: Service rendered     - PRISE_EN_COMPTE_DESTINATAIRE: Acknowledged     - TRANSMISE_MOA: Transmitted to MOA      **Example payload**:     ```json     {       \"identifiantFactureCPP\": 12345,       \"nouveauStatut\": \"REJETEE\",       \"motifRejet\": \"Duplicate invoice\",       \"commentaire\": \"Invoice already received under reference ABC123\"     }     ```      **Rules**:     - A reason is **required** for SUSPENDUE and REJETEE     - Only certain statuses are allowed depending on the invoice's current status


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
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="valideurconsulterfactureapiv1chorusprofacturesvalideurconsulterpost"></a>
# **ValideurConsulterFactureApiV1ChorusProFacturesValideurConsulterPost**
> Object ValideurConsulterFactureApiV1ChorusProFacturesValideurConsulterPost (Dictionary<string, Object> requestBody)

Consult an invoice (Validator)

Retrieves detailed information about an invoice for validators.  **Use case**: Called by validators (public sector) to consult invoice details before approving or rejecting it.  **Required payload**: ```json {   \"idFacture\": 123456789 } ```  **Returns**: Complete invoice details including amounts, dates, attachments, and current status.


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
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="valideurrechercherfacturesapiv1chorusprofacturesvalideurrechercherpost"></a>
# **ValideurRechercherFacturesApiV1ChorusProFacturesValideurRechercherPost**
> Object ValideurRechercherFacturesApiV1ChorusProFacturesValideurRechercherPost (Dictionary<string, Object> requestBody)

Search invoices to validate (Validator)

Search invoices pending validation by the connected validator.      **Role**: Validator in the internal validation workflow.      **Filters**: Dates, structure, service, etc.


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
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="valideurtraiterfactureapiv1chorusprofacturesvalideurtraiterpost"></a>
# **ValideurTraiterFactureApiV1ChorusProFacturesValideurTraiterPost**
> Object ValideurTraiterFactureApiV1ChorusProFacturesValideurTraiterPost (Dictionary<string, Object> requestBody)

Validate or reject an invoice (Validator)

Validate or reject an invoice pending validation.      **Actions**:     - Validate: The invoice moves to the next status in the workflow     - Reject: The invoice is rejected (reason required)


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
| **401** | Authentication required - Invalid or missing JWT token |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

