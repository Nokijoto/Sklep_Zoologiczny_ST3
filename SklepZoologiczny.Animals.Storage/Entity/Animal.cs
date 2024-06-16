using SklepZoologiczny.Common.Storage.Entities;

namespace SklepZoologiczny.Animals.Storage.Entity;

public class Animal: BaseEntity
{
    public string Name { get; set; }
    public string Breed { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public int Price { get; set; }
    
    public Guid SpecieId { get; set; }
    public virtual Specie Specie { get; set; }
}