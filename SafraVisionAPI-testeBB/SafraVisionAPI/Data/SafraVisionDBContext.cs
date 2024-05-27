using Microsoft.EntityFrameworkCore;
using SafraVisionAPI.Models;

namespace SafraVisionAPI.Data
{
    public class SafraVisionDBContext : DbContext
    {
        public SafraVisionDBContext(DbContextOptions<SafraVisionDBContext>options)
            : base(options)
        {
            
        }
        public DbSet<PessoaModel> Pessoa { get; set; }
        public DbSet<UsuarioModel> Usuario { get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<VendaModel> Vendas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
