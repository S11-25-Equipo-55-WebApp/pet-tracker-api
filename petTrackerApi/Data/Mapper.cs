using petTrackerApi.DTO;
using petTrackerApi.Model;

namespace petTrackerApi.Data
{
    public static class Mapper
    {
        public static UsuarioDTO UsuarioMapToDTO(Usuario u)
        {
            return new UsuarioDTO
            {
                UsuarioId = u.UsuarioId,
                UserName = u.UserName,
                Email = u.Email,
                Nombre = u.Nombre
            };
        }

        public static Usuario UsuarioDTOMapToEntity(UsuarioDTO dto)
        {
            return new Usuario
            {
                UsuarioId = dto.UsuarioId,
                UserName = dto.UserName,
                Email = dto.Email,
                Nombre = dto.Nombre
            };
        }

        public static Usuario UsuarioRegistroDTOToEntity(UsuarioRegistroDTO dto)
        {
            return new Usuario
            {
                UserName = dto.UserName,
                Email = dto.Email,
                Nombre = dto.Nombre,
                Password = dto.Password
            };
        }
    }

    //public class Mapper
    //{
    //    public static UsuarioDTO UsuarioMapToDTO(Usuario usuario)
    //    {
    //        return new UsuarioDTO
    //        {
    //            UsuarioId = usuario.UsuarioId,
    //            Email = usuario.Email,
    //            Nombre = usuario.Nombre,
    //            UserName = usuario.UserName,
    //        };
    //    }
    //    public static Usuario UsuarioDTOMapToEntity(UsuarioDTO usuario)
    //    {
    //        return new Usuario
    //        {
    //            UsuarioId = usuario.UsuarioId,
    //            Email = usuario.Email,
    //            Nombre = usuario.Nombre,
    //            UserName = usuario.UserName,

    //        };
    //    }
    //}
}
