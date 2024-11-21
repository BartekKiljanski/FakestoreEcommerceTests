using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace FakestoreEcommerceTests.Helpers
{
    public class AppSettings
    {
        private static IConfigurationRoot Configuration { get; set; }

        static AppSettings()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
            Console.WriteLine($"WebSitePage: {Configuration["AppSettings:WebSitePage"]}");
            Console.WriteLine($"Driver: {Configuration["AppSettings:Driver"]}");
        }

        public static string WebSitePage => Configuration["AppSettings:WebSitePage"];
        public static string Driver => Configuration["AppSettings:Driver"];
    }
}
