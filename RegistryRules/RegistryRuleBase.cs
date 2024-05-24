/*
 * All rules all loosely based on:
 * - https://techcommunity.microsoft.com/t5/modern-work-app-consult-blog/enabling-fixing-pdf-preview-for-outlook-on-windows-10/ba-p/3602110
 * - https://learn.microsoft.com/en-us/windows/win32/shell/how-to-register-a-preview-handler
 * and own observations
 */

using System;
using Gh61.EdgePdfPreviewEnabler.Rules;

namespace Gh61.EdgePdfPreviewEnabler.RegistryRules
{
    /// <summary>
    /// Base class for all rules that needs to be applied to registry.
    /// </summary>
    public abstract class RegistryRuleBase : RuleBase
    {
        protected RegistryRuleBase(string title) : base(title)
        {
        }

        /// <summary>
        /// Will aply edits to the registry for this rule, so it wil be fulfilled.
        /// </summary>
        public abstract void Apply();

        #region Helpers

        /// <summary>
        /// Returns whether the two guids in (supposedly 'B' - brackets) text format equals.
        /// </summary>
        protected bool GuidEquals(string guid1, string guid2)
        {
            return string.Compare(guid1, guid2, StringComparison.OrdinalIgnoreCase) == 0;
        }

        #endregion
    }
}
