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
            if (!_context.Suppliers.Any())
            {
                var suppliers = GetSuppliers();
                _context.Suppliers.AddRange(suppliers);
                _context.SaveChanges();
            }

            if (!_context.Categories.Any())
            {
                var categories = GetCategories();
                _context.Categories.AddRange(categories);
                _context.SaveChanges();
            }

            if (!_context.Products.Any())
            {
                var products = GetProducts();
                _context.Products.AddRange(products);
                _context.SaveChanges();
            }
        }

        private IEnumerable<Product> GetProducts()
        {
            var categoryId = _context.Categories.FirstOrDefault()?.Id;
            var supplierId = _context.Suppliers.FirstOrDefault()?.Id;

            return new List<Product>()
        {
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "TestProduct",
                Description = "TestDescription",
                Price = 100,
                Quantity = 10,
                CategorieId = categoryId ?? Guid.Empty,
                SupplierId = supplierId ?? Guid.Empty
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
                Subcategories = new List<Categorie>
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
                Id = Guid.NewGuid(),
                City = "Warszawa",
                Name = "Supplier1",
                Country = "Poland",
                Street = "Testowa 1",
                Email = "supplier1@example.com",
                Phone = "123456789",
                State = "Mazowieckie",
                ZipCode = "00-000",
                Products = new List<Product>(),
            }
        };
        }
    }
}