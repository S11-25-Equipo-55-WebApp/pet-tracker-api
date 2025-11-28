using petTrackerApi.Data;
using petTrackerApi.DTO;
using petTrackerApi.Helpers;
using petTrackerApi.Model;
using petTrackerApi.Repository;
using petTrackerApi.Repository.GenericRepository;
using petTrackerApi.Services.GenericServices;

namespace petTrackerApi.Services
{
    public class DesparacitacionService : IGenericService<DesparacitacionDTO>
    {
        private readonly IGenericRepository<Desparacitacion> _repository;
        private readonly DesparacitacionRepository _repDesparacitacion;

        public DesparacitacionService(IGenericRepository<Desparacitacion> repository, DesparacitacionRepository repDesparacitacion)
        {
            _repository = repository;
            _repDesparacitacion = repDesparacitacion;
        }
        public async Task<IEnumerable<DesparacitacionDTO>> Get()
        {
            var desparacitaciones = await _repository.Get();
            return desparacitaciones.Select(Mapper.DesparacitacionMapToDTO);
        }
        public async Task<DesparacitacionDTO> GetById(int id)
        {
            var encuentra = await _repository.GetById(id);
            if (encuentra == null) return null;
            var respuesta = Mapper.DesparacitacionMapToDTO(encuentra);
            return respuesta;
        }
        public async Task<DesparacitacionDTO> Create(DesparacitacionDTO dtoDesparacitacion)
        {
            dtoDesparacitacion.Codigo = CodeGenerator.GenerarCodigo(dtoDesparacitacion.MascotaId, dtoDesparacitacion.CreadoAt);
            dtoDesparacitacion.CreadoAt = DateTime.Now;
            dtoDesparacitacion.EditadoAt = DateTime.Now;

            var mapDesparacitacion = Mapper.DesparacitacionDTOMapToEntity(dtoDesparacitacion);
            var desparacitacionCreada = await _repository.Create(mapDesparacitacion);
            return dtoDesparacitacion;
        }
        public async Task<DesparacitacionDTO> Update(int id, DesparacitacionDTO dtoDesparacitacion)
        {
            var desparacitacionBD = await _repository.GetById(id);
            if (desparacitacionBD == null) return null;

            desparacitacionBD.Codigo = CodeGenerator.GenerarCodigo(desparacitacionBD.MascotaId, desparacitacionBD.CreadoAt);
            desparacitacionBD.FechaAplicacion = dtoDesparacitacion.FechaAplicacion;
            desparacitacionBD.FechaProxima = dtoDesparacitacion.FechaProxima;
            desparacitacionBD.Notas = dtoDesparacitacion.Notas;
            desparacitacionBD.MascotaId = dtoDesparacitacion.MascotaId;
            desparacitacionBD.TipoDesparacitacionId = dtoDesparacitacion.TipoDesparacitacionId;
            desparacitacionBD.EditadoAt = dtoDesparacitacion.EditadoAt;

            var actualizado = await _repository.Update(desparacitacionBD);
            return actualizado == null ? null : Mapper.DesparacitacionMapToDTO(actualizado);
        }
        public async Task<DesparacitacionDTO> Delete(int id)
        {
            var desparacitacionEncontrada = await _repository.GetById(id);
            if (desparacitacionEncontrada == null) return null;

            await _repository.Delete(desparacitacionEncontrada);
            return Mapper.DesparacitacionMapToDTO(desparacitacionEncontrada);
        }

        public async Task<IEnumerable<DesparacitacionDTO>> GetDesparacitacionesByIdMascota(int id)
        {
            var listado = await _repDesparacitacion.GetDesparacitacionesByIdMascota(id);
            return listado.Select(Mapper.DesparacitacionMapToDTO);
        }
    }
}
