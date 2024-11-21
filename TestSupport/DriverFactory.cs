
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
           // chromeOptions.AddArgument("--headless"); // Dodanie trybu headless
            chromeOptions.AddArgument("--window-size=1920,1080");



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
    }

    public enum DriverName
    {
        Chrome, Firefox, Ie
    }
}