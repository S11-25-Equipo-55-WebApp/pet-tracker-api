using petTrackerApi.DTO;
using petTrackerApi.Model;
using petTrackerApi.Repository.GenericRepository;

namespace petTrackerApi.Repository.IRepository
{
    public interface IMedicacionRepository : IGenericRepository<Medicacion>
    {
        Task<IEnumerable<Medicacion>> GetByConsultaId(int consultaId);
        Task<IEnumerable<Medicacion>> GetByMascotaId(int mascotaId);
    }
}
