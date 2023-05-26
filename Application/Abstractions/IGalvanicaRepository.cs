using Domain.Models;

namespace Application.Abstractions
{
    public interface IGalvanicaRepository
    {
        Task<ICollection<Galvanica>> ObterGalvanicas(CancellationToken cancellationToken);
        Task<Galvanica?> ObterGalvanica(Guid id, CancellationToken cancellationToken);
        Task Adicionar(Galvanica entidade, CancellationToken cancellationToken);
        Task Alterar(Galvanica entidade, CancellationToken cancellationToken);
        Task Deletar(Guid id, CancellationToken cancellationToken);
    }
}
