using Cookbook.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cookbook.Api.Configuration.Startup
{
    public static partial class ConfigurationExtensions
    {
        public static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration config)        {
            // SQL Server
            string sqlServerConnection = config.GetConnectionString("SqlServerConnection");
            services.AddDbContext<CookbookDbContext>(options => options.UseSqlServer(sqlServerConnection, opt => opt.EnableRetryOnFailure()));

            // Sqlite
            //string sqliteConnection = config.GetConnectionString("SqliteConnection");
            //services.AddDbContext<CookbookDbContext>(options => options.UseSqlite(sqliteConnection));

            return services;
        }
    }
}
