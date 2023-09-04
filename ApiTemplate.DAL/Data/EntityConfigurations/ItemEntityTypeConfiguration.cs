using TextualRPG.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TextualRPG.DAL.Data.EntityConfigurations
{
    public class ItemEntityTypeConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> itemBuilder)
        {
            itemBuilder.ToTable("Items");

            itemBuilder.HasKey(nameof(Item.Id));
            itemBuilder.Property(item => item.Title).HasMaxLength(50).IsRequired();
            itemBuilder.Property(item => item.Description).HasMaxLength(150).IsRequired();
            itemBuilder.Property(item => item.Price).IsRequired();
            itemBuilder.Property(item => item.Type).HasMaxLength(30).IsRequired().HasConversion<string>();
        }
    }
}
