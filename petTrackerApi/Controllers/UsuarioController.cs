using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using petTrackerApi.Data;
using petTrackerApi.DTO;
using petTrackerApi.Repository;
using petTrackerApi.Services.IServices;

namespace petTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<UsuarioDTO>> Get()
        {
            return await _service.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDTO>> GetById(int id)
        {
            var result = await _service.GetById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CrearUsuario([FromBody] UsuarioRegistroDTO dto)
        {
            try
            {
               var resultado = await _service.Registro(dto);
               if(!resultado.Exito) return BadRequest(resultado.Error);

                var usuarioCreado = resultado.dto;
                return CreatedAtAction(nameof(GetById), new { id = usuarioCreado.UsuarioId }, usuarioCreado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioDTO>> Update(int id, [FromBody] UsuarioDTO dto)
        {
            var actualizado = await _service.Update(id, dto);
            if (actualizado == null) return NotFound();

            return Ok(actualizado);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var ok = await _service.Delete(id);
            if (!ok) return NotFound();
            return NoContent();
        }


        [HttpPost("login")]
        public async Task<ActionResult<UsuarioLoginRespuestaDTO>> Login([FromBody] UsuarioLoginDTO dto)
        {
            //return await _service.Login(dto);
            var resultado = await _service.Login(dto);

            if (resultado.Usuario == null || string.IsNullOrEmpty(resultado.Token))
            {
                return Unauthorized("Credenciales inválidas.");
            }

            return Ok(resultado);
        }

        [Authorize]
        [HttpPost("{id}/CambiarPassword")]
        public async Task<IActionResult> CambiarPassword(int id, [FromBody] CambioPasswordDTO dto)
        {
            var resultado = await _service.CambiarPassword(id, dto.PasswordActual, dto.PasswordNuevo);

            if (!resultado.Exito)
                return BadRequest(resultado.Error);

            return Ok("Contraseña actualizada correctamente.");
        }



        // ==========================================================
        //      🔹 1. Solicitar recuperación de contraseña
        // ==========================================================
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Email))
                return BadRequest("El email es obligatorio.");

            var result = await _service.ForgotPassword(dto.Email);

            if (!result.Exito)
                return BadRequest(result.Error);

            return Ok("Si el correo está registrado, se enviaron instrucciones de recuperación.");
        }


        // ==========================================================
        //      🔹 2. Cambiar contraseña usando token
        // ==========================================================
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Token))
                return BadRequest("El token es obligatorio.");

            if (string.IsNullOrWhiteSpace(dto.NewPassword))
                return BadRequest("La nueva contraseña es obligatoria.");

            var result = await _service.ResetPassword(dto.Token, dto.NewPassword);

            if (!result.Exito)
                return BadRequest(result.Error);

            return Ok("La contraseña fue restablecida correctamente.");
        }

        [HttpGet("check-time")]
        public IActionResult CheckServerTime()
        {
            return Ok(new
            {
                ServerLocal = DateTime.Now,
                ServerUtc = DateTime.UtcNow,
                UnixTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
            });
        }
    }

}
