using DiveSpots.Services.Mocks;
using Xamarin.Forms;

namespace DiveSpots.DependencyManagment
{
    internal static class DependencyRegistrations
    {
        internal static void RegisterDependencies()
        {
            RegisterMockDataServices();
        }

        private static void RegisterMockDataServices()
        {
            DependencyService.Register<MockDataStore>();
            DependencyService.Register<CountryDataStoreMock>();
            DependencyService.Register<WaterVisibilityOverviewDataStoreMock>();
        }
    }
}