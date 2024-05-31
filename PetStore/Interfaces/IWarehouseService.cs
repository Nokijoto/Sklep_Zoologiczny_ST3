using PetStore.CrossCutting.Dtos.Warehouse;
using PetStore.Storage.Entities.Warehouse;

namespace PetStore.Interfaces
{
    internal interface IWarehouseService
    {

        Task<List<CategoriesDto>> GetAllCategoriesAsync();
        Task<CategoriesDto> GetCategoryByIdAsync(Guid id);



        Task<List<ProductDto>> GetAllProductsAsync(); 
        Task<ProductDto> GetProductByIdAsync(Guid id);
        Task<ProductDto> GetProductByNameAsync(string name);
        Task<List<ProductDto>> GetProductsByCategoryAsync(Guid categoryId);

        Task<List<SupplierDto>> GetSuppliersAsync();
        Task<SupplierDto> GetSupplierByIdAsync(Guid id);
        Task<SupplierDto> GetSupplierByNameAsync(string name);


    }
}