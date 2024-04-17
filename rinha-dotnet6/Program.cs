using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using rinha_dotnet6.Context;
using rinha_dotnet6.Entities;
using rinha_dotnet6.Service;

DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

Environment.SetEnvironmentVariable("DEFAULT_CONNECTION", DotNetEnv.Env.GetString("DEFAULT_CONNECTION"));

var connectionString = DotNetEnv.Env.GetString("DEFAULT_CONNECTION");


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();

var transaction = new Transaction();



app.MapGet("/", (AppDbContext context) => {
    var getClients = new ClientService(context).GetClients();
    return Results.Ok(getClients);
});

app.MapGet("/transactions", (AppDbContext context) => {
    var getTransactions = new TransactionService(context).GetTransactions();
    return Results.Ok(getTransactions);
});

app.MapPost("/clientes/{id}/transacoes", (int id, AppDbContext context, Transaction transaction) => {

    var makeTransaction = new TransactionService(context).MakeTransaction(id, transaction);

    var client = new Dictionary<string, object>
    {
        ["limite"] = makeTransaction.Limite,
        ["saldo"] = makeTransaction.Saldo
    };

    return Results.Ok(client);
});

app.Run();
