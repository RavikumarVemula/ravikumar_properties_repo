using ApplicationLayer.Abstractions;
using InfrastructureLayer.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InfrastructureLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IAzureStorageService, StorageBlobService>();

            return services;
        }
    }
}
