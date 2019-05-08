using Cookbook.Api.Configuration.WebHostBuilder;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Cookbook.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                // .ConfigureKestrel()
                .UseSetting("https_port", "5001")
                .UseStartup<Startup>();
    }
}
