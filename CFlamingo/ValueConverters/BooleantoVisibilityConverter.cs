using System;
using System.Globalization;
using System.Windows;

namespace CFlamingo
{   
    /// <summary>
    /// Converter that takes in a boolean and return a <see cref="Visibility"/>
    /// </summary>
    public class BooleantoVisibilityConverter : BaseValueConverter<BooleantoVisibilityConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? Visibility.Hidden : Visibility.Visible;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
