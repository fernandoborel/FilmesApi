using FilmesApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRouting(opt => opt.LowercaseUrls = true);
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

Setup.AddSwagger(builder);
Setup.AddRegisterServices(builder);
Setup.AddEntityFrameworkServices(builder);
Setup.AddAutoMapperServices(builder);
Setup.AddCorsServices(builder);
Setup.AddJwtBearerSecurity(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();