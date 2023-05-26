using Domain.Models;
using MediatR;

namespace Application.Produtos.Queries
{
    public class ObterProdutos : IRequest<ICollection<Produto>>
    {
    }
}
