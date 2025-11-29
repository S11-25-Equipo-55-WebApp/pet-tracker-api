using petTrackerApi.Data;
using petTrackerApi.DTO;
using petTrackerApi.Repository.IRepository;
using petTrackerApi.Services.IServices;

namespace petTrackerApi.Services
{
    public class RazaService : IRazaService
    {
        private readonly IRazaRepository _repo;
        private readonly IConfiguration _config;

        public RazaService(IRazaRepository repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
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

        public Task<(bool Exito, string Error, RazaDTO dto)> Registro(RazaDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<RazaDTO> Update(int id, RazaDTO dto)
        {
            throw new NotImplementedException();
        }
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
