using SklepZoologiczny.Warehouse.Storage.Entities;
using SklepZoologiczny.Warehouse.Storage;
using Microsoft.EntityFrameworkCore;
using SklepZoologiczny.Warehouse.Interfaces;

namespace SklepZoologiczny.Warehouse.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly WarehouseDbContext _context;

        public SupplierService(WarehouseDbContext context)
        {
            _context = context;
        }

        public async Task<List<Supplier>> GetAllSuppliersAsync()
        {
            return await _context.Suppliers.ToListAsync();
        }

        public async Task<Supplier> GetSupplierByIdAsync(Guid id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null)
            {
                throw new Exception("Supplier not found.");
            }
            return supplier;
        }

        public async Task<Supplier> CreateSupplierAsync(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();
            return supplier;
        }

        public async Task<Supplier> UpdateSupplierAsync(Guid id, Supplier updatedSupplier)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null)
            {
                throw new Exception("Supplier not found.");
            }

            supplier.Name = updatedSupplier.Name;
            supplier.Email = updatedSupplier.Email;
            supplier.City = updatedSupplier.City;
            supplier.Country = updatedSupplier.Country;
            supplier.State = updatedSupplier.State;
            supplier.Street = updatedSupplier.Street;
            supplier.Products = updatedSupplier.Products;
            supplier.City = updatedSupplier.City;
            supplier.Phone = updatedSupplier.Phone;
            supplier.ZipCode = updatedSupplier.ZipCode;


            await _context.SaveChangesAsync();
            return supplier;
        }

        public async Task DeleteSupplierAsync(Guid id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null)
            {
                throw new Exception("Supplier not found.");
            }

            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();
        }
    }
}
