using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Contracts;
using TaskManagement.Core.Services;

namespace TaskManagement.Core;

public static class DependencyInjection
{
    
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddContracts();

        services.AddScoped<ITaskService, TaskService>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        return services;
    }
}