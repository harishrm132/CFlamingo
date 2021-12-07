using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace CFlamingo
{   
    /// <summary>
    /// Converter that takes in a HEX string and convert it to WPF brush <see cref="SolidColorBrush"/>
    /// </summary>
    public class StringRGBtoBrushConverter : BaseValueConverter<StringRGBtoBrushConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (SolidColorBrush)(new BrushConverter().ConvertFrom($"#{value}"));

        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
