using Gh61.EdgePdfPreviewEnabler.Localization;

namespace Gh61.EdgePdfPreviewEnabler.Commands
{
    public class ApplyDefaultPreviewerCommand : UICommandBase<DefaultPreviewerViewModel>
    {
        public static ApplyDefaultPreviewerCommand Instance { get; } = new ApplyDefaultPreviewerCommand();

        private ApplyDefaultPreviewerCommand() : base(Resources.CommandApply)
        {
        }

        protected override void Execute(DefaultPreviewerViewModel model)
        {
            model.ApplySelectedItem();
        }

        protected override bool CanExecute(DefaultPreviewerViewModel model)
        {
            return model.SelectedItem?.Guid != null;
        }
    }
}
