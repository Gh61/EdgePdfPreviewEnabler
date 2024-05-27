using Microsoft.Win32;

namespace Gh61.EdgePdfPreviewEnabler.RegistryRules
{
    public class PreviewHandlerX64ListRule : PreviewHandlerListRule
    {
        public PreviewHandlerX64ListRule()
            : base(@"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\PreviewHandlers")
        {
        }

        public static bool ShouldBeUsed()
        {
            // this registry key is only mirror of key in PreviewHandlerListRule
            return false;
            //var wow6432Node = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node");
            //return wow6432Node != null;
        }
    }
}
