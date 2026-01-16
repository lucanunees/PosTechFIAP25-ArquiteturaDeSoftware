using FiapCloudGames.Application.Services;
using FiapCloudGames.Application.Services.Interfaces;
using FiapCloudGames.Domain.Repository;
using FiapCloudGames.Infrastructure.Repository;
using FiapCloudGames.Middleware;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

#region [Configuration do appsettings.json BD]
// pega as configura��es do arquivo appsettings.json de conexao com o banco de dados.
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

#endregion

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("V1", new OpenApiInfo
    {
        Title = "FIAP Cloud Games (FCG)",
        Version = "V1",
        Description =
            "Plataforma de venda de jogos digitais e gestao de servidores para partidas online \n\n" +
            "Contatos:\n\n" +
            "- Joao Paulo RM 370112\n\n" +
            "- Lucas Nunes RM 369391\n\n" +
            "- Marcos Antonio RM 368502\n\n" +
            "- David RM 369381\n\n" +
            "- Oberdan Padron Santana RM 369592\n\n",
    });

    // Esquema de segurança JWT (aparece o cadeado)
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Informe: Bearer {seu_token_jwt}"
    });

    // Requisito de segurança global (aplica o cadeado nos endpoints (todos))
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

#region [Configuracao do Entity Framework e SQL Server]
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    //Configura a conexao com o banco de dados SQL Server Local
    options.UseSqlServer(configuration.GetConnectionString("ConnectionString"));

    //Configura a conexao com o banco de dados SQL Server No Docker
    //options.UseSqlServer(configuration.GetConnectionString("DockerConnectionString"));
}, ServiceLifetime.Scoped);

#endregion

#region [Injecao de Dependencia]
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IGamesRepository, GamesRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IAcessUserRepository, AcessUserRepository>();
builder.Services.AddScoped<IPromotionRepository, PromotionRepository>();


builder.Services.AddScoped<IAcessUserService, AcessUserService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IAuthenticateService, AuthenticateService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IPromotionService, PromotionService>();
#endregion

#region [Middleware]
builder.Services.AddCorrelationIdGenerator();
builder.Services.AddTransient(typeof(LoggerBase<>));
#endregion


#region [JWT] Configuracao do JWT

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
});

builder.Services.AddControllers();


#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/V1/swagger.json", "FIAP Cloud Games (FCG) V1");
    });

    app.UseReDoc(c =>
    {
        c.DocumentTitle = "FIAP Cloud Games (FCG)";
        c.SpecUrl = "/swagger/V1/swagger.json";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

