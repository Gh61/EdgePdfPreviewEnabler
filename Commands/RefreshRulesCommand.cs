using System.Collections;
using Gh61.EdgePdfPreviewEnabler.Rules;

namespace Gh61.EdgePdfPreviewEnabler.Commands
{
    internal class RefreshRulesCommand : UICommandBase<IEnumerable>
    {
        public static RefreshRulesCommand Instance { get; } = new RefreshRulesCommand();

        private RefreshRulesCommand() : base("Refresh")
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
