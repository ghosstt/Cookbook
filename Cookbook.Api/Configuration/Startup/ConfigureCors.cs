using Microsoft.Extensions.DependencyInjection;

namespace Cookbook.Api.Configuration.Startup
{
    public static partial class ConfigurationExtensions
    {
        public static IServiceCollection ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("localhost_4200", builder =>
                {
                    builder.WithOrigins("https://localhost:4200")
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                });
            });

            return services;
        }
    }
}
