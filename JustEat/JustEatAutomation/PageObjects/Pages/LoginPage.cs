using OpenQA.Selenium;

namespace JustEatAutomation.PageObjects.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _webDriver;
        private readonly By _email = By.Id("Email");
        private readonly By _password = By.Id("Password");
        private readonly By _loginBtn = By.CssSelector("input[value='Log in']");

        public LoginPage(IWebDriver driver)
        {
            this._webDriver = driver;
        }

        public void FillLoginForm(string email, string password)
        {
            _webDriver.FindElement(_email).SendKeys(email);
            _webDriver.FindElement(_password).SendKeys(password);
        }

        public void Login()
        {
            _webDriver.FindElement(_loginBtn).Click();
        }

     
    }
}
