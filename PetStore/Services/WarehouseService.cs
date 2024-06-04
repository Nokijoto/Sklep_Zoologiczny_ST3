using Microsoft.Identity.Client.Extensibility;
using PetStore.CrossCutting.Dtos.Warehouse;
using PetStore.Interfaces;
using PetStore.Resolver;
using PetStore.Storage;
using PetStore.Storage.Entities.Warehouse;

namespace PetStore.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly WarehouseIntegrationDataResolver _dataResolver;
        private PetStoreDbContext _dbContext;

        public WarehouseService(WarehouseIntegrationDataResolver dataResolver, PetStoreDbContext dbContext)
        {
            _dataResolver = dataResolver;
            _dbContext = dbContext;
        }


        public Task<List<CategoriesDto>> GetAllCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductDto>> GetAllProductsAsync()
        {
             await _dataResolver.GetAllProductAsync();
            return _dbContext.Products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Category = p.Category,
                Quantity = p.Quantity,
                Price = p.Price
            }).ToList();
        }


        public Task<CategoriesDto> GetCategoryByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> GetProductByIdAsync(Guid id)
        {
            if(_dbContext.Products != null  )
            {
                var product = _dbContext.Products.FirstOrDefault(p => p.Id == id);
                if (product != null)
                {
                    return Task.FromResult(new ProductDto
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        Category = product.Category,
                        Quantity = product.Quantity,
                        Price = product.Price
                    });
                }
            }
            return Task.FromResult(new ProductDto());
        }

       

        public Task<List<ProductDto>> GetProductsByCategoryAsync(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<SupplierDto> GetSupplierByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<SupplierDto>> GetSuppliersAsync()
        {
            throw new NotImplementedException();
        }
    }
}
