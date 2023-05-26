using Application.Galvanicas.Commands;
using Application.Galvanicas.Queries;
using MediatR;
using ProdutoApi.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.RegistrarContexto();

var app = builder.Build();

app.ExecutarMigrations();

app.UseHttpsRedirection();

app.RegistrarEndpointDefinitions();

app.Run();
