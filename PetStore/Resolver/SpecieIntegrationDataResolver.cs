using Newtonsoft.Json;
using PetStore.CrossCutting.Dtos.Animals;
using PetStore.Storage.Entities.Animals;
using PetStore.Storage;

namespace PetStore.Resolver
{
    public class SpecieIntegrationDataResolver
    {
        private readonly HttpClient _httpClient;
        private const string EXTERNAL_API_BASE_URL = "http://localhost:5149/api/species";

        public SpecieIntegrationDataResolver(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<SpecieDto> GetSpeciesByIdAsync(Guid id)
        {
            var externalApiUrl = $"{EXTERNAL_API_BASE_URL}/{id}";
            try
            {
                var response = await _httpClient.GetAsync(externalApiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var responseData = JsonConvert.DeserializeObject<SpecieDto>(await response.Content.ReadAsStringAsync());
                    responseData.ExternalSourceName = "Animals";
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
        public async Task<List<SpecieDto>> GetAllSpeciesAsync() {
           
            try
            {
                var response = await _httpClient.GetAsync(EXTERNAL_API_BASE_URL);
                if (response.IsSuccessStatusCode)
                {
                    var responseData = JsonConvert.DeserializeObject<List<SpecieDto>>(await response.Content.ReadAsStringAsync());
                    foreach (var item in responseData)
                    {
                        item.ExternalSourceName = "Animals";
                        item.ExternalId = item.Id;
                    }
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
