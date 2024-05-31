using PetStore.CrossCutting.Dtos.Warehouse;
using PetStore.Interfaces;
using PetStore.Storage.Entities.Warehouse;

namespace PetStore.Services
{
    public class WarehouseService : IWarehouseService
    {
        public Task<List<CategoriesDto>> GetAllCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDto>> GetAllProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CategoriesDto> GetCategoryByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> GetProductByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> GetProductByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDto>> GetProductsByCategoryAsync(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<SupplierDto> GetSupplierByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<SupplierDto> GetSupplierByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<SupplierDto>> GetSuppliersAsync()
        {
            throw new NotImplementedException();
        }
    }
}
