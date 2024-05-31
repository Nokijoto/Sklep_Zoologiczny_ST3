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
        private readonly string apiUrl = "https://localhost:7032/api/";
        public WarehouseIntegrationDataResolver(PetStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task ResolveFor(Guid guid)
        {
            var exist = await _dbContext.Products.AnyAsync(x => x.Id == guid);
            if (exist)
            {
                var productDto = await ResolveFromExternalWarehouse(guid);
                await CreateOrUpdateProducts(productDto);
            }

        }

        private async Task<ProductDto> ResolveFromExternalWarehouse(Guid guid)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("products");

                string responseData = await response.Content.ReadAsStringAsync();

                List<ProductDto> countries = JsonConvert.DeserializeObject<List<ProductDto>>(responseData);

                return countries.FirstOrDefault(x => x.Id == guid);


            }
        }
        
        private async Task<Product> CreateOrUpdateProducts(ProductDto dto)
        {
            var product = new Product
            {
                ExternalId = dto.Id,
                ExternalSourceName = "Warehouse",
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Description,
                Category = dto.Category,
                Quantity = dto.Quantity,
                Price = dto.Price
            };

            _dbContext.Products.Add(product);
            return product;
        }
    }
}
