using Filmes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Filmes.Infra.Data.Mappings;

public class ShoppingMap : IEntityTypeConfiguration<Shopping>
{
    public void Configure(EntityTypeBuilder<Shopping> builder)
    {
        builder.HasKey(e => e.IdShopping)
                .HasName("PK__Shopping__4EE6E630312F603D");

        builder.ToTable("Shopping");

        builder.Property(e => e.Nome).HasMaxLength(255);
    }
}