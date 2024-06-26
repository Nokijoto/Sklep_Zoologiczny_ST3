namespace SklepZoologiczny.Animals.CrossCutting.Dtos;

public class AnimalDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Breed { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public int Price { get; set; }
    public Guid SpecieId { get; set; }

}