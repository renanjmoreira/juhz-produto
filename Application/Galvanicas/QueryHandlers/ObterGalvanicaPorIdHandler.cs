using Application.Abstractions;
using Application.Galvanicas.Queries;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Galvanicas.QueryHandlers
{
    internal class ObterGalvanicaPorIdHandler : IRequestHandler<ObterGalvanicaPorId, Galvanica?>
    {
        private readonly IGalvanicaRepository _repositorio;

        public ObterGalvanicaPorIdHandler(IGalvanicaRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<Galvanica?> Handle(ObterGalvanicaPorId request, CancellationToken cancellationToken)
        {
            return await _repositorio.ObterGalvanica(request.Id, cancellationToken);
        }
    }
}
