using Application.Abstractions;
using Application.Produtos.Queries;
using Domain.Models;
using MediatR;

namespace Application.Produtos.QueryHandlers
{
    internal class ObterProdutosHandler : IRequestHandler<ObterProdutos, ICollection<Produto>>
    {
        private readonly IProdutoRepository _repositorio;

        public ObterProdutosHandler(IProdutoRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<ICollection<Produto>> Handle(ObterProdutos request, CancellationToken cancellationToken)
        {
            return await _repositorio.ObterProdutosComEstoque(cancellationToken);
        }
    }
}
