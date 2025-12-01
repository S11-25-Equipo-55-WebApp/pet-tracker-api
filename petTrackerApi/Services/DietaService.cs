using petTrackerApi.Data;
using petTrackerApi.DTO;
using petTrackerApi.Helpers;
using petTrackerApi.Model;
using petTrackerApi.Repository.IRepository;
using petTrackerApi.Services.IServices;

namespace petTrackerApi.Services
{
    public class DietaService : IDietaService
    {
        private readonly IDietaRepository _repository;

        public DietaService(IDietaRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<DietaDTO>> Get()
        {
            var dietas = await _repository.Get();
            return dietas.Select(Mapper.DietaMapToDTO);
        }

        public async Task<DietaDTO> GetById(int id)
        {
            var encuentra = await _repository.GetById(id);
            if (encuentra == null) return null;
            var respuesta = Mapper.DietaMapToDTO(encuentra);
            return respuesta;
        }

        public async Task<DietaDTO> Create(DietaDTO dtoDieta)
        {
            var mapDieta = Mapper.DietaDTOMapToEntity(dtoDieta);
            mapDieta.CreadoAt = DateTime.Now;
            mapDieta.EditadoAt = DateTime.Now;
            mapDieta.Codigo = CodeGenerator.GenerarCodigo(mapDieta.MascotaId, mapDieta.CreadoAt);

            var dietaCreada = await _repository.Create(mapDieta);
            var dietaResult = Mapper.DietaMapToDTO(dietaCreada);
            return dietaResult;
        }
        public async Task<DietaDTO> Update(int id, DietaDTO dtoDieta)
        {
            var dietaDB = await _repository.GetById(id);
            if (dietaDB == null) return null;

            dietaDB.PorcionDia = dtoDieta.PorcionDia;
            dietaDB.Notas = dtoDieta.Notas;
            dietaDB.TipoAlimentoId = dtoDieta.TipoAlimentoId;
            dietaDB.EditadoAt = DateTime.Now;

            var actualizado = await _repository.Update(dietaDB);
            return actualizado == null ? null : Mapper.DietaMapToDTO(actualizado);
        }

        public async Task<DietaDTO> Delete(int id)
        {
            var dietaEncontrada = await _repository.GetById(id);
            if (dietaEncontrada == null) return null;

            await _repository.Delete(dietaEncontrada);

            return Mapper.DietaMapToDTO(dietaEncontrada);
        }

        public async Task<IEnumerable<DietaDTO>> GetDietasByIdMascota(int id)
        {
            var listado = await _repository.GetDietasByIdMascota(id);
            return listado.Select(Mapper.DietaMapToDTO);
        }

    }
}
