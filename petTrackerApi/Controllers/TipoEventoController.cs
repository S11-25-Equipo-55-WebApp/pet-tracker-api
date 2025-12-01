using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using petTrackerApi.DTO;
using petTrackerApi.Model;
using petTrackerApi.Services.GenericServices;

namespace petTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoEventoController : ControllerBase
    {
        private readonly IGenericService<TipoEventoDTO> _services;
        public TipoEventoController(IGenericService<TipoEventoDTO> services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IEnumerable<TipoEventoDTO>> Get() =>
         await _services.Get();

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoEventoDTO>> GetById(int id)
        {
            var solicitud = await _services.GetById(id);
            if (solicitud == null) return NotFound();
            return Ok(solicitud);
        }

        [HttpPost]
        public async Task<ActionResult<TipoEventoDTO>> Add(TipoEventoDTO tipoEvento)
        {
            var respuesta = await _services.Create(tipoEvento);
            if(respuesta == null) return NotFound();
            return CreatedAtAction(nameof(GetById), new { id = respuesta.TipoEventoId }, respuesta);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<TipoEventoDTO>> Update(int id, TipoEventoDTO book)
        {
            var consulta = await _services.Update(id, book);
            if (consulta == null) return NotFound();
            return Ok(consulta);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoEventoDTO>> Delete(int id)
        {
            var respuesta = await _services.Delete(id);
            if (respuesta == null) return NotFound();
            return Ok(respuesta);
        }
    }
}
