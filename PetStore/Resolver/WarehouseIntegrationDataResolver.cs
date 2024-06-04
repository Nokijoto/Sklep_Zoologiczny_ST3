using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using PetStore.CrossCutting.Dtos.Warehouse;
using PetStore.Storage;
using PetStore.Storage.Entities.Warehouse;
using System.Drawing.Printing;
using System.Net.Http.Headers;
using static System.Net.WebRequestMethods;

namespace PetStore.Resolver
{
    public class WarehouseIntegrationDataResolver 
    {
        private readonly PetStoreDbContext _dbContext;
        private readonly HttpClient _httpClient;
        private const string EXTERNAL_API_BASE_URL = "https://localhost:7032/api";
        public WarehouseIntegrationDataResolver(PetStoreDbContext dbContext, HttpClient httpClient)
        {
            _dbContext = dbContext;
            _httpClient = httpClient;
        }
        
        public async Task<ProductDto> GetAllProductAsync()
        {
            var externalApiUrl = $"{EXTERNAL_API_BASE_URL}/products";
            var response = await _httpClient.GetAsync(externalApiUrl);
            if (response.IsSuccessStatusCode)
            {
                var products = JsonConvert.DeserializeObject<List<ProductDto>>(await response.Content.ReadAsStringAsync());
                foreach (var product in products)
                {
                    if (_dbContext.Products.FirstOrDefault(x => x.ExternalId == product.Id) is null)
                    {
                        await CreateOrUpdateProducts(product);
                    }
                }
            }
            return new ProductDto()
            {
                Name = externalApiUrl.ToString()
            };
        }
        
        private async Task<Product> CreateOrUpdateProducts(ProductDto dto)
        {
            var product = new Product
            {
                ExternalId = dto.Id,
                ExternalSourceName = "Product",
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                Category = dto.Category,
                Quantity = dto.Quantity,
                Price = dto.Price
            };

            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return product;
        }
    }
}
