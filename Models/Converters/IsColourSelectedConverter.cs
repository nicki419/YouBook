using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Data.Converters;
using SukiUI;
using SukiUI.Models;

namespace YouBook.Models.Converters
{
    public class IsColourSelectedConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if( value != null && 
                targetType == typeof(bool?) && 
                ((SukiColorTheme)value).DisplayName == SukiTheme.GetInstance().ActiveColorTheme!.DisplayName) {
                return true;
            } else {
                return false;
            }
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return false;
        }
    }
}