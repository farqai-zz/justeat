using System;
using JustEatAutomation.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace JustEatAutomation.PageObjects.Pages
{
    public class RestaurantSignUpPage
    {
        private readonly IWebDriver _webDriver;
        private readonly WebDriverExtension _extension;
        private readonly By _firstName = By.Name("owner.givenName");
        private readonly By _surName= By.Name("owner.familyName");
        private readonly By _addressOne = By.Name("address.lines.0");
        private readonly By _addressTwo = By.Name("address.city");
        private readonly By _postCode = By.Name("address.postalCode");
        private readonly By _requestedCuisine = By.Name("menu.requestedCuisines.0");
        private readonly By _deliverOrCollect = By.Name("fulfilment.type");
        private readonly By _numberOfDrivers = By.Name("fulfilment.numberOfDeliveryDriversAtPeak");
        private readonly By _nextSteps = By.CssSelector("input[value='Next Step']");
        private readonly By _titleText = By.TagName("h1");
        private readonly By _form = By.Id("nav-trigger");
        private readonly By _homeLink = By.Id("toggle-locations");

        public RestaurantSignUpPage(IWebDriver driver)
        {
            this._webDriver = driver;
            _extension = new WebDriverExtension(_webDriver);
        }

        public void FillForm(string firstName, string surName, string addressOne, string addressTwo, string postCode)
        {
            _extension.WaitForElementToDisplay(_webDriver.FindElement(_form));
            _webDriver.FindElement(_firstName).SendKeys(firstName);
            _webDriver.FindElement(_surName).SendKeys(surName);
            _webDriver.FindElement(_addressOne).SendKeys(addressOne);
            _webDriver.FindElement(_addressTwo).SendKeys(addressTwo);
            _webDriver.FindElement(_addressTwo).SendKeys(addressTwo);
            _webDriver.FindElement(_postCode).SendKeys(postCode); 
        }

        public void SelectCuisine(string cuisine)
        {
            var selectedCuisine = new SelectElement(_webDriver.FindElement(_requestedCuisine));
            selectedCuisine.SelectByValue(cuisine);
        }

        public void SelectFulfillment(string fulfillment)
        {
            var selectedCuisine = new SelectElement(_webDriver.FindElement(_deliverOrCollect));
            selectedCuisine.SelectByValue(fulfillment);
        }

        public void SelectDrivers(string drivers)
        {
            var selectedCuisine = new SelectElement(_webDriver.FindElement(_numberOfDrivers));
            selectedCuisine.SelectByValue(drivers);
        }

        public void SubmitForm()
        {
            _webDriver.FindElement(_nextSteps).Click();
        }

        public string Title()
        {
            _extension.ImplicitlyWait(5);
            return _webDriver.FindElement(_titleText).Text;
        }

        public void WaitForSignUpFormToLoad()
        {
            _extension.WaitForPresence(_webDriver.FindElement(_form));
        }
    }
}