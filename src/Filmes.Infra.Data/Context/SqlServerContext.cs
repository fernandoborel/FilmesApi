using Filmes.Domain.Entities;
using Filmes.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Filmes.Infra.Data.Context;

public class SqlServerContext : DbContext
{

    public SqlServerContext(DbContextOptions<SqlServerContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CinemaMap());
        modelBuilder.ApplyConfiguration(new EnderecoMap());
        modelBuilder.ApplyConfiguration(new FilmeMap());
        modelBuilder.ApplyConfiguration(new SessaoMap());
        modelBuilder.ApplyConfiguration(new ShoppingMap());
    }

    public DbSet<Cinema> Cinema { get; set; }
    public DbSet<Endereco> Endereco { get; set; }
    public DbSet<Filme> Filme { get; set; }
    public DbSet<Sessao> Sessao { get; set; }
    public DbSet<Shopping> Shopping { get; set; }
}
