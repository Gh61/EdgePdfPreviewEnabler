﻿using System;
using System.IO;
using Gh61.EdgePdfPreviewEnabler.Localization;

namespace Gh61.EdgePdfPreviewEnabler.DependencyRules
{
    public class MsWebView2InstalledRule : DependencyRuleBase
    {
        private const string WebView2ExeName = "msedgewebview2.exe";
        private readonly MsEdgeInstalledRule _edgeInstalledRule;

        public MsWebView2InstalledRule(MsEdgeInstalledRule edgeInstalledRule)
            : base(Resources.RuleWebView2Installed)
        {
            _edgeInstalledRule = edgeInstalledRule ?? throw new ArgumentNullException(nameof(edgeInstalledRule));
        }

        public override bool IsFulfilled
        {
            get
            {
                // gets the version directory path
                _ = _edgeInstalledRule.IsFulfilled;

                if (_edgeInstalledRule.VersionDirectoryPath == null)
                    return false;

                var webViewExePath = Path.Combine(_edgeInstalledRule.VersionDirectoryPath, WebView2ExeName);
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
