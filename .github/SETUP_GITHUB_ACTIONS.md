# Configuration GitHub Actions

## Secret NuGet requis

1. Allez sur https://github.com/factpulse/sdk-csharp/settings/secrets/actions
2. Cliquez sur "New repository secret"
3. Nom : `NUGET_API_KEY`
4. Valeur : Votre API key NuGet (obtenue sur https://www.nuget.org/account/apikeys)

## Déploiement

Le workflow se déclenche automatiquement lors de la création d'un tag `v*` (exemple : `v1.0.0`).
