using petTrackerApi.DTO;
using petTrackerApi.Services.GenericServices;

namespace petTrackerApi.Services.IServices
{
    public interface IVacunaService : IGenericService<VacunaDTO>
    {
        Task<IEnumerable<VacunaDTO>> GetVacunasByIdMascota(int id);
    }
}
