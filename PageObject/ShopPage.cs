using FakestoreEcommerceTests.Helpers;
using FakestoreEcommerceTests.TestSupport;
using OpenQA.Selenium;

namespace FakestoreEcommerceTests.PageObject
{
    public class ShopPage : BasePage
    {
        public ShopPage(IWebDriver driver) : base(driver)
        {
        }

        public void Open()
        {
            GoToWebsite();
            OpenMenuItem("Sklep");
            DismissStoreNotice();
        }

        public void AddProductToCart(string productName)
        {
            Utils.GoToUrl(Driver, $"{AppSettings.WebSitePage}?add-to-cart={GetProductId(productName)}");
        }

        public bool IsAddedToCartMessageVisible(string productName)
        {
            var messageXPath = $"//div[contains(@class,'woocommerce-message')][{ProductNameCondition(productName)} and contains(.,'został dodany do koszyka')]";
            return Utils.FindVisibleElement(Driver, messageXPath, Utils.TimeSpan15, $"Brak komunikatu dodania produktu {productName} do koszyka");
        }

        private static string ProductNameCondition(string productName)
        {
            var parts = productName.Split('-');

            if (parts.Length >= 2)
            {
                return $"contains(normalize-space(),'{parts[0].Trim()}') and contains(normalize-space(),'{parts[1].Trim()}')";
            }

            return $"contains(normalize-space(),'{productName}')";
        }

        private static string GetProductId(string productName)
        {
            if (productName.Contains("Egipt") && productName.Contains("El Gouna"))
            {
                return "386";
            }

            throw new ArgumentException($"Brak zdefiniowanego produktu testowego: {productName}");
        }
    }
}
