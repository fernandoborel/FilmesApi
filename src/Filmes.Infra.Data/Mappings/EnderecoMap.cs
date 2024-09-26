using Filmes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Filmes.Infra.Data.Mappings;

public class EnderecoMap : IEntityTypeConfiguration<Endereco>
{
    public void Configure(EntityTypeBuilder<Endereco> builder)
    {

         builder.HasKey(e => e.IdEndereco)
                .HasName("PK__Endereco__0B7C7F17A17B80CF");

         builder.ToTable("Endereco");

         builder.Property(e => e.Logradouro).HasMaxLength(255);
    }
}
