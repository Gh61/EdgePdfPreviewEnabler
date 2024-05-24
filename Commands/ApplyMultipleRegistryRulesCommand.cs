using System.Collections;
using Gh61.EdgePdfPreviewEnabler.Localization;
using Gh61.EdgePdfPreviewEnabler.RegistryRules;

namespace Gh61.EdgePdfPreviewEnabler.Commands
{
    public class ApplyMultipleRegistryRulesCommand : UICommandBase<IEnumerable>
    {
        public static ApplyMultipleRegistryRulesCommand Instance { get; } = new ApplyMultipleRegistryRulesCommand();

        private ApplyMultipleRegistryRulesCommand() : base(Resources.CommandApplyAll)
        {
        }

        protected override void Execute(IEnumerable rules)
        {
            foreach (RegistryRuleBase rule in rules)
            {
                if (ApplyRegistryRuleCommand.CanExecuteCore(rule))
                {
                    ApplyRegistryRuleCommand.ExecuteCore(rule);
                }
            }
        }
    }
}
