using Microsoft.EntityFrameworkCore;
using PetStore.CrossCutting.Dtos.Warehouse;
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
        public DbSet<Entities.Warehouse.InventoryTransaction> InventoryTransactions { get; set; }
        public DbSet<Entities.Warehouse.Employee> Employees { get; set; }

        public DbSet<Entities.Animals.Animal> Animals { get; set; }
        public DbSet<Entities.Animals.Specie> Species { get; set; }
        public DbSet<ProductDto> ProductDto { get; set; } = default!;

    }
}
