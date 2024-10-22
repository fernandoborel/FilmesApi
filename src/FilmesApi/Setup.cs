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
using Microsoft.OpenApi.Models;
using System.Text;

namespace FilmesApi;

public static class Setup
{
    public static void AddSwagger(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen(s =>
        {
            s.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Filmes API",
                Version = "v1",
                Description = "API de Filmes",
                Contact = new OpenApiContact
                {
                    Name = "Fernando Borel",
                    Email = "fernandomenezesborel@gmail.com",
                    Url = new Uri("https://github.com/fernandoborel")
                }
            });

            s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "Insira o token JWT sem a palavra 'Bearer'. Exemplo: '12345abcdef'",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer", // Define o esquema como 'Bearer'
                BearerFormat = "JWT", // Especifica o formato do token
            });

            s.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                    Scheme = "Bearer",
                    Name = "Bearer",
                    In = ParameterLocation.Header,
                },
                new List<string>()
            }
        });
        });
    }


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