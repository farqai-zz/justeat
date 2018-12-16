using System.Threading;
using JustEatAutomation.Utilities;
using OpenQA.Selenium;

namespace JustEatAutomation.PageObjects.Pages
{
    public class RestaurantSignUpWizardPage
    {
        private readonly IWebDriver _webDriver;
        private readonly WebDriverExtension extension;
        private readonly By _restaurantName = By.Name("name");
        private readonly By _restaurantPostCode = By.Name("address.postalCode");
        private readonly By _restaurantMobile = By.Name("owner.phoneNumber");
        private readonly By _restaurantEmail = By.Name("owner.emailAddress");
        private readonly By _getStartedBtn = By.CssSelector("input[value='Get Started']");
        private readonly By _wizardForm = By.Id("wizard-form");
        private readonly By _registerInterest = By.LinkText("Register interest");

        public RestaurantSignUpWizardPage(IWebDriver driver)
        {
            this._webDriver = driver;
            extension = new WebDriverExtension(_webDriver);
        }

        public void FillWizardForm(string name, string postCode, string mobile, string email)
        {
            extension.WaitForElementToDisplay(_webDriver.FindElement(_wizardForm));
            _webDriver.FindElement(_restaurantName).SendKeys(name);
            _webDriver.FindElement(_restaurantPostCode).SendKeys(postCode);
            _webDriver.FindElement(_restaurantMobile).SendKeys(mobile);
            _webDriver.FindElement(_restaurantEmail).SendKeys(email);
        }

        public void SubmitWizardForm()
        {
            _webDriver.FindElement(_getStartedBtn).Click();
            Thread.Sleep(2000);//ToDo use implicit wait on submit
        }

        public bool IsWizardPresent()
        {
           return extension.IsElementPresent(_wizardForm);
        }

        public void RegisterInterest()
        {
            _webDriver.FindElement(_registerInterest).Click();
            Thread.Sleep(2000);//ToDo use implicit wait on submit
        }
    }
}