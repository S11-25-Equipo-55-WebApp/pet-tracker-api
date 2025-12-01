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
        public static TipoAlimentoDTO TipoAlimentoMapToDTO(TipoAlimento tipoAlimento)
        {
            return new TipoAlimentoDTO
            {
                TipoAlimentoId = tipoAlimento.TipoAlimentoId,
                Nombre = tipoAlimento.Nombre,
                Codigo = tipoAlimento.Codigo
            };
        }

        public static TipoAlimento TipoAlimentoDTOMapToEntity(TipoAlimentoDTO dtoTipoAlimento)
        {
            return new TipoAlimento
            {
                TipoAlimentoId = dtoTipoAlimento.TipoAlimentoId,
                Nombre = dtoTipoAlimento.Nombre,
                Codigo = dtoTipoAlimento.Codigo
            };
        }
        public static DietaDTO DietaMapToDTO(Dieta dieta)
        {
            return new DietaDTO
            {
                DietaId = dieta.DietaId,
                Codigo = dieta.Codigo,
                PorcionDia = dieta.PorcionDia,
                Notas = dieta.Notas,
                MascotaId = dieta.MascotaId,
                TipoAlimentoId = dieta.TipoAlimentoId,
                UnidadMedidaId = dieta.UnidadMedidaId

            };
        }

        public static Dieta DietaDTOMapToEntity(DietaDTO dtoDieta)
        {
            return new Dieta
            {
                DietaId = dtoDieta.DietaId,
                Codigo = dtoDieta.Codigo,
                PorcionDia = dtoDieta.PorcionDia,
                Notas = dtoDieta.Notas,
                MascotaId = dtoDieta.MascotaId,
                TipoAlimentoId = dtoDieta.TipoAlimentoId,
                UnidadMedidaId = dtoDieta.UnidadMedidaId

        public static Calendario CalendatioDTOMapToEntity(CalendarioDTO calendario)
        {
            return new Calendario
            {
                CalendarioId = calendario.CalendarioId,
                Codigo = calendario.Codigo,
                CreadoAt = calendario.CreadoAt,
                EditadoAt = calendario.EditadoAt,
                FechaEvento = calendario.FechaEvento,
                MascotaId = calendario.MascotaId,
                Notas = calendario.Notas,
                Titulo = calendario.Titulo,
                TipoEventoId = calendario.TipoEventoId,
                UsuarioId = calendario.UsuarioId
            };
        }

        public static CalendarioDTO CalendarioMapToDTO(Calendario calendario)
        {
            return new CalendarioDTO
            {
                CalendarioId = calendario.CalendarioId,
                Codigo = calendario.Codigo,
                CreadoAt = calendario.CreadoAt,
                EditadoAt = calendario.EditadoAt,
                FechaEvento = calendario.FechaEvento,
                MascotaId = calendario.MascotaId,
                Notas = calendario.Notas,
                Titulo = calendario.Titulo,
                TipoEventoId = calendario.TipoEventoId,
                UsuarioId = calendario.UsuarioId
            };
        }

        public static EstadoRecordatorio EstadoRecordatorioMapToEntity(EstadoRecordatorioDTO estadoRecordatorio)
        {
            return new EstadoRecordatorio
            {
                Codigo = estadoRecordatorio.Codigo,
                CreadoAt = estadoRecordatorio.CreadoAt,
                EditadoAt = estadoRecordatorio.EditadoAt,
                EstadoId = estadoRecordatorio.EstadoId,
                Nombre = estadoRecordatorio.Nombre  
            };
        }

        public static EstadoRecordatorioDTO EstadoRecordatorioMapToDTO(EstadoRecordatorio estadoRecordatorio)
        {
            return new EstadoRecordatorioDTO
            {
                Codigo = estadoRecordatorio.Codigo,
                CreadoAt = estadoRecordatorio.CreadoAt,
                EditadoAt = estadoRecordatorio.EditadoAt,
                EstadoId = estadoRecordatorio.EstadoId,
                Nombre = estadoRecordatorio.Nombre
            };
        }

        public static Tratamiento TratamientoDTOMapToEntity(TratamientoDTO tratamiento)
        {
            return new Tratamiento
            {
                TratamientoId = tratamiento.TratamientoId,
                Codigo = tratamiento.Codigo,
                ConsultaId = tratamiento.ConsultaId,
                CreadoAt = tratamiento.CreadoAt,
                Dosis = tratamiento.Dosis,
                EditadoAt = tratamiento.EditadoAt,
                FechaFin = tratamiento.FechaFin,
                FechaInicio = tratamiento.FechaInicio,
                Frecuencia = tratamiento.Frecuencia,
                Nombre = tratamiento.Nombre,
                Notas = tratamiento.Notas
            };
        }

        public static TratamientoDTO TratamientoMapToDTO(Tratamiento tratamiento)
        {
            return new TratamientoDTO
            {
                TratamientoId = tratamiento.TratamientoId,
                Codigo = tratamiento.Codigo,
                ConsultaId = tratamiento.ConsultaId,
                CreadoAt = tratamiento.CreadoAt,
                Dosis = tratamiento.Dosis,
                EditadoAt = tratamiento.EditadoAt,
                FechaFin = tratamiento.FechaFin,
                FechaInicio = tratamiento.FechaInicio,
                Frecuencia = tratamiento.Frecuencia,
                Nombre = tratamiento.Nombre,
                Notas = tratamiento.Notas
            };
        }
    }
}
