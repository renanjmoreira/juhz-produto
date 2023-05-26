using Application.Abstractions;
using Application.Galvanicas.Queries;
using Domain.Models;
using MediatR;

namespace Application.Galvanicas.QueryHandlers
{
    internal class ObterGalvanicasHandler : IRequestHandler<ObterGalvanicas, ICollection<Galvanica>>
    {
        private readonly IGalvanicaRepository _repositorio;

        public ObterGalvanicasHandler(IGalvanicaRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<ICollection<Galvanica>> Handle(ObterGalvanicas request, CancellationToken cancellationToken)
        {
            return await _repositorio.ObterGalvanicas(cancellationToken);
        }
    }
}
