using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Cookbook.Api.Configuration.Startup
{
    public static partial class ConfigurationExtensions
    {
        public static IServiceCollection ConfigureMediator(this IServiceCollection services)
        {
            services.AddMediatR(typeof(Api.Startup).GetTypeInfo().Assembly);
            return services;
        }
    }
}
