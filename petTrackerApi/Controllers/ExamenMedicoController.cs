using Microsoft.AspNetCore.Mvc;
using petTrackerApi.DTO;
using petTrackerApi.Services.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace petTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamenMedicoController : ControllerBase
    {
        private readonly IExamenMedicoService _service;
        public ExamenMedicoController(IExamenMedicoService services)
        {
            _service = services;
        }
        // GET: api/<ExamenMedicoController>
        [HttpGet]
        public async Task<IEnumerable<ExamenMedicoDTO>> Get()
        {
            return await _service.Get();
        }

        // GET api/<ExamenMedicoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExamenMedicoDTO>> GetById(int id)
        {
            var result = await _service.GetById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // POST api/<ExamenMedicoController>
        [HttpPost]
        public async Task<IActionResult> CrearExamenMedico([FromBody] ExamenMedicoDTO dtoExamen)
        {
            try
            {
                var examenCreada = await _service.Create(dtoExamen);
                return CreatedAtAction(nameof(GetById), new { id = examenCreada.ExamenId }, examenCreada);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ExamenMedicoController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ExamenMedicoDTO>> Update(int id, [FromBody] ExamenMedicoDTO dtoExamen)
        {
            var actualizado = await _service.Update(id, dtoExamen);
            if (actualizado == null) return NotFound();

            return Ok(actualizado);
        }

        // DELETE api/<ExamenMedicoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var respuesta = await _service.Delete(id);
            if (respuesta == null) return NotFound();
            return Ok(respuesta);
        }

        [HttpGet("obtener-examenes-por-consulta")]
        public async Task<IEnumerable<ExamenMedicoDTO>> GetExamenesByConsultaId(int id)
        {
            return await _service.GetExamenMedicoByConsultaId(id);
        }
    }
}
