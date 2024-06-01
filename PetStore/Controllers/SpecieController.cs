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
    }
}
