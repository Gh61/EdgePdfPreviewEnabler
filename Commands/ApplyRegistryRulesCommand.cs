using Gh61.EdgePdfPreviewEnabler.RegistryRules;

namespace Gh61.EdgePdfPreviewEnabler.Commands
{
    internal class ApplyRegistryRulesCommand : UICommandBase<RegistryRuleBase>
    {
        public static ApplyRegistryRulesCommand Instance { get; } = new ApplyRegistryRulesCommand();

        private ApplyRegistryRulesCommand() : base("Apply")
        {
        }

        protected override void Execute(RegistryRuleBase rule)
        {
            rule.Apply();
            rule.Refresh();
        }

        protected override bool CanExecute(RegistryRuleBase parameter)
        {
            return !parameter.IsFulfilled;
        }
    }
}
