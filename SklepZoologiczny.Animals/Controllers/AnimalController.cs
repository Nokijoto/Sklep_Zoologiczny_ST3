using Microsoft.AspNetCore.Mvc;
using SklepZoologiczny.Animals.CrossCutting.Dtos;
using SklepZoologiczny.Animals.Interface;

namespace SklepZoologiczny.Animals.Controllers;
[ApiController]
[Route("api/species/{specieId}/animals")]
public class AnimalController: ControllerBase
{
    private readonly IAnimalService _animalService;
    public AnimalController(IAnimalService animalService)
    {
        _animalService = animalService;
    }
    
    [HttpPost]
    public async Task<ActionResult> CreateAnimal(Guid specieId, [FromBody] CreateAnimalDto animalDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await _animalService.CreateAnimal(specieId, animalDto);
        return Ok();
    }
    
    [HttpGet]
    public async Task <ActionResult<ICollection<AnimalDto>>> GetAll(Guid specieId)
    {
        var animals = await _animalService.GetAll(specieId);
        return Ok(animals);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<AnimalDto>> GetById(Guid specieId, Guid id)
    {
        var animal = await _animalService.GetById(specieId, id);
        return Ok(animal);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAnimal(Guid specieId, Guid id)
    {
        await _animalService.DeleteAnimal(specieId, id);
        return Ok();
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateAnimal(Guid specieId, Guid id, [FromBody] UpdateAnimalDto animalDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await _animalService.UpdateAnimal(specieId, id, animalDto);
        return Ok();
    }
}