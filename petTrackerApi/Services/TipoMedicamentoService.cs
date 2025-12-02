using petTrackerApi.Data;
using petTrackerApi.DTO;
using petTrackerApi.Helpers;
using petTrackerApi.Model;
using petTrackerApi.Repository.GenericRepository;
using petTrackerApi.Repository.IRepository;
using petTrackerApi.Services.GenericServices;

namespace petTrackerApi.Services
{
    public class TipoMedicamentoService : IGenericService<TipoMedicamentoDTO>
    {
        private readonly IGenericRepository<TipoMedicamento> _repository;
        public TipoMedicamentoService(IGenericRepository<TipoMedicamento> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TipoMedicamentoDTO>> Get()
        {
            var tipoMedicamentos = await _repository.Get();
            return tipoMedicamentos.Select(Mapper.TipoMedicamentoMapToDTO);
        }

        public async Task<TipoMedicamentoDTO> GetById(int id)
        {
            var encuentra = await _repository.GetById(id);
            if (encuentra == null) return null;
            var respuesta = Mapper.TipoMedicamentoMapToDTO(encuentra);
            return respuesta;
        }

        public async Task<TipoMedicamentoDTO> Create(TipoMedicamentoDTO dto)
        {
            var mapTipoMedicamento = Mapper.TipoMedicamentoDTOMapToEntity(dto);
            mapTipoMedicamento.CreadoAt = DateTime.Now;
            mapTipoMedicamento.EditadoAt = DateTime.Now;
            mapTipoMedicamento.Codigo = CodeGenerator.GenerarCodigoRandom(mapTipoMedicamento.Nombre);

            var tipoCreado = await _repository.Create(mapTipoMedicamento);
            var tipoMedicamentoResult = Mapper.TipoMedicamentoMapToDTO(tipoCreado);
            return tipoMedicamentoResult;
        }

        public async Task<TipoMedicamentoDTO> Update(int id, TipoMedicamentoDTO dto)
        {
            var controlDB = await _repository.GetById(id);
            if (controlDB == null) return null;

            controlDB.Codigo = CodeGenerator.GenerarCodigoRandom(dto.Nombre);
            controlDB.Nombre = dto.Nombre;
            controlDB.EditadoAt = DateTime.Now;

            var actualizado = await _repository.Update(controlDB);
            return actualizado == null ? null : Mapper.TipoMedicamentoMapToDTO(actualizado);
        }
        public async Task<TipoMedicamentoDTO> Delete(int id)
        {
            var tipoEncontrado = await _repository.GetById(id);
            if (tipoEncontrado == null) return null;

            await _repository.Delete(tipoEncontrado);

            return Mapper.TipoMedicamentoMapToDTO(tipoEncontrado);
        }
    }
}
