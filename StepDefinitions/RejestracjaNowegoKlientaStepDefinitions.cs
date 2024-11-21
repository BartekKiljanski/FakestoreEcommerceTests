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
        private string _randomEmail;
        private string _randomPassword;

		public RejestracjaNowegoKlientaStepDefinitions(IWebDriver driver)
        {
            _driver = driver;
            _customerPageObject = new NewCustomerPageObject(_driver);
        }

        [Given(@"znajduje się na stronie FakeStore")]
        public void GivenZnajdujeSieNaStronieFakeStore()
        {
            _customerPageObject.GoToWebsite();
        }


        [When(@"wybieram ""([^""]*)""")]
        public void WhenWybieram(string myAccount)
        {
            _customerPageObject.SelectLabel(myAccount, 201);
        }

		[Then(@"Wyłączam link")]
		public void ThenWylaczamLink()
		{
            _customerPageObject.DissmissLink();
		}

		[Then(@"Wybieram pole ""([^""]*)"" i wprowadzam losowy email")]
		public void ThenWybieramPoleIWprowadzamLosowyEmail(string email)
		{
			_randomEmail = Utils.GenerateRandomEmail();

			_customerPageObject.FillField(email, _randomEmail);
		}

		
		[Then(@"Wybieram pole ""([^""]*)"" i wprowadzam asd(.*)dfsa!")]
		public void ThenWybieramPoleIWprowadzamAsddfsa(string password, string hasło)
		{
			_customerPageObject.FillField(password, hasło);
		}
		[Then(@"Wybieram pole ""([^""]*)"" i wprowadzam losowe hasło")]
		public void ThenWybieramPoleIWprowadzamLosoweHaslo(string password)
		{

			_randomPassword = Utils.GenerateRandomText(20);
			_customerPageObject.FillField(password, _randomPassword);
		}

		[Then(@"wybieram ""([^""]*)""")]
		public void ThenWybieram(string register)
		{
            _customerPageObject.SelectButton(register);
		}

		[Then(@"Znajduję się w edycji mojego konta i mam zakładkę ""([^""]*)""\.")]
		public void ThenZnajdujeSieWEdycjiMojegoKontaIMamZakladke_(string kokpit)
		{
			_customerPageObject.IsTextVisible(kokpit);
		}


	}
}
