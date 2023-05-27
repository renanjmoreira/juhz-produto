using Application.Abstractions;
using Application.Produtos.Commands;
using Infrastructure;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProdutoApi.Abstractions;

namespace ProdutoApi.Extensions
{
    public static class DependencyInjections
    {
        public static void RegistrarContexto(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("Default");
            builder.Services.AddDbContext<ProdutoContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
            builder.Services.AddScoped<IGalvanicaRepository, GalvanicaRepository>();

            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblyContaining<IProdutoRepository>();
            });
        }

        public static void ExecutarMigrations(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<ProdutoContext>();
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
            }
        }

        public static void RegistrarEndpointDefinitions(this WebApplication app)
        {
            var endpointDefinitions = typeof(Program).Assembly
                .GetTypes()
                .Where(x => x.IsAssignableTo(typeof(IEndpointDefinition)) && !x.IsAbstract && !x.IsInterface)
                .Select(Activator.CreateInstance)
                .Cast<IEndpointDefinition>();

            foreach (var item in endpointDefinitions)
            {
                item.RegistrarEndpoints(app);
            }
        }
    }
}
