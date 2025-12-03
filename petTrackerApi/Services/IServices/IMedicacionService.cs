using petTrackerApi.DTO;
using petTrackerApi.Services.GenericServices;

namespace petTrackerApi.Services.IServices
{
    public interface IMedicacionService : IGenericService<MedicacionDTO>
    {
        Task<IEnumerable<MedicacionDTO>> GetMedicacionByIdConsulta(int id);
        Task<IEnumerable<MedicacionDTO>> GetMedicacionByIdMascota(int id);
    }
}
