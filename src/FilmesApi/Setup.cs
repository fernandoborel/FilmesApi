using Filmes.Application.Interfaces;
using Filmes.Application.Services;
using Filmes.Domain.Interfaces.Repositories;
using Filmes.Domain.Interfaces.Security;
using Filmes.Domain.Interfaces.Services;
using Filmes.Domain.Mappings;
using Filmes.Domain.Services;
using Filmes.Infra.Data.Context;
using Filmes.Infra.Data.Repositories;
using Filmes.Infra.Security.Services;
using Filmes.Infra.Security.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FilmesApi;

public static class Setup
{
    public static void AddRegisterServices(this WebApplicationBuilder builder)
    {
        #region Cinema

        builder.Services.AddTransient<ICinemaAppService, CinemaAppService>();
        builder.Services.AddTransient<ICinemaDomainService, CinemaDomainService>();
        builder.Services.AddTransient<ICinemaRepository, CinemaRepository>();

        #endregion

        #region Endereco

        builder.Services.AddTransient<IEnderecoAppService, EnderecoAppService>();
        builder.Services.AddTransient<IEnderecoDomainService, EnderecoDomainService>();
        builder.Services.AddTransient<IEnderecoRepository, EnderecoRepository>();

        #endregion

        #region Filme

        builder.Services.AddTransient<IFilmeAppService, FilmeAppService>();
        builder.Services.AddTransient<IFilmeDomainService, FilmeDomainService>();
        builder.Services.AddTransient<IFilmeRepository, FilmeRepository>();

        #endregion

        #region Sessão

        builder.Services.AddTransient<ISessaoAppService, SessaoAppService>();
        builder.Services.AddTransient<ISessaoDomainService, SessaoDomainService>();
        builder.Services.AddTransient<ISessaoRepository, SessaoRepository>();

        #endregion

        #region Usuario

        builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
        builder.Services.AddTransient<IUsuarioDomainService, UsuarioDomainService>();
        builder.Services.AddTransient<IUsuarioAppService, UsuarioAppService>();

        #endregion

        #region Autenticar

        builder.Services.AddTransient<IAuthorizationSecurity, AuthorizationSecurity>();

        #endregion
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

    public static void AddCorsServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("DefaultPolicy",
                builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });
    }

    public static void AddJwtBearerSecurity(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
        builder.Services.AddTransient<IAuthorizationSecurity, AuthorizationSecurity>();

        builder.Services.AddAuthentication(
            auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }
            ).AddJwtBearer(
            bearer =>
            {
                bearer.RequireHttpsMetadata = false;
                bearer.SaveToken = true;
                bearer.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.ASCII.GetBytes
                        (builder.Configuration
                        .GetSection("JwtSettings")
                        .GetSection("SecretKey").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
    }

}