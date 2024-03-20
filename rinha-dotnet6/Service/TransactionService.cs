using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rinha_dotnet6.Context;
using rinha_dotnet6.Entities;
using rinha_dotnet6.Models;

namespace rinha_dotnet6.Service
{
    public class TransactionService
    {

        private Transaction transaction;

        private AppDbContext _contextClient { get; set; }

        public TransactionService(AppDbContext contextClient)
        {
            _contextClient = contextClient;
        }
        
        public Cliente MakeTransaction(int Id)
        {

            var client = new ClientService(_contextClient).GetCliente(Id) 
            ?? throw new Exception($"No client found with id {Id}");

            return client;

        }

        
    }
}