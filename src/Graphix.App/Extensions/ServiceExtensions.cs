using Graphix.Business.Handlers;
using Graphix.Business.Handlers.Events;
using Graphix.Data.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Graphix.App.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<MainWindow>();

        services.AddScoped<DrawState>();
        services.AddScoped<ColorEventHandler>();
        services.AddScoped<MouseEventHandler>();
        services.AddScoped<ShapeSelectionHandler>();
        services.AddScoped<Handlers>();

        return services;
    }
}
