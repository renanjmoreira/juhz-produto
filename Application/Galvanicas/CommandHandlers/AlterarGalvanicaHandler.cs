using Application.Abstractions;
using Application.Galvanicas.Commands;
using MediatR;

namespace Application.Galvanicas.CommandHandlers
{
    internal class AlterarGalvanicaHandler : IRequestHandler<AlterarGalvanica>
    {
        private readonly IGalvanicaRepository _repositorio;

        public AlterarGalvanicaHandler(IGalvanicaRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task Handle(AlterarGalvanica request, CancellationToken cancellationToken)
        {
            var galvanica = await _repositorio.ObterGalvanica(request.Id, cancellationToken) ?? throw new Exception("Galvanica não encontrado.");
            galvanica = request.ObterGalvanicaAlterada(galvanica);

            await _repositorio.Alterar(galvanica, cancellationToken);
        }
    }
}
