using Microsoft.EntityFrameworkCore;
using petTrackerApi.Data;
using petTrackerApi.Model;
using petTrackerApi.Repository.GenericRepository;

namespace petTrackerApi.Repository
{
    public class TipoMedicamentoRepository : IGenericRepository<TipoMedicamento>
    {
        private readonly DBContext _db;

        public TipoMedicamentoRepository(DBContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<TipoMedicamento>> Get()
        {
            return await _db.TipoMedicamentos.ToListAsync();
        }

        public async Task<TipoMedicamento> GetById(int id)
        {
            return await _db.TipoMedicamentos.FindAsync(id);
        }

        public async Task<TipoMedicamento> Create(TipoMedicamento entity)
        {
            _db.TipoMedicamentos.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
        public async Task<TipoMedicamento> Update(TipoMedicamento entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<TipoMedicamento> Delete(TipoMedicamento entity)
        {
            _db.TipoMedicamentos.Remove(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
