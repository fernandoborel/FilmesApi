﻿using Filmes.Application.Interfaces;
using Filmes.Application.Services;
using Filmes.Domain.Interfaces.Repositories;
using Filmes.Domain.Interfaces.Services;
using Filmes.Domain.Mappings;
using Filmes.Domain.Services;
using Filmes.Infra.Data.Context;
using Filmes.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi;

public static class Setup
{
    public static void AddRegisterServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<ICinemaAppService, CinemaAppService>();
        builder.Services.AddTransient<ICinemaDomainService, CinemaDomainService>();
        builder.Services.AddTransient<ICinemaRepository, CinemaRepository>();
    }

    public static void AddEntityFrameworkServices(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("BD_Filmes");
        builder.Services.AddDbContext<SqlServerContext>(options => options.UseSqlServer(connectionString));
    }

    public static void AddAutoMapperServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(typeof(CommandToEntity));
    }
}