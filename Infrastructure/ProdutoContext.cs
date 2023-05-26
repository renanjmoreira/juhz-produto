using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class ProdutoContext : DbContext
    {
        public ProdutoContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Galvanica> Galvanicas { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Estoque> Estoque { get; set; }
    }
}
