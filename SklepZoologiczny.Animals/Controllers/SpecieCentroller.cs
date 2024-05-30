using Microsoft.AspNetCore.Mvc;
using SklepZoologiczny.Animals.CrossCutting.Dtos;
using SklepZoologiczny.Animals.Interface;

namespace SklepZoologiczny.Animals.Controllers;
[ApiController]
[Route("api/species")]
public class SpecieCentroller: ControllerBase
{
    private readonly ISpecieService _specieService;
    public SpecieCentroller(ISpecieService specieService)
    {
     _specieService = specieService;   
    }
    
    [HttpGet]
    
    public async Task<ActionResult<IEnumerable<SpecieDto>>> GetAll()
    {
        var species = await _specieService.GetAll();
        return Ok(species);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<SpecieDto>> GetById(Guid id)
    {
        var specie = await _specieService.GetById(id);
        if (specie == null)
        {
            return NotFound();
        }
        return Ok(specie);
    }
    
    [HttpPost]
    public async Task<ActionResult> CreateSpecie([FromBody] SpecieDto specieDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await _specieService.CreateSpecie(specieDto);
        return Ok();
    }
    

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteSpecie(Guid id)
    {
        await _specieService.DeleteSpecie(id);
        return NoContent();
    }
    
    
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateSpecie(Guid id, [FromBody] UpdateSpecieDto specieDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await _specieService.UpdateSpecie(id, specieDto);
        return Ok();
    }
}