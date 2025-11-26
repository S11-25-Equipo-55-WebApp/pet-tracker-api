using petTrackerApi.Model;

namespace petTrackerApi.Repository
{
    public interface IMascotaRepository
    {
        Task<IEnumerable<Mascota>> Get();
        Task<Mascota> GetById(int id);
        Task<Mascota> Registro(Mascota mascota);
        Task<Mascota> Update(int id, Mascota mascota);
        Task<Mascota> Delete(int id);
    }
}
