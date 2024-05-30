using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafraVisionAPI.Models;

namespace SafraVisionAPI.Data.Map
{
    public class PessoaMap : IEntityTypeConfiguration<PessoaModel>
    {
        public void Configure(EntityTypeBuilder<PessoaModel> builder)
        {
            builder.HasKey(x => x.idPessoa);
            builder.Property(x => x.nomePessoa).IsRequired().HasMaxLength(255);
            
        }
    }
}
