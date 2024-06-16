using Microsoft.EntityFrameworkCore;
using SklepZoologiczny.Animals.Storage.Entity;

namespace SklepZoologiczny.Animals.Storage;

public class AnimalsDbContext : DbContext
{
    public DbSet<Animal> Animals { get; set; }
    public DbSet<Specie> Species { get; set; }
    
    public AnimalsDbContext(DbContextOptions<AnimalsDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Specie>()
            .HasMany(x => x.Animals)
            .WithOne(x => x.Specie)
            .HasForeignKey(x => x.SpecieId);
    }
    
}