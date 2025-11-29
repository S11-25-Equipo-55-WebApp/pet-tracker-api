using petTrackerApi.Model;

namespace petTrackerApi.Repository.IRepository
{
    public interface IRazaRepository
    {
        Task<IEnumerable<Raza>> Get();
        Task<Raza> GetById(int id);
        Task<Raza> Registro(Raza raza);
        Task<Raza> Update(int id, Raza raza);
        Task<Raza> Delete(int id);
    }
}
