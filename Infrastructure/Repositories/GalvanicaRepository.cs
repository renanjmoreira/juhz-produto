using Application.Abstractions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class GalvanicaRepository : IGalvanicaRepository
    {
        private readonly ProdutoContext _context;

        public GalvanicaRepository(ProdutoContext context)
        {
            _context = context;
        }

        public async Task Adicionar(Galvanica entidade, CancellationToken cancellationToken)
        {
            _context.Galvanicas.Add(entidade);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Alterar(Galvanica entidade, CancellationToken cancellationToken)
        {
            _context.Galvanicas.Entry(entidade).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Deletar(Guid id, CancellationToken cancellationToken)
        {
            var entidade = await _context.Galvanicas.FindAsync(id, cancellationToken);
            if (entidade is null) return;

            _context.Galvanicas.Remove(entidade);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Galvanica?> ObterGalvanica(Guid id, CancellationToken cancellationToken) => await _context.Galvanicas.FindAsync(id, cancellationToken);

        public async Task<ICollection<Galvanica>> ObterGalvanicas(CancellationToken cancellationToken) => await _context.Galvanicas.ToListAsync(cancellationToken);
    }
}
