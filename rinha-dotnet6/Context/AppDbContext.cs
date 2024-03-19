using Microsoft.EntityFrameworkCore;
using rinha_dotnet6.Entities;

namespace rinha_dotnet6.Context
{
    public class AppDbContext : DbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        DbSet<Cliente> Clientes { get; set; }
        DbSet<Transaction> Transacoes { get; set; }
    
    }
}