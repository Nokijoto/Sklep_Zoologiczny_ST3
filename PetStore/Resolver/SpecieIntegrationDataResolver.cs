using Newtonsoft.Json;
using PetStore.CrossCutting.Dtos.Animals;
using PetStore.Storage.Entities.Animals;
using PetStore.Storage;

namespace PetStore.Resolver
{
    public class SpecieIntegrationDataResolver
    {
        private readonly PetStoreDbContext _dbContext;
        private readonly HttpClient _httpClient;
        private const string EXTERNAL_API_BASE_URL = "http://localhost:5149/api/Species";

        public SpecieIntegrationDataResolver(PetStoreDbContext dbContext, HttpClient httpClient)
        {
            _dbContext = dbContext;
            _httpClient = httpClient;
        }

        public async Task<SpecieDto> GetSpeciesAsync(Guid id)
        {
            var externalApiUrl = $"{EXTERNAL_API_BASE_URL}/{id}";
            var response = await _httpClient.GetAsync(externalApiUrl);
            if (response.IsSuccessStatusCode)
            {
                var specie = JsonConvert.DeserializeObject<SpecieDto>(await response.Content.ReadAsStringAsync());
                await CreateOrUpdateAnimals(specie);
                return specie;

            }
            return new SpecieDto()
            {
                Name = externalApiUrl.ToString()
            };

        }
        private async Task<Specie> CreateOrUpdateAnimals(SpecieDto dto)
        {
            var animal = new Specie
            {
                Id = dto.Id,
                Name = dto.Name,
                ExternalId = dto.Id,
                ExternalSourceName = "Species",
            };
            _dbContext.Species.Add(animal);
            _dbContext.SaveChanges();
            return animal;
        }
    }
}
