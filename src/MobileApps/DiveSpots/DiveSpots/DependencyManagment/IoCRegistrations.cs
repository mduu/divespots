using DiveSpots.Models;
using DiveSpots.Services;
using DiveSpots.Services.Mocks;
using SimpleInjector;

namespace DiveSpots.DependencyManagment
{
    public static class IoCRegistrations
    {
        public static void RegisterDependencies(Container container)
        {
            container.RegisterSingleton<IDataStore<Item>, MockDataStore>();
            container.RegisterSingleton<ICountryDataStore, CountryDataStoreMock>();
            container.RegisterSingleton<IWaterVisibilityOverviewDataStore, WaterVisibilityOverviewDataStoreMock>();
        }
    }
}
