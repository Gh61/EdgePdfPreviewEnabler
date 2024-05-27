using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows.Input;
using Gh61.EdgePdfPreviewEnabler.Commands;
using Gh61.EdgePdfPreviewEnabler.Localization;
using Gh61.EdgePdfPreviewEnabler.RegistryRules;
using Microsoft.Win32;

namespace Gh61.EdgePdfPreviewEnabler
{
    public class DefaultPreviewerViewModel : INotifyPropertyChanged
    {
        private readonly SetAsDefaultPreviewerRule _setDefaultRule;

        public DefaultPreviewerViewModel(SetAsDefaultPreviewerRule setDefaultRule)
        {
            _setDefaultRule = setDefaultRule;
            _setDefaultRule.OnApply += (s, e) => RefreshItems(); // refresh items after default is applied
            RefreshItems();
        }

        private bool _showOnlyPdf = true;
        public bool ShowOnlyPdf
        {
            get => _showOnlyPdf;
            set
            {
                if (SetField(ref _showOnlyPdf, value, nameof(ShowOnlyPdf)))
                {
                    RefreshItems();
                }
            }
        }

        public ObservableCollection<PreviewHandlerItem> Items { get; } = new ObservableCollection<PreviewHandlerItem>();

        private readonly PreviewHandlerItem _emptyItem = new PreviewHandlerItem(Resources.PreviewHandlerItemNone, null);
        private PreviewHandlerItem _selectedItem;
        public PreviewHandlerItem SelectedItem
        {
            get => _selectedItem;
            set => SetField(ref _selectedItem, value, nameof(SelectedItem));
        }

        public ApplyDefaultPreviewerCommand ApplySelectedCommand { get; } = ApplyDefaultPreviewerCommand.Instance;

        public void ApplySelectedItem()
        {
            if (SelectedItem?.Guid == null)
                return;

            _setDefaultRule.ApplyDefaultPdfPreviewer(SelectedItem.Guid);
            Thread.Sleep(100);
            _setDefaultRule.Refresh();
        }

        private void RefreshItems(bool refreshSelected = true)
        {
            var previewHandlersKey = Registry.LocalMachine.OpenSubKey(PreviewHandlerListRule.LocalMachinePreviewHandlerListPath);
            if (previewHandlersKey == null)
            {
                Items.Clear();
                return;
            }

            var values = previewHandlersKey.GetValueNames();
            var newItems = new List<PreviewHandlerItem>(values.Length + 1);

            // The empty item
            newItems.Add(_emptyItem);

            foreach (var guid in values)
            {
                var name = Convert.ToString(previewHandlersKey.GetValue(guid));
                if (string.IsNullOrEmpty(name))
                {
                    name = string.Format(Resources.PreviewHandlerItemUnknown, guid);
                }

                // skip not PDF handlers
                if (ShowOnlyPdf && name.IndexOf("PDF", StringComparison.InvariantCultureIgnoreCase) < 0)
                    continue;

                var item = new PreviewHandlerItem(name, guid);
                newItems.Add(item);
            }

            // Sync to Items
            SyncCollections(newItems, Items);

            // Selected
            if (refreshSelected)
            {
                var currentGuid = _setDefaultRule.GetCurrentDefaultPdfPreviewer();
                SelectedItem = Items.FirstOrDefault(i => i.Guid == currentGuid) ?? _emptyItem;
            }
        }

        private static void SyncCollections<T>(ICollection<T> source, ICollection<T> target)
        {
            // Remove items from target that are not in source
            foreach (var item in new List<T>(target))
            {
                if (!source.Contains(item))
                {
                    target.Remove(item);
                }
            }

            // Add items from source that are not in target
            foreach (var item in source)
            {
                if (!target.Contains(item))
                {
                    target.Add(item);
                }
            }
        }

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

        #region Item class

        public class PreviewHandlerItem
        {
            public PreviewHandlerItem(string name, string guid)
            {
                Name = name;
                Guid = guid;
            }

            public string Name { get; }

            public string Guid { get; }

            #region Equals

            private bool Equals(PreviewHandlerItem other)
            {
                return Name == other.Name && Guid == other.Guid;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((PreviewHandlerItem) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return ((Name != null ? Name.GetHashCode() : 0) * 397) ^ (Guid != null ? Guid.GetHashCode() : 0);
                }
            }

            #endregion
        }

        #endregion
    }
}
