using petTrackerApi.Model;

namespace petTrackerApi.Repository.IRepository
{
    public interface IEspecieRepository
    {
        Task<IEnumerable<Especie>> Get();
        Task<Especie> GetById(int id);
        Task<Especie> Registro(Especie especie);
        Task<Especie> Update(int id, Especie especie);
        Task<Especie> Delete(int id);
    }
}
