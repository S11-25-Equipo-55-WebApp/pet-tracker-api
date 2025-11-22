using petTrackerApi.Model;
using Microsoft.EntityFrameworkCore;

namespace petTrackerApi.Data
{
    public class DBContext: DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<Especie> Especies { get; set; }
        public DbSet<Raza> Razas { get; set; }
        public DbSet<FotosMascota> FotosMascotas { get; set; }
    }
}
