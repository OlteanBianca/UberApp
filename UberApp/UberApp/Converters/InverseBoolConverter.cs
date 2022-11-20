using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace UberApp.Converters
{
    /// <summary>
    /// This class has methods convert to reverse the Boolean values.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class InverseBoolConverter : IValueConverter
    {
        /// <summary>
        /// This method is used to convert to reverse the Boolean values.
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not bool)
            {
                throw new InvalidOperationException("The target must be a boolean");
            }

            return !(bool)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
