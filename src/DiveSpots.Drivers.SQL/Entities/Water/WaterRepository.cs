using DiveSpots.Application.Gateways.Database;
using DiveSpots.Drivers.SQL.Core;

namespace DiveSpots.Drivers.SQL.Entities.Water
{
    internal class WaterRepository : EntityRepositoryBase<Domain.Entities.WaterEntity.Water, WaterModel>, IWaterRepository
    {
        public WaterRepository(ApplicationDbContext context) : base(context)
        {
        }

        protected override void MapToModel(Domain.Entities.WaterEntity.Water entity, WaterModel model)
        {
            base.MapToModel(entity, model);
            model.CountryId = entity.CountryId;
        }
    }
}