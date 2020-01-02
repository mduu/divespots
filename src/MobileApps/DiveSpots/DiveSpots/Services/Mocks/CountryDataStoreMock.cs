using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DiveSpots.Models;

namespace DiveSpots.Services.Mocks
{
    public class CountryDataStoreMock : ICountryDataStore
    {
        private readonly IList<CountryItem> countryItems = new List<CountryItem>
        {
            new CountryItem
            {
                CountryId = MockData.CountryIdSwitzerland,
                Name = "Schweiz",
            },
            new CountryItem
            {
                CountryId = MockData.CountryIdItaly,
                Name = "Italien",
            },
        };
        
        public async Task<IEnumerable<CountryItem>> GetCountryListAsync() => 
            await Task.FromResult<IEnumerable<CountryItem>>(countryItems);
    }
}