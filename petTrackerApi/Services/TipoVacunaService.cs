using petTrackerApi.Data;
using petTrackerApi.DTO;
using petTrackerApi.Model;
using petTrackerApi.Repository.GenericRepository;
using petTrackerApi.Services.GenericServices;

namespace petTrackerApi.Services
{
    public class TipoVacunaService : IGenericService<TipoVacunaDTO>
    {
        private readonly IGenericRepository<TipoVacuna> _repo;
        public TipoVacunaService(IGenericRepository<TipoVacuna> repo)
        {
            _repo = repo;
        }
        public async Task<IEnumerable<TipoVacunaDTO>> Get()
        {
            var lista = await _repo.Get();
            return lista.Select(Mapper.TipoVacunaMapToDTO);
        }

        public async Task<TipoVacunaDTO> GetById(int id)
        {
            var tipoVacuna = await _repo.GetById(id);
            return tipoVacuna == null ? null : Mapper.TipoVacunaMapToDTO(tipoVacuna);
        }

        public Task<TipoVacunaDTO> Create(TipoVacunaDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<TipoVacunaDTO> Update(int id, TipoVacunaDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<TipoVacunaDTO> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
