using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace UberApp.Converters
{
    /// <summary>
    /// This class has methods to convert the DynamicResource to color objects. 
    /// This is needed when DynamicResource is set based on idiom/platform.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class DynamicResourceToColorConverter : IValueConverter
    {
        /// <summary>
        /// This method is used to convert the DynamicResource to color.
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not DynamicResource dynamicResource)
            {
                return value;
            }
            Application.Current.Resources.TryGetValue(dynamicResource.Key, out var color);
            return (Color)color;
        }

        /// <summary>
        /// This method is used to convert the color to DynamicResource.
        /// </summary>   
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}