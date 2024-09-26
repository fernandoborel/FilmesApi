using Filmes.Domain.Interfaces.Repositories;
using Filmes.Infra.Data.Context;
using Filmes.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi;

public static class Setup
{
    public static void AddRegisterServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<ICinemaRepository, CinemaRepository>();
    }

    public static void AddEntityFrameworkServices(this WebApplicationBuilder builder) 
    {
        var connectionString = builder.Configuration.GetConnectionString("BD_Filmes");
        builder.Services.AddDbContext<SqlServerContext>(options => options.UseSqlServer(connectionString));
    }
}