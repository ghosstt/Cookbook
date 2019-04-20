using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.FileProviders.Physical;
using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace Cookbook.Api.Helpers
{
    public static class CertificateHelper
    {
        public static X509Certificate2 LoadCertificate(string path, string fileName)
        {
            //var assembly = typeof(Startup).GetTypeInfo().Assembly;
            //var embeddedFileProvider = new EmbeddedFileProvider(assembly, "Cookbook.Api");

            var physicalFileProvider = new PhysicalFileProvider(path, ExclusionFilters.None);
            var certFileInfo = physicalFileProvider.GetFileInfo(fileName);

            using (var certStream = certFileInfo.CreateReadStream())
            {
                byte[] certPayload;

                using (var memStream = new MemoryStream())
                {
                    certStream.CopyTo(memStream);
                    certPayload = memStream.ToArray();
                }

                return new X509Certificate2(certPayload, "p@ss1234");
            }
        }
    }
}
