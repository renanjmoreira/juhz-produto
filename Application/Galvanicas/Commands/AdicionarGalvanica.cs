using Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Galvanicas.Commands
{
    public class AdicionarGalvanica : IRequest
    {
        public string Nome { get; set; }
        public string Contato { get; set; }
        public int MilesimosMaoObra { get; set; }
        public decimal CotacaoOuro { get; set; }
        public decimal CotacaoRodio { get; set; }
        public Galvanica ObterGalvanica() => new(Nome, Contato, MilesimosMaoObra, CotacaoOuro, CotacaoRodio);
    }
}
