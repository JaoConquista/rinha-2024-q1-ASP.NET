using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rinha_dotnet6.Entities;
using rinha_dotnet6.Models;

namespace rinha_dotnet6.Service
{
    public class TransactionService
    {

        public int ClientId { get; set; }

        private Transaction transaction;
        
        public TransactionService(int Id, Transaction transaction)
        {
            ClientId = Id;
            transaction = transaction;
        }

        
    }
}