using System;
using System.Windows.Input;
using DiveSpots.ViewModels.Base;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DiveSpots.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Launcher.OpenAsync(new Uri("https://xamarin.com/platform")));
        }

        public ICommand OpenWebCommand
        {
            get;
        }
    }
}