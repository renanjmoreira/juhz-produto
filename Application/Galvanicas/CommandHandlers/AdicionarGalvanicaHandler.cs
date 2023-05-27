using Application.Abstractions;
using Application.Galvanicas.Commands;
using Domain.Models;
using MediatR;

namespace Application.Galvanicas.CommandHandlers
{
    internal class AdicionarGalvanicaHandler : IRequestHandler<AdicionarGalvanica>
    {
        private readonly IGalvanicaRepository _repositorio;

        public AdicionarGalvanicaHandler(IGalvanicaRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task Handle(AdicionarGalvanica request, CancellationToken cancellationToken)
        {
            var galvanica = request.ObterGalvanica();
            await _repositorio.Adicionar(galvanica, cancellationToken);
        }
    }
}
