using Microsoft.EntityFrameworkCore;
using petTrackerApi.Data;
using petTrackerApi.Model;
using petTrackerApi.Repository.IRepository;

namespace petTrackerApi.Repository
{
    public class MedicacionRepository : IMedicacionRepository
    {
        private readonly DBContext _db;

        public MedicacionRepository(DBContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Medicacion>> Get()
        {
            return await _db.Medicaciones.ToListAsync();
        }

        public async Task<Medicacion> GetById(int id)
        {
            return await _db.Medicaciones.FindAsync(id);
        }
        public async Task<Medicacion> Create(Medicacion entity)
        {
            _db.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<Medicacion> Update(Medicacion entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return entity;
        }
        public async Task<Medicacion> Delete(Medicacion entity)
        {
            _db.Medicaciones.Remove(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
        public async Task<IEnumerable<Medicacion>> GetByConsultaId(int consultaId)
        {
            var medicaciones = await _db.Medicaciones
                .Include(m => m.Consulta)
                .ThenInclude(c => c.Mascota)
                .Where(m => m.Consulta.ConsultaClinicaId == consultaId)
                .ToListAsync();

            return medicaciones;
        }

        public async Task<IEnumerable<Medicacion>> GetByMascotaId(int mascotaId)
        {
            var medicaciones = await _db.Medicaciones
                .Include(m => m.Consulta)
                .ThenInclude(c => c.Mascota)
                .Where(m => m.Consulta.MascotaId == mascotaId)
                .ToListAsync();

            return medicaciones;
        }
    }
}
