using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Gh61.EdgePdfPreviewEnabler.DependencyRules;
using Gh61.EdgePdfPreviewEnabler.RegistryRules;

namespace Gh61.EdgePdfPreviewEnabler
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            DependencyRules = new ObservableCollection<DependencyRuleBase>()
            {
                new MsEdgeInstalledRule(),
                new MsWebView2InstalledRule()
            };

            RegistryRules = new ObservableCollection<RegistryRuleBase>()
            {
                new PdfOpenWithRule()
            };
        }

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
