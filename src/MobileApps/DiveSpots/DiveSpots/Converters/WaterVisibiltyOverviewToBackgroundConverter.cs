using System;
using System.Globalization;
using DiveSpots.Models;
using Xamarin.Forms;

namespace DiveSpots.Converters
{
    public class WaterVisibiltyOverviewToBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var water = value as WaterVisibillityOverview;
            if (water == null)
            {
                return null;
            }

            var imageResourceName = water.Visibility switch
            {
                Visibility.Excelent => "DiveSpots.Resources.VisibilityBackgrounds.vis_bg_clear.jpg",
                Visibility.Good => "DiveSpots.Resources.VisibilityBackgrounds.vis_bg_good.jpg",
                Visibility.Ok => "DiveSpots.Resources.VisibilityBackgrounds.vis_bg_ok.jpg",
                Visibility.Bad => "DiveSpots.Resources.VisibilityBackgrounds.vis_bg_bad.jpg",
                Visibility.VeryBad => "DiveSpots.Resources.VisibilityBackgrounds.vis_bg_verybad.jpg",
                _ => "",
            };

            return ImageSource.FromResource(imageResourceName);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
