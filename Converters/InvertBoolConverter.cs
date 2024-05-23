using System;
using System.Globalization;
using System.Windows.Data;

namespace Gh61.EdgePdfPreviewEnabler.Converters
{
    internal class InvertBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var valueBool = value as bool? ?? value != null;
            return !valueBool;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Convert(value, targetType, parameter, culture);
        }
    }
}
