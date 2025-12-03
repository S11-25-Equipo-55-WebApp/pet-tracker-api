using petTrackerApi.Model;
using petTrackerApi.Repository.GenericRepository;

namespace petTrackerApi.Repository.IRepository
{
    public interface IDietaRepository : IGenericRepository<Dieta>
    {
        Task<IEnumerable<Dieta>> GetDietasByIdMascota(int id);
    }
}
