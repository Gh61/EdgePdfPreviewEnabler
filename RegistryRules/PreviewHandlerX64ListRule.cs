using Microsoft.Win32;

namespace Gh61.EdgePdfPreviewEnabler.RegistryRules
{
    internal class PreviewHandlerX64ListRule : PreviewHandlerListRule
    {
        public PreviewHandlerX64ListRule()
            : base(@"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\PreviewHandlers")
        {
        }

        public static bool ShouldBeUsed()
        {
            var wow6432Node = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node");
            return wow6432Node != null;
        }
    }
}
