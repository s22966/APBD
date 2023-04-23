using Microsoft.AspNetCore.Mvc;

namespace Exercise_03.Modules.Animals
{
    [Route("api/animals")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalsRepository _animalsRepository;

        public AnimalsController(IAnimalsRepository animalsRepository)
        {
            _animalsRepository = animalsRepository;
        }

        [HttpGet("{ID:int}")]
        public async Task<IActionResult> GetAnimal(int ID)
        {
            var animalModel = await _animalsRepository.GetAnimal(ID);
            return animalModel is null ? NotFound() : Ok(animalModel);
        }

        [HttpPut("{ID:int}")]
        public async Task<IActionResult> PutAnimal(int ID, [FromBody] AnimalPutDto animalPutDto)
        {
            if (!await _animalsRepository.DoesAnimalExists(ID))
            {
                return NotFound();
            }

            return Ok(await _animalsRepository.PutAnimal(ID, animalPutDto));
        }

        [HttpDelete("{ID:int}")]
        public async Task<IActionResult> DeleteAnimal(int ID)
        {
            if (!await _animalsRepository.DoesAnimalExists(ID))
            {
                return NotFound();
            }

            await _animalsRepository.DeleteAnimal(ID);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAnimals(string? orderBy)
        {
            if (orderBy is not null && !_animalsRepository.GetValidOrderByValues().Contains(orderBy))
            {
                return BadRequest();
            }

            return Ok(await _animalsRepository.GetAnimals(orderBy));
        }

        [HttpPost]
        public async Task<IActionResult> PostAnimal([FromBody] AnimalPostDto animalPostDto)
        {
            if (await _animalsRepository.DoesAnimalExists(animalPostDto.ID))
            {
                return Conflict();
            }

            return Created("animals", await _animalsRepository.PostAnimal(animalPostDto));
        }
    }
}

