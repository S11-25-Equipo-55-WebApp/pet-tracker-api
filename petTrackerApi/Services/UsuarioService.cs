using petTrackerApi.Data;
using petTrackerApi.DTO;
using petTrackerApi.Model;
using petTrackerApi.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace petTrackerApi.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repo;
        private readonly IConfiguration _config;

        public UsuarioService(IUsuarioRepository repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }

        public bool IsUniqueUsuario(string username)
        {
            return _repo.IsUniqueUsuario(username);
        }

        public async Task<IEnumerable<UsuarioDTO>> Get()
        {
            var lista = await _repo.Get();
            return lista.Select(Mapper.UsuarioMapToDTO);
        }

        public async Task<UsuarioDTO> GetById(int id)
        {
            var usuario = await _repo.GetById(id);
            return usuario == null ? null : Mapper.UsuarioMapToDTO(usuario);
        }

        public async Task<(bool Exito, string Error, UsuarioDTO dto)> Registro(UsuarioRegistroDTO dto)
        {
            // 1️⃣ Validación de nombre único
            if (!_repo.IsUniqueUsuario(dto.UserName))
                return (false, "Nombre de usuario ya existe.", null);

            // 2️⃣ Mapeo DTO → Entity
            var entity = Mapper.UsuarioRegistroDTOToEntity(dto);

            // 3️⃣ Hash del password en el entity correcto
            var hasher = new PasswordHasher<Usuario>();
            entity.Password = hasher.HashPassword(entity, dto.Password);

            // 4️⃣ Guardamos EL ENTITY QUE TIENE EL HASH
            var creado = await _repo.Registro(entity);

            // 5️⃣ Devolvemos DTO de salida
            var usuarioDTO = Mapper.UsuarioMapToDTO(creado);

            return (true, null, usuarioDTO);
        }

        public async Task<UsuarioDTO> Update(int id, UsuarioDTO dto)
        {
            var entity = Mapper.UsuarioDTOMapToEntity(dto);

            var actualizado = await _repo.Update(id, entity);
            return actualizado == null ? null : Mapper.UsuarioMapToDTO(actualizado);
        }

        public async Task<bool> Delete(int id)
        {
            var eliminado = await _repo.Delete(id);
            return eliminado != null;
        }

        public async Task<UsuarioLoginRespuestaDTO> Login(UsuarioLoginDTO dto)
        {
            var usuario = await _repo.GetByUserName(dto.UserName);
            if (usuario == null)
                return new UsuarioLoginRespuestaDTO { Token = "", Usuario = null };

            var hasher = new PasswordHasher<Usuario>();
            var resultado = hasher.VerifyHashedPassword(usuario, usuario.Password, dto.Password);

            if (resultado == PasswordVerificationResult.Failed)
                return new UsuarioLoginRespuestaDTO { Token = "", Usuario = null };

            // JWT
            var manejadorToken = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["ApiSetting:Secreta"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.NameIdentifier, usuario.UsuarioId.ToString()),
                new Claim(ClaimTypes.Name, usuario.UserName)
            }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = manejadorToken.CreateToken(tokenDescriptor);

            return new UsuarioLoginRespuestaDTO
            {
                Token = manejadorToken.WriteToken(token),
                Usuario = Mapper.UsuarioMapToDTO(usuario)
            };
        }

        public async Task<(bool Exito, string Error)> CambiarPassword(int usuarioId, string passwordActual, string passwordNuevo)
        {
            var usuario = await _repo.GetByIdEntity(usuarioId);
            if (usuario == null)
                return (false, "Usuario no encontrado.");

            var hasher = new PasswordHasher<Usuario>();

            // Verificar password actual
            var resultado = hasher.VerifyHashedPassword(usuario, usuario.Password, passwordActual);
            if (resultado == PasswordVerificationResult.Failed)
                return (false, "La contraseña actual es incorrecta.");

            // Actualizar nueva contraseña hasheada
            usuario.Password = hasher.HashPassword(usuario, passwordNuevo);

            await _repo.UpdatePassword(usuario);

            return (true, null);
        }

    }

}
