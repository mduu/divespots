using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiveSpots.Models;
using DiveSpots.ViewModels;

namespace DiveSpots.Services.Mocks
{
    public class WaterVisibilityOverviewDataStoreMock : IWaterVisibilityOverviewDataStore
    {
        public async Task<IEnumerable<WaterVisibillityOverview>> GetVisibilityOverviewAsync(Guid countryId)
        {
            if (countryId == MockData.CountryIdSwitzerland)
            {
                return await Task.FromResult(
                    new List<WaterVisibillityOverview>
                    {
                        new WaterVisibillityOverview
                        {
                            WaterId = MockData.WaterIdZuerichsee,
                            WaterName = "Zürichsee",
                            Visibility =  Visibility.Good,
                            MarineLife = MarineLife.Much,
                            Temperature = new OverallTemperature
                            {
                                MinCelcius = 4,
                                MaxCelcius = 19,
                            }
                        },
                        new WaterVisibillityOverview
                        {
                            WaterId = MockData.WaterIdWalensee,
                            WaterName = "Walensee",
                            MarineLife = MarineLife.Few,
                            Temperature = new OverallTemperature
                            {
                                MinCelcius = 5,
                                MaxCelcius = 14,
                            }
                        }
                    });
            }

            return await Task.FromResult(Enumerable.Empty<WaterVisibillityOverview>());
        }
    }
}