using Microsoft.AspNetCore.Mvc;
using petTrackerApi.DTO;
using petTrackerApi.Services.GenericServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace petTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoMedicamentoController : ControllerBase
    {
        private readonly IGenericService<TipoMedicamentoDTO> _service;
        public TipoMedicamentoController(IGenericService<TipoMedicamentoDTO> service)
        {
            _service = service;
        }

        // GET: api/<TipoMedicamentoController>
        [HttpGet]
        public async Task<IEnumerable<TipoMedicamentoDTO>> Get()
        {
            return await _service.Get();
        }

        // GET api/<TipoMedicamentoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoMedicamentoDTO>> GetById(int id)
        {
            var result = await _service.GetById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // POST api/<TipoMedicamentoController>
        [HttpPost]
        public async Task<IActionResult> CrearTipoMedicamento([FromBody] TipoMedicamentoDTO dtoTipo)
        {
            try
            {
                var tipoCreado = await _service.Create(dtoTipo);
                return CreatedAtAction(nameof(GetById), new { id = tipoCreado.TipoMedId }, tipoCreado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<TipoMedicamentoController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<TipoMedicamentoDTO>> Update(int id, [FromBody] TipoMedicamentoDTO dtoTipo)
        {
            var actualizado = await _service.Update(id, dtoTipo);
            if (actualizado == null) return NotFound();

            return Ok(actualizado);
        }

        // DELETE api/<TipoMedicamentoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var respuesta = await _service.Delete(id);
            if (respuesta == null) return NotFound();
            return Ok(respuesta);
        }
    }
}
