using System.Windows.Input;

namespace Gh61.EdgePdfPreviewEnabler.Commands
{
    internal interface IUICommand : ICommand
    {
        string Text { get; }
    }
}
