using FakestoreEcommerceTests.Helpers;
using FakestoreEcommerceTests.TestSupport;
using OpenQA.Selenium;

namespace FakestoreEcommerceTests.PageObject
{
    public abstract class BasePage
    {
        protected readonly IWebDriver Driver;

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void GoToWebsite()
        {
            Utils.GoToUrl(Driver, AppSettings.WebSitePage);
        }

        public void OpenMenuItem(string menuItem)
        {
            var menuItemXPath = $"//ul[@id='menu-menu']//a[normalize-space()='{menuItem}']";
            Utils.ForceClickElementWithMessage(Driver, By.XPath(menuItemXPath), Utils.TimeSpan15, $"Brak możliwości wybrania zakładki {menuItem}", 3);
        }

        public void DismissStoreNotice()
        {
            var noticeXPath = "//a[contains(@class,'woocommerce-store-notice__dismiss-link')]";

            if (Utils.IsElementPresent(Driver, noticeXPath, Utils.TimeSpan5))
            {
                Utils.ForceClickElementWithMessage(Driver, By.XPath(noticeXPath), Utils.TimeSpan5, "Brak możliwości zamknięcia komunikatu sklepu", 2);
            }
        }

        public bool IsTextVisible(string text)
        {
            var textXPath = $"//*[contains(normalize-space(),'{text}')]";
            return Utils.FindVisibleElement(Driver, textXPath, Utils.TimeSpan15, $"Brak elementu z tekstem: {text}");
        }
    }
}
