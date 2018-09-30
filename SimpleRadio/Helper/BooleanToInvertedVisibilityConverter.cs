using System;
using System.Globalization;
using System.Windows.Data;

namespace SimpleRadio.Helper
{
    class BooleanToInvertedVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (Boolean)value ?  System.Windows.Visibility.Collapsed : System.Windows.Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
