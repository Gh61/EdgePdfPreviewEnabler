namespace Gh61.EdgePdfPreviewEnabler.Rules
{
    internal interface IRule
    {
        /// <summary>
        /// Returns title of the rule, for UI.
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Returns whether the rule is already fulfilled.
        /// </summary>
        bool IsFulfilled { get; }

        /// <summary>
        /// Will refresh the <see cref="IsFulfilled"/> value (WCF only).
        /// </summary>
        void Refresh();
    }
}
