using Filmes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Filmes.Infra.Data.Mappings;

public class FilmeMap : IEntityTypeConfiguration<Filme>
{
    public void Configure(EntityTypeBuilder<Filme> builder)
    {
        builder.HasKey(e => e.IdFilme)
                .HasName("PK__Filme__6E8F2A769B454965");

        builder.ToTable("Filme");

        builder.Property(e => e.Genero).HasMaxLength(50);

        builder.Property(e => e.Titulo).HasMaxLength(255);
    }
}
