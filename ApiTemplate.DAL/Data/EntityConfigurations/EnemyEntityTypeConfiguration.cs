using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextualRPG.DAL.Models;

namespace TextualRPG.DAL.Data.EntityConfigurations
{
    public class EnemyEntityTypeConfiguration : IEntityTypeConfiguration<Enemy>
    {
        public void Configure(EntityTypeBuilder<Enemy> enemyBuilder)
        {
            enemyBuilder.ToTable("Enemies");

            enemyBuilder.HasKey(nameof(Enemy.Id));
            enemyBuilder.Property(enemy => enemy.Name).HasMaxLength(100).IsRequired();
            enemyBuilder.Property(enemy => enemy.Level).IsRequired();
            enemyBuilder.Property(enemy => enemy.Description);
            enemyBuilder.Property(enemy => enemy.Experience).IsRequired();
            enemyBuilder.Property(enemy => enemy.Hp).IsRequired();
            enemyBuilder.Property(enemy => enemy.Mp).IsRequired();
            enemyBuilder.Property(enemy => enemy.Defense);
            enemyBuilder.Property(enemy => enemy.MagicResistance);
            enemyBuilder.Property(enemy => enemy.BleedResistance);
            enemyBuilder.Property(enemy => enemy.PoisonResistance);
            enemyBuilder.Property(enemy => enemy.StunResistance);

            enemyBuilder.HasOne(e => e.Zone).WithMany(z => z.Enemies);
        }
    }
}
