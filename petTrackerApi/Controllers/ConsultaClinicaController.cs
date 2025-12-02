using Microsoft.AspNetCore.Mvc;
using petTrackerApi.DTO;
using petTrackerApi.Services.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace petTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaClinicaController : ControllerBase
    {
        private readonly IConsultaClinicaService _service;
        public ConsultaClinicaController(IConsultaClinicaService services)
        {
            _service = services;
        }

        // GET: api/<ConsultaClinicaController>
        [HttpGet]
        public async Task<IEnumerable<ConsultaClinicaDTO>> Get()
        {
            return await _service.Get();
        }

        // GET api/<ConsultaClinicaController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConsultaClinicaDTO>> GetById(int id)
        {
            var result = await _service.GetById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // POST api/<ConsultaClinicaController>
        [HttpPost]
        public async Task<IActionResult> CrearConsultaClinica([FromBody] ConsultaClinicaDTO dtoConsulta)
        {
            try
            {
                var consultaCreada = await _service.Create(dtoConsulta);
                return CreatedAtAction(nameof(GetById), new { id = consultaCreada.ConsultaClinicaId}, consultaCreada);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ConsultaClinicaController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ConsultaClinicaDTO>> Update(int id, [FromBody] ConsultaClinicaDTO dtoConsulta)
        {
            var actualizado = await _service.Update(id, dtoConsulta);
            if (actualizado == null) return NotFound();

            return Ok(actualizado);
        }

        // DELETE api/<ConsultaClinicaController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var respuesta = await _service.Delete(id);
            if (respuesta == null) return NotFound();
            return Ok(respuesta);
        }

        [HttpGet("obtener-consultas-clinicas-por-mascota")]
        public async Task<IEnumerable<ConsultaClinicaDTO>> GetConsultasClinicasByIdMascota(int id)
        {
            return await _service.GetConsultasByIdMascota(id);
        }
    }
}
