using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media.Imaging;
using Gh61.EdgePdfPreviewEnabler.Commands;
using Gh61.EdgePdfPreviewEnabler.DependencyRules;
using Gh61.EdgePdfPreviewEnabler.RegistryRules;

namespace Gh61.EdgePdfPreviewEnabler
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            #region Is Admin

            NonAdminMessageVisibility = WinUtils.IsAdmin() ? Visibility.Collapsed : Visibility.Visible;
            AdminShieldBitmapSource = WinUtils.GetWindowsAdminShield();

            #endregion

            #region Rules

            var msInstalledRule = new MsEdgeInstalledRule();

            DependencyRules = new ObservableCollection<DependencyRuleBase>()
            {
                msInstalledRule,
                new MsWebView2InstalledRule(msInstalledRule)
            };

            RegistryRules = new ObservableCollection<RegistryRuleBase>()
            {
                new PdfOpenWithRule(),
                new PdfPersistentHelperRule(),
                new ClsidPreviewHandlerRule(msInstalledRule),
                new PreviewHandlerListRule(),
            };

            if (ClsidX64PreviewHandlerRule.ShouldBeUsed())
            {
                RegistryRules.Insert(3, new ClsidX64PreviewHandlerRule(msInstalledRule));
            }

            if (PreviewHandlerX64ListRule.ShouldBeUsed())
            {
                RegistryRules.Add(new PreviewHandlerX64ListRule());
            }

            SetAsDefaultRule = new SetAsDefaultPreviewerRule();

            #endregion
        }

        public Visibility NonAdminMessageVisibility { get; }

        public BitmapSource AdminShieldBitmapSource { get; }

        public ObservableCollection<DependencyRuleBase> DependencyRules { get; }

        public ObservableCollection<RegistryRuleBase> RegistryRules { get; }

        public RegistryRuleBase SetAsDefaultRule { get; }

        public ApplyRegistryRuleCommand ApplyRegistryRuleCommand { get; } = ApplyRegistryRuleCommand.Instance;
    }
}
