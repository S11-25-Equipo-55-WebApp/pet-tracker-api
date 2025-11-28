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
                UserName = u.Username,
                Email = u.Email,
                Nombre = u.Nombre
            };
        }

        public static Usuario UsuarioDTOMapToEntity(UsuarioDTO dto)
        {
            return new Usuario
            {
                UsuarioId = dto.UsuarioId,
                Username = dto.UserName,
                Email = dto.Email,
                Nombre = dto.Nombre
            };
        }

        public static Usuario UsuarioRegistroDTOToEntity(UsuarioRegistroDTO dto)
        {
            return new Usuario
            {
                Username = dto.UserName,
                Email = dto.Email,
                Nombre = dto.Nombre,
                Password = dto.Password
            };
        }

        public static EspecieDTO EspecieMapToDTO(Especie especie)
        {
            return new EspecieDTO
            {
                EspecieId = especie.EspecieId,
                Codigo = especie.Codigo,
                Nombre = especie.Nombre
            };
        }

        public static Especie EspecieDTOMapToEntity(EspecieDTO dtoEspecie)
        {
            return new Especie
            {
                EspecieId = dtoEspecie.EspecieId,
                Codigo = dtoEspecie.Codigo,
                Nombre = dtoEspecie.Nombre
            };
        }
        public static RazaDTO RazaMapToDTO(Raza raza)
        {
            return new RazaDTO
            {
                RazaId = raza.RazaId,
                Codigo = raza.Codigo,
                Nombre = raza.Nombre
            };
        }

        public static Raza RazaDTOMapToEntity(RazaDTO dtoRaza)
        {
            return new Raza
            {
                RazaId = dtoRaza.RazaId,
                Codigo = dtoRaza.Codigo,
                Nombre = dtoRaza.Nombre
            };
        }
        public static MascotaDTO MascotaMapToDTO(Mascota mascota)
        {
            return new MascotaDTO
            {
                MascotaId = mascota.MascotaId,
                Nombre = mascota.Nombre,
                Codigo = mascota.Codigo,
                FechaNacimiento = mascota.FechaNacimiento,
                EspecieId = mascota.EspecieId,
                RazaId = mascota.RazaId,
                FotoMascota = mascota.FotoMascota,
                UsuarioId = mascota.UsuarioId,
                CreadoAt = mascota.CreadoAt,
                EditadoAt = mascota.EditadoAt,
            };
        }

        public static Mascota MascotaDTOMapToEntity(MascotaDTO dtoMascota)
        {
            return new Mascota
            {
                MascotaId = dtoMascota.MascotaId,
                Nombre = dtoMascota.Nombre,
                Codigo = dtoMascota.Codigo,
                FechaNacimiento = dtoMascota.FechaNacimiento,
                EspecieId = dtoMascota.EspecieId,
                RazaId = dtoMascota.RazaId,
                FotoMascota = dtoMascota.FotoMascota,
                UsuarioId = dtoMascota.UsuarioId,
                CreadoAt = dtoMascota.CreadoAt,
                EditadoAt = dtoMascota.EditadoAt
            };
        }
        public static DesparacitacionDTO DesparacitacionMapToDTO(Desparacitacion desparacitacion)
        {
            return new DesparacitacionDTO
            {
                DesparacitacionId = desparacitacion.DesparacitacionId,
                Codigo = desparacitacion.Codigo,
                FechaAplicacion = desparacitacion.FechaAplicacion,
                FechaProxima = desparacitacion.FechaProxima,
                Notas = desparacitacion.Notas,
                MascotaId = desparacitacion.MascotaId,
                TipoDesparacitacionId = desparacitacion.TipoDesparacitacionId,
                CreadoAt = desparacitacion.CreadoAt,
                EditadoAt = desparacitacion.EditadoAt
            };
        }

        public static Desparacitacion DesparacitacionDTOMapToEntity(DesparacitacionDTO dtoDesparacitacion)
        {
            return new Desparacitacion
            {
                DesparacitacionId = dtoDesparacitacion.DesparacitacionId,
                Codigo = dtoDesparacitacion.Codigo,
                FechaAplicacion = dtoDesparacitacion.FechaAplicacion,
                FechaProxima = dtoDesparacitacion.FechaProxima,
                Notas = dtoDesparacitacion.Notas,
                MascotaId = dtoDesparacitacion.MascotaId,
                TipoDesparacitacionId = dtoDesparacitacion.TipoDesparacitacionId,
                CreadoAt = dtoDesparacitacion.CreadoAt,
                EditadoAt = dtoDesparacitacion.EditadoAt
            };
        }
    }
}
