using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SklepZoologiczny.Animals.CrossCutting.Dtos;
using SklepZoologiczny.Animals.Interface;
using SklepZoologiczny.Animals.Storage;
using SklepZoologiczny.Animals.Storage.Entity;

namespace SklepZoologiczny.Animals.Service;

public class AnimalService: IAnimalService
{
    private readonly AnimalsDbContext _dbContext;
    private readonly IMapper _mapper;

    public AnimalService(AnimalsDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task CreateAnimal(Guid specieId, CreateAnimalDto animalDto)
    {
        var specie = await _dbContext.Species.FirstOrDefaultAsync(x => x.Id == specieId);
        if (specie is null) throw new Exception("Specie not found");
        
        var animal = _mapper.Map<Animal>(animalDto);
        animal.SpecieId = specieId;
        await _dbContext.Animals.AddAsync(animal);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<ICollection<AnimalDto>> GetAll(Guid specieId)
    {
        var animals = await _dbContext.Species.Include(r => r.Animals).FirstOrDefaultAsync(x => x.Id == specieId);
        if (animals is null) throw new Exception("Specie not found");
        var animalsDto = _mapper.Map<ICollection<AnimalDto>>(animals.Animals);
        return animalsDto;
    }
    public async Task<AnimalDto> GetById(Guid specieId, Guid id)
    {
        var specie = await _dbContext.Species.FirstOrDefaultAsync(x => x.Id == specieId);
        if (specie is null) throw new Exception("Specie not found");
        
        var animal = await _dbContext.Animals.Include(r => r.Specie).FirstOrDefaultAsync(x => x.Id == id);
        var animalDto = _mapper.Map<AnimalDto>(animal);
        return animalDto;
    }
    public async Task DeleteAnimal(Guid specieId, Guid id)
    {
        var specie = await _dbContext.Species.FirstOrDefaultAsync(x => x.Id == specieId);
        if (specie is null) throw new Exception("Specie not found");
        
        var animal = await _dbContext.Animals.Include(r => r.Specie).FirstOrDefaultAsync(x => x.Id == id);
        if (animal is null) throw new Exception("Animal not found");
        _dbContext.Animals.Remove(animal);
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task UpdateAnimal(Guid specieId, Guid id, UpdateAnimalDto animalDto)
    {
        var specie = await _dbContext.Species.FirstOrDefaultAsync(x => x.Id == specieId);
        if (specie is null) throw new Exception("Specie not found");
        
        var animal = await _dbContext.Animals.Include(r => r.Specie).FirstOrDefaultAsync(x => x.Id == id);
        if (animal is null) throw new Exception("Animal not found");
        _mapper.Map(animalDto, animal);
        await _dbContext.SaveChangesAsync();
    }
}