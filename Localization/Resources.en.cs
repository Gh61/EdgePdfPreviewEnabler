namespace Gh61.EdgePdfPreviewEnabler.Localization
{
    public static partial class Resources
    {
        private static LocalizationDefinition GetDefinitionEN()
        {
            return new LocalizationDefinition()
            {
                Translations =
                {
                    {LocalizationKey.NonAdminMessage, "This application is NOT running with Admin privileges."},
                    {LocalizationKey.AdminPrivilegeWarning, "You probably won't be able to Apply registry patches and/or Install required software."},
                    {LocalizationKey.InstallationsHeader, "Installations:"},
                    {LocalizationKey.RegistryHeader, "Registry:"},
                    {LocalizationKey.DefaultPdfPreviewerHeader, "Set as default PDF Previewer:"},

                    {LocalizationKey.PreviewHandlerItemUnknown, "Unknown - {0}"},
                    {LocalizationKey.PreviewHandlerItemNone, "None"},
                    {LocalizationKey.PreviewHandlerItemOnlyPdf, "Show only PDF"},
                    {LocalizationKey.PreviewHandlerCurrent, "Current PDF Previewer:"},

                    {LocalizationKey.CommandApply, "Apply"},
                    {LocalizationKey.CommandApplyAll, "Apply All"},
                    {LocalizationKey.CommandInstall, "Install"},
                    {LocalizationKey.CommandRefresh, "Refresh"},
                    {LocalizationKey.CommandRestartAsAdmin, "Restart as Administrator"},

                    {LocalizationKey.RuleMsEdgeInstalled, "Microsoft Edge (preview helper) installed"},
                    {LocalizationKey.RuleWebView2Installed, "Microsoft WebView2 installed"},

                    {LocalizationKey.ExceptionCannotApplyMsEdgeNotInstalled, "Cannot Apply, when MS Edge is not installed"}
                }
            };
        }
    }
}
