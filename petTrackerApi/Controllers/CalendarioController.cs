using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using petTrackerApi.DTO;
using petTrackerApi.Services.GenericServices;

namespace petTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarioController : ControllerBase
    {
        private readonly IGenericService<CalendarioDTO> _service;
        public CalendarioController(IGenericService<CalendarioDTO> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<CalendarioDTO>> Get() =>
            await _service.Get();

        [HttpGet("{id}")]
        public async Task<ActionResult<CalendarioDTO>>GetById(int id)
        {
            var solicitud = await _service.GetById(id);
            if(solicitud == null) return NotFound();
            return Ok(solicitud);
        }

        [HttpPost]
        public async Task<ActionResult<CalendarioDTO>> Add(CalendarioDTO calendario)
        {
            var respuesta = await _service.Create(calendario);
            if(respuesta == null) return NotFound();
            return CreatedAtAction(nameof(GetById), new {id = respuesta.CalendarioId}, respuesta); 
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CalendarioDTO>> Update(int id, CalendarioDTO calendario)
        {
            var consulta = await _service.Update(id, calendario);
            if(consulta == null) return NotFound();
            return Ok(consulta);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CalendarioDTO>> Delete(int id)
        {
            var respuesta = await _service.Delete(id);
            if(respuesta == null) return NotFound();
            return Ok(respuesta);
        }
    }
}
