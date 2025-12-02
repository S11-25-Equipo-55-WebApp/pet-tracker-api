using petTrackerApi.Data;
using petTrackerApi.DTO;
using petTrackerApi.Helpers;
using petTrackerApi.Model;
using petTrackerApi.Repository.GenericRepository;
using petTrackerApi.Repository.IRepository;
using petTrackerApi.Services.IServices;

namespace petTrackerApi.Services
{
    public class ConsultaClinicaService : IConsultaClinicaService
    {
        private readonly IConsultaClinicaRepository _repository;
        public ConsultaClinicaService(IConsultaClinicaRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<ConsultaClinicaDTO>> Get()
        {
            var consultasClinicas = await _repository.Get();
            return consultasClinicas.Select(Mapper.ConsultaClinicaMapToDTO);
        }

        public async Task<ConsultaClinicaDTO> GetById(int id)
        {
            var encuentra = await _repository.GetById(id);
            if (encuentra == null) return null;
            var respuesta = Mapper.ConsultaClinicaMapToDTO(encuentra);
            return respuesta;
        }
        public async Task<ConsultaClinicaDTO> Create(ConsultaClinicaDTO dtoConsulta)
        {
            var mapConsulta = Mapper.ConsultaClinicaDTOMapToEntity(dtoConsulta);
            mapConsulta.CreadoAt = DateTime.Now;
            mapConsulta.EditadoAt = DateTime.Now;
            mapConsulta.Codigo = CodeGenerator.GenerarCodigoDobleFechaDateTime(mapConsulta.MascotaId, mapConsulta.CreadoAt, mapConsulta.EditadoAt);

            var consultaCreada = await _repository.Create(mapConsulta);
            var consultaResult = Mapper.ConsultaClinicaMapToDTO(consultaCreada);
            return consultaResult;
        }

        public async Task<ConsultaClinicaDTO> Update(int id, ConsultaClinicaDTO dtoConsulta)
        {
            var consultaDB = await _repository.GetById(id);
            if (consultaDB == null) return null;

            consultaDB.FechaConsulta = dtoConsulta.FechaConsulta;
            consultaDB.Motivo = dtoConsulta.Motivo;
            consultaDB.Diagnostico = dtoConsulta.Diagnostico;
            consultaDB.Veterinario  = dtoConsulta.Veterinario;
            consultaDB.Notas = dtoConsulta.Notas;
            consultaDB.MascotaId = dtoConsulta.MascotaId;
            consultaDB.EditadoAt = DateTime.Now;
            consultaDB.Codigo = CodeGenerator.GenerarCodigoDobleFechaDateTime(consultaDB.MascotaId, consultaDB.CreadoAt, consultaDB.EditadoAt);

            var actualizado = await _repository.Update(consultaDB);
            return actualizado == null ? null : Mapper.ConsultaClinicaMapToDTO(actualizado);
        }
        public async Task<ConsultaClinicaDTO> Delete(int id)
        {
            var consultaEncontrada = await _repository.GetById(id);
            if (consultaEncontrada == null) return null;

            await _repository.Delete(consultaEncontrada);

            return Mapper.ConsultaClinicaMapToDTO(consultaEncontrada);
        }

        public async Task<IEnumerable<ConsultaClinicaDTO>> GetConsultasByIdMascota(int id)
        {
            var listado = await _repository.GetConsultasByIdMascota(id);
            return listado.Select(Mapper.ConsultaClinicaMapToDTO);
        }
    }
}
