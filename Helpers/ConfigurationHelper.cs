using Microsoft.Extensions.Configuration;
using System.IO;

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
