using System.Collections.Generic;
using System.Globalization;

namespace Gh61.EdgePdfPreviewEnabler.Localization
{
    public static partial class Resources
    {
        private static readonly LocalizationDefinition DefaultDefinition;
        private static readonly Dictionary<string, LocalizationDefinition> Definitions;

        static Resources()
        {
            Definitions = new Dictionary<string, LocalizationDefinition>()
            {
                {"en", GetDefinitionEN()},
                {"cs", GetDefinitionCS()}
            };

            // default localization = en
            DefaultDefinition = Definitions["en"];
        }

        public static string GetTranslation(LocalizationKey key)
        {
            return GetTranslation(key, CultureInfo.CurrentUICulture);
        }

        public static string GetTranslation(LocalizationKey key, CultureInfo culture)
        {
            var cultureKey = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            if (Definitions.TryGetValue(cultureKey, out var definition))
            {
                var translation = definition.GetTranslation(key);
                if (!string.IsNullOrEmpty(translation))
                {
                    return translation;
                }
            }
            return DefaultDefinition.GetTranslation(key);
        }
    }
}
