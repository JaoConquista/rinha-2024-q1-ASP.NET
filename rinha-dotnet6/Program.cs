using Microsoft.EntityFrameworkCore;
using rinha_dotnet6.Context;
using rinha_dotnet6.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();

Console.WriteLine("Port : " + app.Configuration["port"]);

app.MapGet("/", () => "Hello World!");

app.MapPost("/clientes/{id}/transacoes", () => {
    return "post method";
});

app.Run();
