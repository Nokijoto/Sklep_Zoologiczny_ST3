using SklepZoologiczny.Common.Storage.Entities;

namespace SklepZoologiczny.Animals.Storage.Entity;

public class Specie: BaseEntity
{
    public string Name { get; set; }
    
    public virtual ICollection<Animal> Animals { get; set; }
}