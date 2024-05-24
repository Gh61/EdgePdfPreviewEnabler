using Gh61.EdgePdfPreviewEnabler.DependencyRules;
using Microsoft.Win32;

namespace Gh61.EdgePdfPreviewEnabler.RegistryRules
{
    public class ClsidX64PreviewHandlerRule : ClsidPreviewHandlerRule
    {
        public ClsidX64PreviewHandlerRule(MsEdgeInstalledRule edgeInstalledRule)
            : base(edgeInstalledRule, @"WOW6432Node\CLSID\")
        {
        }

        public static bool ShouldBeUsed()
        {
            var wow6432Node = Registry.ClassesRoot.OpenSubKey(@"WOW6432Node");
            return wow6432Node != null;
        }
    }
}
