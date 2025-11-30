using petTrackerApi.Model;
using petTrackerApi.Repository.GenericRepository;

namespace petTrackerApi.Repository.IRepository
{
    public interface IDesparacitacionRepository : IGenericRepository<Desparacitacion>
    {
        Task<IEnumerable<Desparacitacion>> GetDesparacitacionesByIdMascota(int id);
    }
}
