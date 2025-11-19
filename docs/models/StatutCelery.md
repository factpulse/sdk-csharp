# FactPulse.SDK.Model.StatutCelery
Statuts possibles d'une tâche Celery lors du polling.  **Valeurs possibles :** - `PENDING` : Tâche en attente de traitement - `STARTED` : Tâche en cours d'exécution - `SUCCESS` : Tâche terminée avec succès (vérifier `resultat.statut` pour le résultat métier) - `FAILURE` : Erreur système lors de l'exécution (crash, exception non gérée) - `RETRY` : Tentative de ré-exécution en cours (après un échec temporaire)

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

