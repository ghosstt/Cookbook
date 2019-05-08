using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Cookbook.Api.Configuration.Startup
{
    public static partial class ConfigurationExtensions
    {
        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            // https://localhost:5001/swagger/index.html
            // https://localhost:5001/swagger/v1/swagger.json

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info { Title = "Cookbook API", Description = "Cookbook API Swagger", Version = "v1" });
                options.AddSecurityDefinition("oauth2", new ApiKeyScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                    In = "header",
                    Name = "Authorization",
                    Type = "apiKey"
                });

                // options.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> { {"Bearer", new string[] { }} });
                // options.OperationFilter<SecurityRequirementsOperationFilter>();

                // XML comments in swagger
                // https://exceptionnotfound.net/adding-swagger-to-asp-net-core-web-api-using-xml-documentation/
                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //options.IncludeXmlComments(xmlPath);
            });

            return services;
        }
    }
}
