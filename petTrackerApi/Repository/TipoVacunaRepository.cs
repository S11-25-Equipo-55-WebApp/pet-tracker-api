using Microsoft.EntityFrameworkCore;
using petTrackerApi.Data;
using petTrackerApi.Model;
using petTrackerApi.Repository.GenericRepository;

namespace petTrackerApi.Repository
{
    public class TipoVacunaRepository : IGenericRepository<TipoVacuna>
    {
        private readonly DBContext _db;

        public TipoVacunaRepository(DBContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<TipoVacuna>> Get()
        {
            return await _db.TipoVacunas.ToListAsync();
        }

        public async Task<TipoVacuna> GetById(int id)
        {
            return await _db.TipoVacunas.FindAsync(id);
        }

        public Task<TipoVacuna> Create(TipoVacuna entity)
        {
            throw new NotImplementedException();
        }

        public Task<TipoVacuna> Update(TipoVacuna entity)
        {
            throw new NotImplementedException();
        }
        public Task<TipoVacuna> Delete(TipoVacuna entity)
        {
            throw new NotImplementedException();
        }
    }
}
