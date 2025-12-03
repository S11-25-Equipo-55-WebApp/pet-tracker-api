using petTrackerApi.Data;
using petTrackerApi.DTO;
using petTrackerApi.Helpers;
using petTrackerApi.Model;
using petTrackerApi.Repository.GenericRepository;
using petTrackerApi.Services.GenericServices;

namespace petTrackerApi.Services
{
    public class TipoExamenService : IGenericService<TipoExamenDTO>
    {
        private readonly IGenericRepository<TipoExamen> _repo;
        private readonly IConfiguration _config;

        public TipoExamenService(IGenericRepository<TipoExamen> repo, IConfiguration config)
        {
            _config = config;
            _repo = repo;
        }

        public async Task<IEnumerable<TipoExamenDTO>> Get()
        {
            var lista = await _repo.Get();
            return lista.Select(Mapper.TipoExamenMapToDTO);
        }

        public async Task<TipoExamenDTO> GetById(int id)
        {
            var entity = await _repo.GetById(id);
            return entity == null ? null : Mapper.TipoExamenMapToDTO(entity);
        }

        public async Task<TipoExamenDTO> Create(TipoExamenDTO dto)
        {
            dto.Codigo = CodeGenerator.GenerarCodigo(dto.TipoExamenId, dto.CreadoAt);
            dto.CreadoAt = DateTime.Now;
            dto.EditadoAt = DateTime.Now;
            var entity = Mapper.TipoExamenDTOMapToEntity(dto);
            await _repo.Create(entity);
            return Mapper.TipoExamenMapToDTO(entity);
        }

        public async Task<TipoExamenDTO> Delete(int id)
        {
            var entity = await _repo.GetById(id);
            if (entity == null) return null;
            await _repo.Delete(entity);
            return Mapper.TipoExamenMapToDTO(entity);
        }

       

        public async Task<TipoExamenDTO> Update(int id, TipoExamenDTO dto)
        {
            var entity = await _repo.GetById(id);
            if (entity == null) return null;
            entity.TipoExamenId = dto.TipoExamenId;
            entity.Nombre = dto.Nombre;
            entity.Codigo = CodeGenerator.GenerarCodigo(dto.TipoExamenId, dto.CreadoAt);
            entity.CreadoAt = dto.CreadoAt;
            entity.EditadoAt = DateTime.Now;
            await _repo.Update(entity);
            return Mapper.TipoExamenMapToDTO(entity);
        }
    }
}
