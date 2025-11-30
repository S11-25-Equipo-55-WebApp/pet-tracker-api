using Microsoft.AspNetCore.Mvc;
using petTrackerApi.DTO;
using petTrackerApi.Services;
using petTrackerApi.Services.GenericServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace petTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDesparacitacionController : ControllerBase
    {
        private IGenericService<TipoDesparacitacionDTO> _service;
        public TipoDesparacitacionController(IGenericService<TipoDesparacitacionDTO> services)
        {
            _service = services;
        }
        // GET: api/<TipoDesparacitacionController>
        [HttpGet]
        public async Task<IEnumerable<TipoDesparacitacionDTO>> Get()
        {
            return await _service.Get();
        }

        // GET api/<TipoDesparacitacionController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoDesparacitacionDTO>> GetById(int id)
        {
            var result = await _service.GetById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}
