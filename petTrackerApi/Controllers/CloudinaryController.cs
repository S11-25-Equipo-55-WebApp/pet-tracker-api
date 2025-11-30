using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using petTrackerApi.Model;
using petTrackerApi.Services.IServices;

namespace petTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CloudinaryController : ControllerBase
    {
        private readonly ICloudinaryService _service;

        public CloudinaryController(ICloudinaryService service)
        {
            _service = service;
        }

        [HttpPost("image")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UploadImage([FromForm] UploadImageRequest request)
        {
            if (request == null)
                return BadRequest("Request inválido.");

            var response = await _service.UploadImageAsync(request.File);

            if (!response.Success)
                return StatusCode(500, response.Error);

            return Ok(new
            {
                Url = response.Url,
                PublicId = response.PublicId
            });
        }
    }
}
