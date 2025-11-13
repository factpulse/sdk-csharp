# FactPulse.SDK.Model.OptionsProcessing
Options de traitement pour la génération et la soumission.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ProfilFacturx** | **string** | Profil Factur-X à utiliser | [optional] [default to ProfilFacturxEnum.EN16931]
**AutoEnrichir** | **bool** | Auto-enrichir les données (APIs Entreprises, Chorus Pro, etc.) | [optional] [default to true]
**Valider** | **bool** | Valider le XML Factur-X avec Schematron | [optional] [default to true]
**VerifierParametresDestination** | **bool** | Vérifier les paramètres requis par la destination (ex: code_service pour Chorus) | [optional] [default to true]

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

