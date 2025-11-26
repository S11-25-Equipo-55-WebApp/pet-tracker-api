using petTrackerApi.Repository;

namespace petTrackerApi.Services
{
    public class EspecieService
    {
        private readonly IEspecieRepository _repo;
        private readonly IConfiguration _config;

        public EspecieService(IEspecieRepository repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }
    }
}
