using System.Collections;
using Gh61.EdgePdfPreviewEnabler.Localization;
using Gh61.EdgePdfPreviewEnabler.Rules;

namespace Gh61.EdgePdfPreviewEnabler.Commands
{
    public class RefreshRulesCommand : UICommandBase<IEnumerable>
    {
        public static RefreshRulesCommand Instance { get; } = new RefreshRulesCommand();

        private RefreshRulesCommand() : base(Resources.CommandRefresh)
        {
        }

        protected override void Execute(IEnumerable rules)
        {
            foreach (IRule rule in rules)
            {
                rule.Refresh();
            }
        }
    }
}
