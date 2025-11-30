using petTrackerApi.Model;
using petTrackerApi.Repository.GenericRepository;

namespace petTrackerApi.Repository.IRepository
{
    public interface IVacunaRepository : IGenericRepository<Vacuna>
    {
        Task<IEnumerable<Vacuna>> GetVacunasByIdMascota(int id);
    }
}
