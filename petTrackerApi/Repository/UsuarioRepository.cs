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

        public bool IsUniqueEmail(string mail)
        {
            return !_db.Usuarios.Any(m => m.Email.ToLower() == mail.ToLower());
        }

        public bool IsUniqueNombre(string nombre)
        {
            return !_db.Usuarios.Any(n => n.Nombre.ToLower() == nombre.ToLower());
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

        
    }    
}
