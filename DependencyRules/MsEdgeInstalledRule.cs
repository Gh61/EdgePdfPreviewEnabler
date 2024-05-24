using System.Diagnostics;
using System.IO;

namespace Gh61.EdgePdfPreviewEnabler.DependencyRules
{
    internal class MsEdgeInstalledRule : DependencyRuleBase
    {
        private const string MsEdgePath = @"C:\Program Files (x86)\Microsoft\Edge\Application";
        private const string MsEdgeExeName = "msedge.exe";

        public MsEdgeInstalledRule()
            : base("Microsoft Edge (preview helper) installed")
        {
        }

        /// <summary>
        /// Returns full path to current version of MsEdge installation.
        /// </summary>
        public string VersionDirectoryPath
        {
            get;
            private set;
        }

        /// <summary>
        /// Returns full path to PdfPreviewHandler.dll in MsEdge installation directory.
        /// </summary>
        public string PdfPreviewDllPath
        {
            get;
            private set;
        }

        /// <summary>
        /// <inheritdoc/>
        /// Also loads the properties <see cref="VersionDirectoryPath"/> and <see cref="PdfPreviewDllPath"/>.
        /// </summary>
        public override bool IsFulfilled
        {
            get
            {
                VersionDirectoryPath = null;
                PdfPreviewDllPath = null;

                var exePath = Path.Combine(MsEdgePath, MsEdgeExeName);
                if (!File.Exists(exePath))
                    return false;

                var exeVersion = FileVersionInfo.GetVersionInfo(exePath);
                var detectedVersion = exeVersion.ProductVersion;

                VersionDirectoryPath = Path.Combine(MsEdgePath, detectedVersion);
                if (!Directory.Exists(VersionDirectoryPath))
                    return false;

                PdfPreviewDllPath = Path.Combine(VersionDirectoryPath, @"PdfPreview\PdfPreviewHandler.dll");
                if (!File.Exists(PdfPreviewDllPath))
                    return false;

                return true;
            }
        }

        protected override string GetInstallUrl()
        {
            return "https://microsoft.com/edge";
        }
    }
}
