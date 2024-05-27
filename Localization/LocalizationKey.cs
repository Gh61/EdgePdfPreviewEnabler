namespace Gh61.EdgePdfPreviewEnabler.Localization
{
    public enum LocalizationKey
    {
        // MainWindow
        NonAdminMessage,
        AdminPrivilegeWarning,
        InstallationsHeader,
        RegistryHeader,
        DefaultPdfPreviewerHeader,

        // DefaultPreviewerViewModel
        PreviewHandlerItemUnknown,
        PreviewHandlerItemNone,
        PreviewHandlerItemOnlyPdf,
        PreviewHandlerCurrent,

        // Commands
        CommandApply,
        CommandApplyAll,
        CommandInstall,
        CommandRefresh,
        CommandRestartAsAdmin,

        // Rules
        RuleMsEdgeInstalled,
        RuleWebView2Installed,

        // Exceptions
        ExceptionCannotApplyMsEdgeNotInstalled
    }
}
