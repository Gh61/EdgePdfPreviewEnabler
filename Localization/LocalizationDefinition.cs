using System.Collections.Generic;

namespace Gh61.EdgePdfPreviewEnabler.Localization
{
    internal class LocalizationDefinition
    {
        public Dictionary<LocalizationKey, string> Translations { get; } = new Dictionary<LocalizationKey, string>();

        public string GetTranslation(LocalizationKey key)
        {
            if (Translations.TryGetValue(key, out var translation))
            {
                return translation;
            }

            return null;
        }
    }
}
