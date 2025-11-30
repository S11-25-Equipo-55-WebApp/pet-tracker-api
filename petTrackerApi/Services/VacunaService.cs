using petTrackerApi.Data;
using petTrackerApi.DTO;
using petTrackerApi.Helpers;
using petTrackerApi.Model;
using petTrackerApi.Repository.IRepository;
using petTrackerApi.Services.IServices;

namespace petTrackerApi.Services
{
    public class VacunaService : IVacunaService
    {
        private readonly IVacunaRepository _repository;
        public VacunaService(IVacunaRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<VacunaDTO>> Get()
        {
            var vacunas = await _repository.Get();
            return vacunas.Select(Mapper.VacunaMapToDTO);
        }

        public async Task<VacunaDTO> GetById(int id)
        {
            var encuentra = await _repository.GetById(id);
            if (encuentra == null) return null;
            var respuesta = Mapper.VacunaMapToDTO(encuentra);
            return respuesta;
        }

        public async Task<VacunaDTO> Create(VacunaDTO dtoVacuna)
        {
            var mapVacuna= Mapper.VacunaDTOMapToEntity(dtoVacuna);
            mapVacuna.CreadoAt = DateTime.Now;
            mapVacuna.EditadoAt = DateTime.Now;
            mapVacuna.Codigo = CodeGenerator.GenerarCodigoVacuna(mapVacuna.MascotaId, mapVacuna.CreadoAt, mapVacuna.FechaProxima);

            var vacunaCreada = await _repository.Create(mapVacuna);
            var vacunaResult = Mapper.VacunaMapToDTO(vacunaCreada);
            return vacunaResult;
        }
        public async Task<VacunaDTO> Update(int id, VacunaDTO dtoVacuna)
        {
            var vacunaDB = await _repository.GetById(id);
            if (vacunaDB == null) return null;

            vacunaDB.FechaAplicacion = dtoVacuna.FechaAplicacion;
            vacunaDB.FechaProxima = dtoVacuna.FechaProxima;
            vacunaDB.Notas = dtoVacuna.Notas;
            vacunaDB.TipoVacunaId = dtoVacuna.TipoVacunaId;
            vacunaDB.EditadoAt = DateTime.Now;

            var actualizado = await _repository.Update(vacunaDB);
            return actualizado == null ? null : Mapper.VacunaMapToDTO(actualizado);
        }

        public async Task<VacunaDTO> Delete(int id)
        {
            var vacunaEncontrada = await _repository.GetById(id);
            if (vacunaEncontrada == null) return null;

            await _repository.Delete(vacunaEncontrada);

            return Mapper.VacunaMapToDTO(vacunaEncontrada);
        }


        public async Task<IEnumerable<VacunaDTO>> GetVacunasByIdMascota(int id)
        {
            var listado = await _repository.GetVacunasByIdMascota(id);
            return listado.Select(Mapper.VacunaMapToDTO);
        }

    }
}
