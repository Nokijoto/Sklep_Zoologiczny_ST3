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
                if (!_context.Employees.Any())
                {
                    var employes = GetEmployees();
                    _context.AddRange(employes);
                    _context.SaveChanges();
                }
                if(!_context.Suppliers.Any())
                {
                    var suppliers = GetSuppliers();
                    _context.AddRange(suppliers);
                    _context.SaveChanges();
                }
                if (!_context.InventoryTransactions.Any())
                {
                    var transactions = GetTransactions();
                }
                if(!_context.Categories.Any())
                {
                    var categories = GetCategories();
                    _context.AddRange(categories);
                    _context.SaveChanges();
                }
                if(!_context.Products.Any())
                {
                    var products = GetProducts();
                    _context.AddRange(products);
                    _context.SaveChanges();
                }
            }
        }

        private object[] GetProducts()
        {
            throw new NotImplementedException();
        }

        private IEnumerable<Categorie> GetCategories()
        {
            return new List<Categorie>()
            {
                
            };
        }

        private object GetTransactions()
        {
            throw new NotImplementedException();
        }

        private object[] GetSuppliers()
        {
            throw new NotImplementedException();
        }

        private IEnumerable<Employee> GetEmployees()
        {
            return new List<Employee>
            {
                new Employee()
                {
                    Id = new Guid(),
                    Name = "Jan Kowalski",
                },
                new Employee()
                {
                    Id = new Guid(),
                    Name = "Anna Nowak",
                },
                new Employee()
                {
                    Id = new Guid(),
                    Name = "Piotr Wiśniewski",
                }
            };
        }
    }
}
