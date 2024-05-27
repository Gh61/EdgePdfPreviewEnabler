using System;
using Microsoft.Win32;

namespace Gh61.EdgePdfPreviewEnabler.RegistryRules
{
    public class SetAsDefaultPreviewerRule : RegistryRuleBase
    {
        public SetAsDefaultPreviewerRule()
            : base(@"HKCR\.pdf\ShellEx\{8895b1c6-b41f-4c1c-a562-0d564250836f}")
        {
        }

        public EventHandler OnApply;

        public override bool IsFulfilled
        {
            get
            {
                var value = GetCurrentDefaultPdfPreviewer();
                if (!GuidEquals(value, ClsidPreviewHandlerRule.PreviewHandlerGuid))
                    return false;

                return true;
            }
        }

        public override void Apply()
        {
            ApplyDefaultPdfPreviewer(ClsidPreviewHandlerRule.PreviewHandlerGuid);

            // fire event after applying the change
            OnApply?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Returns GUID of current default PDF previewer, or null if none is set.
        /// </summary>
        public string GetCurrentDefaultPdfPreviewer()
        {
            var pdfExtensionKey = Registry.ClassesRoot.OpenSubKey(".pdf");
            if (pdfExtensionKey == null)
                return null;

            var shellExKey = pdfExtensionKey.OpenSubKey("ShellEx");
            if (shellExKey == null)
                return null;

            var previewKey = shellExKey.OpenSubKey("{8895b1c6-b41f-4c1c-a562-0d564250836f}");
            if (previewKey == null)
                return null;

            var value = previewKey.GetValue(null);
            if (value == null)
                return null;

            return Convert.ToString(value);
        }

        /// <summary>
        /// Will apply given PDF previewer guid as default previewer for PDF documents.
        /// </summary>
        public void ApplyDefaultPdfPreviewer(string newDefaultPreviewerGuid)
        {
            if (string.IsNullOrEmpty(newDefaultPreviewerGuid))
                throw new ArgumentNullException(nameof(newDefaultPreviewerGuid));

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
            if (!GuidEquals(Convert.ToString(value), newDefaultPreviewerGuid))
            {
                previewKey.SetValue(null, newDefaultPreviewerGuid, RegistryValueKind.String);
            }
        }
    }
}
