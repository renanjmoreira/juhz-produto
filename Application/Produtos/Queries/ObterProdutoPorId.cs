using Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Produtos.Queries
{
    public class ObterProdutoPorId : IRequest<Produto?>
    {
        public ObterProdutoPorId(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
