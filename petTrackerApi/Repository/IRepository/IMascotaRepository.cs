using petTrackerApi.Model;
using petTrackerApi.Repository.GenericRepository;
using petTrackerApi.Services.GenericServices;

namespace petTrackerApi.Repository.IRepository
{
    public interface IMascotaRepository : IGenericRepository<Mascota>
    {
        Task<IEnumerable<Mascota>> GetByIdEntity(int id);
    }
}
