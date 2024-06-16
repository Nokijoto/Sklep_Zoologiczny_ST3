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
            var categories = _context.Categories.ToList();
            var suppliers = _context.Suppliers.ToList();

            return new List<Product>()
        {
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Karma dla psów",
                Description = "Wysokiej jakości karma dla psów",
                Price = 50,
                Quantity = 100,
                CategorieId = categories[0].Id,
                SupplierId = suppliers[0].Id
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Zabawka dla kota",
                Description = "Interaktywna zabawka dla kotów",
                Price = 20,
                Quantity = 200,
                CategorieId = categories[1].Id,
                SupplierId = suppliers[1].Id
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Klatka dla ptaków",
                Description = "Przestronna i bezpieczna klatka dla ptaków",
                Price = 150,
                Quantity = 50,
                CategorieId = categories[2].Id,
                SupplierId = suppliers[2].Id
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
                Name = "Karma dla zwierząt",
                Description = "Wszystkie rodzaje karmy dla zwierząt",
                ParentCategory = null,
                ParentCategoryId = null
            },
            new Categorie()
            {
                Id = Guid.NewGuid(),
                Name = "Zabawki dla zwierząt",
                Description = "Różne zabawki dla zwierząt",
                ParentCategory = null,
                ParentCategoryId = null
            },
            new Categorie()
            {
                Id = Guid.NewGuid(),
                Name = "Akcesoria dla zwierząt",
                Description = "Akcesoria dla zwierząt",
                ParentCategory = null,
                ParentCategoryId = null
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
                Name = "Zwierzakowo",
                Country = "Polska",
                Street = "Krakowska 1",
                Email = "kontakt@zwierzakowo.pl",
                Phone = "123456789",
                State = "Mazowieckie",
                ZipCode = "00-001"
            },
            new Supplier()
            {
                Id = Guid.NewGuid(),
                City = "Kraków",
                Name = "Planeta Zwierząt",
                Country = "Polska",
                Street = "Floriańska 5",
                Email = "info@planetazwierzat.pl",
                Phone = "987654321",
                State = "Małopolskie",
                ZipCode = "30-002"
            },
            new Supplier()
            {
                Id = Guid.NewGuid(),
                City = "Gdańsk",
                Name = "Supplies dla Zwierząt",
                Country = "Polska",
                Street = "Długa 10",
                Email = "support@supplies.pl",
                Phone = "555555555",
                State = "Pomorskie",
                ZipCode = "80-003"
            }
        };
        }
    }
}