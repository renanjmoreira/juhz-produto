using Application.Abstractions;
using Application.Produtos.Queries;
using Domain.Models;
using MediatR;

namespace Application.Produtos.QueryHandlers
{
    internal class ObterProdutoPorIdHandler : IRequestHandler<ObterProdutoPorId, Produto?>
    {
        private readonly IProdutoRepository _repositorio;

        public ObterProdutoPorIdHandler(IProdutoRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<Produto?> Handle(ObterProdutoPorId request, CancellationToken cancellationToken)
        {
            return await _repositorio.ObterProdutoComEstoque(request.Id, cancellationToken);
        }
    }
}
