using Microsoft.EntityFrameworkCore;
using petTrackerApi.Data;
using petTrackerApi.Model;

namespace petTrackerApi.Repository
{
    public class MascotaRepository : IMascotaRepository
    {
        private readonly DBContext _db;

        public MascotaRepository(DBContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Mascota>> Get()
        {
            return await _db.Mascota.ToListAsync();
        }

        public async Task<Mascota> GetById(int id)
        {
            return await _db.Mascota.FindAsync(id);
        }

        public async Task<Mascota> Registro(Mascota mascota)
        {
            _db.Mascota.Add(mascota);
            await _db.SaveChangesAsync();
            return mascota;
        }

        public async Task<Mascota> Update(int id, Mascota mascota)
        {
            var mascotaDB = await _db.Mascota.FindAsync(id);
            if (mascotaDB == null) return null;

            mascotaDB.Nombre = mascota.Nombre;
            mascotaDB.FechaNacimiento = mascota.FechaNacimiento;
            mascotaDB.EspecieId = mascota.EspecieId;
            mascotaDB.RazaId = mascota.RazaId;
            mascotaDB.FotoMascotaId = mascota.FotoMascotaId;
            mascotaDB.EditadoAt = DateTime.Now;

            await _db.SaveChangesAsync();
            return mascotaDB;
        }
        public async Task<Mascota> Delete(int id)
        {
            var mascotaDB = await _db.Mascota.FindAsync(id);
            if (mascotaDB == null) return null;

            _db.Mascota.Remove(mascotaDB);
            await _db.SaveChangesAsync();

            return mascotaDB;
        }
    }
}
