using petTrackerApi.DTO;

namespace petTrackerApi.Services
{
    public interface IEspecieService
    {
        Task<IEnumerable<EspecieDTO>> Get();
        Task<EspecieDTO> GetById(int id);
        Task<(bool Exito, string Error, EspecieDTO dto)> Registro(EspecieDTO dto);
        Task<EspecieDTO> Update(int id, EspecieDTO dto);
        Task<bool> Delete(int id);
    }
}
