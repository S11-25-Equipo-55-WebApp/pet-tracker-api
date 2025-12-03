using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using petTrackerApi.DTO;
using petTrackerApi.Services.GenericServices;

namespace petTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoExamenController : ControllerBase
    {
        private readonly IGenericService<TipoExamenDTO> _service;
        public TipoExamenController(IGenericService<TipoExamenDTO> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<TipoExamenDTO>> Get() =>
            await _service.Get();

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoExamenDTO>> GetById(int id)
        {
            var solicitud = await _service.GetById(id);
            if (solicitud == null) return NotFound();
            return Ok(solicitud);
        }


        [HttpPost]
        public async Task<ActionResult<TipoExamenDTO>> Add(TipoExamenDTO dto)
        {
            var respuesta = await _service.Create(dto);
            if (respuesta == null) return NotFound();
            return CreatedAtAction(nameof(GetById), new { id = respuesta.TipoExamenId }, respuesta);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TipoExamenDTO>> Update(int id, TipoExamenDTO dto)
        {
            var consulta = await _service.Update(id, dto);
            if (consulta == null) return NotFound();
            return Ok(consulta);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoExamenDTO>> Delete(int id)
        {
            var respuesta = await _service.Delete(id);
            if (respuesta == null) return NotFound();
            return Ok(respuesta);
        }
    }
}
