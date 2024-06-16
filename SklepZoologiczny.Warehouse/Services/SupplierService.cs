using SklepZoologiczny.Warehouse.Storage.Entities;
using SklepZoologiczny.Warehouse.Storage;
using Microsoft.EntityFrameworkCore;
using SklepZoologiczny.Warehouse.Interfaces;
using SklepZoologiczny.Warehouse.CrossCutting.Dtos;
using SklepZoologiczny.Warehouse.Extension;

namespace SklepZoologiczny.Warehouse.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly WarehouseDbContext _context;

        public SupplierService(WarehouseDbContext context)
        {
            _context = context;
        }

        public async Task<List<SupplierDto>> GetAllSuppliersAsync()
        {
            return await _context.Suppliers.Select(x=>x.ToDto()).ToListAsync();
        }

        public async Task<SupplierDto> GetSupplierByIdAsync(Guid id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null)
            {
                throw new Exception("Supplier not found.");
            }
            return supplier.ToDto();
        }

        public async Task CreateSupplierAsync(CreateSupplierDto supplier)
        {
            _context.Suppliers.Add(supplier.ToEntity());
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSupplierAsync(Guid id, CreateSupplierDto updatedSupplier)
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
            supplier.City = updatedSupplier.City;
            supplier.Phone = updatedSupplier.Phone;
            supplier.ZipCode = updatedSupplier.ZipCode;
            //supplier.Products = (ICollection<Product>)updatedSupplier.Products;


            await _context.SaveChangesAsync();
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
