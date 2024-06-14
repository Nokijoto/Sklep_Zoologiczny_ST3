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
        private readonly HttpClient _httpClient;
        private const string EXTERNAL_API_BASE_URL = "https://localhost:7032/api";
        public WarehouseIntegrationDataResolver( HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task<List<ProductDto>> GetAllProductAsync()
        {
            var externalApiUrl = $"{EXTERNAL_API_BASE_URL}/products";
            try
            {
                var response = await _httpClient.GetAsync(externalApiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var responseData = JsonConvert.DeserializeObject<List<ProductDto>>(await response.Content.ReadAsStringAsync());
                    return responseData;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<ProductDto> GetProductByIdAsync(Guid id)
        {
            var externalApiUrl = $"{EXTERNAL_API_BASE_URL}/products/{id}";
            try
            {
                var response = await _httpClient.GetAsync(externalApiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var responseData = JsonConvert.DeserializeObject<ProductDto>(await response.Content.ReadAsStringAsync());
                    return responseData;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<List<ProductDto>> GetProductsByCategoryAsync(Guid categoryId)
        {
            var externalApiUrl = $"{EXTERNAL_API_BASE_URL}/products/category/{categoryId}";
            try
            {
                var response = await _httpClient.GetAsync(externalApiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var responseData = JsonConvert.DeserializeObject<List<ProductDto>>(await response.Content.ReadAsStringAsync());
                    return responseData;
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
        