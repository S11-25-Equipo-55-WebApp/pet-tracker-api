using petTrackerApi.DTO;
using petTrackerApi.Services.GenericServices;

namespace petTrackerApi.Services.IServices
{
    public interface IExamenMedicoService : IGenericService<ExamenMedicoDTO>
    {
        Task<IEnumerable<ExamenMedicoDTO>> GetExamenMedicoByConsultaId(int id);
    }
}
