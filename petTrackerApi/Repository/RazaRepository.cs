using Microsoft.EntityFrameworkCore;
using petTrackerApi.Data;
using petTrackerApi.Model;
using petTrackerApi.Repository.GenericRepository;
using petTrackerApi.Repository.IRepository;

namespace petTrackerApi.Repository
{
    public class RazaRepository : IGenericRepository<Raza>
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
        public Task<Raza> Create(Raza entity)
        {
            throw new NotImplementedException();
        }

        public Task<Raza> Update(Raza entity)
        {
            throw new NotImplementedException();
        }
        public Task<Raza> Delete(Raza entity)
        {
            throw new NotImplementedException();
        }
    }
}
