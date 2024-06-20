using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafraVisionAPI.Models;

namespace SafraVisionAPI.Data.Map
{
    public class ClienteMap : IEntityTypeConfiguration<ClienteModel>
    {
        public void Configure(EntityTypeBuilder<ClienteModel> builder)
        {
            builder.HasKey(x => x.idCliente);
            builder.Property(x => x.nomeCliente).IsRequired().HasMaxLength(255);
            builder.Property(x => x.descricao).IsRequired().HasMaxLength(255);
            builder.Property(x => x.numeroTelefone).IsRequired();
        }
    }
}
