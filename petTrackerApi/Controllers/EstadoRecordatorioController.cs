using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc;
using petTrackerApi.DTO;
using petTrackerApi.Services.GenericServices;

namespace petTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoRecordatorioController : ControllerBase
    {
        private readonly IGenericService<EstadoRecordatorioDTO> _service;
        public EstadoRecordatorioController(IGenericService<EstadoRecordatorioDTO> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<EstadoRecordatorioDTO>> Get() => await _service.Get();

        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoRecordatorioDTO>>GetById(int id)
        {
            var solicitud = await _service.GetById(id);
            if (solicitud == null) return NotFound();
            return Ok(solicitud);
        }

        [HttpPost]
        public async Task<ActionResult<EstadoRecordatorioDTO>> Add(EstadoRecordatorioDTO estado)
        {
            var respuesta = await _service.Create(estado);
            if(respuesta == null) return NotFound();
            return CreatedAtAction(nameof(GetById), new {id = respuesta.EstadoId}, respuesta);
        }

        [HttpPut]
        public async Task<ActionResult<EstadoRecordatorioDTO>> Update(int id, EstadoRecordatorioDTO estado)
        {
            var consulta = await _service.Update(id, estado);
            if(consulta == null) return NotFound();
            return Ok(consulta);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EstadoRecordatorioDTO>> Delete(int id)
        {
            var respuesta = await _service.Delete(id);
            if(respuesta == null) return NotFound();
            return Ok(respuesta);
        }
    }
}
