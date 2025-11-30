using petTrackerApi.DTO;
using petTrackerApi.Services.GenericServices;

namespace petTrackerApi.Services.IServices
{
    public interface IDesparacitacionService : IGenericService<DesparacitacionDTO>
    {
        Task<IEnumerable<DesparacitacionDTO>> GetDesparacitacionesByIdMascota(int id);
    }
}
