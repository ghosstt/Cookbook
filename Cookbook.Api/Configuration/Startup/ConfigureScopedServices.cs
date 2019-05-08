using Cookbook.Api.Features.Auth.Services;
using Cookbook.Api.Features.Ingredient.Services;
using Cookbook.Api.Features.Recipe.Services;
using Cookbook.Api.Features.Security.Services;
using Cookbook.Api.Features.User.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Cookbook.Api.Configuration.Startup
{
    public static partial class ConfigurationExtensions
    {
        public static IServiceCollection ConfigureScopedServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<IIngredientService, IngredientService>();
            return services;
        }
    }
}
