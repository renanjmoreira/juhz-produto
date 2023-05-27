using Domain.Enums;
using Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Produtos.Commands
{
    public class AlterarProduto : IRequest
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Guid IdGalvanica { get; set; }
        public string NomeFornecedor { get; set; }
        public string CodigoFornecedor { get; set; }
        public Banho Banho { get; set; }
        public decimal Peso { get; set; }
        public int MilesimosCamada { get; set; }
        public decimal Custo { get; set; }
        public decimal CustoBanho { get; set; }
        public decimal Margem { get; set; }
        public decimal Preco { get; set; }
        public List<EstoqueAdicionarProduto> Estoque { get; set; }

        public Produto ObterProdutoAlterado(Produto produto) => produto.Alterar(Nome, Descricao, NomeFornecedor, CodigoFornecedor, Banho, Peso, MilesimosCamada, Custo, CustoBanho, Margem, Preco);
    }

    public class EstoqueEditarProduto
    {
        public Guid Id { get; set; }
        public string Medida { get; set; }
        public int Quantidade { get; set; }
    }
}
