using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using PetStore.CrossCutting.Dtos.Warehouse;
using PetStore.Storage;
using PetStore.Storage.Entities.Warehouse;
using SklepZoologiczny.Animals.CrossCutting.Dtos;
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

        public void Resolve()
        {
            // Resolve data from external warehouse system
        }

        public async Task ResolveAsync()
        {
            // Resolve data from external warehouse system
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
            // Resolve data from external warehouse system
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
        
        private async Task<ProductDto> CreateOrUpdateProducts(ProductDto dto)
        {
            var product = new ProductDto
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                Category = dto.Category,
                Quantity = dto.Quantity,
                Price = dto.Price
            };

        
            return product;
        }
    }
}
