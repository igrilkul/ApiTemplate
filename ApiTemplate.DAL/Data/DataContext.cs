using TextualRPG.DAL.Data.EntityConfigurations;
using TextualRPG.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace TextualRPG.DAL.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Item> Items => Set<Item>();
        public DbSet<Character> Characters => Set<Character>();
        public DbSet<Zone> Zones => Set<Zone>();
        public DbSet<Enemy> Enemies => Set<Enemy>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ItemEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CharacterEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ZoneEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EnemyEntityTypeConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
