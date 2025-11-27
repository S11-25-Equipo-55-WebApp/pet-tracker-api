using Microsoft.AspNetCore.Mvc;
using petTrackerApi.DTO;
using petTrackerApi.Services;
using petTrackerApi.Services.GenericServices;
using System.Threading.Tasks;

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
        public async Task<IActionResult> CrearMascota([FromBody] MascotaDTO dtoMascota)
        {
            try
            {
                var mascotaCreada = await _service.Create(dtoMascota);
                return CreatedAtAction(nameof(GetById), new { id = mascotaCreada.MascotaId }, mascotaCreada);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<MascotaController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<MascotaDTO>> Update(int id, [FromBody] MascotaDTO dtoMascota)
        {
            var actualizado = await _service.Update(id, dtoMascota);
            if (actualizado == null) return NotFound();

            return Ok(actualizado);
        }

        // DELETE api/<MascotaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
