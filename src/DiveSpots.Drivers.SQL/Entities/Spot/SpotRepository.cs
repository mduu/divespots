using DiveSpots.Application.Gateways.Database;
using DiveSpots.Drivers.SQL.Core;

namespace DiveSpots.Drivers.SQL.Entities.Spot
{
    internal class SpotRepository : EntityRepositoryBase<Domain.Entities.SpotEntry.Spot, SpotModel>, ISpotRepository
    {
        public SpotRepository(ApplicationDbContext context) : base(context)
        {
        }
        
        protected override void MapToModel(Domain.Entities.SpotEntry.Spot entity, SpotModel model)
        {
            base.MapToModel(entity, model);
            model.WaterId = entity.WaterId;
        }
    }
}