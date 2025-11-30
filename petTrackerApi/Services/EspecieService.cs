using petTrackerApi.Data;
using petTrackerApi.DTO;
using petTrackerApi.Model;
using petTrackerApi.Repository.GenericRepository;
using petTrackerApi.Repository.IRepository;
using petTrackerApi.Services.GenericServices;
using petTrackerApi.Services.IServices;

namespace petTrackerApi.Services
{
    public class EspecieService : IGenericService<EspecieDTO>
    {
        private readonly IGenericRepository<Especie> _repo;

        public EspecieService(IGenericRepository<Especie> repo)
        {
            _repo = repo;
        }
        public async Task<IEnumerable<EspecieDTO>> Get()
        {
            var lista = await _repo.Get();
            return lista.Select(Mapper.EspecieMapToDTO);
        }
        
        public async Task<EspecieDTO> GetById(int id)
        {
            var especie = await _repo.GetById(id);
            return especie == null ? null : Mapper.EspecieMapToDTO(especie);
        }

        public Task<EspecieDTO> Create(EspecieDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<EspecieDTO> Update(int id, EspecieDTO dto)
        {
            throw new NotImplementedException();
        }

        Task<EspecieDTO> IGenericService<EspecieDTO>.Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
