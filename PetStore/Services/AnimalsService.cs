using PetStore.CrossCutting.Dtos.Animals;
using PetStore.Interfaces;
using PetStore.Resolver;

namespace PetStore.Services
{
    public class AnimalsService : IAnimalsService
    {
        private readonly SpecieIntegrationDataResolver _resolver;
        public AnimalsService(SpecieIntegrationDataResolver resolver)
        {
            _resolver = resolver;
        }

        public Task<AnimalDto> GetAnimalByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<AnimalDto> GetAnimalBySpecieIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<AnimalDto> GetAnimalsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AnimalDto> GetAnimalsByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<AnimalDto> GetAnimalsBySpecieName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<SpecieDto> GetSpecielByIdAsync(Guid id)
        {
            return await _resolver.GetSpeciesAsync(id);
        }

        public Task<SpecieDto> GetSpecieByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<SpecieDto> GetSpeciesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
