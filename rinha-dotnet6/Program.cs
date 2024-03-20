using Microsoft.EntityFrameworkCore;
using rinha_dotnet6.Context;
using rinha_dotnet6.Entities;
using rinha_dotnet6.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/clientes/{id}/transacoes", (int id, AppDbContext context) => {
    var transaction = new TransactionService(context).MakeTransaction(id);
    return Results.Ok(transaction);
});

app.Run();
