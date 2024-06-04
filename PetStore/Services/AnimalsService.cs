using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;
using PetStore.CrossCutting.Dtos.Animals;
using PetStore.Interfaces;
using PetStore.Resolver;
using PetStore.Storage;

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
            if(_dbContext.Species.FirstOrDefault(x => x.Id == id) is null) // do poprawy nalezy go poprawić tak żeby sprawdzał czy wszystkie wartości są już w bazie danych
            {
                await _animalResolver.GetAnimalAsync(id);
            }
            var animals = await _dbContext.Animals.Where(x => x.SpecieId == id).ToListAsync();

            return animals.Select(animal => new AnimalDto
            {
                Id = animal.Id,
                Name = animal.Name,
                Breed = animal.Breed,
                Age = animal.Age
            }).ToList();
        }

        public async Task<AnimalDto> GetAnimalByIdAsync(Guid specieId, Guid id)
        {
            var animalById= await _dbContext.Animals.FirstOrDefaultAsync(x => x.Id == id && x.SpecieId==specieId);
            if (animalById is not null)
            {
                return new AnimalDto
                {
                    Id = animalById.Id,
                    Name = animalById.Name,
                    Breed = animalById.Breed,
                    Age=animalById.Age,
                    Gender=animalById.Gender,
                    Price=animalById.Price                    
                };
            }
            return await _animalResolver.GetAnimalByIdAsync(specieId, id);
        }

        public async Task<SpecieDto> GetSpecielByIdAsync(Guid id)
        {
            var specielById= await _dbContext.Species.FirstOrDefaultAsync(x => x.Id == id);
            if (specielById is not null)
            {
                return new SpecieDto
                {
                    Id = specielById.Id,
                    Name = specielById.Name
                };
            }
            return await _resolver.GetSpeciesByIdAsync(id);
        }

        public async Task<IEnumerable<SpecieDto>> GetSpeciesAsync()
        {
            await _resolver.GetAllSpeciesAsync();
            var species = await _dbContext.Species.ToListAsync();
            return species.Select(x => new SpecieDto
            {
                Id = x.Id,
                Name = x.Name
            });
        }
    }
}
