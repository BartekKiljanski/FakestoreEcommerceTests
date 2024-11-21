using System;
using FakestoreEcommerceTests.Helpers;
using FakestoreEcommerceTests.PageObject;
using FakestoreEcommerceTests.TestSupport;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace FakestoreEcommerceTests.StepDefinitions
{
    [Binding]
    public class RejestracjaNowegoKlientaStepDefinitions
    {

        private readonly IWebDriver _driver;
        private readonly NewCustomerPageObject _customerPageObject;

        public RejestracjaNowegoKlientaStepDefinitions(IWebDriver driver)
        {
            _driver = driver;
            _customerPageObject = new NewCustomerPageObject(_driver);
        }

        [Given(@"znajduje się na stronie FakeStore")]
        public void GivenZnajdujeSieNaStronieFakeStore()
        {
            Console.WriteLine($"WebSitePage: {AppSettings.WebSitePage}");
            _customerPageObject.GoToWebsite();
        }



        [When(@"wybieram <zakladka>")]
        public void WhenWybieramZakladka(string myAccount)
        {
            _customerPageObject.SelectLabel(myAccount, 201);
        }


      
        [When(@"Podaję przy rejestracji losowy email")]
        public void WhenPodajePrzyRejestracjiLosowyEmail()
        {
            _randomEmail = Utils.GenerateRandomEmail();
            _customerPageObject.EnterEmail(_randomEmail);
        }

        [When(@"Wybieram pole ""([^""]*)"" i Haslo\.(.*)!")]
        public void WhenWybieramPoleIHaslo_(string password, int p1)
        {
            throw new PendingStepException();
        }

      

        [When(@"wybieram ""([^""]*)""")]
        public void WhenWybieram(string myAccount)
        {
            _customerPageObject.SelectLabel(myAccount, 201);
        }

        [Then(@"znajduję się w zakładce ""([^""]*)""")]
        public void ThenZnajdujeSieWZakladce(string accountTab)
        {
            throw new PendingStepException();
        }

    }
}
