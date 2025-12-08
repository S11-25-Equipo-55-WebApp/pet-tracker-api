using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using petTrackerApi.DTO;
using petTrackerApi.Services;
using petTrackerApi.Services.IServices;

namespace petTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IMessage _service;

        public EmailController(IMessage service)
        {
            _service = service;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendEmail(SendEmailRequestDTO request)
        {
            _service.SendEmail(request.Subject, request.Body, request.To);
            return Ok();
        }
    }
}
