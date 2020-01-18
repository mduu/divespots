using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using DiveSpots.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DiveSpots.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WatersOverviewPage : ContentPage
    {
        private WatersOverviewPageViewModel ViewModel => BindingContext as WatersOverviewPageViewModel;
        
        public WatersOverviewPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            FetchAll();
        }

        private void FetchAll()
        {
            ViewModel?.LoadCountryListCommand.Execute(null);
        }
    }
}
