using System.Collections.Generic;
using Gh61.EdgePdfPreviewEnabler.DependencyRules;

namespace Gh61.EdgePdfPreviewEnabler.Commands
{
    internal class InstallDependencyRuleCommand : UICommandBase<DependencyRuleBase>
    {
        public static InstallDependencyRuleCommand Instance { get; } = new InstallDependencyRuleCommand();

        private readonly HashSet<DependencyRuleBase> _registeredRules = new HashSet<DependencyRuleBase>();

        private InstallDependencyRuleCommand() : base("Install")
        {
        }

        protected override void Execute(DependencyRuleBase rule)
        {
            rule.DoInstall();
        }

        protected override bool CanExecute(DependencyRuleBase rule)
        {
            if (_registeredRules.Add(rule))
            {
                rule.PropertyChanged += (s, e) =>
                {
                    if (e.PropertyName == nameof(rule.IsFulfilled))
                    {
                        OnCanExecuteChanged();
                    }
                };
            }

            return !rule.IsFulfilled;
        }
    }
}
