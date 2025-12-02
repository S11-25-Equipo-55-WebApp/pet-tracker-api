using petTrackerApi.DTO;
using petTrackerApi.Services.GenericServices;

namespace petTrackerApi.Services.IServices
{
    public interface IControlPesoService : IGenericService<ControlPesoDTO>
    {
        Task<IEnumerable<ControlPesoDTO>> GetControlPesoByIdMascota(int id);
    }
}
