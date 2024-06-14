using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;
using PetStore.CrossCutting.Dtos.Animals;
using PetStore.Extensions;
using PetStore.Interfaces;
using PetStore.Resolver;
using PetStore.Storage;
using PetStore.Storage.Entities.Animals;

namespace PetStore.Services
{
    public class AnimalsService : IAnimalsService
    {
        private readonly SpecieIntegrationDataResolver _resolver;
        private readonly PetStoreDbContext _dbContext;
        private readonly AnimalIntegrationDataResolver _animalResolver;
        public AnimalsService(SpecieIntegrationDataResolver resolver, PetStoreDbContext dbContext, AnimalIntegrationDataResolver animalResolver)
        {
            _resolver = resolver;
            _dbContext = dbContext;
            _animalResolver=animalResolver;
        }

        public async Task<ICollection<AnimalDto>> GetAllAnimalsAsync(Guid id)
        {
            try
            {
                if (_dbContext.Animals != null && await _dbContext.Animals.AnyAsync())
                {
                    return await _dbContext.Animals.Select(s => new AnimalDto
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Breed = s.Breed,
                        Age = s.Age
                    }).ToListAsync();
                  
                }
                else
                {
                    List<AnimalDto> dataFromResolver = await _animalResolver.GetAnimalAsync(id);

                    var animals = dataFromResolver.Select(s => new Animal
                    {
                        Id = s.Id,
                        Name = s.Name
                    }).ToList();

                    await _dbContext.Animals.AddRangeAsync(animals);
                    await _dbContext.SaveChangesAsync();

                    return await _dbContext.Animals.Select(s => new AnimalDto
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Breed = s.Breed,
                        Age = s.Age
                    }).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<AnimalDto> GetAnimalByIdAsync(Guid specieId, Guid id)
        {
            try
            {
                var animal = await _dbContext.Animals.FindAsync(id);

                if (animal != null)
                {
                    return new AnimalDto{
                        Id = animal.Id,
                        Name = animal.Name,
                        Breed = animal.Breed,
                        Age = animal.Age
                    };
                }
                else
                {
                    var dataFromResolver = await _animalResolver.GetAnimalByIdAsync(specieId,id);

                    if (dataFromResolver != null)
                    {
                        var newcategory = new Animal
                        {
                            Id = dataFromResolver.Id,
                            Name = dataFromResolver.Name,
                            Breed = dataFromResolver.Breed,
                            Age = dataFromResolver.Age
                        };
                        _dbContext.Animals.Add(newcategory);
                        await _dbContext.SaveChangesAsync();
                        return new AnimalDto
                        {
                            Id = animal.Id,
                            Name = animal.Name,
                            Breed = animal.Breed,
                            Age = animal.Age
                        };
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<SpecieDto> GetSpecielByIdAsync(Guid id)
        {
            try
            {
                var specie = await _dbContext.Species.FindAsync(id);

                if (specie != null)
                {
                    return new SpecieDto
                    {
                        Id = specie.Id,
                        Name = specie.Name
                    };
                }
                else
                {
                    var DtoFromResolver = await _resolver.GetSpeciesByIdAsync(id);

                    if (DtoFromResolver != null)
                    {
                        var newspecie = new Specie
                        {
                            Id = DtoFromResolver.Id,
                            Name = DtoFromResolver.Name
                        };
                        _dbContext.Species.Add(newspecie);
                        await _dbContext.SaveChangesAsync();
                        return new SpecieDto
                        {
                            Id = newspecie.Id,
                            Name = newspecie.Name
                        };
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<SpecieDto>> GetSpeciesAsync()
        {
            try
            {
                if (_dbContext.Species != null && await _dbContext.Species.AnyAsync())
                {
                    return await _dbContext.Species.Select(s => new SpecieDto
                    {
                        Id = s.Id,
                        Name = s.Name
                    }).ToListAsync();
                }
                else
                {
                    List<SpecieDto> dataFromResolver = await _resolver.GetAllSpeciesAsync();

                    var species = dataFromResolver.Select(s => new Specie
                    {
                        Id = s.Id,
                        Name = s.Name
                    }).ToList();

                    await _dbContext.Species.AddRangeAsync(species);
                    await _dbContext.SaveChangesAsync();

                    return await _dbContext.Species.Select(s => new  SpecieDto
                    {
                        Id = s.Id,
                        Name = s.Name
                    }).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
