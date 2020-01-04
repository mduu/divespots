using System;
using System.Globalization;
using DiveSpots.Models;
using Xamarin.Forms;

namespace DiveSpots.Converters
{
    public class VisibilityToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var visibility = (Visibility) value;

            return visibility switch
            {
                Visibility.Excelent => "Perfekt",
                Visibility.Good => "Gut",
                Visibility.Ok => "Ok",
                Visibility.Bad => "Schlecht",
                Visibility.VeryBad => "Sehr schlecht",
                _ => "",
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
