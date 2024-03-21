using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rinha_dotnet6.Context;
using rinha_dotnet6.Entities;

namespace rinha_dotnet6.Service
{
    public class ClientService
    {

        private readonly AppDbContext _context;
        public ClientService(AppDbContext context)
        {
            _context = context;
        }

        public Cliente GetCliente(int Id)
        {
            if (_context == null)
            {
                throw new Exception("_context is null");
            }
            var client = _context.Clientes.FirstOrDefault(c => c.Id == Id)
            ?? throw new Exception($"No client found with id {Id}");
            return client;
        }

        public Cliente UpdateClient(Cliente client)
        {
            _context.Update(client);
            _context.SaveChanges();
            return client;
        }
    }
}