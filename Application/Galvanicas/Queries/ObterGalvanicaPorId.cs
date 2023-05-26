using Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Galvanicas.Queries
{
    public class ObterGalvanicaPorId : IRequest<Galvanica?>
    {
        public ObterGalvanicaPorId(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
