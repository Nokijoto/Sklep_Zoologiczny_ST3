using Microsoft.EntityFrameworkCore;
using SklepZoologiczny.Warehouse.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SklepZoologiczny.Warehouse.Storage
{
    public class WarehouseDbContext: DbContext
    {
        public DbSet<Products> Products { get; set; }
        public WarehouseDbContext(DbContextOptions<WarehouseDbContext> options) : base(options)
        {
        }

    }
}
