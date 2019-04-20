using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Cookbook.Api.Configuration.Startup
{
    public static partial class ConfigurationExtensions
    {
        public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper();
            return services;
        }
    }
}
