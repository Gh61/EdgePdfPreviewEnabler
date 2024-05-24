using System;
using Microsoft.Win32;

namespace Gh61.EdgePdfPreviewEnabler.RegistryRules
{
    internal class PdfPersistentHelperRule : RegistryRuleBase
    {
        public PdfPersistentHelperRule()
            : base(@"HKCR\.pdf\PersistentHandler")
        {
        }

        public override bool IsFulfilled
        {
            get
            {
                var pdfExtensionKey = Registry.ClassesRoot.OpenSubKey(".pdf");
                if (pdfExtensionKey == null)
                    return false;

                var persistentHandler = pdfExtensionKey.OpenSubKey("PersistentHandler");
                if (persistentHandler == null)
                    return false;

                var containsCorrectGuid = persistentHandler.GetValue(null);
                if (!GuidEquals(Convert.ToString(containsCorrectGuid), "{1AA9BF05-9A97-48c1-BA28-D9DCE795E93C}"))
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

            var persistentHandler = pdfExtensionKey.OpenSubKey("PersistentHandler", true);
            if (persistentHandler == null)
            {
                persistentHandler = pdfExtensionKey.CreateSubKey("PersistentHandler");
            }

            var containsCorrectGuid = persistentHandler.GetValue(null);
            if (!GuidEquals(Convert.ToString(containsCorrectGuid), "{1AA9BF05-9A97-48c1-BA28-D9DCE795E93C}"))
            {
                persistentHandler.SetValue(null, "{1AA9BF05-9A97-48c1-BA28-D9DCE795E93C}", RegistryValueKind.String);
            }
        }
    }
}
