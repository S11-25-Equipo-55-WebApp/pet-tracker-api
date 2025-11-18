using petTrackerApi.Data;
using petTrackerApi.DTO;
using petTrackerApi.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace petTrackerApi.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DBContext _db;

        public UsuarioRepository(DBContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Usuario>> Get()
        {
            return await _db.Usuarios.ToListAsync();
        }

        public async Task<Usuario> GetById(int id)
        {
            return await _db.Usuarios.FindAsync(id);
        }

        public async Task<Usuario> GetByUserName(string username)
        {
            return await _db.Usuarios.FirstOrDefaultAsync(
                u => u.UserName.ToLower() == username.ToLower());
        }

        public bool IsUniqueUsuario(string username)
        {
            return !_db.Usuarios.Any(u => u.UserName.ToLower() == username.ToLower());
        }

        public async Task<Usuario> Registro(Usuario usuario)
        {
            _db.Usuarios.Add(usuario);
            await _db.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> Update(int id, Usuario usuarioActualizado)
        {
            var usuarioDB = await _db.Usuarios.FindAsync(id);
            if (usuarioDB == null) return null;

            usuarioDB.Nombre = usuarioActualizado.Nombre;
            usuarioDB.UserName = usuarioActualizado.UserName;
            usuarioDB.Email = usuarioActualizado.Email;

            if (!string.IsNullOrWhiteSpace(usuarioActualizado.Password))
            {
                usuarioDB.Password = usuarioActualizado.Password;
            }

            await _db.SaveChangesAsync();
            return usuarioDB;
        }

        public async Task<Usuario> Delete(int id)
        {
            var usuarioDB = await _db.Usuarios.FindAsync(id);
            if (usuarioDB == null) return null;

            _db.Usuarios.Remove(usuarioDB);
            await _db.SaveChangesAsync();

            return usuarioDB;
        }

        public async Task<Usuario> GetByIdEntity(int id)
        {
            return await _db.Usuarios.FirstOrDefaultAsync(u => u.UsuarioId == id);
        }

        public async Task UpdatePassword(Usuario usuario)
        {
            _db.Usuarios.Update(usuario);
            await _db.SaveChangesAsync();
        }

        //private readonly DBContext _dbContext;
        //private string _claveSecreta;
        //public UsuarioRepository(DBContext dBContext, IConfiguration configuration) 
        //{
        //    _dbContext = dBContext;
        //    _claveSecreta = configuration.GetValue<string>("ApiSetting:Secreta");
        //}

        //public async Task<IEnumerable<UsuarioDTO>> Get()
        //{
        //    var usuarios = await _dbContext.Usuarios.ToListAsync();
        //    return usuarios.Select(Mapper.UsuarioMapToDTO);
        //}

        //public async Task<UsuarioDTO> GetById(int id)
        //{
        //    var solicitud = await _dbContext.Usuarios.FindAsync(id);
        //    if (solicitud == null) return null;
        //    var respuesta = Mapper.UsuarioMapToDTO(solicitud);
        //    return respuesta;
        //}

        //public bool IsUniqueUsuario(string usuario)
        //{
        //    return !_dbContext.Usuarios.Any(u => u.UserName.ToLower() == usuario.ToLower());
        //}

        //public async Task<UsuarioLoginRespuestaDTO> Login(UsuarioLoginDTO loginDTO)
        //{
        //    var usuario = await _dbContext.Usuarios
        //        .FirstOrDefaultAsync(u => u.UserName.ToLower() == loginDTO.UserName.ToLower());

        //    if (usuario == null)
        //    {
        //        return new UsuarioLoginRespuestaDTO { Token = "", Usuario = null };
        //    }

        //    var hasher = new PasswordHasher<Usuario>();
        //    var resultado = hasher.VerifyHashedPassword(usuario, usuario.Password, loginDTO.Password);

        //    if (resultado == PasswordVerificationResult.Failed)
        //    {
        //        return new UsuarioLoginRespuestaDTO { Token = "", Usuario = null };
        //    }

        //    var manejadorToken = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(_claveSecreta);

        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new[]
        //        {
        //    new Claim(ClaimTypes.NameIdentifier, usuario.UsuarioId.ToString()),
        //    new Claim(ClaimTypes.Name, usuario.UserName),
        //}),
        //        Expires = DateTime.UtcNow.AddDays(1),
        //        SigningCredentials = new SigningCredentials(
        //            new SymmetricSecurityKey(key),
        //            SecurityAlgorithms.HmacSha256Signature)
        //    };

        //    var token = manejadorToken.CreateToken(tokenDescriptor);

        //    return new UsuarioLoginRespuestaDTO
        //    {
        //        Token = manejadorToken.WriteToken(token),
        //        Usuario = new UsuarioDTO
        //        {
        //            UsuarioId = usuario.UsuarioId,
        //            UserName = usuario.UserName,
        //            Nombre = usuario.Nombre,
        //            Email = usuario.Email
        //        }
        //    };
    }

        //public async Task<Usuario> Registro(UsuarioRegistroDTO usuarioRegistroDTO)
        //{
        //    if (_dbContext.Usuarios.Any(u => u.UserName.ToLower() == usuarioRegistroDTO.UserName.ToLower())) 
        //    {
        //        throw new Exception("El nombre de usuario ya está en uso");
        //    }

        //    var usuario = new Usuario()
        //    {
        //        UserName = usuarioRegistroDTO.UserName,
        //        Email = usuarioRegistroDTO.Email,
        //        Nombre = usuarioRegistroDTO.Nombre,
        //        Password = usuarioRegistroDTO.Password,
        //    };

        //    var hasher = new PasswordHasher<Usuario>();
        //    usuario.Password = hasher.HashPassword(usuario, usuarioRegistroDTO.Password);

        //    _dbContext.Usuarios.Add(usuario);
        //    await _dbContext.SaveChangesAsync();
        //    return usuario;
        //}


        //public async Task<Usuario> Update(int id, Usuario usuarioActualizado)
        //{
        //    var usuarioDB = await _dbContext.Usuarios.FirstOrDefaultAsync(u => u.UsuarioId == id);
        //    if (usuarioDB == null) return null;

        //    // VALIDACIÓN DE USERNAME DUPLICADO
        //    if (_dbContext.Usuarios.Any(u =>
        //            u.UserName.ToLower() == usuarioActualizado.UserName.ToLower()
        //            && u.UsuarioId != id))
        //    {
        //        throw new Exception("El nombre de usuario ya está en uso.");
        //    }
        //    //actualizar campos permitidos
        //    usuarioDB.UserName = usuarioActualizado.UserName;
        //    usuarioDB.Nombre = usuarioActualizado.Nombre;
        //    usuarioDB.Email = usuarioActualizado.Email;

        //    //Si el usuario envía un password nuevo, se hashea
        //    if (!string.IsNullOrWhiteSpace(usuarioActualizado.Password))
        //    {
        //        var hasher = new PasswordHasher<Usuario>();
        //        usuarioDB.Password = hasher.HashPassword(usuarioDB, usuarioActualizado.Password);
        //    }
        //    await _dbContext.SaveChangesAsync();
        //    return usuarioDB;
        //}

        //public async Task<Usuario> Delete(int id)
        //{
        //    var usuarioDB = await _dbContext.Usuarios.FirstOrDefaultAsync(u => u.UsuarioId == id);

        //    if (usuarioDB == null)
        //        return null;

        //    _dbContext.Usuarios.Remove(usuarioDB);
        //    await _dbContext.SaveChangesAsync();

        //    return usuarioDB;
        //}

    
}
