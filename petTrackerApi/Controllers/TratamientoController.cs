using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using petTrackerApi.DTO;
using petTrackerApi.Services.GenericServices;

namespace petTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TratamientoController : ControllerBase
    {
        private readonly IGenericService<TratamientoDTO> _service;
        public TratamientoController(IGenericService<TratamientoDTO> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<TratamientoDTO>> Get() => await _service.Get();

        [HttpGet("{id}")]
        public async Task<ActionResult<TratamientoDTO>>GetById(int id)
        {
            var solicitud = await _service.GetById(id);
            if(solicitud == null)return NotFound();
            return Ok(solicitud);
        }

        [HttpPost]
        public async Task<ActionResult<TratamientoDTO>> Add(TratamientoDTO tratamiento)
        {
            var respuesta = await _service.Create(tratamiento);
            if(respuesta == null) return NotFound();
            return CreatedAtAction(nameof(GetById), new { id = respuesta.TratamientoId }, respuesta);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TratamientoDTO>>Update(int id, TratamientoDTO tratamiento)
        {
            var consulta = await _service.Update(id, tratamiento);
            if(consulta == null) return NotFound();
            return Ok(consulta);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TratamientoDTO>> Delete(int id)
        {
            var respuesta = await _service.Delete(id);
            if (respuesta == null) return NotFound();
            return Ok(respuesta);
        }
    }
}
