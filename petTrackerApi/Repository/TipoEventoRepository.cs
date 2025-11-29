using Microsoft.EntityFrameworkCore;
using petTrackerApi.Data;
using petTrackerApi.Model;
using petTrackerApi.Repository.GenericRepository;

namespace petTrackerApi.Repository
{
    public class TipoEventoRepository : IGenericRepository<TipoEvento>
    {
        private readonly DBContext _db;
        public TipoEventoRepository(DBContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<TipoEvento>> Get()
        {
            return await _db.TipoEventos.ToListAsync();
        }

        public async Task<TipoEvento> GetById(int id)
        {
            return await _db.TipoEventos.FindAsync(id);
        }
        public async Task<TipoEvento> Create(TipoEvento entity)
        {
            _db.TipoEventos.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<TipoEvento> Delete(TipoEvento entity)
        {
            _db.TipoEventos.Remove(entity);
            await _db.SaveChangesAsync();
            return entity;
        }


        public async Task<TipoEvento> Update(TipoEvento entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
