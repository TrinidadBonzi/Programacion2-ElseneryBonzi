using Microsoft.AspNetCore.Mvc;
using Veterinaria.Datos.Dtos;
using Veterinaria.Logica.Animal;

namespace Veterinaria.Controllers
{
    [Route("animales")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalLogica _animalLogica;
        public AnimalController(IAnimalLogica animalLogica)
        {
            _animalLogica = animalLogica;
        }
        
        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            AnimalDto animalDto = _animalLogica.ObtenerAnimal(id);

            if (animalDto == null)
            {
                return NotFound();
            }

            return Ok(animalDto);
        }
        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            bool eliminado = _animalLogica.EliminarAnimal(id);
            if (!eliminado)
                return NotFound();

            return NoContent();
        }
        [HttpPost]
        public IActionResult AgregarAnimal([FromBody] AnimalDto nuevoAnimal)
        {
            if (nuevoAnimal == null)
            {
                return BadRequest("El animal no puede ser nulo.");
            }
            bool agregado = _animalLogica.AgregarAnimal(nuevoAnimal);
            if (!agregado)
            {
                return BadRequest("Error al agregar el animal.");
            }
            return CreatedAtAction(nameof(ObtenerPorId), new { id = nuevoAnimal.idAnimal }, nuevoAnimal);
        }
        [HttpPut("{id}")]
        public IActionResult ActualizarAnimal(int id, [FromBody] AnimalDto animalDto)
        {
            if (animalDto == null)
            {
                return BadRequest("El animal no puede ser nulo.");
            }
            var animalExistente = _animalLogica.ObtenerAnimal(id);
            if (animalExistente == null)
            {
                return NotFound();
            }
            animalDto.idAnimal = id;
            bool actualizado = _animalLogica.ActualizarAnimal(id, animalDto);
            if (!actualizado)
            {
                return BadRequest("Error al actualizar el animal.");
            }
            return NoContent();
        }

    }
}
