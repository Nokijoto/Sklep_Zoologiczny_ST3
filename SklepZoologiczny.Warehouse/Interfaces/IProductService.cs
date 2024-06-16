using SklepZoologiczny.Warehouse.Storage.Entities;
using SklepZoologiczny.Warehouse.CrossCutting.Dtos;
namespace SklepZoologiczny.Warehouse.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllProductsAsync();
        Task<ProductDto> GetProductByIdAsync(Guid id);
        Task CreateProductAsync(CreateProductDto product);
        Task UpdateProductAsync(Guid id, CreateProductDto updatedProduct);
        Task DeleteProductAsync(Guid id);
    }
}
