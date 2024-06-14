using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PetStore.CrossCutting.Dtos.Animals;
using PetStore.Storage;
using PetStore.Storage.Entities.Animals;

namespace PetStore.Resolver
{
    public class AnimalIntegrationDataResolver
    {
        private readonly HttpClient _httpClient;
        private const string EXTERNAL_API_BASE_URL = "http://localhost:5149/api/species";
        public AnimalIntegrationDataResolver( HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<AnimalDto>> GetAnimalAsync(Guid specieId)
        {

            var externalApiUrl = $"{EXTERNAL_API_BASE_URL}/{specieId}/animals";
            try
            {
                var response = await _httpClient.GetAsync(EXTERNAL_API_BASE_URL);
                if (response.IsSuccessStatusCode)
                {
                    var responseData = JsonConvert.DeserializeObject<List<AnimalDto>>(await response.Content.ReadAsStringAsync());
                    return responseData;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public async Task<AnimalDto> GetAnimalByIdAsync(Guid specieId, Guid id)
        {
            var externalApiUrl = $"{EXTERNAL_API_BASE_URL}/{specieId}/animals/{id}";
            try
            {
                var response = await _httpClient.GetAsync(externalApiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var responseData = JsonConvert.DeserializeObject<AnimalDto>(await response.Content.ReadAsStringAsync());
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
