using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DiveSpots.Models;

namespace DiveSpots.Services
{
    public interface IWaterVisibilityOverviewDataStore
    {
        Task<IEnumerable<WaterVisibillityOverview>> GetVisibilityOverviewAsync(Guid countryId);
    }
}
