using SklepZoologiczny.Warehouse.Storage.Entities;

namespace SklepZoologiczny.Warehouse.Interfaces
{
    public interface ISupplierService
    {
        Task<Supplier> CreateSupplierAsync(Supplier supplier);
        Task DeleteSupplierAsync(Guid id);
        Task<List<Supplier>> GetAllSuppliersAsync();
        Task<Supplier> GetSupplierByIdAsync(Guid id);
        Task<Supplier> UpdateSupplierAsync(Guid id, Supplier updatedSupplier);
    }
}