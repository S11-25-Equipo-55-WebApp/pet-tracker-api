using Microsoft.AspNetCore.Mvc;
using petTrackerApi.DTO;
using petTrackerApi.Services;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace petTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecieController : ControllerBase
    {
        private readonly IEspecieService _service;

        public EspecieController(IEspecieService service)
        {
            _service = service;
        }

        // GET: api/<EspecieController>
        [HttpGet]
        public async Task<IEnumerable<EspecieDTO>> Get()
        {
            return await _service.Get();
        }

        // GET api/<EspecieController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EspecieDTO>> GetById(int id)
        {
            var result = await _service.GetById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}
