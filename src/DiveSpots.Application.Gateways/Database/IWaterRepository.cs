using DiveSpots.Domain.Entities;
using DiveSpots.Domain.Entities.WaterEntity;

namespace DiveSpots.Application.Gateways.Database
{
    public interface IWaterRepository : IEntityRepository<Water>
    {
    }
}