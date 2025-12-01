using CloudinaryDotNet.Actions;
using Microsoft.EntityFrameworkCore;
using petTrackerApi.Data;
using petTrackerApi.Model;
using petTrackerApi.Repository.GenericRepository;

namespace petTrackerApi.Repository
{
    public class TratamientoRepository: IGenericRepository<Tratamiento>
    {
        private readonly DBContext _db;
        public TratamientoRepository(DBContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Tratamiento>> Get()
        {
            return await _db.Tratamientos.ToListAsync();
        }

        public async Task<Tratamiento> GetById(int id)
        {
            return await _db.Tratamientos.FindAsync(id);
        }


        public async Task<Tratamiento> Create(Tratamiento entity)
        {
            _db.Tratamientos.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<Tratamiento> Delete(Tratamiento entity)
        {
            _db.Tratamientos.Remove(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

      
        public async Task<Tratamiento> Update(Tratamiento entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
