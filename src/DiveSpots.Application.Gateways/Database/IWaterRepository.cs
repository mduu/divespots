using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DiveSpots.Domain.Entities.WaterEntity;

namespace DiveSpots.Application.Gateways.Database
{
    public interface IWaterRepository : IEntityRepository<Water>
    {
        Task<IEnumerable<Water>> GetAllByCountryAsync(Guid countryId);
    }
}    