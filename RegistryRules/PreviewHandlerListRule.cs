﻿using Microsoft.Win32;

namespace Gh61.EdgePdfPreviewEnabler.RegistryRules
{
    public class PreviewHandlerListRule : RegistryRuleBase
    {
        /// <summary>
        /// Default name for Preview Handler
        /// </summary>
        private const string PreviewerTitle = "Microsoft PDF Previewer";

        /// <summary>
        /// Path to HLKM registry, where all preview handlers should be registered.
        /// </summary>
        public const string LocalMachinePreviewHandlerListPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\PreviewHandlers";

        private readonly string _path;

        public PreviewHandlerListRule()
            : this(LocalMachinePreviewHandlerListPath)
        {
        }

        protected PreviewHandlerListRule(string path)
            : base(@"HKLM\" + path)
        {
            _path = path;
        }

        public override bool IsFulfilled
        {
            get
            {
                var previewHandlers = Registry.LocalMachine.OpenSubKey(_path);
                if (previewHandlers == null)
                {
                    return false;
                }

                var value = previewHandlers.GetValue(ClsidPreviewHandlerRule.PreviewHandlerGuid);
                if (value == null)
                {
                    return false;
                }

                return true;
            }
        }

        public override void Apply()
        {
            var previewHandlers = Registry.LocalMachine.OpenSubKey(_path, true);
            if (previewHandlers == null)
            {
                previewHandlers = Registry.LocalMachine.CreateSubKey(_path);
            }

            var value = previewHandlers.GetValue(ClsidPreviewHandlerRule.PreviewHandlerGuid);
            if (value == null)
            {
                previewHandlers.SetValue(ClsidPreviewHandlerRule.PreviewHandlerGuid, PreviewerTitle, RegistryValueKind.String);
            }
        }
    }
}
