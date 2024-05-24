using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media.Imaging;
using Gh61.EdgePdfPreviewEnabler.DependencyRules;
using Gh61.EdgePdfPreviewEnabler.RegistryRules;

namespace Gh61.EdgePdfPreviewEnabler
{
    internal class MainWindowViewModel : INotifyPropertyChanged
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

            #endregion
        }

        public Visibility NonAdminMessageVisibility { get; }

        public BitmapSource AdminShieldBitmapSource { get; }

        public ObservableCollection<DependencyRuleBase> DependencyRules { get; }

        public ObservableCollection<RegistryRuleBase> RegistryRules { get; }

        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool SetField<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion
    }
}
