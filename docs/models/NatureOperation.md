# FactPulse.SDK.Model.NatureOperation
Nature de l'opération (BT-23) pour Factur-X - Réforme française.  BR-FR-08: Le cadre de facturation doit être l'un des codes suivants. La première lettre indique : B = Biens, S = Services, M = Mixte.  Ref: XP Z12-012, article_conformite_pdf_facturx.md  Exemple d'utilisation:     >>> cadre = CadreDeFacturation(     ...     code_cadre_facturation=CodeCadreFacturation.A1_FACTURE_FOURNISSEUR,     ...     nature_operation=NatureOperation.BIENS     ... )

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

