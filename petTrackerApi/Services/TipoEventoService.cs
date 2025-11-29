using petTrackerApi.Data;
using petTrackerApi.DTO;
using petTrackerApi.Helpers;
using petTrackerApi.Model;
using petTrackerApi.Repository.GenericRepository;
using petTrackerApi.Services.GenericServices;

namespace petTrackerApi.Services
{
    public class TipoEventoService : IGenericService<TipoEventoDTO>
    {
        private readonly IGenericRepository<TipoEvento> _repo;
        private readonly IConfiguration _config;

        public TipoEventoService(IGenericRepository<TipoEvento> repo, IConfiguration config)
        {
            _config = config;
            _repo = repo;
        }

        public async Task<TipoEventoDTO> Create(TipoEventoDTO dto)
        {
            dto.Codigo = CodeGenerator.GenerarCodigo(dto.TipoEventoId, dto.CreadoAt);
            dto.CreadoAt = DateTime.Now;
            dto.EditadoAt = DateTime.Now;
            var entity = Mapper.TipoEventoDTOMapToEntity(dto);
            await _repo.Create(entity);
            return Mapper.TipoEventoMapToDTO(entity);
        }

        public async Task<TipoEventoDTO> Delete(int id)
        {
            var entity = await _repo.GetById(id);

            if (entity == null)
                return null;

            await _repo.Delete(entity);
            return Mapper.TipoEventoMapToDTO(entity);
        }

        public async Task<IEnumerable<TipoEventoDTO>> Get()
        {
            var lista = await _repo.Get();
            return lista.Select(Mapper.TipoEventoMapToDTO);
        }

        public async Task<TipoEventoDTO> GetById(int id)
        {
            var entity = await _repo.GetById(id);
            return entity == null ? null : Mapper.TipoEventoMapToDTO(entity);
        }

        public async Task<TipoEventoDTO> Update(int id, TipoEventoDTO dto)
        {
            var entity = await _repo.GetById(id);
            if (entity == null)
                return null;

            entity.Nombre = dto.Nombre;
            entity.Codigo = CodeGenerator.GenerarCodigo(entity.TipoEventoId, entity.CreadoAt);
            entity.Descripcion = dto.Descripcion;
            entity.CreadoAt = dto.CreadoAt;
            entity.EditadoAt = dto.EditadoAt;

            await _repo.Update(entity);
            return Mapper.TipoEventoMapToDTO(entity);
        }
    }
}
