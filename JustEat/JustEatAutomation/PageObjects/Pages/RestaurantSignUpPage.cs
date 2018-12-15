using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace JustEatAutomation.PageObjects.Pages
{
    public class RestaurantSignUpPage
    {
        private readonly IWebDriver _webDriver;
        private readonly By _restaurantName = By.Name("name");
        private readonly By _restaurantPostCode = By.Name("address.postalCode");
        private readonly By _restaurantMobile = By.Name("owner.phoneNumber");
        private readonly By _restaurantEmail = By.Name("owner.emailAddress");
        private readonly By _getStartedBtn = By.CssSelector("input[value='Get Started']");

        public RestaurantSignUpPage(IWebDriver driver)
        {
            this._webDriver = driver;
        }

        public void FillWizardForm(string name, string postCode, string mobile, string email)
        {
            _webDriver.FindElement(_restaurantName).SendKeys(name);
            _webDriver.FindElement(_restaurantPostCode).SendKeys(postCode);
            _webDriver.FindElement(_restaurantMobile).SendKeys(mobile);
            _webDriver.FindElement(_restaurantEmail).SendKeys(email);
        }

        public void SubmitWizardForm()
        {
            _webDriver.FindElement(_getStartedBtn).Click();
        }
    }
}