using Microsoft.EntityFrameworkCore;
using petTrackerApi.Data;
using petTrackerApi.Model;
using petTrackerApi.Repository.GenericRepository;

namespace petTrackerApi.Repository
{
    public class CalendarioRepository : IGenericRepository<Calendario>
    {
        private readonly DBContext _db;
        public CalendarioRepository(DBContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Calendario>> Get()
        {
            return await _db.Calendarios.ToListAsync();
        }

        public async Task<Calendario> GetById(int id)
        {
            return await _db.Calendarios.FindAsync(id);
        }
        public async Task<Calendario> Create(Calendario entity)
        {
            _db.Calendarios.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<Calendario> Delete(Calendario entity)
        {
            _db.Calendarios.Remove(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

     

        public async Task<Calendario> Update(Calendario entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
