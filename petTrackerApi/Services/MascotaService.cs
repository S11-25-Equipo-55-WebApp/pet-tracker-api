using petTrackerApi.Data;
using petTrackerApi.DTO;
using petTrackerApi.Model;
using petTrackerApi.Repository.GenericRepository;
using petTrackerApi.Services.GenericServices;
using petTrackerApi.Helpers;

namespace petTrackerApi.Services
{
    public class MascotaService : IGenericService<MascotaDTO>
    {
        private readonly IGenericRepository<Mascota> _repository;
        
        public MascotaService(IGenericRepository<Mascota> repository)
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
            dtoMascota.Codigo = CodeGenerator.GenerarCodigo(dtoMascota.Nombre, dtoMascota.CreadoAt);
            dtoMascota.CreadoAt = DateTime.Now;
            dtoMascota.EditadoAt = DateTime.Now;

            var mapMascota = Mapper.MascotaDTOMapToEntity(dtoMascota);
            var mascotaCreada = await _repository.Create(mapMascota);
            return dtoMascota;
        }

        public async Task<MascotaDTO> Update(int id, MascotaDTO dtoMascota)
        {
            var mascotaDB = await _repository.GetById(id);
            if (mascotaDB == null) return null;

            mascotaDB.Nombre = dtoMascota.Nombre;
            mascotaDB.FechaNacimiento = dtoMascota.FechaNacimiento;
            mascotaDB.EspecieId = dtoMascota.EspecieId;
            mascotaDB.RazaId = dtoMascota.RazaId;
            mascotaDB.FotoMascota = dtoMascota.FotoMascota;
            mascotaDB.EditadoAt = DateTime.Now;

            var entity = Mapper.MascotaDTOMapToEntity(dtoMascota);

            var actualizado = await _repository.Update(id, entity);
            return actualizado == null ? null : Mapper.MascotaMapToDTO(actualizado);
        }
        public async Task<MascotaDTO> Delete(int id)
        {

            var mascotaEncontrada = await _repository.GetById(id);
            if (mascotaEncontrada == null) return null;

            await _repository.Delete(mascotaEncontrada);

            return Mapper.MascotaMapToDTO(mascotaEncontrada);
        }
    }
}
