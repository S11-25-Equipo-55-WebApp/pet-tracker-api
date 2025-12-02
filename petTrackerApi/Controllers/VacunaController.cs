using Microsoft.AspNetCore.Mvc;
using petTrackerApi.DTO;
using petTrackerApi.Services.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace petTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacunaController : ControllerBase
    {
        private readonly IVacunaService _service;
        public VacunaController(IVacunaService services)
        {
            _service = services;
        }
        // GET: api/<VacunaController>
        [HttpGet]
        public async Task<IEnumerable<VacunaDTO>> Get()
        {
            return await _service.Get();
        }

        // GET api/<VacunaController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VacunaDTO>> GetById(int id)
        {
            var result = await _service.GetById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // POST api/<VacunaController>
        [HttpPost]
        public async Task<IActionResult> CrearVacuna([FromBody] VacunaDTO dtoVacuna)
        {
            try
            {
                var vacunaCreada = await _service.Create(dtoVacuna);
                return CreatedAtAction(nameof(GetById), new { id = vacunaCreada.VacunaId}, vacunaCreada);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<VacunaController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<VacunaDTO>> Update(int id, [FromBody] VacunaDTO dtoVacuna)
        {
            var actualizado = await _service.Update(id, dtoVacuna);
            if (actualizado == null) return NotFound();

            return Ok(actualizado);
        }

        // DELETE api/<VacunaController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var respuesta = await _service.Delete(id);
            if (respuesta == null) return NotFound();
            return Ok(respuesta);
        }

        [HttpGet("obtener-vacunas-por-mascota")]
        public async Task<IEnumerable<VacunaDTO>> GetVacunasByMascota(int id)
        {
            return await _service.GetVacunasByIdMascota(id);
        }
    }
}
