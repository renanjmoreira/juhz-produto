using Domain.Enums;
using Domain.Objects;

namespace Domain.Models
{
    public class Produto : Entidade
    {
        public string Codigo { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public string NomeFornecedor { get; private set; }
        public string CodigoFornecedor { get; private set; }
        public Banho Banho { get; private set; }
        public decimal Peso { get; private set; }
        public int MilesimosCamada { get; private set; }
        public decimal Custo { get; private set; }
        public decimal CustoBanho { get; private set; }
        public decimal Margem { get; private set; }
        public decimal Preco { get; private set; }

        private readonly List<Estoque> _estoque = new();
        public IReadOnlyList<Estoque> Estoque => _estoque.AsReadOnly();

        protected Produto() { }

        public Produto(string nome, string descricao, string nomeFornecedor, string codigoFornecedor, Banho banho, decimal peso, int milesimosCamada, decimal custo, decimal custoBanho, decimal margem, decimal preco)
        {
            Nome = nome;
            Descricao = descricao;
            NomeFornecedor = nomeFornecedor;
            CodigoFornecedor = codigoFornecedor;
            Banho = banho;
            Peso = peso;
            MilesimosCamada = milesimosCamada;
            Custo = custo;
            CustoBanho = custoBanho;
            Margem = margem;
            Preco = preco;
        }

        public Produto Alterar(string nome, string descricao, string nomeFornecedor, string codigoFornecedor, Banho banho, decimal peso, int milesimosCamada, decimal custo, decimal custoBanho, decimal margem, decimal preco)
        {
            Nome = nome;
            Descricao = descricao;
            NomeFornecedor = nomeFornecedor;
            CodigoFornecedor = codigoFornecedor;
            Banho = banho;
            Peso = peso;
            MilesimosCamada = milesimosCamada;
            Custo = custo;
            CustoBanho = custoBanho;
            Margem = margem;
            Preco = preco;

            return this;
        }

        public void AdicionarEstoque(string medida, int quantidade)
        {
            var estoque = Estoque.FirstOrDefault(x => x.Medida == medida);
            if (estoque is null)
            {
                estoque = new Estoque(this, medida, quantidade);
                _estoque.Add(estoque);
            }
            else
            {
                estoque.AlterarQuantidade(quantidade);
            }
        }

        public bool ValidarCalculoPreco(Galvanica galvanica)
        {
            var custoBanho = CalcularCustoBanho(galvanica);
            var preco = (Custo + CustoBanho) * (1 + Margem / 100);

            return (CustoBanho == custoBanho && preco == Preco);
        }

        private decimal CalcularCustoBanho(Galvanica galvanica)
        {
            if (Peso > 0)
            {
                if (Banho == Banho.Ouro)
                {
                    return (MilesimosCamada + galvanica.MilesimosMaoObra) * galvanica.CotacaoOuro / 1000 * Peso;
                }
                else
                {
                    return Peso * galvanica.CotacaoRodio / 1000;
                }
            }

            return 0;
        }
    }
}
