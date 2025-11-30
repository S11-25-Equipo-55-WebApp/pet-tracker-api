using petTrackerApi.Data;
using petTrackerApi.DTO;
using petTrackerApi.Model;
using petTrackerApi.Repository.GenericRepository;
using petTrackerApi.Services.GenericServices;
using petTrackerApi.Helpers;
using petTrackerApi.Repository;
using petTrackerApi.Repository.IRepository;
using petTrackerApi.Services.IServices;

namespace petTrackerApi.Services
{
    public class MascotaService : IMascotaService
    {
        private readonly IMascotaRepository _repository;
        
        public MascotaService(IMascotaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<MascotaDTO>> Get()
        {
            var mascotas = await _repository.Get();
            return mascotas.Select(Mapper.MascotaMapToDTO);
        }
        public async Task<MascotaDTO> GetById(int id)
        {
            var encuentra = await _repository.GetById(id);
            if (encuentra == null) return null;
            var respuesta = Mapper.MascotaMapToDTO(encuentra);
            return respuesta;
        }
        public async Task<MascotaDTO> Create(MascotaDTO dtoMascota)
        {
            var mapMascota = Mapper.MascotaDTOMapToEntity(dtoMascota);
            mapMascota.CreadoAt = DateTime.Now;
            mapMascota.EditadoAt = DateTime.Now;
            mapMascota.Codigo = CodeGenerator.GenerarCodigo(mapMascota.Nombre, mapMascota.CreadoAt, mapMascota.UsuarioId);

            var mascotaCreada = await _repository.Create(mapMascota);
            var mascotaResult = Mapper.MascotaMapToDTO(mascotaCreada);
            return mascotaResult;
        }

        public async Task<MascotaDTO> Update(int id, MascotaDTO dtoMascota)
        {
            var mascotaDB = await _repository.GetById(id);
            if (mascotaDB == null) return null;

            mascotaDB.Nombre = dtoMascota.Nombre;
            mascotaDB.Codigo = CodeGenerator.GenerarCodigo(dtoMascota.Nombre, mascotaDB.CreadoAt, mascotaDB.UsuarioId);
            mascotaDB.FechaNacimiento = dtoMascota.FechaNacimiento;
            mascotaDB.EspecieId = dtoMascota.EspecieId;
            mascotaDB.RazaId = dtoMascota.RazaId;
            mascotaDB.FotoMascota = dtoMascota.FotoMascota;
            mascotaDB.EditadoAt = DateTime.Now;

            var actualizado = await _repository.Update(mascotaDB);
            return actualizado == null ? null : Mapper.MascotaMapToDTO(actualizado);
        }
        public async Task<MascotaDTO> Delete(int id)
        {

            var mascotaEncontrada = await _repository.GetById(id);
            if (mascotaEncontrada == null) return null;

            await _repository.Delete(mascotaEncontrada);

            return Mapper.MascotaMapToDTO(mascotaEncontrada);
        }

        public async Task<IEnumerable<MascotaDTO>> GetMascotasByIdUsuario(int id)
        {
            var listado = await _repository.GetByIdEntity(id);
            return listado.Select(Mapper.MascotaMapToDTO);
        }
    }
}
