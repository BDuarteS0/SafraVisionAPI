using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafraVisionAPI.Models;

namespace SafraVisionAPI.Data.Map
{
    public class CompradorMap : IEntityTypeConfiguration<CompradorModel>
    {
        public void Configure(EntityTypeBuilder<CompradorModel> builder)
        {
            builder.Property(x => x.descricao).IsRequired().HasMaxLength(255);
        }
    }
}
