using TextualRPG.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TextualRPG.DAL.Data.EntityConfigurations
{
    public class ZoneEntityTypeConfiguration : IEntityTypeConfiguration<Zone>
    {
        
        public void Configure(EntityTypeBuilder<Zone> zoneBuilder)
        {
            zoneBuilder.ToTable("Zones");

            zoneBuilder.HasKey(nameof(Zone.Id));
            zoneBuilder.Property(zone => zone.Name).HasMaxLength(50).IsRequired();
            zoneBuilder.Property(zone => zone.RequiredLevel).HasDefaultValue(0).IsRequired();
            zoneBuilder.Property(zone => zone.Description);

            zoneBuilder.HasMany(z => z.Enemies).WithOne(e => e.Zone);

        }
    }
}
