using System;
using System.Runtime.ConstrainedExecution;
using Microsoft.EntityFrameworkCore;
using SportStore.Models.ModelsDB;

namespace SportStore.Models
{
    public class SportStoreContext:DbContext
    {
        public SportStoreContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Basket> Baskets { get; set; } = null!;
        public DbSet<Characteristic> Characteristics { get; set; } = null!;
        public DbSet<Clothes> GetClothes { get; set; } = null!;
        public DbSet<ClothesStore> ClothesStores { get; set; } = null!;
        public DbSet<History> Histories { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=SportStore;User Id=sa;Password=Valuetech@123;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clothes>()
                .HasOne(c => c.Characteristic)
                .WithOne(ch => ch.Clothes)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ClothesStore>()
                .HasOne(cs => cs.Clothes)
                .WithOne(c => c.ClothesStore)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}

