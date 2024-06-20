using Microsoft.EntityFrameworkCore;
using SafraVisionAPI.Data.Map;
using SafraVisionAPI.Models;

namespace SafraVisionAPI.Data
{
    public class SafraVisionDBContext : DbContext
    {
        public SafraVisionDBContext(DbContextOptions<SafraVisionDBContext> options)
            : base(options)
        {

        }

        public virtual DbSet<UsuarioModel> Usuario { get; set; }
        public virtual DbSet<VendaModel> Venda { get; set; }
        public virtual DbSet<ClienteModel> Cliente { get; set; }
        public virtual DbSet<ProdutoModel> Produto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=safraserver.database.windows.net;DataBase=DB_SafraVision02;User Id=safra-admin;Password=P0o9i8u7!bruno");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new VendaMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());

            base.OnModelCreating(modelBuilder);
            
            
        }
    }
}
