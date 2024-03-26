using Microsoft.EntityFrameworkCore;
using rinha_dotnet6.Entities;

namespace rinha_dotnet6.Context
{
    public class AppDbContext : DbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Transaction> Transacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasData(

                new Cliente { Id = 1, Limite = 100000, SaldoInicial = 0 },
                new Cliente { Id = 2, Limite = 80000, SaldoInicial = 0 },
                new Cliente { Id = 3, Limite = 1000000, SaldoInicial = 0 },
                new Cliente { Id = 4, Limite = 10000000, SaldoInicial = 0 },
                new Cliente { Id = 5, Limite = 500000, SaldoInicial = 0 }

            );
        }

    }
}