using Domain.Enums;
using Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Galvanicas.Commands
{
    public class AlterarGalvanica : IRequest
    {        
        public Guid Id { get; set; }        
        public string Nome { get; set; }        
        public string Contato { get; set; }        
        public int MilesimosMaoObra { get; set; }        
        public decimal CotacaoOuro { get; set; }        
        public decimal CotacaoRodio { get; set; }

        public Galvanica ObterGalvanicaAlterada(Galvanica galvanica) => galvanica.Alterar(Nome, Contato, MilesimosMaoObra, CotacaoOuro, CotacaoRodio);
    }
}
