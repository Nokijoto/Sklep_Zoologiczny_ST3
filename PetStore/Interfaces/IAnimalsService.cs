using PetStore.CrossCutting.Dtos.Animals;

namespace PetStore.Interfaces
{
    public interface IAnimalsService
    {
        Task<AnimalDto> GetAnimalByIdAsync(Guid specieId, Guid id);
        Task<AnimalDto> GetAllAnimalsAsync(Guid id);

        Task<SpecieDto> GetSpeciesAsync();
        Task<SpecieDto> GetSpecielByIdAsync(Guid id);
    }
}
