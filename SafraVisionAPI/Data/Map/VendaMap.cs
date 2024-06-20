using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafraVisionAPI.Models;

namespace SafraVisionAPI.Data.Map
{
    public class VendaMap : IEntityTypeConfiguration<VendaModel>
    {
        public void Configure(EntityTypeBuilder<VendaModel> builder)
        {
            builder.HasKey(x => x.idVenda);
            builder.Property(x => x.clienteVenda).IsRequired().HasMaxLength(255);
            builder.Property(x => x.produtoVenda).IsRequired().HasMaxLength(255);
            builder.Property(x => x.descricaoVenda).IsRequired().HasMaxLength(255);
            builder.Property(x => x.qtdVendida).IsRequired().HasMaxLength(255);
            builder.Property(x => x.dataVenda).IsRequired();
            
        }
    }
}
