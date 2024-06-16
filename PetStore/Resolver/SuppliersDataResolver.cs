using Microsoft.AspNetCore.Components.RenderTree;
using Newtonsoft.Json;
using PetStore.CrossCutting.Dtos.Warehouse;
using PetStore.Storage;
using PetStore.Storage.Entities.Warehouse;

namespace PetStore.Resolver
{
    public class SuppliersDataResolver
    {
        private readonly HttpClient _httpClient;
        private const string EXTERNAL_API_BASE_URL = "https://localhost:7032/api";
        public SuppliersDataResolver(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<SupplierDto>> GetAllSupplierAsync()
        {
            var externalApiUrl = $"{EXTERNAL_API_BASE_URL}/suppliers";
            try
            {
                var response = await _httpClient.GetAsync(externalApiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var suppliers = JsonConvert.DeserializeObject<List<SupplierDto>>(await response.Content.ReadAsStringAsync());
                    suppliers.ForEach(supplier =>
                    {
                        supplier.ExternalSourceName = "Warehouse";
                        supplier.ExternalId = supplier.Id;
                    });
                    return suppliers;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<SupplierDto> GetSupplierByIdAsync(Guid id)
        {
            var externalApiUrl = $"{EXTERNAL_API_BASE_URL}/suppliers/{id}";
            try
            {
                var response = await _httpClient.GetAsync(externalApiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var supplier = JsonConvert.DeserializeObject<SupplierDto>(await response.Content.ReadAsStringAsync());
                    supplier.ExternalSourceName = "Warehouse";
                    supplier.ExternalId = supplier.Id;
                    return supplier;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }   

    }
}
