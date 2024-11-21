using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

using System.IO;
using Microsoft.Extensions.Configuration;

namespace FakestoreEcommerceTests.Helpers
{
    public class ConfigurationHelper
    {
        public static IConfigurationRoot GetIConfigurationRoot(string outputPath)
        {
            return new ConfigurationBuilder()
                .SetBasePath(outputPath)
                .AddJsonFile("appsettings.json", optional: true)
                .Build();
        }

        public static IConfigurationRoot GetApplicationConfiguration(string outputPath)
        {
            var iConfig = GetIConfigurationRoot(outputPath);
            return iConfig;
        }
    }
}
