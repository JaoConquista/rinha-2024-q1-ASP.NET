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

        private AppDbContext _context { get; set; }

        public TransactionService(AppDbContext contextClient)
        {
            _context = contextClient;
        }

        private string SaveTransaction(Transaction transaction, int client_id)
        {
            var transactionToSave = new Transaction {
                Client_Id = client_id,
                Valor = transaction.Valor,
                Tipo = transaction.Tipo,
                Descricao = transaction.Descricao,
                Data = DateTime.UtcNow
            };
            _context.Transacoes.Add(transactionToSave);
            _context.SaveChanges();

            return "Transação cadastrada com sucesso";
        }

        public Cliente MakeTransaction(int Id, Transaction transaction)
        {

            var client = new ClientService(_context).GetCliente(Id);

            var save =  new TransactionService(_context);


            if (transaction.Tipo == "d")
            {
                var diference = client.Limite + client.Saldo;

                Console.WriteLine("Limite: " + client.Limite);
                Console.WriteLine("SaldoInicial: " + client.Saldo);
                Console.WriteLine("diferença: " + diference);
                
                
                if(transaction.Valor > diference)
                {

                    throw new Exception("Limite no máximo");

                }

                else if (transaction.Valor <= client.Limite || transaction.Valor <= client.Saldo)
                {
                    client.Saldo -= transaction.Valor;

                    save.SaveTransaction(transaction, client.Id);

                    return new ClientService(_context).UpdateClient(client);
                }

                throw new Exception("Transação não permitida");

            }
            else if (transaction.Tipo == "c")
            {
                client.Saldo += transaction.Valor;

                save.SaveTransaction(transaction, client.Id);

                new ClientService(_context).UpdateClient(client);
            }
            else
            {
                throw new Exception("Transação não permitida");
            }

            return client;

        }

        public List<Transaction> GetTransactions()
        {
            var transactions = _context.Transacoes.ToList();

            return transactions;

        }

    }
}