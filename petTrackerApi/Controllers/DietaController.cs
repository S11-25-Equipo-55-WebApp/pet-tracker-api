using Microsoft.AspNetCore.Mvc;
using petTrackerApi.DTO;
using petTrackerApi.Services.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace petTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DietaController : ControllerBase
    {
        private readonly IDietaService _service;
        public DietaController(IDietaService services)
        {
            _service = services;
        }

        // GET: api/<DietaController>
        [HttpGet]
        public async Task<IEnumerable<DietaDTO>> Get()
        {
            return await _service.Get();
        }

        // GET api/<DietaController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DietaDTO>> GetById(int id)
        {
            var result = await _service.GetById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // POST api/<DietaController>
        [HttpPost]
        public async Task<IActionResult> CrearDieta([FromBody] DietaDTO dtoDieta)
        {
            try
            {
                var dietaCreada = await _service.Create(dtoDieta);
                return CreatedAtAction(nameof(GetById), new { id = dietaCreada.DietaId }, dietaCreada);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<DietaController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<DietaDTO>> Update(int id, [FromBody] DietaDTO dtoDieta)
        {
            var actualizado = await _service.Update(id, dtoDieta);
            if (actualizado == null) return NotFound();

            return Ok(actualizado);
        }

        // DELETE api/<DietaController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var respuesta = await _service.Delete(id);
            if (respuesta == null) return NotFound();
            return Ok(respuesta);
        }

        [HttpGet("obtener-dietas-por-mascota")]
        public async Task<IEnumerable<DietaDTO>> GetDietasByIdMascota(int id)
        {
            return await _service.GetDietasByIdMascota(id);
        }
    }
}
