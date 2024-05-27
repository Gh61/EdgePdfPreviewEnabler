using System;
using Gh61.EdgePdfPreviewEnabler.DependencyRules;
using Gh61.EdgePdfPreviewEnabler.Localization;
using Microsoft.Win32;

namespace Gh61.EdgePdfPreviewEnabler.RegistryRules
{
    public class ClsidPreviewHandlerRule : RegistryRuleBase
    {
        /// <summary>
        /// GUID for PDF Preview Handler
        /// </summary>
        public const string PreviewHandlerGuid = "{3A84F9C2-6164-485C-A7D9-4B27F8AC009E}";

        /// <summary>
        /// Default name for Preview Handler
        /// </summary>
        private const string PreviewHandlerName = "PDF Preview Handler";

        private readonly MsEdgeInstalledRule _edgeInstalledRule;
        private readonly string _clsidPath;

        public ClsidPreviewHandlerRule(MsEdgeInstalledRule edgeInstalledRule)
            :this(edgeInstalledRule, @"CLSID\")
        {
        }

        protected ClsidPreviewHandlerRule(MsEdgeInstalledRule edgeInstalledRule, string path)
            : base(@"HKCR\" + path + PreviewHandlerGuid)
        {
            _clsidPath = path;
            _edgeInstalledRule = edgeInstalledRule ?? throw new ArgumentNullException(nameof(edgeInstalledRule));
        }

        public override bool IsFulfilled
        {
            get
            {
                // Edge not installed, cannot be fulfilled
                if (!_edgeInstalledRule.IsFulfilled)
                    return false;

                // Here we have the path to the PreviewHandler DLL
                var clsidKey = Registry.ClassesRoot.OpenSubKey(_clsidPath + PreviewHandlerGuid);
                if (clsidKey == null)
                    return false;

                var isEnabled = clsidKey.GetValue("EnablePreviewHandler");
                if (!Convert.ToBoolean(isEnabled))
                    return false;

                var serverKey = clsidKey.OpenSubKey("InProcServer32");
                if (serverKey == null)
                    return false;

                var dllPath = serverKey.GetValue(null);
                if (Convert.ToString(dllPath) != _edgeInstalledRule.PdfPreviewDllPath)
                    return false;

                return true;
            }
        }

        public override void Apply()
        {
            if (!_edgeInstalledRule.IsFulfilled)
                throw new InvalidOperationException(Resources.ExceptionCannotApplyMsEdgeNotInstalled);

            var clsidKey = Registry.ClassesRoot.OpenSubKey(_clsidPath + PreviewHandlerGuid, true);
            if (clsidKey == null)
            {
                clsidKey = Registry.ClassesRoot.CreateSubKey(_clsidPath + PreviewHandlerGuid);
            }

            clsidKey.SetValue(null, PreviewHandlerName, RegistryValueKind.String);
            clsidKey.SetValue("DisplayName", PreviewHandlerName, RegistryValueKind.String);
            clsidKey.SetValue("AppID", "{6d2b5079-2f0b-48dd-ab7f-97cec514d30b}", RegistryValueKind.String);
            clsidKey.SetValue("EnablePreviewHandler", 1, RegistryValueKind.DWord);

            var serverKey = clsidKey.OpenSubKey("InProcServer32", true);
            if (serverKey == null)
            {
                serverKey = clsidKey.CreateSubKey("InProcServer32");
            }

            serverKey.SetValue(null, _edgeInstalledRule.PdfPreviewDllPath, RegistryValueKind.String);
            serverKey.SetValue("ThreadingModel", "Apartment", RegistryValueKind.String);
        }
    }
}
