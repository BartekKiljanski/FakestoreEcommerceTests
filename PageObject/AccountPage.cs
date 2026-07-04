using FakestoreEcommerceTests.Models;
using FakestoreEcommerceTests.TestSupport;
using OpenQA.Selenium;

namespace FakestoreEcommerceTests.PageObject
{
    public class AccountPage : BasePage
    {
        public AccountPage(IWebDriver driver) : base(driver)
        {
        }

        public void Open()
        {
            GoToWebsite();
            OpenMenuItem("Moje konto");
            DismissStoreNotice();
        }

        public void Login(TestUser user)
        {
            FillFieldById("username", user.Email);
            FillFieldById("password", user.Password);
            SubmitButton("Zaloguj się");
        }

        public void Register(TestUser user)
        {
            FillFieldById("reg_email", user.Email);
            FillFieldById("reg_password", user.Password);
            SubmitButton("Zarejestruj się");
        }

        public void RegisterWithEmailOnly(string email)
        {
            FillFieldById("reg_email", email);
            SubmitButton("Zarejestruj się");
        }

        public void Logout()
        {
            Driver.Manage().Cookies.DeleteAllCookies();
            Open();
        }

        public bool IsDashboardVisible()
        {
            return IsTextVisible("Kokpit");
        }

        public bool IsErrorVisible()
        {
            return Utils.IsElementPresent(Driver, "//ul[contains(@class,'woocommerce-error')]", Utils.TimeSpan15, "Brak komunikatu błędu");
        }

        public string GetErrorText()
        {
            return Utils.GetTextFromVisibleElement(Driver, "//ul[contains(@class,'woocommerce-error')]", Utils.TimeSpan15, "Brak treści błędu");
        }

        public string GetPasswordValidationMessage()
        {
            var passwordField = Driver.FindElement(By.Id("reg_password"));
            return passwordField.GetAttribute("validationMessage");
        }

        private void FillFieldById(string id, string value)
        {
            Utils.ClearAndSendKeysById(Driver, id, Utils.TimeSpan15, value, $"Nie można uzupełnić pola {id}.");
        }

        private void SubmitButton(string buttonValue)
        {
            var buttonXPath = $"//button[@value='{buttonValue}']";
            Utils.ForceClickElementWithMessage(Driver, By.XPath(buttonXPath), Utils.TimeSpan15, $"Brak możliwości wybrania przycisku {buttonValue}", 3);
        }
    }
}
