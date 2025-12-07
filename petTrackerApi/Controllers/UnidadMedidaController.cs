using Microsoft.AspNetCore.Mvc;
using petTrackerApi.DTO;
using petTrackerApi.Services.GenericServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace petTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadMedidaController : ControllerBase
    {
        private readonly IGenericService<UnidadMedidaDTO> _service;
        public UnidadMedidaController(IGenericService<UnidadMedidaDTO> service)
        {
            _service = service;
        }

        // GET: api/<UnidadMedidaController>
        [HttpGet]
        public async Task<IEnumerable<UnidadMedidaDTO>> Get()
        {
            return await _service.Get();
        }

        // GET api/<UnidadMedidaController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UnidadMedidaDTO>> GetById(int id)
        {
            var result = await _service.GetById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}
