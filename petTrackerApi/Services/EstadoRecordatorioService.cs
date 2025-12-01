using petTrackerApi.Data;
using petTrackerApi.DTO;
using petTrackerApi.Helpers;
using petTrackerApi.Model;
using petTrackerApi.Repository.GenericRepository;
using petTrackerApi.Services.GenericServices;

namespace petTrackerApi.Services
{
    public class EstadoRecordatorioService : IGenericService<EstadoRecordatorioDTO>

    {
        private readonly IGenericRepository<EstadoRecordatorio> _repo;
        private readonly IConfiguration _config;

        public EstadoRecordatorioService(IGenericRepository<EstadoRecordatorio> repo, IConfiguration config)
        {
            _config = config;
            _repo = repo;
        }
        public async Task<IEnumerable<EstadoRecordatorioDTO>> Get()
        {
            var lista = await _repo.Get();
            return lista.Select(Mapper.EstadoRecordatorioMapToDTO);
        }

        public async Task<EstadoRecordatorioDTO> GetById(int id)
        {
            var entity = await _repo.GetById(id);
            return entity == null ? null : Mapper.EstadoRecordatorioMapToDTO(entity);
        }

        public async Task<EstadoRecordatorioDTO> Create(EstadoRecordatorioDTO dto)
        {
            dto.Codigo = CodeGenerator.GenerarCodigo(dto.EstadoId, dto.CreadoAt);
            dto.CreadoAt = DateTime.Now;
            dto.EditadoAt = DateTime.Now;
            var entity = Mapper.EstadoRecordatorioMapToEntity(dto);
            await _repo.Create(entity);
            return Mapper.EstadoRecordatorioMapToDTO(entity);
        }

        public async Task<EstadoRecordatorioDTO> Delete(int id)
        {
            var entity = await _repo.GetById(id);
            if (entity == null) return null;
            await _repo.Delete(entity);
            return Mapper.EstadoRecordatorioMapToDTO(entity);
        }


        public async Task<EstadoRecordatorioDTO> Update(int id, EstadoRecordatorioDTO dto)
        {
            var entity = await _repo.GetById(id);
            if (entity == null) return null;
            entity.CreadoAt = DateTime.Now;
            entity.EditadoAt = DateTime.Now;
            entity.EstadoId = dto.EstadoId;
            entity.Codigo = CodeGenerator.GenerarCodigo(dto.EstadoId, dto.CreadoAt);
            entity.Nombre = dto.Nombre;

            await _repo.Update(entity);
            return Mapper.EstadoRecordatorioMapToDTO(entity);
        }
    }
}
