using Microsoft.EntityFrameworkCore;
using SafraVisionAPI.Data.Map;
using SafraVisionAPI.Models;

namespace SafraVisionAPI.Data
{
    public class SafraVisionDBContext : DbContext
    {
        public SafraVisionDBContext(DbContextOptions<SafraVisionDBContext>options)  
            : base(options)
        {
            
        }
        
        public DbSet<UsuarioModel> Usuario { get; set; }
        public DbSet<VendaModel> Venda { get; set; }
        public DbSet<CompradorModel> Comprador { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new VendaMap());
            modelBuilder.ApplyConfiguration(new CompradorMap());

            base.OnModelCreating(modelBuilder);
            
            
        }
    }
}
