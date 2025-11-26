using Microsoft.AspNetCore.Mvc;
using petTrackerApi.DTO;
using petTrackerApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace petTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RazaController : ControllerBase
    {
        private readonly IRazaService _service;

        public RazaController(IRazaService service)
        {
            _service = service;
        }
        // GET: api/<RazaController>
        [HttpGet]
        public async Task<IEnumerable<RazaDTO>> Get()
        {
            return await _service.Get();
        }

        // GET api/<RazaController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RazaDTO>> Get(int id)
        {
            var result = await _service.GetById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}
