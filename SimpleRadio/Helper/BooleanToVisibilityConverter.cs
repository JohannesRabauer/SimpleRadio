using System;
using System.Globalization;
using System.Windows.Data;

namespace SimpleRadio.Helper
{
    class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (Boolean)value ?  System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
