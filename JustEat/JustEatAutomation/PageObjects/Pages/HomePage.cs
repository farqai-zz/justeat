using JustEatAutomation.Utilities;
using OpenQA.Selenium;

namespace JustEatAutomation.PageObjects.Pages
{
    public class HomePage
    {
        private readonly IWebDriver _webDriver;
        private readonly WebDriverExtension extension;
        private readonly By _postCodeTxtBox = By.Id("postcode");
        private readonly By _restaurantSignUpLink = By.LinkText("Restaurant sign up");
        private readonly By _loginLink = By.LinkText("Log in");
        private readonly By _loginMessage = By.Id("data-test-header-account-name");

        public HomePage(IWebDriver driver)
        {
            this._webDriver = driver;
            extension = new WebDriverExtension(_webDriver);
        }

        public void InsertPostcode(string postCode)
        {
         _webDriver.FindElement(_postCodeTxtBox).SendKeys(postCode);
        }

        public void SearchOnPostCode()
        {
            _webDriver.FindElement(_postCodeTxtBox).SendKeys(Keys.Enter);
        }

        public void GoToRestaurantSignUpForm()
        {
             extension.ScrollToView(_webDriver.FindElement(_restaurantSignUpLink));
            _webDriver.FindElement(_restaurantSignUpLink).Click();
        }

        public void GoToLoginPage()
        {
            _webDriver.FindElement(_loginLink).Click();
        }

        public bool HasLoggedIn()
        {
            return _webDriver.FindElement(_loginMessage).Displayed;
        }
    }
}