﻿using System.Collections;
using Gh61.EdgePdfPreviewEnabler.RegistryRules;

namespace Gh61.EdgePdfPreviewEnabler.Commands
{
    internal class ApplyMultipleRegistryRulesCommand : UICommandBase<IEnumerable>
    {
        public static ApplyMultipleRegistryRulesCommand Instance { get; } = new ApplyMultipleRegistryRulesCommand();

        private ApplyMultipleRegistryRulesCommand() : base("Apply All")
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