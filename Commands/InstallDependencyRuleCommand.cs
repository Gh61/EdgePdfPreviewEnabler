using System.Collections.Generic;
using Gh61.EdgePdfPreviewEnabler.DependencyRules;
using Gh61.EdgePdfPreviewEnabler.Localization;

namespace Gh61.EdgePdfPreviewEnabler.Commands
{
    public class InstallDependencyRuleCommand : UICommandBase<DependencyRuleBase>
    {
        public static InstallDependencyRuleCommand Instance { get; } = new InstallDependencyRuleCommand();

        private readonly HashSet<DependencyRuleBase> _registeredRules = new HashSet<DependencyRuleBase>();

        private InstallDependencyRuleCommand() : base(Resources.CommandInstall)
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
