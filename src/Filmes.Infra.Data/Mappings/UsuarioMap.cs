using Filmes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Filmes.Infra.Data.Mappings;

public class UsuarioMap : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuario");

        builder.HasKey(u => u.IdUsuario);

        builder.Property(u => u.Nome)
            .HasColumnName("Nome")
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(u => u.Email)
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder.HasIndex(u=> u.Email)
            .IsUnique();

        builder.Property(u => u.Senha)
            .HasColumnType("varchar(100)")
            .IsRequired();
    }
}