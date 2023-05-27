using Application.Produtos.Commands;
using Domain.Enums;
using Microsoft.IdentityModel.Tokens;
using System;

namespace ProdutoApi.Filters.Produtos
{
    public class AdicionarProdutoValidation : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var entidade = context.GetArgument<AdicionarProduto>(1);

            if (entidade.Nome.IsNullOrEmpty())
                return await Task.FromResult(Results.BadRequest());

            if (!Guid.TryParse(entidade.IdGalvanica.ToString(), out _))
                return await Task.FromResult(Results.BadRequest());

            if (!Enum.IsDefined(typeof(Banho), entidade.Banho))
                return await Task.FromResult(Results.BadRequest());

            if (entidade.Peso <= 0)
                return await Task.FromResult(Results.BadRequest());

            if (entidade.MilesimosCamada <= 0)
                return await Task.FromResult(Results.BadRequest());

            if (entidade.Custo <= 0)
                return await Task.FromResult(Results.BadRequest());

            if (entidade.Margem <= 0)
                return await Task.FromResult(Results.BadRequest());

            return await next(context);
        }
    }
}
