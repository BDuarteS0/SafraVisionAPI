using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafraVisionAPI.Models;

namespace SafraVisionAPI.Data.Map
{
    public class ProdutoMap : IEntityTypeConfiguration<ProdutoModel>
    {
        public void Configure(EntityTypeBuilder<ProdutoModel> builder)
        {
            builder.HasKey(x => x.idProduto);
            builder.Property(x => x.nomeProduto).IsRequired().HasMaxLength(255);
            builder.Property(x => x.descricao).IsRequired().HasMaxLength(255);
            builder.Property(x => x.preco).IsRequired();
            builder.Property(x => x.qtdEstoque).IsRequired();
        }

    }
}
