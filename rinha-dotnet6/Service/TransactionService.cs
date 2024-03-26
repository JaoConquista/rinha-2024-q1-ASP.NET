using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        private string SaveTransaction(Transaction transaction)
        {
            _contextClient.Transacoes.Add(transaction);
            _contextClient.SaveChanges();

            return "Transação cadastrada com sucesso";
        }

        public Cliente MakeTransaction(int Id, Transaction transaction)
        {

            var client = new ClientService(_contextClient).GetCliente(Id);

            if (transaction.Tipo == "d")
            {
                var diference = client.Limite + client.SaldoInicial;

                Console.WriteLine("Limite: " + client.Limite);
                Console.WriteLine("SaldoInicial: " + client.SaldoInicial);
                Console.WriteLine("diferença: " + diference);
                
                
                if(transaction.Valor > diference)
                {

                    throw new Exception("Limite no máximo");

                }

                else if (transaction.Valor <= client.Limite || transaction.Valor <= client.SaldoInicial)
                {
                    client.SaldoInicial -= transaction.Valor;

                    return new ClientService(_contextClient).UpdateClient(client);
                }

                throw new Exception("Transação não permitida");

            }
            else if (transaction.Tipo == "c")
            {
                client.SaldoInicial += transaction.Valor;

                new ClientService(_contextClient).UpdateClient(client);
            }
            else
            {
                throw new Exception("Transação não permitida");
            }

            var save = new TransactionService(_contextClient);

            save.SaveTransaction(transaction);

            return client;

        }



    }
}