using petTrackerApi.Model;
using Microsoft.EntityFrameworkCore;

namespace petTrackerApi.Data
{
    public class DBContext: DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
