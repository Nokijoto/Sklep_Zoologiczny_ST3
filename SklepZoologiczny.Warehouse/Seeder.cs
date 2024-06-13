using Microsoft.EntityFrameworkCore;
using SklepZoologiczny.Warehouse.Storage;
using SklepZoologiczny.Warehouse.Storage.Entities;

namespace SklepZoologiczny.Warehouse
{
    public class Seeder
    { 
        private readonly WarehouseDbContext _context;
        public Seeder(WarehouseDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Database.CanConnect())
            {

                if (!_context.Suppliers.Any())
                {
                    var suppliers = GetSuppliers();
                    _context.AddRange(suppliers);
                    _context.SaveChanges();
                }

                if (!_context.Categories.Any())
                {
                    var categories = GetCategories();
                    _context.AddRange(categories);
                    _context.SaveChanges();
                }
                if (!_context.Products.Any())
                {
                    var products = GetProducts();
                    _context.AddRange(products);
                    _context.SaveChanges();
                }
            }
        }

        private IEnumerable<Product> GetProducts()
        {
            return new List<Product>()
    {
        new Product()
        {
            Id = Guid.NewGuid(),
            Name = "TestProduct",
            Description = "TestDescription",
            Price = 100,
        }
    };
        }

        private IEnumerable<Categorie> GetCategories()
        {
            return new List<Categorie>()
    {
        new Categorie()
        {
            Id = Guid.NewGuid(),
            Name = "TestCategory",
            Description = "TestCategoryDescription",
            ParentCategory = null,
            ParentCategoryId = null,
            Subcategories= new List<Categorie>
            {
                new Categorie()
                {
                    Id = Guid.NewGuid(),
                    Name = "SubCategory1",
                    Description = "SubCategoryDescription1",
                    ParentCategory = null,
                    ParentCategoryId = null,
                    Subcategories = new List<Categorie>(),
                }
            },
            Products = new List<Product>(),
        }
    };
        }

        

        private IEnumerable<Supplier> GetSuppliers()
        {
            return new List<Supplier>()
    {
        new Supplier()
        {
            City = "Warszawa",
            Name = "Supplier1",
            Country = "Poland",
            Street = "Testowa 1",
            Email = "supplier1@example.com",
            Id = Guid.NewGuid(),
            Phone = "123456789",
            Products = new List<Product>(),
            State = "Mazowieckie",
            ZipCode = "00-000",
        }
    };
        }

       
    }
}
