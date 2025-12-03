using Microsoft.EntityFrameworkCore;
using petTrackerApi.Data;
using petTrackerApi.Model;
using petTrackerApi.Repository.GenericRepository;

namespace petTrackerApi.Repository
{
    public class TipoExamenRepository : IGenericRepository<TipoExamen>
    {
        private readonly DBContext _db;
        public TipoExamenRepository(DBContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<TipoExamen>> Get()
        {
            return await _db.TipoExamen.ToListAsync();
        }

        public async Task<TipoExamen> GetById(int id)
        {
            
            return await _db.TipoExamen.FindAsync(id);
        }

        public async Task<TipoExamen> Update(TipoExamen entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return entity;
        }
        public async Task<TipoExamen> Create(TipoExamen entity)
        {
            _db.TipoExamen.Add(entity);
            await _db.SaveChangesAsync();
            return entity;  
        }

        public async Task<TipoExamen> Delete(TipoExamen entity)
        {
            _db.TipoExamen.Remove(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

       

       
    }
}
