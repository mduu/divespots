using DiveSpots.Application.Gateways.Database;
using DiveSpots.Drivers.SQL.Core;

namespace DiveSpots.Drivers.SQL.Entities.Country
{
    internal class CountryRepository : EntityRepositoryBase<Domain.Entities.CountryEntity.Country, CountryModel>, ICountryRepository
    {
        public CountryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}