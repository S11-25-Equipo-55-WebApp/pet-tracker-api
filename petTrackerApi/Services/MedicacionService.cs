using petTrackerApi.Data;
using petTrackerApi.DTO;
using petTrackerApi.Helpers;
using petTrackerApi.Repository.IRepository;
using petTrackerApi.Services.IServices;

namespace petTrackerApi.Services
{
    public class MedicacionService : IMedicacionService
    {
        private readonly IMedicacionRepository _repository;
        public MedicacionService(IMedicacionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<MedicacionDTO>> Get()
        {
            var medicaciones = await _repository.Get();
            return medicaciones.Select(Mapper.MedicacionMapToDTO);
        }

        public async Task<MedicacionDTO> GetById(int id)
        {
            var encuentra = await _repository.GetById(id);
            if (encuentra == null) return null;
            var respuesta = Mapper.MedicacionMapToDTO(encuentra);
            return respuesta;
        }
        public async Task<MedicacionDTO> Create(MedicacionDTO dto)
        {
            var mapMedicacion = Mapper.MedicacionDTOMapToEntity(dto);
            mapMedicacion.CreadoAt = DateTime.Now;
            mapMedicacion.EditadoAt = DateTime.Now;
            mapMedicacion.Codigo = CodeGenerator.GenerarCodigoDobleFechaDateTime(mapMedicacion.ConsultaId, mapMedicacion.CreadoAt, mapMedicacion.EditadoAt);

            var medicacionCreada = await _repository.Create(mapMedicacion);
            var medicacionResult = Mapper.MedicacionMapToDTO(medicacionCreada);
            return medicacionResult;
        }
        public async Task<MedicacionDTO> Update(int id, MedicacionDTO dto)
        {
            var medicacionBD = await _repository.GetById(id);
            if (medicacionBD == null) return null;

            medicacionBD.Descripcion = dto.Descripcion;
            medicacionBD.TipoMedicacionId = dto.TipoMedicacionId;
            medicacionBD.Frecuencia = dto.Frecuencia;
            medicacionBD.ConsultaId = dto.ConsultaId;
            medicacionBD.Nombre = dto.Nombre;
            medicacionBD.EditadoAt = DateTime.Now;
            medicacionBD.Codigo = CodeGenerator.GenerarCodigoDobleFechaDateTime(medicacionBD.ConsultaId, medicacionBD.CreadoAt, medicacionBD.EditadoAt);

            var actualizado = await _repository.Update(medicacionBD);
            return actualizado == null ? null : Mapper.MedicacionMapToDTO(actualizado);
        }

        public async Task<MedicacionDTO> Delete(int id)
        {
            var medicacionEncontrada = await _repository.GetById(id);
            if (medicacionEncontrada == null) return null;

            await _repository.Delete(medicacionEncontrada);

            return Mapper.MedicacionMapToDTO(medicacionEncontrada);
        }

        public async Task<IEnumerable<MedicacionDTO>> GetMedicacionByIdConsulta(int id)
        {
            var listado = await _repository.GetByConsultaId(id);
            return listado.Select(Mapper.MedicacionMapToDTO);
        }

        public async Task<IEnumerable<MedicacionDTO>> GetMedicacionByIdMascota(int id)
        {
            var listado = await _repository.GetByMascotaId(id);
            return listado.Select(Mapper.MedicacionMapToDTO);
        }
    }
}
