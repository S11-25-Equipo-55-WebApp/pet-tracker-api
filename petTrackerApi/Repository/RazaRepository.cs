using Microsoft.EntityFrameworkCore;
using petTrackerApi.Data;
using petTrackerApi.Model;
using petTrackerApi.Repository.IRepository;

namespace petTrackerApi.Repository
{
    public class RazaRepository : IRazaRepository
    {
        private readonly DBContext _db;

        public RazaRepository(DBContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Raza>> Get()
        {
            return await _db.Razas.ToListAsync();
        }

        public async Task<Raza> GetById(int id)
        {
            return await _db.Razas.FindAsync(id);
        }

        public Task<Raza> Registro(Raza raza)
        {
            throw new NotImplementedException();
        }

        public Task<Raza> Update(int id, Raza raza)
        {
            throw new NotImplementedException();
        }
        public Task<Raza> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
