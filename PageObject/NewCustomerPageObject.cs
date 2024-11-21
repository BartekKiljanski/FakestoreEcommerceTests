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
        string _kafelekAR = $"//mdb-card-body[.//span[contains(text(), '{submitAR}')]]//button[contains(text(), '{buttonText}')]";
        Utils.ScrollToElementAndClickMessage(_driver, By.XPath(_kafelekAR), Utils.TimeSpan15, $"Nie znaleziono przycisku '{buttonText}' we wniosku WNIOSEK AKTYWNY RODZIC");
        public void EnterEmail(string email)
        {
            var emailField = $"//input[@name='{email}']";
            Utils.ScrollToElementAndClickMessage(_driver, By.XPath(_kafelekAR), Utils.TimeSpan15, $"Nie znaleziono przycisku '{buttonText}' we wniosku WNIOSEK AKTYWNY RODZIC");
            var emailField =//input[@name='email']
; // Upewnij się, że ID jest poprawne emailField.Clear(); emailField.SendKeys(email); } public void EnterPassword(string password) { var passwordField = _driver.FindElement(By.Id("password")); // Upewnij się, że ID jest poprawne passwordField.Clear(); passwordField.SendKeys(password); }
        }
        public void EnterPassword(string password)
        {
            var passwordField = _driver.FindElement(By.Id("password")); // Upewnij się, że ID jest poprawne passwordField.Clear(); passwordField.SendKeys(password); }
        }
    }
}
