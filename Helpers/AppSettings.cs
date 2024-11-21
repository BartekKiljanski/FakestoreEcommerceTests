using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace FakestoreEcommerceTests.Helpers
{
    public class AppSettings
    {
        static IConfigurationRoot configuration = ConfigurationHelper.GetApplicationConfiguration(TestContext.CurrentContext.TestDirectory);

        public static string WebSitePage { get { return configuration.GetValue<string>("AppSettings:WebSitePage"); } }
        public static string Driver { get { return configuration.GetValue<string>("AppSettings:Driver"); } }
    }
}
