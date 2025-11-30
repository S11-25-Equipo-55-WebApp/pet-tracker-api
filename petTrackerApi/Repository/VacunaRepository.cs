using Microsoft.EntityFrameworkCore;
using petTrackerApi.Data;
using petTrackerApi.Model;
using petTrackerApi.Repository.IRepository;

namespace petTrackerApi.Repository
{
    public class VacunaRepository : IVacunaRepository
    {
        public readonly DBContext _db;

        public VacunaRepository(DBContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Vacuna>> Get()
        {
            return await _db.Vacunas.ToListAsync();
        }

        public async Task<Vacuna> GetById(int id)
        {
            return await _db.Vacunas.FindAsync(id);
        }
        public async Task<Vacuna> Create(Vacuna vacuna)
        {
            _db.Add(vacuna);
            await _db.SaveChangesAsync();
            return vacuna;
        }
        public async Task<Vacuna> Update(Vacuna vacuna)
        {
            _db.Entry(vacuna).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return vacuna;
        }

        public async Task<Vacuna> Delete(Vacuna vacuna)
        {
            _db.Vacunas.Remove(vacuna);
            await _db.SaveChangesAsync();
            return vacuna;
        }

        public async Task<IEnumerable<Vacuna>> GetVacunasByIdMascota(int id)
        {
            return await _db.Vacunas.Where(x => x.MascotaId == id).ToListAsync();
        }
    }
}
