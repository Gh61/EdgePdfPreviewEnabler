﻿using Gh61.EdgePdfPreviewEnabler.DependencyRules;

namespace Gh61.EdgePdfPreviewEnabler.Commands
{
    internal class InstallDependencyRuleCommand : UICommandBase<DependencyRuleBase>
    {
        public static InstallDependencyRuleCommand Instance { get; } = new InstallDependencyRuleCommand();

        private InstallDependencyRuleCommand() : base("Install")
        {
        }

        protected override void Execute(DependencyRuleBase rule)
        {
            rule.DoInstall();
        }

        protected override bool CanExecute(DependencyRuleBase rule)
        {
            return !rule.IsFulfilled;
        }
    }
}