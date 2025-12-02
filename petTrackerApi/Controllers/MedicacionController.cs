using Microsoft.AspNetCore.Mvc;
using petTrackerApi.DTO;
using petTrackerApi.Services.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace petTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicacionController : ControllerBase
    {
        private readonly IMedicacionService _service;
        public MedicacionController(IMedicacionService services)
        {
            _service = services;
        }
        // GET: api/<MedicacionController>
        [HttpGet]
        public async Task<IEnumerable<MedicacionDTO>> Get()
        {
            return await _service.Get();
        }

        // GET api/<MedicacionController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MedicacionDTO>> GetById(int id)
        {
            var result = await _service.GetById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // POST api/<MedicacionController>
        [HttpPost]
        public async Task<IActionResult> CrearMedicacion([FromBody] MedicacionDTO dtoMedicacion)
        {
            try
            {
                var medicacionCreada = await _service.Create(dtoMedicacion);
                return CreatedAtAction(nameof(GetById), new { id = medicacionCreada.MedicacionId }, medicacionCreada);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<MedicacionController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<MedicacionDTO>> Update(int id, [FromBody] MedicacionDTO dtoMedicacion)
        {
            var actualizado = await _service.Update(id, dtoMedicacion);
            if (actualizado == null) return NotFound();

            return Ok(actualizado);
        }

        // DELETE api/<MedicacionController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var respuesta = await _service.Delete(id);
            if (respuesta == null) return NotFound();
            return Ok(respuesta);
        }

        [HttpGet("obtener-medicaciones-por-mascota")]
        public async Task<IEnumerable<MedicacionDTO>> GetMedicacionesByIdMascota(int id)
        {
            return await _service.GetMedicacionByIdMascota(id);
        }

        [HttpGet("obtener-medicaciones-por-consulta")]
        public async Task<IEnumerable<MedicacionDTO>> GetMedicacionesByIdConsulta(int id)
        {
            return await _service.GetMedicacionByIdConsulta(id);
        }
    }
}
