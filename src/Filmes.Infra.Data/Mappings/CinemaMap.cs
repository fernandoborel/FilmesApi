using Filmes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Filmes.Infra.Data.Mappings;

public class CinemaMap : IEntityTypeConfiguration<Cinema>
{
    public void Configure(EntityTypeBuilder<Cinema> builder)
    {
        builder.HasKey(e => e.IdCinema)
            .HasName("PK__Cinema__87B23C6A5AA1F76F");

        builder.ToTable("Cinema");

        builder.Property(e => e.Nome)
            .HasMaxLength(255)
            .IsRequired();

        builder.HasOne(d => d.IdEnderecoNavigation)
            .WithMany(p => p.Cinemas)
            .HasForeignKey(d => d.IdEndereco)
            .HasConstraintName("FK_Cinema_Endereco");

        builder.HasOne(d => d.IdShoppingNavigation)
            .WithMany(p => p.Cinemas)
            .HasForeignKey(d => d.IdShopping)
            .HasConstraintName("FK_Cinema_Shopping");
    }
}