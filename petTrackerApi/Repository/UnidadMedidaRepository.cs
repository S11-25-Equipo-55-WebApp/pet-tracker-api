using Microsoft.EntityFrameworkCore;
using petTrackerApi.Data;
using petTrackerApi.Model;
using petTrackerApi.Repository.GenericRepository;

namespace petTrackerApi.Repository
{
    public class UnidadMedidaRepository : IGenericRepository<UnidadMedida>
    {
        private readonly DBContext _db;

        public UnidadMedidaRepository(DBContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<UnidadMedida>> Get()
        {
            return await _db.UnidadesMedidas.ToListAsync();
        }

        public async Task<UnidadMedida> GetById(int id)
        {
            return await _db.UnidadesMedidas.FindAsync(id);
        }

        public Task<UnidadMedida> Create(UnidadMedida entity)
        {
            throw new NotImplementedException();
        }
        public Task<UnidadMedida> Update(UnidadMedida entity)
        {
            throw new NotImplementedException();
        }

        public Task<UnidadMedida> Delete(UnidadMedida entity)
        {
            throw new NotImplementedException();
        }
    }
}
