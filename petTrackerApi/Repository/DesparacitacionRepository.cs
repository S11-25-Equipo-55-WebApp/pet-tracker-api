using Microsoft.EntityFrameworkCore;
using petTrackerApi.Data;
using petTrackerApi.Model;
using petTrackerApi.Repository.GenericRepository;
using petTrackerApi.Repository.IRepository;

namespace petTrackerApi.Repository
{
    public class DesparacitacionRepository : IDesparacitacionRepository
    {
        private readonly DBContext _db;

        public DesparacitacionRepository(DBContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Desparacitacion>> Get()
        {
            return await _db.Desparacitaciones.ToListAsync();
        }

        public async Task<Desparacitacion> GetById(int id)
        {
            return await _db.Desparacitaciones.FindAsync(id);
        }
        public async Task<Desparacitacion> Create(Desparacitacion desparacitacion)
        {
            _db.Add(desparacitacion);
            await _db.SaveChangesAsync();
            return desparacitacion;
        }
        public async Task<Desparacitacion> Update(Desparacitacion desparacitacion)
        {
            _db.Entry(desparacitacion).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return desparacitacion;
        }

        public async Task<Desparacitacion> Delete(Desparacitacion desparacitacion)
        {
            _db.Desparacitaciones.Remove(desparacitacion);
            await _db.SaveChangesAsync();
            return desparacitacion;
        }

        public async Task<IEnumerable<Desparacitacion>> GetDesparacitacionesByIdMascota(int id)
        {
            return await _db.Desparacitaciones.Where(x => x.MascotaId == id).ToListAsync();
        }

    }
}
