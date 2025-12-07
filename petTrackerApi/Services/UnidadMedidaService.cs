using petTrackerApi.Data;
using petTrackerApi.DTO;
using petTrackerApi.Model;
using petTrackerApi.Repository.GenericRepository;
using petTrackerApi.Services.GenericServices;

namespace petTrackerApi.Services
{
    public class UnidadMedidaService : IGenericService<UnidadMedidaDTO>
    {
        private readonly IGenericRepository<UnidadMedida> _repo;

        public UnidadMedidaService(IGenericRepository<UnidadMedida> repo)
        {
            _repo = repo;
        }
        public async Task<IEnumerable<UnidadMedidaDTO>> Get()
        {
            var lista = await _repo.Get();
            return lista.Select(Mapper.UnidadMedidaMapToDTO);
        }

        public async Task<UnidadMedidaDTO> GetById(int id)
        {
            var entity = await _repo.GetById(id);
            return entity == null ? null : Mapper.UnidadMedidaMapToDTO(entity);
        }

        public Task<UnidadMedidaDTO> Create(UnidadMedidaDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<UnidadMedidaDTO> Update(int id, UnidadMedidaDTO dto)
        {
            throw new NotImplementedException();
        }
        public Task<UnidadMedidaDTO> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
