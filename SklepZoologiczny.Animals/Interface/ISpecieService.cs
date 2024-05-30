using SklepZoologiczny.Animals.CrossCutting.Dtos;

namespace SklepZoologiczny.Animals.Interface;

public interface ISpecieService
{
    Task<IEnumerable<SpecieDto>> GetAll();
    Task<SpecieDto> GetById(Guid id);
    Task CreateSpecie(SpecieDto specieDto);
    Task UpdateSpecie(Guid id, UpdateSpecieDto specieDto);
    Task DeleteSpecie(Guid id);
}