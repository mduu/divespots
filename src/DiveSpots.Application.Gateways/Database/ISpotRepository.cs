using DiveSpots.Domain.Entities.SpotEntry;

namespace DiveSpots.Application.Gateways.Database
{
    public interface ISpotRepository : IEntityRepository<Spot>
    {
    }
}