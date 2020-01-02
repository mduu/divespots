using System.Collections.Generic;
using System.Threading.Tasks;
using DiveSpots.Models;

namespace DiveSpots.Services
{
    internal interface ICountryDataStore
    {
        Task<IEnumerable<CountryItem>> GetCountryListAsync();
    }
}