using petTrackerApi.Data;
using petTrackerApi.DTO;
using petTrackerApi.Helpers;
using petTrackerApi.Model;
using petTrackerApi.Repository.GenericRepository;
using petTrackerApi.Services.GenericServices;

namespace petTrackerApi.Services
{
    public class TratamientoService : IGenericService<TratamientoDTO>
    {
        private readonly IGenericRepository<Tratamiento> _repo;
        private readonly IConfiguration _config;

        public TratamientoService(IGenericRepository<Tratamiento> repo, IConfiguration config)
        {
            _config = config;
            _repo = repo;
        }
        public async Task<IEnumerable<TratamientoDTO>> Get()
        {
            var lista = await _repo.Get();
            return lista.Select(Mapper.TratamientoMapToDTO);
        }

        public async Task<TratamientoDTO> GetById(int id)
        {
            var entity = await _repo.GetById(id);
            return entity == null ? null : Mapper.TratamientoMapToDTO(entity);
        }
        public async Task<TratamientoDTO> Create(TratamientoDTO dto)
        {
            dto.Codigo = CodeGenerator.GenerarCodigo(dto.TratamientoId, dto.CreadoAt);
            dto.CreadoAt = DateTime.Now;
            dto.EditadoAt = DateTime.Now;
            var entity = Mapper.TratamientoDTOMapToEntity(dto);
            await _repo.Create(entity);
            return Mapper.TratamientoMapToDTO(entity);
        }

        public async Task<TratamientoDTO> Delete(int id)
        {
            var entity = await _repo.GetById(id);
            if (entity == null) return null;
            await _repo.Delete(entity);
            return Mapper.TratamientoMapToDTO(entity);
        }

        

        public async Task<TratamientoDTO> Update(int id, TratamientoDTO dto)
        {
            var entity = await _repo.GetById(id);
            if (entity == null) return null;
            entity.TratamientoId = dto.TratamientoId;
            entity.Codigo = CodeGenerator.GenerarCodigo(entity.TratamientoId, entity.CreadoAt);
            entity.Nombre = dto.Nombre;
            entity.CreadoAt = dto.CreadoAt;
            entity.EditadoAt = DateTime.Now;
            entity.FechaInicio = dto.FechaInicio;
            entity.FechaFin = dto.FechaFin;
            entity.Frecuencia = dto.Frecuencia;
            entity.Dosis = dto.Dosis;
            entity.Notas = dto.Notas;
            entity.ConsultaId = dto.ConsultaId;

            await _repo.Update(entity);
            return Mapper.TratamientoMapToDTO(entity);

        }
    }
}
