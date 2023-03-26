using Microsoft.EntityFrameworkCore;

namespace Squares.API.Extensions;

public static class DatabaseHelpers
{
    internal static void AddDatabaseContext(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<DatabaseContext.DatabaseContext>(opt =>
            opt.UseNpgsql($"Server={Environment.GetEnvironmentVariable("DB_HOST" ?? "squares_database")};" +
                          $"Port={Environment.GetEnvironmentVariable("DB_PORT") ?? "5432"};" +
                          $"Database={Environment.GetEnvironmentVariable("DB_NAME") ?? "squares_database"};" +
                          $"User Id={Environment.GetEnvironmentVariable("DB_USER") ?? "R3477Y57R0NGU53RN4M3"};" +
                          $"Password={Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "R3477Y57R0NGP455W0RD"};"));
    }

    internal static void UseEnsureDatabaseIsCreated(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;

        var context = services.GetRequiredService<DatabaseContext.DatabaseContext>();

        context.Database.EnsureCreated();
    }
}