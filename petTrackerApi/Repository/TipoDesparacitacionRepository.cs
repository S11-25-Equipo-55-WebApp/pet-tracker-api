using Microsoft.EntityFrameworkCore;
using petTrackerApi.Data;
using petTrackerApi.Model;
using petTrackerApi.Repository.GenericRepository;

namespace petTrackerApi.Repository
{
    public class TipoDesparacitacionRepository : IGenericRepository<TipoDesparacitacion>
    {
        private readonly DBContext _db;

        public TipoDesparacitacionRepository(DBContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<TipoDesparacitacion>> Get()
        {
            return await _db.TipoDesparacitaciones.ToListAsync();
        }

        public async Task<TipoDesparacitacion> GetById(int id)
        {
            return await _db.TipoDesparacitaciones.FindAsync(id);
        }
        public Task<TipoDesparacitacion> Create(TipoDesparacitacion entity)
        {
            throw new NotImplementedException();
        }

        public Task<TipoDesparacitacion> Update(TipoDesparacitacion entity)
        {
            throw new NotImplementedException();
        }

        public Task<TipoDesparacitacion> Delete(TipoDesparacitacion entity)
        {
            throw new NotImplementedException();
        }
    }
}
