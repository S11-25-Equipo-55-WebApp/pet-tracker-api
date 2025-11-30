using petTrackerApi.Data;
using petTrackerApi.DTO;
using petTrackerApi.Model;
using petTrackerApi.Repository.GenericRepository;
using petTrackerApi.Repository.IRepository;
using petTrackerApi.Services.GenericServices;
using petTrackerApi.Services.IServices;

namespace petTrackerApi.Services
{
    public class RazaService : IGenericService<RazaDTO>
    {
        private readonly IGenericRepository<Raza> _repo;
        public RazaService(IGenericRepository<Raza> repo)
        {
            _repo = repo;
        }
        public async Task<IEnumerable<RazaDTO>> Get()
        {
            var lista = await _repo.Get();
            return lista.Select(Mapper.RazaMapToDTO);
        }

        public async Task<RazaDTO> GetById(int id)
        {
            var raza = await _repo.GetById(id);
            return raza == null ? null : Mapper.RazaMapToDTO(raza);
        }

        public Task<RazaDTO> Create(RazaDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<RazaDTO> Update(int id, RazaDTO dto)
        {
            throw new NotImplementedException();
        }

        Task<RazaDTO> IGenericService<RazaDTO>.Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
