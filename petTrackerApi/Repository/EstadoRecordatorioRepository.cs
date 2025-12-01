using Microsoft.EntityFrameworkCore;
using petTrackerApi.Data;
using petTrackerApi.Model;
using petTrackerApi.Repository.GenericRepository;

namespace petTrackerApi.Repository
{
    public class EstadoRecordatorioRepository : IGenericRepository<EstadoRecordatorio>
    {
        private readonly DBContext _db;
        public EstadoRecordatorioRepository(DBContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<EstadoRecordatorio>> Get()
        {
            return await _db.EstadoRecordatorios.ToListAsync();
        }

        public async Task<EstadoRecordatorio> GetById(int id)
        {
            return await _db.EstadoRecordatorios.FindAsync(id);
        }

        public async Task<EstadoRecordatorio> Create(EstadoRecordatorio entity)
        {
            _db.EstadoRecordatorios.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<EstadoRecordatorio> Delete(EstadoRecordatorio entity)
        {
            _db.EstadoRecordatorios.Remove(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

      
        public async Task<EstadoRecordatorio> Update(EstadoRecordatorio entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
