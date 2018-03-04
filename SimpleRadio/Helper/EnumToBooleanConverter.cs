﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace SimpleRadio.Helper
{
    class EnumToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.Equals(parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.Equals(true))
                return parameter;
            return Binding.DoNothing;
        }
    }
}
