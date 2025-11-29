using Microsoft.EntityFrameworkCore;
using petTrackerApi.Data;
using petTrackerApi.Model;
using petTrackerApi.Repository.IRepository;

namespace petTrackerApi.Repository
{
    public class EspecieRepository : IEspecieRepository
    {
        private readonly DBContext _db;

        public EspecieRepository(DBContext db)
        {
            _db = db;
        }


        public async Task<IEnumerable<Especie>> Get()
        {
            return await _db.Especies.ToListAsync();
        }

        public async Task<Especie> GetById(int id)
        {
            return await _db.Especies.FindAsync(id);
        }

        public Task<Especie> Registro(Especie especie)
        {
            throw new NotImplementedException();
        }

        public Task<Especie> Update(int id, Especie especie)
        {
            throw new NotImplementedException();
        }
        public Task<Especie> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
