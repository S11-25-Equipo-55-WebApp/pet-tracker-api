using Microsoft.AspNetCore.Mvc;
using petTrackerApi.DTO;
using petTrackerApi.Services;
using petTrackerApi.Services.GenericServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace petTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MascotaController : ControllerBase
    {
        private IGenericService<MascotaDTO> _service;
        public MascotaController(IGenericService<MascotaDTO> services)
        {
            _service = services;
        }

        // GET: api/<MascotaController>
        [HttpGet]
        public async Task<IEnumerable<MascotaDTO>> Get()
        {
            return await _service.Get();
        }

        // GET api/<MascotaController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MascotaDTO>> GetById(int id)
        {
            var result = await _service.GetById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // POST api/<MascotaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MascotaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MascotaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
