using Microsoft.EntityFrameworkCore;
using TaskManagement.Api.Middlewares;

namespace TaskManagement.Api.Extensions;

public static class HostExtensions
{
    public static async Task MigrateDatabaseAsync<T>(this IHost host) where T : DbContext
    {
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;
        var logger = services.GetRequiredService<ILogger<T>>();
        try
        {
            var context = services.GetRequiredService<T>();
            await context.Database.MigrateAsync();
            logger.LogInformation("Migrated database associated with context {DbContextName}", typeof(T).Name);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while migrating the database used on context {DbContextName}",
                typeof(T).Name);
            
            throw;
        }
    }
    
    public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
    }
}