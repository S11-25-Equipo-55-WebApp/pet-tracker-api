using petTrackerApi.Model;
using petTrackerApi.Repository.GenericRepository;

namespace petTrackerApi.Repository.IRepository
{
    public interface IConsultaClinicaRepository : IGenericRepository<ConsultaClinica>
    {
        Task<IEnumerable<ConsultaClinica>> GetConsultasByIdMascota(int id);
    }
}
