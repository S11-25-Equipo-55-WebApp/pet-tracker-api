using Microsoft.EntityFrameworkCore;
using petTrackerApi.Data;
using petTrackerApi.Model;
using petTrackerApi.Repository.GenericRepository;
using petTrackerApi.Repository.IRepository;

namespace petTrackerApi.Repository
{
    public class ConsultaClinicaRepository : IConsultaClinicaRepository
    {
        private readonly DBContext _db;
        public ConsultaClinicaRepository(DBContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<ConsultaClinica>> Get()
        {
            return await _db.ConsultaClinicas.ToListAsync();
        }

        public async Task<ConsultaClinica> GetById(int id)
        {
            return await _db.ConsultaClinicas.FindAsync(id);
        }

        public async Task<ConsultaClinica> Create(ConsultaClinica consulta)
        {
            _db.ConsultaClinicas.Add(consulta);
            await _db.SaveChangesAsync();
            return consulta;
        }
        public async Task<ConsultaClinica> Update(ConsultaClinica consulta)
        {
            _db.Entry(consulta).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return consulta;
        }

        public async Task<ConsultaClinica> Delete(ConsultaClinica consulta)
        {
            _db.ConsultaClinicas.Remove(consulta);
            await _db.SaveChangesAsync();
            return consulta;
        }

        public async Task<IEnumerable<ConsultaClinica>> GetConsultasByIdMascota(int id)
        {
            return await _db.ConsultaClinicas.Where(x => x.MascotaId == id).ToListAsync();
        }
    }
}
