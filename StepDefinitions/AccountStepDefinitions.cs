using FakestoreEcommerceTests.Helpers;
using FakestoreEcommerceTests.Models;
using FakestoreEcommerceTests.PageObject;
using FluentAssertions;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace FakestoreEcommerceTests.StepDefinitions
{
    [Binding]
    public class AccountStepDefinitions
    {
        private readonly AccountPage _accountPage;
        private TestUser? _createdUser;

        public AccountStepDefinitions(IWebDriver driver)
        {
            _accountPage = new AccountPage(driver);
        }

        [Given(@"otwieram stronę logowania")]
        [Given(@"otwieram stronę rejestracji")]
        public void GivenOtwieramStroneKonta()
        {
            _accountPage.Open();
        }

        [When(@"loguję się jako użytkownik ""([^""]*)""")]
        public void WhenLogujeSieJakoUzytkownik(string userName)
        {
            var user = TestUserFactory.GetUser(userName);
            _accountPage.Login(user);
        }

        [When(@"rejestruję nowego losowego klienta")]
        public void WhenRejestrujeNowegoLosowegoKlienta()
        {
            _createdUser = TestUserFactory.CreateRandomUser();
            _accountPage.Register(_createdUser);
        }

        [When(@"wylogowuję klienta")]
        public void WhenWylogowujeKlienta()
        {
            _accountPage.Logout();
        }

        [When(@"loguję się ostatnio utworzonym klientem")]
        public void WhenLogujeSieOstatnioUtworzonymKlientem()
        {
            _createdUser.Should().NotBeNull();
            _accountPage.Login(_createdUser!);
        }

        [When(@"próbuję zarejestrować klienta bez hasła")]
        public void WhenProbujeZarejestrowacKlientaBezHasla()
        {
            var user = TestUserFactory.CreateRandomUser();
            _accountPage.RegisterWithEmailOnly(user.Email);
        }

        [Then(@"widzę kokpit konta klienta")]
        public void ThenWidzeKokpitKontaKlienta()
        {
            _accountPage.IsDashboardVisible().Should().BeTrue();
        }

        [Then(@"widzę komunikat błędu logowania")]
        public void ThenWidzeKomunikatBleduLogowania()
        {
            _accountPage.IsErrorVisible().Should().BeTrue();
            _accountPage.GetErrorText().Should().NotBeNullOrWhiteSpace();
        }

        [Then(@"widzę komunikat błędu rejestracji")]
        public void ThenWidzeKomunikatBleduRejestracji()
        {
            _accountPage.IsErrorVisible().Should().BeTrue();
            _accountPage.GetErrorText().Should().NotBeNullOrWhiteSpace();
        }

        [Then(@"widzę walidację wymaganego hasła")]
        public void ThenWidzeWalidacjeWymaganegoHasla()
        {
            _accountPage.GetPasswordValidationMessage().Should().NotBeNullOrWhiteSpace();
        }
    }
}
