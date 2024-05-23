using System;
using System.Windows.Input;

namespace Gh61.EdgePdfPreviewEnabler.Commands
{
    internal abstract class UICommandBase<TParameter> : IUICommand
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
    }
}
