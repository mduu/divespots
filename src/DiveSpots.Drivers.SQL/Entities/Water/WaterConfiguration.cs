using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiveSpots.Drivers.SQL.Entities.Water
{
    internal class WaterConfiguration : IEntityTypeConfiguration<WaterModel>
    {
        public void Configure(EntityTypeBuilder<WaterModel> builder)
        {
            builder.ToTable("Waters");
            builder.Property(e => e.CountryId).IsRequired();
        }
    }
}