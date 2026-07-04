using FakestoreEcommerceTests.TestSupport;
using OpenQA.Selenium;

namespace FakestoreEcommerceTests.PageObject
{
    public class CartPage : BasePage
    {
        public CartPage(IWebDriver driver) : base(driver)
        {
        }

        public void Open()
        {
            OpenMenuItem("Koszyk");
        }

        public bool ContainsProduct(string productName)
        {
            var productXPath = $"//td[contains(@class,'product-name')]//a[{ProductNameCondition(productName)}]";
            return Utils.FindVisibleElement(Driver, productXPath, Utils.TimeSpan15, $"Brak produktu {productName} w koszyku");
        }

        public void ChangeQuantity(string productName, string quantity)
        {
            var quantityXPath = $"//tr[contains(@class,'cart_item')][.//td[contains(@class,'product-name')]//a[{ProductNameCondition(productName)}]]//input[contains(@class,'qty')]";
            Utils.ClearAndSendKeysByXPath(Driver, quantityXPath, Utils.TimeSpan15, quantity, $"Nie można zmienić ilości produktu {productName}.");
        }

        public void UpdateCart()
        {
            var updateCartXPath = "//button[@name='update_cart']";
            Utils.ForceClickElementWithMessage(Driver, By.XPath(updateCartXPath), Utils.TimeSpan15, "Brak możliwości aktualizacji koszyka", 3);
        }

        public bool HasQuantity(string productName, string quantity)
        {
            var quantityXPath = $"//tr[contains(@class,'cart_item')][.//td[contains(@class,'product-name')]//a[{ProductNameCondition(productName)}]]//input[contains(@class,'qty') and @value='{quantity}']";
            return Utils.FindVisibleElement(Driver, quantityXPath, Utils.TimeSpan15, $"Ilość produktu {productName} nie jest równa {quantity}");
        }

        public void RemoveProduct(string productName)
        {
            var removeXPath = $"//tr[contains(@class,'cart_item')][.//td[contains(@class,'product-name')]//a[{ProductNameCondition(productName)}]]//a[contains(@class,'remove')]";
            Utils.ForceClickElementWithMessage(Driver, By.XPath(removeXPath), Utils.TimeSpan15, $"Brak możliwości usunięcia produktu {productName}", 3);
        }

        public bool IsEmpty()
        {
            return Utils.FindVisibleElement(Driver, "//div[contains(@class,'cart-empty')]", Utils.TimeSpan15, "Koszyk nie jest pusty");
        }

        public void GoToCheckout()
        {
            var checkoutXPath = "//a[contains(@class,'checkout-button')]";
            Utils.ForceClickElementWithMessage(Driver, By.XPath(checkoutXPath), Utils.TimeSpan15, "Brak możliwości przejścia do zamówienia", 3);
        }

        public bool IsCheckoutPageVisible()
        {
            return IsTextVisible("Zamówienie") || Driver.Url.Contains("zamowienie");
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
    }
}
