using Microsoft.EntityFrameworkCore;
using petTrackerApi.Data;
using petTrackerApi.Model;
using petTrackerApi.Repository.IRepository;

namespace petTrackerApi.Repository
{
    public class ExamenMedicoRepository : IExamenMedicoRepository
    {
        private readonly DBContext _db;

        public ExamenMedicoRepository(DBContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<ExamenMedico>> Get()
        {
            return await _db.ExamenMedicos.ToListAsync();
        }

        public async Task<ExamenMedico> GetById(int id)
        {
            return await _db.ExamenMedicos.FindAsync(id);
        }
        public async Task<ExamenMedico> Create(ExamenMedico entity)
        {
            _db.ExamenMedicos.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<ExamenMedico> Update(ExamenMedico entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return entity;
        }
        public async Task<ExamenMedico> Delete(ExamenMedico entity)
        {
            _db.ExamenMedicos.Remove(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<ExamenMedico>> GetByConsultaId(int consultaId)
        {
            return await _db.ExamenMedicos.Where(x => x.ConsultaId == consultaId).ToListAsync();
        }
    }
}
