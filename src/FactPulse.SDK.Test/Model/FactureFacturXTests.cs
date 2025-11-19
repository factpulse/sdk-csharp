/*
 * API REST FactPulse
 *
 *  API REST pour la facturation électronique en France : Factur-X, AFNOR PDP/PA, signatures électroniques.  ## 🎯 Fonctionnalités principales  ### 📄 Génération de factures Factur-X - **Formats** : XML seul ou PDF/A-3 avec XML embarqué - **Profils** : MINIMUM, BASIC, EN16931, EXTENDED - **Normes** : EN 16931 (directive UE 2014/55), ISO 19005-3 (PDF/A-3), CII (UN/CEFACT) - **🆕 Format simplifié** : Génération à partir de SIRET + auto-enrichissement (API Chorus Pro + Recherche Entreprises)  ### ✅ Validation et conformité - **Validation XML** : Schematron (45 à 210+ règles selon profil) - **Validation PDF** : PDF/A-3, métadonnées XMP Factur-X, signatures électroniques - **VeraPDF** : Validation stricte PDF/A (146+ règles ISO 19005-3) - **Traitement asynchrone** : Support Celery pour validations lourdes (VeraPDF)  ### 📡 Intégration AFNOR PDP/PA (XP Z12-013) - **Soumission de flux** : Envoi de factures vers Plateformes de Dématérialisation Partenaires - **Recherche de flux** : Consultation des factures soumises - **Téléchargement** : Récupération des PDF/A-3 avec XML - **Directory Service** : Recherche d'entreprises (SIREN/SIRET) - **Multi-client** : Support de plusieurs configs PDP par utilisateur (stored credentials ou zero-storage)  ### ✍️ Signature électronique PDF - **Standards** : PAdES-B-B, PAdES-B-T (horodatage RFC 3161), PAdES-B-LT (archivage long terme) - **Niveaux eIDAS** : SES (auto-signé), AdES (CA commerciale), QES (PSCO) - **Validation** : Vérification intégrité cryptographique et certificats - **Génération de certificats** : Certificats X.509 auto-signés pour tests  ### 🔄 Traitement asynchrone - **Celery** : Génération, validation et signature asynchrones - **Polling** : Suivi d'état via `/taches/{id_tache}/statut` - **Pas de timeout** : Idéal pour gros fichiers ou validations lourdes  ## 🔒 Authentification  Toutes les requêtes nécessitent un **token JWT** dans le header Authorization : ``` Authorization: Bearer YOUR_JWT_TOKEN ```  ### Comment obtenir un token JWT ?  #### 🔑 Méthode 1 : API `/api/token/` (Recommandée)  **URL :** `https://www.factpulse.fr/api/token/`  Cette méthode est **recommandée** pour l'intégration dans vos applications et workflows CI/CD.  **Prérequis :** Avoir défini un mot de passe sur votre compte  **Pour les utilisateurs inscrits via email/password :** - Vous avez déjà un mot de passe, utilisez-le directement  **Pour les utilisateurs inscrits via OAuth (Google/GitHub) :** - Vous devez d'abord définir un mot de passe sur : https://www.factpulse.fr/accounts/password/set/ - Une fois le mot de passe créé, vous pourrez utiliser l'API  **Exemple de requête :** ```bash curl -X POST https://www.factpulse.fr/api/token/ \\   -H \"Content-Type: application/json\" \\   -d '{     \"username\": \"votre_email@example.com\",     \"password\": \"votre_mot_de_passe\"   }' ```  **Paramètre optionnel `client_uid` :**  Pour sélectionner les credentials d'un client spécifique (PA/PDP, Chorus Pro, certificats de signature), ajoutez `client_uid` :  ```bash curl -X POST https://www.factpulse.fr/api/token/ \\   -H \"Content-Type: application/json\" \\   -d '{     \"username\": \"votre_email@example.com\",     \"password\": \"votre_mot_de_passe\",     \"client_uid\": \"550e8400-e29b-41d4-a716-446655440000\"   }' ```  Le `client_uid` sera inclus dans le JWT et permettra à l'API d'utiliser automatiquement : - Les credentials AFNOR/PDP configurés pour ce client - Les credentials Chorus Pro configurés pour ce client - Les certificats de signature électronique configurés pour ce client  **Réponse :** ```json {   \"access\": \"eyJ0eXAiOiJKV1QiLCJhbGc...\",  // Token d'accès (validité: 30 min)   \"refresh\": \"eyJ0eXAiOiJKV1QiLCJhbGc...\"  // Token de rafraîchissement (validité: 7 jours) } ```  **Avantages :** - ✅ Automatisation complète (CI/CD, scripts) - ✅ Gestion programmatique des tokens - ✅ Support du refresh token pour renouveler automatiquement l'accès - ✅ Intégration facile dans n'importe quel langage/outil  #### 🖥️ Méthode 2 : Génération via Dashboard (Alternative)  **URL :** https://www.factpulse.fr/dashboard/  Cette méthode convient pour des tests rapides ou une utilisation occasionnelle via l'interface graphique.  **Fonctionnement :** - Connectez-vous au dashboard - Utilisez les boutons \"Generate Test Token\" ou \"Generate Production Token\" - Fonctionne pour **tous** les utilisateurs (OAuth et email/password), sans nécessiter de mot de passe  **Types de tokens :** - **Token Test** : Validité 24h, quota 1000 appels/jour (gratuit) - **Token Production** : Validité 7 jours, quota selon votre forfait  **Avantages :** - ✅ Rapide pour tester l'API - ✅ Aucun mot de passe requis - ✅ Interface visuelle simple  **Inconvénients :** - ❌ Nécessite une action manuelle - ❌ Pas de refresh token - ❌ Moins adapté pour l'automatisation  ### 📚 Documentation complète  Pour plus d'informations sur l'authentification et l'utilisation de l'API : https://www.factpulse.fr/documentation-api/     
 *
 * The version of the OpenAPI document: 1.0.0
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using Xunit;

using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using FactPulse.SDK.Model;
using FactPulse.SDK.Client;
using System.Reflection;

namespace FactPulse.SDK.Test.Model
{
    /// <summary>
    ///  Class for testing FactureFacturX
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the model.
    /// </remarks>
    public class FactureFacturXTests : IDisposable
    {
        // TODO uncomment below to declare an instance variable for FactureFacturX
        //private FactureFacturX instance;

        public FactureFacturXTests()
        {
            // TODO uncomment below to create an instance of FactureFacturX
            //instance = new FactureFacturX();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of FactureFacturX
        /// </summary>
        [Fact]
        public void FactureFacturXInstanceTest()
        {
            // TODO uncomment below to test "IsType" FactureFacturX
            //Assert.IsType<FactureFacturX>(instance);
        }

        /// <summary>
        /// Test the property 'NumeroFacture'
        /// </summary>
        [Fact]
        public void NumeroFactureTest()
        {
            // TODO unit test for the property 'NumeroFacture'
        }

        /// <summary>
        /// Test the property 'DateEcheancePaiement'
        /// </summary>
        [Fact]
        public void DateEcheancePaiementTest()
        {
            // TODO unit test for the property 'DateEcheancePaiement'
        }

        /// <summary>
        /// Test the property 'ModeDepot'
        /// </summary>
        [Fact]
        public void ModeDepotTest()
        {
            // TODO unit test for the property 'ModeDepot'
        }

        /// <summary>
        /// Test the property 'Destinataire'
        /// </summary>
        [Fact]
        public void DestinataireTest()
        {
            // TODO unit test for the property 'Destinataire'
        }

        /// <summary>
        /// Test the property 'Fournisseur'
        /// </summary>
        [Fact]
        public void FournisseurTest()
        {
            // TODO unit test for the property 'Fournisseur'
        }

        /// <summary>
        /// Test the property 'CadreDeFacturation'
        /// </summary>
        [Fact]
        public void CadreDeFacturationTest()
        {
            // TODO unit test for the property 'CadreDeFacturation'
        }

        /// <summary>
        /// Test the property 'References'
        /// </summary>
        [Fact]
        public void ReferencesTest()
        {
            // TODO unit test for the property 'References'
        }

        /// <summary>
        /// Test the property 'MontantTotal'
        /// </summary>
        [Fact]
        public void MontantTotalTest()
        {
            // TODO unit test for the property 'MontantTotal'
        }

        /// <summary>
        /// Test the property 'DateFacture'
        /// </summary>
        [Fact]
        public void DateFactureTest()
        {
            // TODO unit test for the property 'DateFacture'
        }

        /// <summary>
        /// Test the property 'LignesDePoste'
        /// </summary>
        [Fact]
        public void LignesDePosteTest()
        {
            // TODO unit test for the property 'LignesDePoste'
        }

        /// <summary>
        /// Test the property 'LignesDeTva'
        /// </summary>
        [Fact]
        public void LignesDeTvaTest()
        {
            // TODO unit test for the property 'LignesDeTva'
        }

        /// <summary>
        /// Test the property 'Notes'
        /// </summary>
        [Fact]
        public void NotesTest()
        {
            // TODO unit test for the property 'Notes'
        }

        /// <summary>
        /// Test the property 'Commentaire'
        /// </summary>
        [Fact]
        public void CommentaireTest()
        {
            // TODO unit test for the property 'Commentaire'
        }

        /// <summary>
        /// Test the property 'IdUtilisateurCourant'
        /// </summary>
        [Fact]
        public void IdUtilisateurCourantTest()
        {
            // TODO unit test for the property 'IdUtilisateurCourant'
        }

        /// <summary>
        /// Test the property 'PiecesJointesComplementaires'
        /// </summary>
        [Fact]
        public void PiecesJointesComplementairesTest()
        {
            // TODO unit test for the property 'PiecesJointesComplementaires'
        }
    }
}
