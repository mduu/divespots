using DiveSpots.Domain.Entities.CountryEntity;

namespace DiveSpots.Application.Gateways.Database
{
    public interface ICountryRepository : IEntityRepository<Country>
    {
    }
}