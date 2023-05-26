using Domain.Models;

namespace Application.Abstractions
{
    public interface IProdutoRepository
    {
        Task<ICollection<Produto>> ObterProdutosComEstoque(CancellationToken cancellationToken);
        Task<Produto?> ObterProdutoComEstoque(Guid id, CancellationToken cancellationToken);
        Task Adicionar(Produto entidade, CancellationToken cancellationToken);
        Task Alterar(Produto entidade, CancellationToken cancellationToken);
        Task Deletar(Guid id, CancellationToken cancellationToken);
    }
}
