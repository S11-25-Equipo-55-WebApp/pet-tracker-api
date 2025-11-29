using petTrackerApi.Data;
using petTrackerApi.DTO;
using petTrackerApi.Repository.IRepository;
using petTrackerApi.Services.IServices;

namespace petTrackerApi.Services
{
    public class EspecieService : IEspecieService
    {
        private readonly IEspecieRepository _repo;
        private readonly IConfiguration _config;

        public EspecieService(IEspecieRepository repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
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

        public Task<(bool Exito, string Error, EspecieDTO dto)> Registro(EspecieDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<EspecieDTO> Update(int id, EspecieDTO dto)
        {
            throw new NotImplementedException();
        }
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
