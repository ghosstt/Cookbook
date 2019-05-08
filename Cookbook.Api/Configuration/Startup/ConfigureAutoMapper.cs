using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Cookbook.Api.Configuration.Startup
{
    public static partial class ConfigurationExtensions
    {
        public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Api.Startup).GetTypeInfo().Assembly);
            return services;
        }
    }
}
