using System.Windows.Input;

namespace Gh61.EdgePdfPreviewEnabler.Commands
{
    public interface IUICommand : ICommand
    {
        string Text { get; }
    }
}
