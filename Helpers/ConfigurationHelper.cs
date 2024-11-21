using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

using System.IO;


namespace FakestoreEcommerceTests.Helpers
{
    public class ConfigurationHelper
    {
        // Definicje właściwości dla ustawień
        public string WebSitePage { get; set; }
        public string Driver { get; set; }

        private static IConfigurationRoot _configurationRoot;

        static ConfigurationHelper()
        {
            _configurationRoot = GetIConfigurationRoot(Directory.GetCurrentDirectory());
        }

        public static IConfigurationRoot GetIConfigurationRoot(string outputPath)
        {
            return new ConfigurationBuilder()
                .SetBasePath(outputPath)
                .AddJsonFile("appsettings.json", optional: true)
                .Build();
        }

        public static ConfigurationHelper GetApplicationConfiguration()
        {
            var configuration = new ConfigurationHelper();
            _configurationRoot
                .GetSection("AppSettings").Bind(configuration);
            return configuration;
        }
    }
}
