using petTrackerApi.Data;
using petTrackerApi.DTO;
using petTrackerApi.Helpers;
using petTrackerApi.Model;
using petTrackerApi.Repository.GenericRepository;
using petTrackerApi.Services.GenericServices;

namespace petTrackerApi.Services
{
    public class CalendarioService : IGenericService<CalendarioDTO>
    {
        private readonly IGenericRepository<Calendario> _repo;
        private readonly IConfiguration _config;
        public CalendarioService(IGenericRepository<Calendario> repo, IConfiguration config)
        {
            _config = config;
            _repo = repo;
        }
        public async Task<IEnumerable<CalendarioDTO>> Get()
        {
            var lista = await _repo.Get();
            return lista.Select(Mapper.CalendarioMapToDTO);
        }

        public async Task<CalendarioDTO> GetById(int id)
        {
            var entity = await _repo.GetById(id);
            return entity == null ? null : Mapper.CalendarioMapToDTO(entity);
        }
        public async Task<CalendarioDTO> Create(CalendarioDTO dto)
        {
            dto.Codigo = CodeGenerator.GenerarCodigo(dto.CalendarioId, dto.CreadoAt);
            dto.CreadoAt = DateTime.Now;
            dto.EditadoAt = DateTime.Now;
            var entity = Mapper.CalendatioDTOMapToEntity(dto);
            await _repo.Create(entity);
            return Mapper.CalendarioMapToDTO(entity);
        }

        public async Task<CalendarioDTO> Delete(int id)
        {
            var entity = await _repo.GetById(id);
            if (entity == null) return null;
            await _repo.Delete(entity);
            return Mapper.CalendarioMapToDTO(entity);
        }



        public async Task<CalendarioDTO> Update(int id, CalendarioDTO dto)
        {
            var entity = await _repo.GetById(id);
            if (entity == null) return null;
            entity.FechaEvento = dto.FechaEvento;
            entity.TipoEventoId = dto.TipoEventoId;
            entity.CalendarioId = dto.CalendarioId;
            entity.UsuarioId = dto.UsuarioId;
            entity.CreadoAt = dto.CreadoAt;
            entity.EditadoAt = dto.EditadoAt;
            entity.Notas = dto.Notas;
            entity.Titulo = dto.Titulo;
            entity.Codigo = CodeGenerator.GenerarCodigo(dto.CalendarioId, dto.CreadoAt);
            entity.MascotaId = dto.MascotaId;

            await _repo.Update(entity);
            return Mapper.CalendarioMapToDTO(entity);
        }
    }
}
