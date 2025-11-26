using petTrackerApi.DTO;
using petTrackerApi.Repository;

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


        public Task<IEnumerable<EspecieDTO>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<EspecieDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<(bool Exito, string Error, EspecieDTO dto)> Registro(UsuarioRegistroDTO dto)
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
