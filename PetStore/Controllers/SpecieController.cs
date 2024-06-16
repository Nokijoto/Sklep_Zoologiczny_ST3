using Microsoft.AspNetCore.Mvc;
using PetStore.CrossCutting.Dtos.Animals;
using PetStore.Interfaces;

namespace PetStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpecieController : ControllerBase
    {
        private readonly IAnimalsService _service;
        public SpecieController(IAnimalsService animalsService)
        {
            _service = animalsService;
        }

        [HttpGet("{specieId}")]
        public async Task<ActionResult<SpecieDto>> Dawajednegospecie(Guid specieId)
        {
            var specie = await _service.GetSpecielByIdAsync(specieId);
            return Ok(specie);
        }
        [HttpGet]
        public async Task<ActionResult<SpecieDto>> Dawajwszystkiespecies()
        {
            var species = await _service.GetSpeciesAsync();
            return Ok(species);
        }

        [HttpGet("{specieId}/animals")]
        public async Task<ActionResult<AnimalDto>> Dawajwszystkiezwierzaki(Guid specieId)
        {
            var animals = await _service.GetAllAnimalsAsync(specieId);
            return Ok(animals);
        }

        [HttpGet("{specieId}/animals/{id}")]
        public async Task<ActionResult<AnimalDto>> Dawajzwierzaka(Guid specieId, Guid id)
        {
            var animal = await _service.GetAnimalByIdAsync(specieId, id);
            return Ok(animal);
        }
    }
}
