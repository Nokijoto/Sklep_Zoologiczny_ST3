using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PetStore.CrossCutting.Dtos.Animals;
using PetStore.Storage;
using PetStore.Storage.Entities.Animals;

namespace PetStore.Resolver
{
    public class AnimalIntegrationDataResolver
    {
        private readonly PetStoreDbContext _dbContext;
        private readonly HttpClient _httpClient;
        private const string EXTERNAL_API_BASE_URL = "http://localhost:5149/api/species";

        public AnimalIntegrationDataResolver(PetStoreDbContext dbContext, HttpClient httpClient)
        {
            _dbContext = dbContext;
            _httpClient = httpClient;
        }
        public async Task<AnimalDto> GetAnimalAsync(Guid specieId)
        {
            var externalApiUrl = $"{EXTERNAL_API_BASE_URL}/{specieId}/animals";
            var response = await _httpClient.GetAsync(externalApiUrl);
            if (response.IsSuccessStatusCode)
            {
                var animal = JsonConvert.DeserializeObject<List<AnimalDto>>(await response.Content.ReadAsStringAsync());
                foreach (var animalDto in animal)
                {
                    await CreateOrUpdateAnimals(animalDto);
                }
            }
            return new AnimalDto()
            {
                Name = externalApiUrl.ToString()
            };
        }
        public async Task<AnimalDto> GetAnimalByIdAsync(Guid specieId, Guid id)
        {
            var externalApiUrl = $"{EXTERNAL_API_BASE_URL}/{specieId}/animals/{id}";
            var response = await _httpClient.GetAsync(externalApiUrl);
            if (response.IsSuccessStatusCode)
            {
                var animal = JsonConvert.DeserializeObject<AnimalDto>(await response.Content.ReadAsStringAsync());
                await CreateOrUpdateAnimals(animal);
                return animal;
            }
            return new AnimalDto()
            {
                Name = externalApiUrl.ToString()
            };
        }

        public async Task<AnimalDto> CreateOrUpdateAnimals(AnimalDto dto)
        {
            
            var animal = new Animal
            {
                Id = dto.Id,
                Name = dto.Name,
                Breed = dto.Breed,
                Age = dto.Age,
                Gender = dto.Gender,
                Price = dto.Price,
                SpecieId = dto.SpecieId,
                ExternalId = dto.Id,
                ExternalSourceName = "Animals"


            };
            await _dbContext.Animals.AddAsync(animal);
            await _dbContext.SaveChangesAsync();
            return dto;
        }
    }
}
