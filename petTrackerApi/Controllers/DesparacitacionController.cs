using Microsoft.AspNetCore.Mvc;
using petTrackerApi.DTO;
using petTrackerApi.Services;
using petTrackerApi.Services.GenericServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace petTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesparacitacionController : ControllerBase
    {
        private IGenericService<DesparacitacionDTO> _service;
        private readonly DesparacitacionService _serviceDesparacitacion;
        public DesparacitacionController(IGenericService<DesparacitacionDTO> services, DesparacitacionService servicioDesparacitacion)
        {
            _service = services;
            _serviceDesparacitacion = servicioDesparacitacion;
        }
            // GET: api/<DesparacitacionController>
            [HttpGet]
        public async Task<IEnumerable<DesparacitacionDTO>> Get()
        {
            return await _service.Get();
        }

        // GET api/<DesparacitacionController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DesparacitacionDTO>> GetById(int id)
        {
            var result = await _service.GetById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // POST api/<DesparacitacionController>
        [HttpPost]
        public async Task<IActionResult> CrearDesparacitacion([FromBody] DesparacitacionDTO dtoDesparacitacion)
        {
            try
            {
                var desparacitacionCreada = await _service.Create(dtoDesparacitacion);
                return CreatedAtAction(nameof(GetById), new { id = desparacitacionCreada.DesparacitacionId }, desparacitacionCreada);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<DesparacitacionController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<MascotaDTO>> Update(int id, [FromBody] DesparacitacionDTO dtoDesparacitacion)
        {
            var actualizado = await _service.Update(id, dtoDesparacitacion);
            if (actualizado == null) return NotFound();

            return Ok(actualizado);
        }

        // DELETE api/<DesparacitacionController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var ok = await _service.Delete(id);
            return NoContent();
        }

        [HttpGet("get-desparacitacion-por-mascota")]
        public async Task<IEnumerable<DesparacitacionDTO>> GetDesparacitacionesByIdMascota(int id)
        {
            return await _serviceDesparacitacion.GetDesparacitacionesByIdMascota(id);
        }

    }
}
