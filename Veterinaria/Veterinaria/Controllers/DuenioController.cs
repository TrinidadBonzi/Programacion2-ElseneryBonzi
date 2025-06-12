using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Veterinaria.Datos.Dtos;
using Veterinaria.Logica.Duenio;

namespace Veterinaria.Controllers
{
    [Route("api/duenios")]
    [ApiController]
    public class DuenioController : ControllerBase
    {
        private readonly IDuenioLogica _duenioLogica;
        public DuenioController(IDuenioLogica duenioLogica)
        {
            _duenioLogica = duenioLogica;
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            DuenioDto duenioDto = _duenioLogica.ObtenerDuenio(id);

            if (duenioDto == null)
            {
                return NotFound();
            }

            return Ok(duenioDto);
        }
        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            bool eliminado = _duenioLogica.EliminarDuenio(id);
            if (!eliminado)
                return NotFound();

            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> AgregarDuenio([FromBody] DuenioDto nuevoDuenio)
        {
            if (nuevoDuenio == null)
            {
                return BadRequest("El dueño no puede ser nulo.");
            }
            bool agregado = _duenioLogica.AgregarDuenio(nuevoDuenio);
            if (!agregado)
            {
                return BadRequest("Error al agregar el dueño.");
            }
            return CreatedAtAction(nameof(ObtenerPorId), new { id = nuevoDuenio.idDuenio }, nuevoDuenio);
        }
        [HttpPut("{id}")]
        public IActionResult ActualizarDuenio(int id, [FromBody] DuenioDto duenioDto)
        {
            if (duenioDto == null)
            {
                return BadRequest("El dueño no puede ser nulo.");
            }
            var duenioExistente = _duenioLogica.ObtenerDuenio(id);
            if (duenioExistente == null)
            {
                return NotFound();
            }
            bool actualizado = _duenioLogica.ActualizarDuenio(id, duenioDto);
            if (!actualizado)
            {
                return BadRequest("Error al actualizar el dueño.");
            }
            return NoContent();
        }
    }
}
