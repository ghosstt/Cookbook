using Cookbook.Api.Features.Ingredient.Services;
using Cookbook.Api.Features.Recipe.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Cookbook.Api.Configuration.Startup
{
    public static partial class ConfigurationExtensions
    {
        public static IServiceCollection ConfigureScopedServices(this IServiceCollection services)
        {
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<IIngredientService, IngredientService>();
            return services;
        }
    }
}
