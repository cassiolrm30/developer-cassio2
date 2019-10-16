using Microsoft.EntityFrameworkCore;

namespace API_Processos_Core.Models
{
    public class Contexto : DbContext
    {
        public Contexto()
        {

        }

        public Contexto(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Escritorio> Escritorios { get; set; }
        public DbSet<Processo> Processos { get; set; }
    }
}