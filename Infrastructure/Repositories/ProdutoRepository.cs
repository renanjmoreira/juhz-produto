using Application.Abstractions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ProdutoContext _context;

        public ProdutoRepository(ProdutoContext context)
        {
            _context = context;
        }

        public async Task Adicionar(Produto entidade, CancellationToken cancellationToken)
        {
            _context.Produtos.Add(entidade);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Alterar(Produto entidade, CancellationToken cancellationToken)
        {
            _context.Produtos.Entry(entidade).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Deletar(Guid id, CancellationToken cancellationToken)
        {
            var entidade = await _context.Produtos.FindAsync(id, cancellationToken);
            if (entidade is null) return;

            _context.Produtos.Remove(entidade);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Produto?> ObterProdutoComEstoque(Guid id, CancellationToken cancellationToken) => await _context.Produtos.FindAsync(id, cancellationToken);

        public async Task<ICollection<Produto>> ObterProdutosComEstoque(CancellationToken cancellationToken) => await _context.Produtos.Include(x => x.Estoque).ToListAsync(cancellationToken);
    }
}
