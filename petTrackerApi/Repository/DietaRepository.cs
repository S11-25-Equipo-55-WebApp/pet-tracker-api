using Microsoft.EntityFrameworkCore;
using petTrackerApi.Data;
using petTrackerApi.Model;
using petTrackerApi.Repository.IRepository;

namespace petTrackerApi.Repository
{
    public class DietaRepository : IDietaRepository
    {
        private readonly DBContext _db;

        public DietaRepository(DBContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Dieta>> Get()
        {
            return await _db.Dietas.ToListAsync();
        }

        public async Task<Dieta> GetById(int id)
        {
            return await _db.Dietas.FindAsync(id);
        }
        public async Task<Dieta> Create(Dieta dieta)
        {
            _db.Dietas.Add(dieta);
            await _db.SaveChangesAsync();
            return dieta;
        }

        public async Task<Dieta> Update(Dieta dieta)
        {
            _db.Entry(dieta).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return dieta;
        }
        public async Task<Dieta> Delete(Dieta dieta)
        {
            _db.Dietas.Remove(dieta);
            await _db.SaveChangesAsync();
            return dieta;
        }

        public async Task<IEnumerable<Dieta>> GetDietasByIdMascota(int id)
        {
            return await _db.Dietas.Where(x => x.MascotaId == id).ToListAsync();
        }
    }
}
