using petTrackerApi.Model;
using petTrackerApi.Repository.GenericRepository;

namespace petTrackerApi.Repository.IRepository
{
    public interface IControlPesoRepository : IGenericRepository<ControlPeso>
    {
        Task<IEnumerable<ControlPeso>> GetControlPesoByIdMascota(int id);
    }
}
