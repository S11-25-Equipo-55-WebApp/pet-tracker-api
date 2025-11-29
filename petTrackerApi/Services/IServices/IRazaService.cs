using petTrackerApi.DTO;

namespace petTrackerApi.Services.IServices
{
    public interface IRazaService
    {
        Task<IEnumerable<RazaDTO>> Get();
        Task<RazaDTO> GetById(int id);
        Task<(bool Exito, string Error, RazaDTO dto)> Registro(RazaDTO dto);
        Task<RazaDTO> Update(int id, RazaDTO dto);
        Task<bool> Delete(int id);
    }
}
