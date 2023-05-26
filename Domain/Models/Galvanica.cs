using Domain.Objects;

namespace Domain.Models
{
    public class Galvanica : Entidade
    {
        public string Nome { get; private set; }
        public string Contato { get; private set; }
        public int MilesimosMaoObra { get; private set; }
        public decimal CotacaoOuro { get; private set; }
        public decimal CotacaoRodio { get; private set; }

        protected Galvanica() { }

        public Galvanica(string nome, string contato, int milesimosMaoObra, decimal cotacaoOuro, decimal cotacaoRodio)
        {
            Nome = nome;
            Contato = contato;
            MilesimosMaoObra = milesimosMaoObra;
            CotacaoOuro = cotacaoOuro;
            CotacaoRodio = cotacaoRodio;
        }

        public Galvanica Alterar(string nome, string contato, int milesimosMaoObra, decimal cotacaoOuro, decimal cotacaoRodio)
        {
            Nome = nome;
            Contato = contato;
            MilesimosMaoObra = milesimosMaoObra;
            CotacaoOuro = cotacaoOuro;
            CotacaoRodio = cotacaoRodio;

            return this;
        }
    }
}
