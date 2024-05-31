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

        public Task<List<ProductDto>> GetAllProductsAsync()
        {
            if (_dbContext.Products != null)
            {
                var products = _dbContext.Products.ToList();
                var productDtos = new List<ProductDto>();
                foreach (var product in products)
                {
                    productDtos.Add(new ProductDto
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        Category = product.Category,
                        Quantity = product.Quantity,
                        Price = product.Price
                    });
                }
                return Task.FromResult(productDtos);
            };
            return Task.FromResult(new List<ProductDto>());

        }


        protected  async Task OnBeforeRecordCreatedAsync(PetStoreDbContext dbContext, Product entity)
        {
            if (entity.Id != null)
            {
                await _dataResolver.ResolveFor(entity.Id);
            }
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
