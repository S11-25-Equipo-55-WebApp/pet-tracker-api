using Microsoft.AspNetCore.Mvc;
using petTrackerApi.DTO;
using petTrackerApi.Services.GenericServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace petTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoAlimentoController : ControllerBase
    {
        private IGenericService<TipoAlimentoDTO> _service;
        public TipoAlimentoController(IGenericService<TipoAlimentoDTO> services)
        {
            _service = services;
        }
        // GET: api/<TipoVacunaController>
        [HttpGet]
        public async Task<IEnumerable<TipoAlimentoDTO>> Get()
        {
            return await _service.Get();
        }

        // GET api/<TipoVacunaController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoAlimentoDTO>> GetById(int id)
        {
            var result = await _service.GetById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}
