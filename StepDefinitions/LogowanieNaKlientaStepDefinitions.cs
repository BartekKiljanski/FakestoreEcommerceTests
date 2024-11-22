using FakestoreEcommerceTests.PageObject;
using Microsoft.Win32;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace FakestoreEcommerceTests.StepDefinitions
{
    [Binding]
    public class LogowanieNaKlientaStepDefinitions
    {


		private readonly IWebDriver _driver;
		private readonly NewCustomerPageObject _customerPageObject;


		public LogowanieNaKlientaStepDefinitions(IWebDriver driver)
		{
			_driver = driver;
			_customerPageObject = new NewCustomerPageObject(_driver);
		}


		[Given(@"znajduje się na podstronie ""([^""]*)""")]
		public void GivenZnajdujeSieNaPodstronie(string account)
		{
			_customerPageObject.IsElementVisible("h2", account);
		}

		[Given(@"wybieram ""([^""]*)""")]
		public void GivenWybieram(string LogIn)
		{
			_customerPageObject.SelectButton(LogIn);
		}

		[Then(@"Wybieram pole do logowania i wprowadzam ""([^""]*)""")]
		public void ThenWybieramPoleDoLogowaniaIWprowadzam(string email)
		{
			_customerPageObject.FillField("id", "username", email);
		}

		[Then(@"Wybieram pole z hasłem i wprowadzam ""([^""]*)""")]
		public void ThenWybieramPoleZHaslemIWprowadzam(string haslo)
		{
			_customerPageObject.FillField("id", "password", haslo);
		}

	}
}
