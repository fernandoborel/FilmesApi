using Filmes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Filmes.Infra.Data.Mappings;

public class SessaoMap : IEntityTypeConfiguration<Sessao>
{
    public void Configure(EntityTypeBuilder<Sessao> builder)
    {
        builder.HasNoKey();

        builder.ToTable("Sessao");

        builder.HasOne(d => d.IdCinemaNavigation)
            .WithMany()
            .HasForeignKey(d => d.IdCinema)
            .HasConstraintName("FK_Sessao_Cinema");

        builder.HasOne(d => d.IdFilmeNavigation)
            .WithMany()
            .HasForeignKey(d => d.IdFilme)
            .HasConstraintName("FK_Sessao_Filme");
    }
}