using System.IO;

namespace Gh61.EdgePdfPreviewEnabler.DependencyRules
{
    internal class MsWebView2InstalledRule : MsEdgeInstalledRule
    {
        private const string WebView2ExeName = "msedgewebview2.exe";

        public MsWebView2InstalledRule()
            : base("Microsoft WebView2 installed")
        {
        }

        public override bool IsFulfilled
        {
            get
            {
                // gets the version directory path
                _ = base.IsFulfilled;

                if (VersionDirectoryPath == null)
                    return false;

                var webViewExePath = Path.Combine(VersionDirectoryPath, WebView2ExeName);
                if (!File.Exists(webViewExePath))
                    return false;

                return true;
            }
        }

        protected override string GetInstallUrl()
        {
            return "https://developer.microsoft.com/en-us/microsoft-edge/webview2/consumer/";
        }
    }
}
