namespace Gh61.EdgePdfPreviewEnabler.Localization
{
    public static partial class Resources
    {
        /// <summary>
        ///   Looks up a localized string similar to This application is NOT running with Admin privileges..
        /// </summary>
        public static string NonAdminMessage => GetTranslation(LocalizationKey.NonAdminMessage);

        /// <summary>
        ///   Looks up a localized string similar to You probably won't be able to Apply registry patches and/or Install required software..
        /// </summary>
        public static string AdminPrivilegeWarning => GetTranslation(LocalizationKey.AdminPrivilegeWarning);

        /// <summary>
        ///   Looks up a localized string similar to Installations:.
        /// </summary>
        public static string InstallationsHeader => GetTranslation(LocalizationKey.InstallationsHeader);

        /// <summary>
        ///   Looks up a localized string similar to Registry:.
        /// </summary>
        public static string RegistryHeader => GetTranslation(LocalizationKey.RegistryHeader);

        /// <summary>
        ///   Looks up a localized string similar to Set as default PDF Previewer:.
        /// </summary>
        public static string DefaultPdfPreviewerHeader => GetTranslation(LocalizationKey.DefaultPdfPreviewerHeader);

        /// <summary>
        ///   Looks up a localized string similar to Unknown - {0}.
        /// </summary>
        public static string PreviewHandlerItemUnknown => GetTranslation(LocalizationKey.PreviewHandlerItemUnknown);

        /// <summary>
        ///   Looks up a localized string similar to None.
        /// </summary>
        public static string PreviewHandlerItemNone => GetTranslation(LocalizationKey.PreviewHandlerItemNone);

        /// <summary>
        ///   Looks up a localized string similar to Show only PDF.
        /// </summary>
        public static string PreviewHandlerItemOnlyPdf => GetTranslation(LocalizationKey.PreviewHandlerItemOnlyPdf);

        /// <summary>
        ///   Looks up a localized string similar to Current PDF Previewer:.
        /// </summary>
        public static string PreviewHandlerCurrent => GetTranslation(LocalizationKey.PreviewHandlerCurrent);

        /// <summary>
        ///   Looks up a localized string similar to Apply.
        /// </summary>
        public static string CommandApply => GetTranslation(LocalizationKey.CommandApply);

        /// <summary>
        ///   Looks up a localized string similar to Apply All.
        /// </summary>
        public static string CommandApplyAll => GetTranslation(LocalizationKey.CommandApplyAll);

        /// <summary>
        ///   Looks up a localized string similar to Install.
        /// </summary>
        public static string CommandInstall => GetTranslation(LocalizationKey.CommandInstall);

        /// <summary>
        ///   Looks up a localized string similar to Refresh.
        /// </summary>
        public static string CommandRefresh => GetTranslation(LocalizationKey.CommandRefresh);

        /// <summary>
        ///   Looks up a localized string similar to Restart as Administrator.
        /// </summary>
        public static string CommandRestartAsAdmin => GetTranslation(LocalizationKey.CommandRestartAsAdmin);

        /// <summary>
        ///   Looks up a localized string similar to Microsoft Edge (preview helper) installed.
        /// </summary>
        public static string RuleMsEdgeInstalled => GetTranslation(LocalizationKey.RuleMsEdgeInstalled);

        /// <summary>
        ///   Looks up a localized string similar to Microsoft WebView2 installed.
        /// </summary>
        public static string RuleWebView2Installed => GetTranslation(LocalizationKey.RuleWebView2Installed);

        /// <summary>
        ///   Looks up a localized string similar to Cannot Apply, when MS Edge is not installed.
        /// </summary>
        public static string ExceptionCannotApplyMsEdgeNotInstalled => GetTranslation(LocalizationKey.ExceptionCannotApplyMsEdgeNotInstalled);

    }
}