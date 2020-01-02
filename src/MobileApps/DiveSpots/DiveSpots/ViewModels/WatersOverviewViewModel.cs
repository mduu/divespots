using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DiveSpots.Models;
using DiveSpots.Services;
using Xamarin.Forms;

namespace DiveSpots.ViewModels
{
    public class WatersOverviewViewModel : BaseViewModel
    {
        private IWaterVisibilityOverviewDataStore waterVisibilityStore => DependencyService.Get<IWaterVisibilityOverviewDataStore>();
        private ICountryDataStore countryStore => DependencyService.Get<ICountryDataStore>();
        private CountryItem selectedCountry;
        private bool isRefreshingWaters = false;

        public WatersOverviewViewModel()
        {
            Title = "Gewässer";
        }

        public Command LoadCountryListCommand => new Command(async () =>
        {
            if (IsBusy) return;

            IsBusy = true;
            try
            {
                await LoadCountriesAsync();
            }
            finally
            {
                IsBusy = false;
            }
        });

        public Command LoadWatersCommand => new Command(async () =>
        {
            if (IsRefreshingWaters) return;

            IsRefreshingWaters = true;
            try
            {
                await LoadWatersAsync();
            }
            finally
            {
                IsRefreshingWaters = false;
            }
        });

        public ObservableCollection<CountryItem> CountryList { get; set; } = new ObservableCollection<CountryItem>();
        public CountryItem SelectedCountry
        {
            get => selectedCountry;
            set
            {
                if (selectedCountry != value)
                {
                    SetProperty(ref selectedCountry, value);
                    LoadWatersCommand.Execute(null);
                }
            }
        }

        public ObservableCollection<WaterVisibillityOverview> Waters { get; set; } = new ObservableCollection<WaterVisibillityOverview>();

        public bool IsRefreshingWaters
        {
            get => isRefreshingWaters;
            set => SetProperty(ref isRefreshingWaters, value);
        }

        private async Task LoadCountriesAsync()
        {
            CountryList.Clear();
            var countries = await countryStore.GetCountryListAsync();
            foreach (var country in countries)
            {
                CountryList.Add(country);
            }
        }

        private async Task LoadWatersAsync()
        {
            Waters.Clear();
            if (SelectedCountry != null)
            {
                var waters = await waterVisibilityStore.GetVisibilityOverviewAsync(SelectedCountry.CountryId);
                foreach (var water in waters)
                {
                    Waters.Add(water);
                }
            }
        }
    }
}
