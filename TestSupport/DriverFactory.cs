
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
            IWebDriver webDriver; // Deklaracja zmiennej przed switch

            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("incognito");

            switch (driverName)
            {
                case DriverName.Chrome:
                    webDriver = new ChromeDriver(chromeOptions);
                    break;
                case DriverName.Firefox:
                    webDriver = new FirefoxDriver();
                    break;
                case DriverName.Ie:
                    webDriver = new InternetExplorerDriver();
                    break;
                default:
                    webDriver = new ChromeDriver(chromeOptions);
                    break;
            }
            webDriver.Manage().Window.Size = new System.Drawing.Size(2560, 1960);

            return webDriver;
        }
       
	}

	public enum DriverName
	{
		Chrome, Firefox, Ie
	}

}