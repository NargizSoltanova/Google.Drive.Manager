using GoogleDriveManager.Configuration;
using GoogleDriveManager.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GoogleDriveManager;

public static class ConfigureService
{
    public static IServiceCollection AddGoogleDriveServices(this IServiceCollection services)
    {
        services.AddScoped<IDriveService, DriveManager>();
        services.AddScoped<Configure>();
        return services;
    }
}
