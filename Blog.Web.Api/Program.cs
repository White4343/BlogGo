using System.Globalization;
using Infrastructure.Interfaces;
using Infrastructure.PasswordHashing;
using Microsoft.EntityFrameworkCore;
using User.Web.Api.Data;
using User.Web.Api.Endpoints;
using User.Web.Api.Users;
using User.Web.Api.Users.RegisterUser;

var configuration = GetConfiguration();

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    if (!builder.Environment.IsDevelopment())
    {
        var password = Environment.GetEnvironmentVariable("MSSQL_SA_PASSWORD");

        ArgumentNullException.ThrowIfNull(connectionString);
        connectionString = string.Format(CultureInfo.InvariantCulture, connectionString, password);
    }

    options.UseSqlServer(connectionString);
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.SetIsOriginAllowed((host => true))
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

builder.Services.AddRouting(opt => opt.LowercaseUrls = true);

builder.Services.AddScoped<DatabaseInitialization>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<RegisterUserHandler>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    options =>
    {
        options.SwaggerDoc("v1", new() { Title = "User API", Version = "v1" });
    });

builder.Services.AddEndpoints();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(setup =>
        setup.SwaggerEndpoint($"{configuration["PathBase"]}/swagger/v1/swagger.json", "User API v1")
        );
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseRouting();

app.MapEndpoints();

CreateDbIfNotExists(app);

await app.RunAsync().ConfigureAwait(false);

void CreateDbIfNotExists(IHost host)
{
    using var scope = host.Services.CreateScope();
    var dbInit = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbInit.Database.Migrate();
}

IConfiguration GetConfiguration()
{
    var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", false, true)
        .AddEnvironmentVariables();

    return builder.Build();
}