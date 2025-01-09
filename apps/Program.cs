
using Microsoft.AspNetCore.Builder; // This namespace provides classes for building and configuring ASP.NET Core applications and middleware components.
using Microsoft.Extensions.DependencyInjection; // This namespace provides classes for adding services to the ASP.NET Core application's service container.
using Microsoft.EntityFrameworkCore; // provides classes for working with Entity Framework Core, a set of .NET libraries for working with data access.
using Swashbuckle.AspNetCore.Swagger; // This namespace provides classes for working with Swagger
using Microsoft.OpenApi.Models; // This namespace provides classes for working with Open API 3.0.

using PlaneTicketSystem.Data;
using PlaneTicketSystem.Data.Migrations;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers(); // This registers the MVC controllers
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Add SQL server context
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddScoped<MigrationManager>();

        // Add CORS services to allow requests from your Django frontend
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
        });

        var app = builder.Build();

        // Initialize Database
        using (var scope = app.Services.CreateScope())
        {
            var migrationManager = scope.ServiceProvider.GetRequiredService<MigrationManager>();
            migrationManager.InitializeDatabaseAsync().Wait();
        }

        // Configure the HTTP request pipeline
        app.UseSwagger();
        app.UseSwaggerUI();

        // Add routing and CORS middleware
        app.UseRouting(); // Add this line to enable routing
        app.UseCors(); // Add this to enable CORS

        app.UseHttpsRedirection();
        app.UseAuthorization();

        // Configure endpoints after UseRouting
        app.MapControllers();

        app.Run();
    }
}

