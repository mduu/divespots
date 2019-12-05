using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiveSpots.Drivers.SQL.Entities.Country
{
    internal class CountryConfiguration : IEntityTypeConfiguration<CountryModel>
    {
        public void Configure(EntityTypeBuilder<CountryModel> builder)
        {
            builder.ToTable("Countries");
        }
    }
}