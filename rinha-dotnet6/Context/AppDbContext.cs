using Microsoft.EntityFrameworkCore;
using rinha_dotnet6.Entities;

namespace rinha_dotnet6.Context
{
    public class AppDbContext : DbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Cliente)
                .WithMany()
                .HasForeignKey(t => t.Client_Id);

            modelBuilder.Entity<Cliente>().HasData(
                new Cliente { Id = 1, Limite = 100000, Saldo = 0 },
                new Cliente { Id = 2, Limite = 80000, Saldo = 0 },
                new Cliente { Id = 3, Limite = 1000000, Saldo = 0 },
                new Cliente { Id = 4, Limite = 10000000, Saldo = 0 },
                new Cliente { Id = 5, Limite = 500000, Saldo = 0 }
            );
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Transaction> Transacoes { get; set; }

    }
}