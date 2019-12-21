using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiveSpots.Application.Gateways.Database;
using DiveSpots.Drivers.SQL.Core;
using Microsoft.EntityFrameworkCore;

namespace DiveSpots.Drivers.SQL.Entities.Water
{
    internal class WaterRepository : EntityRepositoryBase<Domain.Entities.WaterEntity.Water, WaterModel>, IWaterRepository
    {
        public WaterRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Domain.Entities.WaterEntity.Water>> GetAllByCountryAsync(Guid countryId)
        {
            return 
                (await GetDbSet()
                    .Where(w => w.CountryId == countryId)
                    .ToListAsync()
                )
                .Select(GetEntityFromJsonData);
        }

        protected override void MapToModel(Domain.Entities.WaterEntity.Water entity, WaterModel model)
        {
            base.MapToModel(entity, model);
            model.CountryId = entity.CountryId;
        }
    }
}