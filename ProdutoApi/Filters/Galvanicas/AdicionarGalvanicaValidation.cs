using Application.Galvanicas.Commands;
using Domain.Enums;
using Microsoft.IdentityModel.Tokens;

namespace ProdutoApi.Filters.Galvanicas
{
    public class AdicionarGalvanicaValidation : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var entidade = context.GetArgument<AdicionarGalvanica>(1);

            if (entidade.Nome.IsNullOrEmpty())
                return await Task.FromResult(Results.BadRequest());

            if (entidade.Contato.IsNullOrEmpty())
                return await Task.FromResult(Results.BadRequest());

            if (entidade.MilesimosMaoObra <= 0)
                return await Task.FromResult(Results.BadRequest());

            if (entidade.CotacaoOuro <= 0)
                return await Task.FromResult(Results.BadRequest());

            if (entidade.CotacaoRodio <= 0)
                return await Task.FromResult(Results.BadRequest());

            return await next(context);
        }
    }
}
