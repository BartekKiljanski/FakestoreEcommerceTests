using FakestoreEcommerceTests.PageObject;
using FluentAssertions;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace FakestoreEcommerceTests.StepDefinitions
{
    [Binding]
    public class CartStepDefinitions
    {
        private readonly ShopPage _shopPage;
        private readonly CartPage _cartPage;

        public CartStepDefinitions(IWebDriver driver)
        {
            _shopPage = new ShopPage(driver);
            _cartPage = new CartPage(driver);
        }

        [Given(@"otwieram stronę sklepu")]
        public void GivenOtwieramStroneSklepu()
        {
            _shopPage.Open();
        }

        [When(@"dodaję produkt ""([^""]*)"" do koszyka")]
        public void WhenDodajeProduktDoKoszyka(string productName)
        {
            _shopPage.AddProductToCart(productName);
        }

        [When(@"przechodzę do koszyka")]
        public void WhenPrzechodzeDoKoszyka()
        {
            _cartPage.Open();
        }

        [When(@"zmieniam ilość produktu ""([^""]*)"" na ""([^""]*)""")]
        public void WhenZmieniamIloscProduktuNa(string productName, string quantity)
        {
            _cartPage.ChangeQuantity(productName, quantity);
            _cartPage.UpdateCart();
        }

        [When(@"usuwam produkt ""([^""]*)"" z koszyka")]
        public void WhenUsuwamProduktZKoszyka(string productName)
        {
            _cartPage.RemoveProduct(productName);
        }

        [When(@"przechodzę do zamówienia")]
        public void WhenPrzechodzeDoZamowienia()
        {
            _cartPage.GoToCheckout();
        }

        [Then(@"widzę komunikat dodania produktu ""([^""]*)""")]
        public void ThenWidzeKomunikatDodaniaProduktu(string productName)
        {
            _shopPage.IsAddedToCartMessageVisible(productName).Should().BeTrue();
        }

        [Then(@"produkt ""([^""]*)"" znajduje się w koszyku")]
        public void ThenProduktZnajdujeSieWKoszyku(string productName)
        {
            _cartPage.Open();
            _cartPage.ContainsProduct(productName).Should().BeTrue();
        }

        [Then(@"produkt ""([^""]*)"" ma ilość ""([^""]*)"" w koszyku")]
        public void ThenProduktMaIloscWKoszyku(string productName, string quantity)
        {
            _cartPage.HasQuantity(productName, quantity).Should().BeTrue();
        }

        [Then(@"koszyk jest pusty")]
        public void ThenKoszykJestPusty()
        {
            _cartPage.IsEmpty().Should().BeTrue();
        }

        [Then(@"widzę stronę zamówienia")]
        public void ThenWidzeStroneZamowienia()
        {
            _cartPage.IsCheckoutPageVisible().Should().BeTrue();
        }
    }
}
