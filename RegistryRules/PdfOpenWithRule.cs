using System;
using Microsoft.Win32;

namespace Gh61.EdgePdfPreviewEnabler.RegistryRules
{
    internal class PdfOpenWithRule : RegistryRuleBase
    {
        public PdfOpenWithRule()
            : base(@"HKCR\.pdf\OpenWithProgids")
        {
        }

        public override bool IsFulfilled
        {
            get
            {
                var pdfExtensionKey = Registry.ClassesRoot.OpenSubKey(".pdf");
                if (pdfExtensionKey == null)
                    return false;

                // content type
                var contentType = pdfExtensionKey.GetValue("Content Type");
                if (contentType as string != "application/pdf")
                    return false;

                var openWithProgids = pdfExtensionKey.OpenSubKey("OpenWithProgids");
                if (openWithProgids == null)
                    return false;

                var containsMsEdge = openWithProgids.GetValue("MSEdgePDF");
                if (containsMsEdge == null)
                    return false;

                return true;
            }
        }

        public override void Apply()
        {
            var pdfExtensionKey = Registry.ClassesRoot.OpenSubKey(".pdf");
            if (pdfExtensionKey == null)
            {
                pdfExtensionKey = Registry.ClassesRoot.CreateSubKey(".pdf");
            }

            // content type
            var contentType = pdfExtensionKey.GetValue("Content Type");
            if (Convert.ToString(contentType) != "application/pdf")
            {
                pdfExtensionKey.SetValue("Content Type", "application/pdf", RegistryValueKind.String);
            }

            var openWithProgids = pdfExtensionKey.OpenSubKey("OpenWithProgids");
            if (openWithProgids == null)
            {
                openWithProgids = pdfExtensionKey.CreateSubKey("OpenWithProgids");
            }

            var containsMsEdge = openWithProgids.GetValue("MSEdgePDF");
            if (containsMsEdge == null)
            {
                openWithProgids.SetValue("MSEdgePDF", "", RegistryValueKind.String);
            }
        }
    }
}
