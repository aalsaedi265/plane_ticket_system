
using Microsoft.AspNetCore.Builder; // This namespace provides classes for building and configuring ASP.NET Core applications and middleware components.
using Microsoft.Extensions.DependencyInjection; // This namespace provides classes for adding services to the ASP.NET Core application's service container.
using Microsoft.EntityFrameworkCore; // provides classes for working with Entity Framework Core, a set of .NET libraries for working with data access.
using Swashbuckle.AspNetCore.Swagger; // This namespace provides classes for working with Swagger
using Microsoft.OpenApi.Models; // This namespace provides classes for working with Open API 3.0.

using PlaneTicketSystem.Data;


public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args); // Creates a new instance of the WebApplication class using the provided arguments.

        // Add services to the container.
        builder.Services.AddControllers(); // Adds the Controllers service to the service collection.
        builder.Services.AddEndpointsApiExplorer(); // Adds the Endpoints API Explorer service to the service collection.
        builder.Services.AddSwaggerGen(); // Adds the SwaggerGen service to the service collection.

        // Add SQL server context
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        var app = builder.Build(); // Builds the application.

        app.UseSwagger(); // Adds the Swagger middleware to the application.
        app.UseSwaggerUI(); // Adds the Swagger UI middleware to the application.
        app.UseHttpsRedirection(); // Adds the HTTPS redirection middleware to the application.
        app.UseAuthorization(); // Adds the authorization middleware to the application.
        app.MapControllers(); // Maps the controllers to the application.

        app.Run(); // Starts the application.

    }
}

