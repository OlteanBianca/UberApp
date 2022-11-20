using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace UberApp.Converters
{
    /// <summary>
    /// This class have methods to convert integer to string .
    /// </summary>
    [Preserve(AllMembers = true)]
    public class NameValidationConverter : IValueConverter
    {
        /// <summary>
        /// This method is used to convert integer to string.
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is ICollection<string> errors && errors.Count > 0 ? errors.ElementAt(0) : null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
