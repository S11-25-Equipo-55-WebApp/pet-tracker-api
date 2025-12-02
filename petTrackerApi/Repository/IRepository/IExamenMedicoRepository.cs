using petTrackerApi.Model;
using petTrackerApi.Repository.GenericRepository;

namespace petTrackerApi.Repository.IRepository
{
    public interface IExamenMedicoRepository : IGenericRepository<ExamenMedico>
    {
        Task<IEnumerable<ExamenMedico>> GetByConsultaId(int consultaId);
    }
}
