using Microsoft.EntityFrameworkCore;
using petTrackerApi.Data;
using petTrackerApi.Model;
using petTrackerApi.Repository.GenericRepository;

namespace petTrackerApi.Repository
{
    public class TipoAlimentoRepository : IGenericRepository<TipoAlimento>
    {
        private readonly DBContext _db;

        public TipoAlimentoRepository(DBContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<TipoAlimento>> Get()
        {
            return await _db.TipoAlimentos.ToListAsync();
        }

        public async Task<TipoAlimento> GetById(int id)
        {
            return await _db.TipoAlimentos.FindAsync(id);
        }
        public Task<TipoAlimento> Create(TipoAlimento entity)
        {
            throw new NotImplementedException();
        }

        public Task<TipoAlimento> Update(TipoAlimento entity)
        {
            throw new NotImplementedException();
        }
        public Task<TipoAlimento> Delete(TipoAlimento entity)
        {
            throw new NotImplementedException();
        }
    }
}
