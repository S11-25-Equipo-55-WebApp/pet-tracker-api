using petTrackerApi.DTO;
using petTrackerApi.Services.GenericServices;

namespace petTrackerApi.Services.IServices
{
    public interface IMascotaService : IGenericService<MascotaDTO>
    {
        Task<IEnumerable<MascotaDTO>> GetMascotasByIdUsuario(int id);
    }
}
