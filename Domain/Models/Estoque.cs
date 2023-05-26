using Domain.Objects;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Models
{
    public class Estoque : Entidade
    {
        [JsonIgnore]
        [ForeignKey("ProdutoId")]
        public Produto Produto { get; private set; }
        public string Medida { get; private set; }
        public int Quantidade { get; private set; }

        protected Estoque() { }

        public Estoque(Produto produto, string medida, int quantidade)
        {
            Produto = produto;
            Medida = medida;
            Quantidade = quantidade;
        }

        public void AlterarQuantidade(int quantidade)
        {
            if (quantidade < 0)
            {
                throw new ArgumentException("Quantidade em estoque inválida.");
            }

            Quantidade = quantidade;
        }
    }
}
