using petTrackerApi.Data;
using petTrackerApi.DTO;
using petTrackerApi.Helpers;
using petTrackerApi.Model;
using petTrackerApi.Repository.IRepository;
using petTrackerApi.Services.IServices;

namespace petTrackerApi.Services
{
    public class ExamenMedicoService : IExamenMedicoService
    {
        private readonly IExamenMedicoRepository _repository;

        public ExamenMedicoService(IExamenMedicoRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<ExamenMedicoDTO>> Get()
        {
            var examenes = await _repository.Get();
            return examenes.Select(Mapper.ExamenMedicoMapToDTO);
        }

        public async Task<ExamenMedicoDTO> GetById(int id)
        {
            var encuentra = await _repository.GetById(id);
            if (encuentra == null) return null;
            var respuesta = Mapper.ExamenMedicoMapToDTO(encuentra);
            return respuesta;
        }

        public async Task<ExamenMedicoDTO> Create(ExamenMedicoDTO dto)
        {
            var mapExamen = Mapper.ExamenMedicoDTOMapToEntity(dto);
            mapExamen.CreadoAt = DateTime.Now;
            mapExamen.EditadoAt = DateTime.Now;
            mapExamen.Codigo = CodeGenerator.GenerarCodigoDobleFecha(mapExamen.ConsultaId, mapExamen.CreadoAt, mapExamen.FechaExamen);

            var examenCreado = await _repository.Create(mapExamen);
            var examenResult = Mapper.ExamenMedicoMapToDTO(examenCreado);
            return examenResult;
        }

        public async Task<ExamenMedicoDTO> Update(int id, ExamenMedicoDTO dto)
        {
            var examenDB = await _repository.GetById(id);
            if (examenDB == null) return null;

            examenDB.FechaExamen = dto.FechaExamen;
            examenDB.Resultado = dto.Resultado;
            examenDB.ConsultaId = dto.ConsultaId;
            examenDB.TipoExamenId = dto.TipoExamenId;
            examenDB.EditadoAt = DateTime.Now;

            var actualizado = await _repository.Update(examenDB);
            return actualizado == null ? null : Mapper.ExamenMedicoMapToDTO(actualizado);
        }
        public async Task<ExamenMedicoDTO> Delete(int id)
        {
            var examenEncontrado = await _repository.GetById(id);
            if (examenEncontrado == null) return null;

            await _repository.Delete(examenEncontrado);

            return Mapper.ExamenMedicoMapToDTO(examenEncontrado);
        }
        public async Task<IEnumerable<ExamenMedicoDTO>> GetExamenMedicoByConsultaId(int id)
        {
            var listado = await _repository.GetByConsultaId(id);
            return listado.Select(Mapper.ExamenMedicoMapToDTO);
        }
    }
}
