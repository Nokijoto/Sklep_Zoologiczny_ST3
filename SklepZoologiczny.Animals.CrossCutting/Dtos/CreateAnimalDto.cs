namespace SklepZoologiczny.Animals.CrossCutting.Dtos;

public class CreateAnimalDto
{
    public string Name { get; set; }
    public string Breed { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public decimal Price { get; set; }
    
}