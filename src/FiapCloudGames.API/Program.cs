using FiapCloudGames;
using FiapCloudGames.Application.Services;
using FiapCloudGames.Application.Services.Interfaces;
using FiapCloudGames.Domain.Repository;
using FiapCloudGames.Infrastructure.Repository;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;
using System.Text.Json.Serialization;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

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
            "Plataforma de venda de jogos digitais e gest�o de servidores para partidas online \n\n" +
            "Contatos:\n\n" +
            "- Joao Paulo\n\n" +
            "- Lucas Nunes RM 369391\n\n" +
            "- Marcos Antonio RM 368502\n\n" +
            "- David RM 369381\n\n" +
            "- Oberdan RM 369592\n\n",
    });
});

#region [Configuracao do Entity Framework e SQL Server]
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    //Configura a conexao com o banco de dados SQL Server Local
    //options.UseSqlServer(configuration.GetConnectionString("ConnectionString"));

    //Configura a conexao com o banco de dados SQL Server No Docker
    options.UseSqlServer(configuration.GetConnectionString("DockerConnectionString"));
}, ServiceLifetime.Scoped);

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IGamesRepository, GamesRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAcessUserRepository, AcessUserRepository>();

builder.Services.AddScoped<IAcessUserService, AcessUserService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IAuthenticateService, AuthenticateService>();
builder.Services.AddScoped<ITokenService, TokenService>();
#endregion


#region [JWT] Configuracao do JWT

// Adicione uma validação para garantir que a chave JWT não seja nula
var jwtKey = builder.Configuration["Jwt:Key"];
if (string.IsNullOrEmpty(jwtKey))
{
    throw new InvalidOperationException("A chave JWT não foi configurada. Verifique o arquivo appsettings.json.");
}

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
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
});


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

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

        // Registrar o erro com o Serilog
        Log.Error(exception, "An unhandled exception occurred.");

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

        await context.Response.WriteAsJsonAsync(new
        {
            StatusCode = context.Response.StatusCode,
            Message = "An unexpected error occurred. Please try again later."
        });
    });
});
// Middleware de logging
app.UseSerilogRequestLogging();

// Middleware de redirecionamento HTTPS
app.UseHttpsRedirection();

// Middleware de roteamento (necessário para MapControllers funcionar)
app.UseRouting();

// Middleware de autenticação e autorização
app.UseAuthentication();
app.UseAuthorization();

// Middleware personalizado (deve ser registrado após UseRouting)
app.UseMiddleware<LogMiddleware>();

// Mapear os endpoints dos controllers
app.MapControllers();

// Endpoint de teste
app.MapGet("/error-test", () =>
{
    throw new Exception("This is a test exception.");
});

app.Run();
