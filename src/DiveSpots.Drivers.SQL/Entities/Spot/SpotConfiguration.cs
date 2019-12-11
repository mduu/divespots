using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiveSpots.Drivers.SQL.Entities.Spot
{
    internal class SpotConfiguration : IEntityTypeConfiguration<SpotModel>
    {
        public void Configure(EntityTypeBuilder<SpotModel> builder)
        {
            builder.ToTable("Spots");
            builder.Property(e => e.WaterId).IsRequired();
        }
    }
}