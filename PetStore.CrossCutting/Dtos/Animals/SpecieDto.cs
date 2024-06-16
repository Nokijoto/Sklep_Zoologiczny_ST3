namespace PetStore.CrossCutting.Dtos.Animals;
public class SpecieDto : ExternalSource
{
    public Guid Id { get; set; }
    public string Name { get; set; }

}