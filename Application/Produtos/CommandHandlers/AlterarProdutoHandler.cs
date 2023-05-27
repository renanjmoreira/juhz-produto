using Application.Abstractions;
using Application.Produtos.Commands;
using MediatR;

namespace Application.Produtos.CommandHandlers
{
    internal class AlterarProdutoHandler : IRequestHandler<AlterarProduto>
    {
        private readonly IProdutoRepository _repositorio;
        private readonly IGalvanicaRepository _repositorioGalvanica;

        public AlterarProdutoHandler(IProdutoRepository repositorio, IGalvanicaRepository repositorioGalvanica)
        {
            _repositorio = repositorio;
            _repositorioGalvanica = repositorioGalvanica;
        }

        public async Task Handle(AlterarProduto request, CancellationToken cancellationToken)
        {
            var galvanica = await _repositorioGalvanica.ObterGalvanica(request.IdGalvanica, cancellationToken) ?? throw new Exception("Galvanica não encontrado.");
            var produto = await _repositorio.ObterProdutoComEstoque(request.Id, cancellationToken) ?? throw new Exception("Produto não encontrado");

            produto = request.ObterProdutoAlterado(produto);
            foreach (var estoque in request.Estoque)
            {
                produto.AdicionarEstoque(estoque.Medida, estoque.Quantidade);
            } 

            if (!produto.ValidarCalculoPreco(galvanica))
            {
                throw new Exception("Calculo de Preço inválido.");
            }

            await _repositorio.Alterar(produto, cancellationToken);
        }
    }
}
