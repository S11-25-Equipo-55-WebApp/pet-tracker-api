using petTrackerApi.DTO;
using petTrackerApi.Services.GenericServices;

namespace petTrackerApi.Services.IServices
{
    public interface IDietaService : IGenericService<DietaDTO>
    {
        Task<IEnumerable<DietaDTO>> GetDietasByIdMascota(int id);
    }
}
