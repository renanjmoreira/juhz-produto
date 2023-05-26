using Application.Galvanicas.Commands;
using Application.Galvanicas.Queries;
using Application.Produtos.Commands;
using Application.Produtos.Queries;
using MediatR;
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

        private async Task<IResult> ObterGalvanicaPorId(IMediator mediator, Guid id)
        {
            var command = new ObterGalvanicaPorId(id);
            var produto = await mediator.Send(command);

            return TypedResults.Ok(produto);
        }

        private async Task<IResult> ObterGalvanicas(IMediator mediator)
        {
            var command = new ObterGalvanicas();
            var produtos = await mediator.Send(command);

            return TypedResults.Ok(produtos);
        }

        private async Task<IResult> AdicionarGalvanica(IMediator mediator, AdicionarGalvanica command)
        {
            await mediator.Send(command);
            return TypedResults.Ok();
        }

        private async Task<IResult> AlterarGalvanica(IMediator mediator, AlterarGalvanica command)
        {
            await mediator.Send(command);
            return TypedResults.Ok();
        }
    }
}
