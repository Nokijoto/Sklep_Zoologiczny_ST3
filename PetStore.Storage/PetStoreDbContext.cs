using Microsoft.EntityFrameworkCore;
using PetStore.CrossCutting.Dtos.Warehouse;
using PetStore.Storage.Entities.Animals;
using PetStore.Storage.Entities.Warehouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Storage
{
    public class PetStoreDbContext : DbContext
    {
        public PetStoreDbContext(DbContextOptions<PetStoreDbContext> options) : base(options)
        {
        }

        public DbSet<Entities.Warehouse.Product> Products { get; set; }
        public DbSet<Entities.Warehouse.Categorie> Categories { get; set; }
        public DbSet<Entities.Warehouse.Supplier> Suppliers { get; set; }

        public DbSet<Entities.Animals.Animal> Animals { get; set; }
        public DbSet<Entities.Animals.Specie> Species { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(x => x.Categorie)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategorieId);

            modelBuilder.Entity<Product>()
                .HasOne(x => x.Supplier)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.SupplierId);

            modelBuilder.Entity<Categorie>()
            .HasOne(c => c.ParentCategory)
            .WithMany(c => c.Subcategories)
            .HasForeignKey(c => c.ParentCategoryId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Specie>()
            .HasMany(x => x.Animals)
            .WithOne(x => x.Specie)
            .HasForeignKey(x => x.SpecieId);
            
            modelBuilder.Entity<Animal>()
           .HasOne(a => a.Specie)
           .WithMany()
           .HasForeignKey(a => a.SpecieId)
           .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
