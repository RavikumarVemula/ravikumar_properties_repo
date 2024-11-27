using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;

namespace PropertyAPI.Extensions.EndPoints
{
    /// <summary>
    /// Endpoint Extension class
    /// </summary>
    public static class EndpointExtensions
    {
        public static IServiceCollection AddEndpointsExtension(this IServiceCollection services
            , params Assembly[] assemblies
            ) 
        {

            ServiceDescriptor[] serviceDescriptors = assemblies
         .SelectMany(a => a.GetTypes())
         .Where(type => type is { IsAbstract: false, IsInterface: false } &&
                        type.IsAssignableTo(typeof(IEndpoint)))
         .Select(type => ServiceDescriptor.Transient(typeof(IEndpoint), type))
         .ToArray();

            services.TryAddEnumerable(serviceDescriptors);

            return services;

        }

        public static IApplicationBuilder UseMapEndpoints(this WebApplication app,
            RouteGroupBuilder? routeGroupBuilder = null)
        {
            IEnumerable<IEndpoint> endpoints = app.Services.GetRequiredService<IEnumerable<IEndpoint>>();

            IEndpointRouteBuilder builder = routeGroupBuilder is null ?  app: routeGroupBuilder;

            foreach (var endpoint in endpoints) 
            { 
                endpoint.MapEndpoint(builder); ;
            }

            return app;
        }
    }
}
