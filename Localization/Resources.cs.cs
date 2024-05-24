namespace Gh61.EdgePdfPreviewEnabler.Localization
{
    public static partial class Resources
    {
        private static LocalizationDefinition GetDefinitionCS()
        {
            return new LocalizationDefinition()
            {
                Translations =
                {
                    {LocalizationKey.NonAdminMessage, "Tato aplikace NENÍ spuštěna s administrátorskými oprávněními."},
                    {LocalizationKey.AdminPrivilegeWarning, "Pravděpodobně nebude možné aplikovat opravy registru a/nebo instalovat požadovaný software."},
                    {LocalizationKey.InstallationsHeader, "Instalace:"},
                    {LocalizationKey.RegistryHeader, "Registry:"},
                    {LocalizationKey.DefaultPdfPreviewerHeader, "Nastavit jako výchozí pro náhledy PDF:"},

                    {LocalizationKey.CommandApply, "Použít"},
                    {LocalizationKey.CommandApplyAll, "Použít vše"},
                    {LocalizationKey.CommandInstall, "Instalovat"},
                    {LocalizationKey.CommandRefresh, "Znovu načíst"},
                    {LocalizationKey.CommandRestartAsAdmin, "Restartovat jako správce"},

                    {LocalizationKey.RuleMsEdgeInstalled, "Nainstalován Microsoft Edge (náhledový pomocník)"},
                    {LocalizationKey.RuleWebView2Installed, "Nainstalován Microsoft WebView2"},

                    {LocalizationKey.ExceptionCannotApplyMsEdgeNotInstalled, "Nelze použít, když MS Edge není nainstalován"}
                }
            };
        }
    }
}
