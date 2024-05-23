using System.Diagnostics;
using Gh61.EdgePdfPreviewEnabler.Rules;

namespace Gh61.EdgePdfPreviewEnabler.DependencyRules
{
    internal abstract class DependencyRuleBase : RuleBase
    {
        protected DependencyRuleBase(string title) : base(title)
        {
        }

        protected abstract string GetInstallUrl();

        public void DoInstall()
        {
            var url = GetInstallUrl();
            Process.Start(url);
        }
    }
}
