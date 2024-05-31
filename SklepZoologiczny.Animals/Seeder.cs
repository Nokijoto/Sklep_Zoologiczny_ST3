using SklepZoologiczny.Animals.Storage;
using SklepZoologiczny.Animals.Storage.Entity;

namespace SklepZoologiczny.Animals;

public class Seeder
{
    private readonly AnimalsDbContext _context;
    public Seeder(AnimalsDbContext context)
    {
        _context = context;
    }

    public void Seed()
    {
        if (_context.Database.CanConnect())
        {
            if (!_context.Species.Any())
            {
                var species = GetSpecies();
                _context.AddRange(species);
                _context.SaveChanges();
            }
        }
    }
    private IEnumerable<Specie> GetSpecies()
    {
        return new List<Specie>
        {
            new Specie()
            {
                Id = new Guid(),
                Name = "Pies",
                Animals = new List<Animal>
                {
                    new Animal()
                    {
                        Id = new Guid(),
                        Name = "Azor",
                        Breed = "Owczarek Niemiecki",
                        Age = 5,
                        Gender = "M",
                        Price = 2000,
                    },
                    new Animal()
                    {
                        Id = new Guid(),
                        Name = "Burek",
                        Breed = "Mieszaniec",
                        Age = 3,
                        Gender = "M",
                        Price = 500
                    },
                    new Animal()
                    {
                        Id = new Guid(),
                        Name = "Reksio",
                        Breed = "Jamnik",
                        Age = 2,
                        Gender = "M",
                        Price = 1000
                    }
                }
            },
            new Specie()
            {
                Id = new Guid(),
                Name = "Kot",
                Animals = new List<Animal>
                {
                    new Animal()
                    {
                        Id = new Guid(),
                        Name = "Filemonica",
                        Breed = "Syjamski",
                        Age = 1,
                        Gender = "F",
                        Price = 1500
                    }
                }
            },
            new Specie()
            {
                Id = new Guid(),
                Name = "Rybka",
                Animals = new List<Animal>
                {
                    new Animal()
                    {
                        Id = new Guid(),
                        Name = "Złotka",
                        Breed = "Złota",
                        Age = 1,
                        Gender = "M",
                        Price = 50

                    }
                }
            },
            new Specie
            {
                Id = Guid.NewGuid(),
                Name = "Papuga",
                Animals = new List<Animal>
                {
                    new Animal
                    {
                        Id = Guid.NewGuid(),
                        Name = "Kazik",
                        Breed = "Amazonka",
                        Age = 3,
                        Gender = "M",
                        Price = 1000
                    },
                    new Animal
                    {
                        Id = Guid.NewGuid(),
                        Name = "Tiko",
                        Breed = "Ara",
                        Age = 4,
                        Gender = "M",
                        Price = 3000
                    },
                    new Animal
                    {
                        Id = Guid.NewGuid(),
                        Name = "Polly",
                        Breed = "Kakadu",
                        Age = 2,
                        Gender = "F",
                        Price = 2500
                    }
                }
            },
            new Specie
            {
                Id = Guid.NewGuid(),
                Name = "Królik",
                Animals = new List<Animal>
                {
                    new Animal
                    {
                        Id = Guid.NewGuid(),
                        Name = "MarthyBunny",
                        Breed = "miniaturka",
                        Age = 2,
                        Gender = "F",
                        Price = 200
                    },
                    new Animal
                    {
                        Id = Guid.NewGuid(),
                        Name = "Kicuś",
                        Breed = "Królik angorski",
                        Age = 3,
                        Gender = "M",
                        Price = 300
                    }
                }
            },
            new Specie
            {
                Id = Guid.NewGuid(),
                Name = "Chomik",
                Animals = new List<Animal>
                {
                    new Animal
                    {
                        Id = Guid.NewGuid(),
                        Name = "Puszek",
                        Breed = "Chomik syryjski",
                        Age = 1,
                        Gender = "M",
                        Price = 30
                    },
                    new Animal
                    {
                        Id = Guid.NewGuid(),
                        Name = "Fifi",
                        Breed = "Chomik dżungarski",
                        Age = 1,
                        Gender = "F",
                        Price = 25
                    }
                }

            }
        };
    }
}
