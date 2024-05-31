using PetStore.CrossCutting.Dtos.Warehouse;
using PetStore.Storage.Entities.Warehouse;

namespace PetStore.Interfaces
{
    public interface IWarehouseService
    {

        public Task<List<CategoriesDto>> GetAllCategoriesAsync();
        public Task<CategoriesDto> GetCategoryByIdAsync(Guid id);

        public Task<List<ProductDto>> GetAllProductsAsync();
        public Task<ProductDto> GetProductByIdAsync(Guid id);
        public Task<ProductDto> GetProductByNameAsync(string name);
        public Task<List<ProductDto>> GetProductsByCategoryAsync(Guid categoryId);

        public Task<List<SupplierDto>> GetSuppliersAsync();
        public Task<SupplierDto> GetSupplierByIdAsync(Guid id);
        public Task<SupplierDto> GetSupplierByNameAsync(string name);


    }
}