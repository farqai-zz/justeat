using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace JustEatAutomation.PageObjects.Pages
{
    public class HomePage
    {
        private readonly IWebDriver _driver;
        private readonly By _postCode = By.Id("postcode");

        public HomePage(IWebDriver driver)
        {
            this._driver = driver;
        }

        public void InsertPostcode(string postCode)
        {
            _driver.FindElement(_postCode).SendKeys(postCode);
        }

        public void SearchOnPostCode()
        {
            _driver.FindElement(_postCode).SendKeys(Keys.Enter);
        }
    }
}