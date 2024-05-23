using System.Collections.Generic;
using System.ComponentModel;

namespace Gh61.EdgePdfPreviewEnabler.Rules
{
    internal abstract class RuleBase : IRule, INotifyPropertyChanged
    {
        protected RuleBase(string title)
        {
            Title = title;
        }

        public string Title { get; }

        public abstract bool IsFulfilled { get; }

        public void Refresh()
        {
            OnPropertyChanged(nameof(IsFulfilled));
        }

        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion
    }
}
