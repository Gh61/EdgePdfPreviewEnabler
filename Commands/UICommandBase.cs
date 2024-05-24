using System;
using System.Windows.Input;

namespace Gh61.EdgePdfPreviewEnabler.Commands
{
    public abstract class UICommandBase<TParameter> : IUICommand
    {
        protected UICommandBase(string text)
        {
            Text = text;
        }

        public string Text { get; }

        void ICommand.Execute(object parameter)
        {
            Execute((TParameter)parameter);
        }

        protected abstract void Execute(TParameter parameter);

        public bool CanExecute(object parameter)
        {
            return CanExecute((TParameter)parameter);
        }

        protected virtual bool CanExecute(TParameter parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Will fire the <see cref="CanExecuteChanged"/> event.
        /// </summary>
        protected void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
