using Microsoft.EntityFrameworkCore;
using petTrackerApi.Data;
using petTrackerApi.Model;
using petTrackerApi.Repository.IRepository;

namespace petTrackerApi.Repository
{
    public class ControlPesoRepository : IControlPesoRepository
    {
        private readonly DBContext _db;
        public ControlPesoRepository(DBContext db)
        { 
            _db = db;
        }
        public async Task<IEnumerable<ControlPeso>> Get()
        {
            return await _db.ControlPesos.ToListAsync();
        }

        public async Task<ControlPeso> GetById(int id)
        {
            return await _db.ControlPesos.FindAsync(id);
        }
        public async Task<ControlPeso> Create(ControlPeso controlPeso)
        {
            _db.ControlPesos.Add(controlPeso);
            await _db.SaveChangesAsync();
            return controlPeso;
        }

        public async Task<ControlPeso> Update(ControlPeso controlPeso)
        {
            _db.Entry(controlPeso).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return controlPeso;
        }

        public async Task<ControlPeso> Delete(ControlPeso controlPeso)
        {
            _db.ControlPesos.Remove(controlPeso);
            await _db.SaveChangesAsync();
            return controlPeso;
        }

        public async Task<IEnumerable<ControlPeso>> GetControlPesoByIdMascota(int id)
        {
            return await _db.ControlPesos.Where(x => x.MascotaId == id).ToListAsync();
        }
    }
}
