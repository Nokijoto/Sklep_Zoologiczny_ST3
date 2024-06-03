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
        private const string EXTERNAL_API_BASE_URL = "http://localhost:5149/api/species";

        public SpecieIntegrationDataResolver(PetStoreDbContext dbContext, HttpClient httpClient)
        {
            _dbContext = dbContext;
            _httpClient = httpClient;
        }

        public async Task<SpecieDto> GetSpeciesByIdAsync(Guid id)
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
        public async Task<SpecieDto> GetAllSpeciesAsync() {
            var response = await _httpClient.GetAsync(EXTERNAL_API_BASE_URL);
            if (response.IsSuccessStatusCode)
            {
                var species = JsonConvert.DeserializeObject<List<SpecieDto>>(await response.Content.ReadAsStringAsync());
                foreach (var specie in species)
                {
                    if(_dbContext.Species.FirstOrDefault(x => x.Id == specie.Id) is null){
                        await CreateOrUpdateAnimals(specie);
                    }
                }
            }
            return new SpecieDto()
            {
                Name = response.ToString()
            };
        }

        private async Task<Specie> CreateOrUpdateAnimals(SpecieDto dto)
        {
            var specie = new Specie
            {
                Id = dto.Id,
                Name = dto.Name,
                ExternalId = dto.Id,
                ExternalSourceName = "Species",
            };
            _dbContext.Species.Add(specie);
            _dbContext.SaveChanges();
            return specie;
        }
    }
}
