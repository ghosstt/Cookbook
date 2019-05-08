using Cookbook.Api.Helpers;
using Microsoft.AspNetCore.Hosting;
using System.Net;

namespace Cookbook.Api.Configuration.WebHostBuilder
{
    public static class ConfigurationExtensions
    {
        public static IWebHostBuilder ConfigureKestrel(this IWebHostBuilder webHostBuilder)
        {
            webHostBuilder.UseKestrel(options =>
            {
                options.Listen(IPAddress.Loopback, 5000);
                options.Listen(IPAddress.Loopback, 5001, listenOptions =>
                {
                    var serverCertificate = CertificateHelper.LoadCertificate("C:\\Projects\\Cookbook\\certificates", "localhost.pfx");
                    listenOptions.UseHttps(serverCertificate);
                });
            });

            return webHostBuilder;
        }
    }
}
