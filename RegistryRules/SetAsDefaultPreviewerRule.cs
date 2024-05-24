using System;
using Microsoft.Win32;

namespace Gh61.EdgePdfPreviewEnabler.RegistryRules
{
    internal class SetAsDefaultPreviewerRule : RegistryRuleBase
    {
        public SetAsDefaultPreviewerRule()
            : base(@"HKCR\.pdf\ShellEx\{8895b1c6-b41f-4c1c-a562-0d564250836f}")
        {
        }

        public override bool IsFulfilled
        {
            get
            {
                var pdfExtensionKey = Registry.ClassesRoot.OpenSubKey(".pdf");
                if (pdfExtensionKey == null)
                    return false;

                var shellExKey = pdfExtensionKey.OpenSubKey("ShellEx");
                if (shellExKey == null)
                    return false;

                var previewKey = shellExKey.OpenSubKey("{8895b1c6-b41f-4c1c-a562-0d564250836f}");
                if (previewKey == null)
                    return false;

                var value = previewKey.GetValue(null);
                if (!GuidEquals(Convert.ToString(value), ClsidPreviewHandlerRule.PreviewHandlerGuid))
                    return false;

                return true;
            }
        }

        public override void Apply()
        {
            var pdfExtensionKey = Registry.ClassesRoot.OpenSubKey(".pdf", true);
            if (pdfExtensionKey == null)
            {
                pdfExtensionKey = Registry.ClassesRoot.CreateSubKey(".pdf");
            }

            var shellExKey = pdfExtensionKey.OpenSubKey("ShellEx", true);
            if (shellExKey == null)
            {
                pdfExtensionKey.CreateSubKey("ShellEx");
            }

            var previewKey = shellExKey.OpenSubKey("{8895b1c6-b41f-4c1c-a562-0d564250836f}", true);
            if (previewKey == null)
            {
                shellExKey.CreateSubKey("{8895b1c6-b41f-4c1c-a562-0d564250836f}");
            }

            var value = previewKey.GetValue(null);
            if (!GuidEquals(Convert.ToString(value), ClsidPreviewHandlerRule.PreviewHandlerGuid))
            {
                previewKey.SetValue(null, ClsidPreviewHandlerRule.PreviewHandlerGuid, RegistryValueKind.String);
            }
        }
    }
}
