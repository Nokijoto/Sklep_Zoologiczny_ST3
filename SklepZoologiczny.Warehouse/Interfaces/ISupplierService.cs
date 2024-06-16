using SklepZoologiczny.Warehouse.CrossCutting.Dtos;
using SklepZoologiczny.Warehouse.Storage.Entities;

namespace SklepZoologiczny.Warehouse.Interfaces
{
    public interface ISupplierService
    {
        Task CreateSupplierAsync(CreateSupplierDto supplier);
        Task DeleteSupplierAsync(Guid id);
        Task<List<SupplierDto>> GetAllSuppliersAsync();
        Task<SupplierDto> GetSupplierByIdAsync(Guid id);
        Task UpdateSupplierAsync(Guid id, CreateSupplierDto updatedSupplier);
    }
}