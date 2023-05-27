using Application.Galvanicas.Commands;
using Application.Galvanicas.Queries;
using Application.Produtos.Commands;
using Application.Produtos.Queries;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProdutoApi.Abstractions;
using ProdutoApi.Filters.Galvanicas;

namespace ProdutoApi.EndpointDefinitions
{
    public class GalvanicasEndpointDefinition : IEndpointDefinition
    {
        public void RegistrarEndpoints(WebApplication app)
        {
            var galvanica = app.MapGroup("/galvanica");

            galvanica.MapGet("/{id}", ObterGalvanicaPorId)
                .WithName("ObterGalvanicaPorId");

            galvanica.MapGet("/", ObterGalvanicas);

            galvanica.MapPost("/", AdicionarGalvanica)
                .AddEndpointFilter<AdicionarGalvanicaValidation>();

            galvanica.MapPut("/", AlterarGalvanica);
        }

        private async Task<Ok<Galvanica>> ObterGalvanicaPorId(IMediator mediator, Guid id)
        {
            var command = new ObterGalvanicaPorId(id);
            var galvanica = await mediator.Send(command);

            return TypedResults.Ok(galvanica);
        }

        private async Task<Ok<ICollection<Galvanica>>> ObterGalvanicas(IMediator mediator)
        {
            var command = new ObterGalvanicas();
            var galvanicas = await mediator.Send(command);

            return TypedResults.Ok(galvanicas);
        }

        private async Task<Ok> AdicionarGalvanica(IMediator mediator, AdicionarGalvanica command)
        {
            await mediator.Send(command);
            return TypedResults.Ok();
        }

        private async Task<Ok> AlterarGalvanica(IMediator mediator, AlterarGalvanica command)
        {
            await mediator.Send(command);
            return TypedResults.Ok();
        }
    }
}
