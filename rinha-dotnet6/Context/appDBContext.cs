using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using rinha_dotnet6.Models;

namespace rinha_dotnet6.Context
{
    public class AppDBContext : DbContext


    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        DbSet<Cliente> Clientes { get; set; }
        DbSet<Transaction> Transacoes { get; set; }
        DbSet<Extrato> Extratos { get; set; }
    

    }
}