using Microsoft.EntityFrameworkCore;
using petTrackerApi.Data;
using petTrackerApi.Helpers;
using petTrackerApi.Model;
using petTrackerApi.Repository.GenericRepository;

namespace petTrackerApi.Repository
{
    public class MascotaRepository : IGenericRepository<Mascota>
    {
        private readonly DBContext _db;

        public MascotaRepository(DBContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Mascota>> Get()
        {
            return await _db.Mascota.ToListAsync();
        }

        public async Task<Mascota> GetById(int id)
        {
            return await _db.Mascota.FindAsync(id);
        }

        public async Task<Mascota> Create(Mascota mascota)
        {
            _db.Mascota.Add(mascota);
            await _db.SaveChangesAsync();
            return mascota;
        }

        public async Task<Mascota> Update(int id, Mascota mascota)
        {
            await _db.SaveChangesAsync();
            return mascota;
        }
        public async Task<Mascota> Delete(Mascota mascota)
        {
            _db.Mascota.Remove(mascota);
            await _db.SaveChangesAsync();
            return mascota;
        }
    }
}
