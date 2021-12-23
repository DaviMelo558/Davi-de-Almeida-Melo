using Microsoft.EntityFrameworkCore;
using RecodeTrip.Models;

namespace RecodeTrip.Data
{
    public class ViagemContext: DbContext
    {
        public ViagemContext(DbContextOptions<ViagemContext> opt): base(opt)
        {
        }
        public DbSet<Viagem> Viagens { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Companhia> Companhias{ get; set; }
    }
}