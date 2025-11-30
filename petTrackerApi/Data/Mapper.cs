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
                Nombre = u.Nombre,
                Apellido = u.Apellido,
                Telefono = u.Telefono
            };
        }

        public static Usuario UsuarioDTOMapToEntity(UsuarioDTO dto)
        {
            return new Usuario
            {
                UsuarioId = dto.UsuarioId,
                Username = dto.UserName,
                Email = dto.Email,
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Telefono = dto.Telefono
            };
        }

        public static Usuario UsuarioRegistroDTOToEntity(UsuarioRegistroDTO dto)
        {
            return new Usuario
            {
                Username = dto.UserName,
                Email = dto.Email,
                Nombre = dto.Nombre,
                Password = dto.Password,
                Apellido = dto.Apellido,
                Telefono = dto.Telefono
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
                UsuarioId = mascota.UsuarioId
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
                UsuarioId = dtoMascota.UsuarioId
            };
        }
        public static Mascota MascotaRegistroDTOMapToEntity(MascotaDTO dtoMascota)
        {
            return new Mascota
            {
                MascotaId = dtoMascota.MascotaId,
                Nombre = dtoMascota.Nombre,
                FechaNacimiento = dtoMascota.FechaNacimiento,
                EspecieId = dtoMascota.EspecieId,
                RazaId = dtoMascota.RazaId,
                FotoMascota = dtoMascota.FotoMascota,
                UsuarioId = dtoMascota.UsuarioId
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
        public static TipoDesparacitacionDTO TipoDesparacitacionMapToDTO(TipoDesparacitacion tipoDesparacitacion)
        {
            return new TipoDesparacitacionDTO
            {
                TipoDesparacitacionId = tipoDesparacitacion.TipoDesparacitacionId,
                Nombre = tipoDesparacitacion.Nombre,
                Codigo = tipoDesparacitacion.Codigo
            };
        }

        public static TipoDesparacitacion TipoDesparacitacionDTOMapToEntity(TipoDesparacitacionDTO dtoTipoDesparacitacion)
        {
            return new TipoDesparacitacion
            {
                TipoDesparacitacionId = dtoTipoDesparacitacion.TipoDesparacitacionId,
                Nombre = dtoTipoDesparacitacion.Nombre,
                Codigo = dtoTipoDesparacitacion.Codigo
            };
        }
        public static TipoEvento TipoEventoDTOMapToEntity(TipoEventoDTO tipo)
        {
            return new TipoEvento
            {
                TipoEventoId = tipo.TipoEventoId,
                Nombre = tipo.Nombre,
                Codigo = tipo.Codigo,
                Descripcion = tipo.Descripcion,
                CreadoAt = tipo.CreadoAt,
                EditadoAt = tipo.EditadoAt,
            };
        }

        public static TipoEventoDTO TipoEventoMapToDTO(TipoEvento tipo)
        {
            return new TipoEventoDTO
            {
                TipoEventoId = tipo.TipoEventoId,
                Nombre = tipo.Nombre,
                Codigo = tipo.Codigo,
                Descripcion = tipo.Descripcion,
                CreadoAt = tipo.CreadoAt,
                EditadoAt = tipo.EditadoAt,
            };
        }
        public static TipoVacunaDTO TipoVacunaMapToDTO(TipoVacuna tipoVacuna)
        {
            return new TipoVacunaDTO
            {
                TipoVacunaId = tipoVacuna.TipoVacunaId,
                Nombre = tipoVacuna.Nombre,
                Codigo = tipoVacuna.Codigo
            };
        }

        public static TipoVacuna TipoVacunaDTOMapToEntity(TipoVacunaDTO dtoTipoVacuna)
        {
            return new TipoVacuna
            {
                TipoVacunaId = dtoTipoVacuna.TipoVacunaId,
                Nombre = dtoTipoVacuna.Nombre,
                Codigo = dtoTipoVacuna.Codigo
            };
        }
        public static VacunaDTO VacunaMapToDTO(Vacuna vacuna)
        {
            return new VacunaDTO
            {
                VacunaId = vacuna.VacunaId,
                Codigo = vacuna.Codigo,
                FechaAplicacion = vacuna.FechaAplicacion,
                FechaProxima = vacuna.FechaProxima,
                Notas = vacuna.Notas,
                MascotaId = vacuna.MascotaId,
                TipoVacunaId = vacuna.TipoVacunaId
            };
        }

        public static Vacuna VacunaDTOMapToEntity(VacunaDTO dtoVacuna)
        {
            return new Vacuna
            {
                VacunaId = dtoVacuna.VacunaId,
                Codigo = dtoVacuna.Codigo,
                FechaAplicacion = dtoVacuna.FechaAplicacion,
                FechaProxima = dtoVacuna.FechaProxima,
                Notas = dtoVacuna.Notas,
                MascotaId = dtoVacuna.MascotaId,
                TipoVacunaId = dtoVacuna.TipoVacunaId
            };
        }
    }
}
