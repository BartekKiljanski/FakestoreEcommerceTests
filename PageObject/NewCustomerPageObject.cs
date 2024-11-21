using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakestoreEcommerceTests.Helpers;
using FakestoreEcommerceTests.TestSupport;
using OpenQA.Selenium;

namespace FakestoreEcommerceTests.PageObject
{
    public class NewCustomerPageObject
    {
        private readonly IWebDriver _driver;

        public NewCustomerPageObject(IWebDriver driver)
        {
            _driver = driver;
        }

        public void GoToWebsite()
        {
            Utils.GoToUrl(_driver, AppSettings.WebSitePage);
        }

        public void SelectLabel(string tab, int idItem)
        {
            string _tab = $"//li[@id='menu-item-{idItem}']/a[text()='{tab}']";
            Utils.ForceClickElementWithMessage(_driver, By.XPath(_tab), Utils.TimeSpan15, $"Brak możliwości wybrania zakładki {_tab}", 3);

        }
		public void DissmissLink()
		{
			string _link = "//a[@class='woocommerce-store-notice__dismiss-link']";
			Utils.ForceClickElementWithMessage(_driver, By.XPath(_link), Utils.TimeSpan15, $"Brak możliwośc zamkniecia linku {_link}", 3);

		}
		public bool IsTextVisible(string text)
		{
			string _textXPath = $"//a[text()='{text}']";
			bool isVisible = Utils.FindVisibleElement(_driver, _textXPath, Utils.TimeSpan15, $"Brak elementu z tekstem: {text}");
			return isVisible;
		}


		public void SelectButton(string button)
		{
			string _button = $"//button[@value='{button}']";
			Utils.ForceClickElementWithMessage(_driver, By.XPath(_button), Utils.TimeSpan15, $"Brak możliwości wybrania przycisku {button}", 3);

		}
		public void FillField(string formAutocomplete, string optionText)
		{
			string _formAutocompleteXPath = $"//input[@autocomplete='{formAutocomplete}']";
			Utils.ClearAndSendKeysByXPath(_driver, _formAutocompleteXPath, TimeSpan.FromSeconds(15), optionText, $"Nie można wejść w interakcję z polem {formAutocomplete}.");

		}
	}
}
