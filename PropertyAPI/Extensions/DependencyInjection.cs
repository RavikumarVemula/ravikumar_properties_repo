namespace PropertyAPI.Extensions
{
    internal static class DependencyInjection
    {

        public static IServiceCollection AddCorsExtension(this IServiceCollection services) 
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp", policy =>
                {
                    policy.WithOrigins("http://localhost:3000")  
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            return services;
        }
    }
}
