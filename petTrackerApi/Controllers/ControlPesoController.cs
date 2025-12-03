using Microsoft.AspNetCore.Mvc;
using petTrackerApi.DTO;
using petTrackerApi.Services.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace petTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControlPesoController : ControllerBase
    {
        private readonly IControlPesoService _service;
        public ControlPesoController(IControlPesoService services)
        {
            _service = services;
        }
        // GET: api/<ControlPesoController>
        [HttpGet]
        public async Task<IEnumerable<ControlPesoDTO>> Get()
        {
            return await _service.Get();
        }

        // GET api/<ControlPesoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ControlPesoDTO>> GetById(int id)
        {
            var result = await _service.GetById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // POST api/<ControlPesoController>
        [HttpPost]
        public async Task<IActionResult> CrearControlPeso([FromBody] ControlPesoDTO dtoControl)
        {
            try
            {
                var controlCreado = await _service.Create(dtoControl);
                return CreatedAtAction(nameof(GetById), new { id = controlCreado.ControlPesoId }, controlCreado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ControlPesoController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ControlPesoDTO>> Update(int id, [FromBody] ControlPesoDTO dtoControl)
        {
            var actualizado = await _service.Update(id, dtoControl);
            if (actualizado == null) return NotFound();

            return Ok(actualizado);
        }

        // DELETE api/<ControlPesoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var respuesta = await _service.Delete(id);
            if (respuesta == null) return NotFound();
            return Ok(respuesta);
        }

        [HttpGet("obtener-control-peso-por-mascota")]
        public async Task<IEnumerable<ControlPesoDTO>> GetControlPesoByIdMascota(int id)
        {
            return await _service.GetControlPesoByIdMascota(id);
        }
    }
}
