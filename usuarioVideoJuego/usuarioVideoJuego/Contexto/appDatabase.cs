using Microsoft.EntityFrameworkCore;
using usuarioVideoJuego.Modelo;

namespace usuarioVideoJuego.Contexto
{
    public class appDatabase:DbContext
    {
        public appDatabase(DbContextOptions<appDatabase> options)
           : base(options)
        {

        }
        public DbSet<usuario> usuario { get; set; }
        public DbSet<email> email { get; set; }
        public DbSet<videoJuego> videoJuegos { get; set; }
    }
}
