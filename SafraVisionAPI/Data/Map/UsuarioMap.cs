using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SafraVisionAPI.Models;

namespace SafraVisionAPI.Data.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {
            builder.HasKey(x => x.idUsuario);
            builder.Property(x => x.nomeUsuario).IsRequired().HasMaxLength(255);
            builder.Property(x => x.email).IsRequired().HasMaxLength(255);
            builder.Property(x => x.senha).IsRequired().HasMaxLength(255);

        }
    }
}
   
