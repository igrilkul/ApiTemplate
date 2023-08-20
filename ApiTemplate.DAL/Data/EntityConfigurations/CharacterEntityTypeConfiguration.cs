using ApiTemplate.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTemplate.DAL.Data.EntityConfigurations
{
    public class CharacterEntityTypeConfiguration : IEntityTypeConfiguration<Character>
    {
        public void Configure(EntityTypeBuilder<Character> characterBuilder)
        {
            characterBuilder.ToTable("Characters");

            characterBuilder.HasKey(nameof(Item.Id));
            characterBuilder.Property(c => c.Name).HasMaxLength(50).IsRequired();
            characterBuilder.Property(c=>c.ClassName).HasMaxLength(50).IsRequired();
            characterBuilder.Property(c=>c.Level).IsRequired();
        }
    }
}
