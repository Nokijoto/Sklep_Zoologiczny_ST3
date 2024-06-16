using Newtonsoft.Json;
using PetStore.CrossCutting.Dtos.Warehouse;
using System.Net.Http;

namespace PetStore.Resolver
{
    public class CategoriesDataResolver
    {
        private readonly HttpClient _httpClient;
        private const string EXTERNAL_API_BASE_URL = "https://localhost:7032/api";
        public CategoriesDataResolver(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CategoriesDto>> GetAllCategoriesAsync()
        {
            var externalApiUrl = $"{EXTERNAL_API_BASE_URL}/Categories";
            try
            {
                var response = await _httpClient.GetAsync(externalApiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var responseData = JsonConvert.DeserializeObject<List<CategoriesDto>>(await response.Content.ReadAsStringAsync());
                    responseData.ForEach(responese =>
                    {
                        responese.ExternalSourceName = "Warehouse";
                        responese.ExternalId = responese.Id;
                    });
                    return responseData;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<CategoriesDto> GetCategorieByIdAsync(Guid id)
        {
            var externalApiUrl = $"{EXTERNAL_API_BASE_URL}/Categories/{id}";
            try
            {
                var response = await _httpClient.GetAsync(externalApiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var responseData = JsonConvert.DeserializeObject<CategoriesDto>(await response.Content.ReadAsStringAsync());
                    responseData.ExternalSourceName = "Warehouse";
                    responseData.ExternalId = responseData.Id;
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
