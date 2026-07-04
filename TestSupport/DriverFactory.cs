using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;

namespace FakestoreEcommerceTests.TestSupport
{
    public static class DriverFactory
    {
        public static IWebDriver GetDriver()
        {
            string driver = Helpers.AppSettings.Driver;
            Enum.TryParse(driver, out DriverName driverName);
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("incognito");
            chromeOptions.AddArgument("--window-size=1920,1080");
            chromeOptions.AddArgument("--no-sandbox");
            chromeOptions.AddArgument("--disable-dev-shm-usage");

            if (IsHeadlessEnabled())
            {
                chromeOptions.AddArgument("--headless=new");
            }

            IWebDriver webDriver = driverName switch
            {
                DriverName.Chrome => new ChromeDriver(chromeOptions),
                DriverName.Firefox => new FirefoxDriver(),
                DriverName.Ie => new InternetExplorerDriver(),
                _ => new ChromeDriver(chromeOptions),
            };
            webDriver.Manage().Cookies.DeleteAllCookies();
            return webDriver;
        }

        private static bool IsHeadlessEnabled()
        {
            var headless = Environment.GetEnvironmentVariable("HEADLESS");
            var ci = Environment.GetEnvironmentVariable("CI");

            return string.Equals(headless, "true", StringComparison.OrdinalIgnoreCase)
                || string.Equals(ci, "true", StringComparison.OrdinalIgnoreCase);
        }
    }

    public enum DriverName
    {
        Chrome, Firefox, Ie
    }
}
