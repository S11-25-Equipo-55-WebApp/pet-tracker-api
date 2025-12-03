using petTrackerApi.DTO;
using petTrackerApi.Services.GenericServices;

namespace petTrackerApi.Services.IServices
{
    public interface IConsultaClinicaService : IGenericService<ConsultaClinicaDTO>
    {
        Task<IEnumerable<ConsultaClinicaDTO>> GetConsultasByIdMascota(int id);
    }
}
