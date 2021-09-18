using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace CFlamingo
{
    /// <summary>
    /// Base Value Converter that allows direct XAML usage
    /// </summary>
    /// <typeparam name="T">Type of Value Converter</typeparam>
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter 
        where T : class, new()
    {
        #region Private Members
        /// <summary>
        /// Single unit instance of this value converter
        /// </summary>
        private static T mConverter = null;

        #endregion

        #region Markup Extension Methods
        /// <summary>
        /// Provide static instance of the value converter
        /// </summary>
        /// <param name="serviceProvider">The Service Provider</param>
        /// <returns></returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return mConverter ?? (mConverter = new T());
        } 
        #endregion

        #region Value Converter Methods
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

        #endregion


    }
}
