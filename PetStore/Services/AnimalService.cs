using PetStore.Interfaces;
using SklepZoologiczny.Animals.CrossCutting.Dtos;

namespace PetStore.Services
{
    public class AnimalService : IAnimalsService
    {
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

        public Task<SpecieDto> GetSpecieByIdAsync(Guid id)
        {
            throw new NotImplementedException();
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
