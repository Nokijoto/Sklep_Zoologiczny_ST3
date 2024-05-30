using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SklepZoologiczny.Animals.CrossCutting.Dtos;
using SklepZoologiczny.Animals.Interface;
using SklepZoologiczny.Animals.Storage;
using SklepZoologiczny.Animals.Storage.Entity;

namespace SklepZoologiczny.Animals.Service;

public class SpecieServices: ISpecieService
{
    private readonly AnimalsDbContext _dbContext;
    private readonly IMapper _mapper;

    public SpecieServices(AnimalsDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SpecieDto>> GetAll()
    {
        var species = await _dbContext.Species.Include(r=>r.Animals).ToListAsync();
        var speciesDto = _mapper.Map<IEnumerable<SpecieDto>>(species);
        return speciesDto;
    }
    public async Task<SpecieDto> GetById(Guid id)
    {
        var specie = await _dbContext.Species.Include(r=>r.Animals).FirstOrDefaultAsync(x => x.Id == id);
        var specieDto = _mapper.Map<SpecieDto>(specie);
        return specieDto;
    }
    public async Task CreateSpecie(SpecieDto specieDto)
    {
        var specie = _mapper.Map<Specie>(specieDto);
        await _dbContext.Species.AddAsync(specie);
        await _dbContext.SaveChangesAsync();
    }
    public async Task UpdateSpecie(Guid id, UpdateSpecieDto specieDto)
    {
        var specie = await _dbContext.Species.FirstOrDefaultAsync(x => x.Id == id);
        if (specie is null) throw new Exception("Specie not found");
        specie.Name = specieDto.Name;
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteSpecie(Guid id)
    {
        var specie = await _dbContext.Species.FirstOrDefaultAsync(x => x.Id == id);
        if (specie is null) throw new Exception("Specie not found");
        _dbContext.Species.Remove(specie);
        await _dbContext.SaveChangesAsync();
        
    }
    
    
}