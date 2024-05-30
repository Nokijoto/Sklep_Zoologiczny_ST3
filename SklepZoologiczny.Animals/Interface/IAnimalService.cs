using SklepZoologiczny.Animals.CrossCutting.Dtos;

namespace SklepZoologiczny.Animals.Interface;

public interface IAnimalService
{
    Task CreateAnimal(Guid specieId, CreateAnimalDto animalDto);
    Task<ICollection<AnimalDto>> GetAll(Guid specieId);
    Task<AnimalDto> GetById(Guid specieId, Guid id);
    Task DeleteAnimal(Guid specieId, Guid id);
    Task UpdateAnimal(Guid specieId, Guid id, UpdateAnimalDto animalDto);
}