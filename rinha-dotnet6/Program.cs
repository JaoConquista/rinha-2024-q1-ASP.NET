using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using rinha_dotnet6.Context;
using rinha_dotnet6.Entities;
using rinha_dotnet6.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();

var transaction = new Transaction();



app.MapGet("/", (AppDbContext context) => {
    var getClients = new ClientService(context).GetClients();
    return Results.Ok(getClients);
});

app.MapPost("/clientes/{id}/transacoes", (int id, AppDbContext context, Transaction transaction) => {

    var makeTransaction = new TransactionService(context).MakeTransaction(id, transaction);

    var client = new Dictionary<string, object>
    {
        ["limite"] = makeTransaction.Limite,
        ["saldo"] = makeTransaction.SaldoInicial
    };

    return Results.Ok(client);
});

app.Run();
