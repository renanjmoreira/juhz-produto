using Domain.Models;
using MediatR;

namespace Application.Galvanicas.Queries
{
    public class ObterGalvanicas : IRequest<ICollection<Galvanica>>
    {
    }
}
