using Application.Produtos.Commands;
using Application.Produtos.Queries;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using ProdutoApi.Abstractions;
using ProdutoApi.Filters.Produtos;

namespace ProdutoApi.EndpointDefinitions
{
    public class ProdutosEndpointDefinition : IEndpointDefinition
    {
        public void RegistrarEndpoints(WebApplication app)
        {
            var produto = app.MapGroup("/produto");

            produto.MapGet("/{id}", ObterProdutoPorId)
                .WithName("ObterProdutoPorId");

            produto.MapGet("/", ObterProdutos);

            produto.MapPost("/", AdicionarProduto)
                .AddEndpointFilter<AdicionarProdutoValidation>();

            produto.MapPut("/", AlterarProduto);
        }

        private async Task<Ok<Produto>> ObterProdutoPorId(IMediator mediator, Guid id)
        {
            var command = new ObterProdutoPorId(id);
            var produto = await mediator.Send(command);

            return TypedResults.Ok(produto);
        }

        private async Task<Ok<ICollection<Produto>>> ObterProdutos(IMediator mediator)
        {
            var command = new ObterProdutos();
            var produtos = await mediator.Send(command);

            return TypedResults.Ok(produtos);
        }

        private async Task<Ok> AdicionarProduto(IMediator mediator, AdicionarProduto command)
        {
            await mediator.Send(command);
            return TypedResults.Ok();
        }

        private async Task<Ok> AlterarProduto(IMediator mediator, AlterarProduto command)
        {
            await mediator.Send(command);
            return TypedResults.Ok();
        }
    }
}
