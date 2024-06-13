using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using SklepZoologiczny.Warehouse.Storage.Entities;

namespace SklepZoologiczny.Warehouse.Storage;

public class WarehouseDbContext:DbContext
{
    public DbSet<Categorie> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }

    public WarehouseDbContext(DbContextOptions<WarehouseDbContext> options) : base(options)
    {
    }
}