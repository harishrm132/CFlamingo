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
            if (parameter == null)
                return (bool)value ? Visibility.Hidden : Visibility.Visible;
            else
                return (bool)value ? Visibility.Visible : Visibility.Hidden;

        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
