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
        private readonly By _postCodeTxtBox = By.Id("postcode");
        private readonly By _restaurantSignUpLink = By.LinkText("Restaurant sign up");
       // private readonly By _restaurantInterest = By.LinkText("Register interest");

        public HomePage(IWebDriver driver)
        {
            this._driver = driver;
        }

        public void InsertPostcode(string postCode)
        {
            _driver.FindElement(_postCodeTxtBox).SendKeys(postCode);
        }

        public void SearchOnPostCode()
        {
            _driver.FindElement(_postCodeTxtBox).SendKeys(Keys.Enter);
        }

        public void GoToRestaurantSignUpForm()
        {
             ScrollToView(_driver.FindElement(_restaurantSignUpLink));
            _driver.FindElement(_restaurantSignUpLink).Click();
        }

        public void ScrollToView(IWebElement element)
        {
            if (element.Location.Y > 200)
            {
                ScrollTo(0, element.Location.Y - 100); // Make sure element is in the view but below the top navigation pane
            }

        }
        public void ScrollTo(int xPosition = 0, int yPosition = 0)
        {
            var js = $"window.scrollTo({xPosition}, {yPosition})";
            ((IJavaScriptExecutor)_driver).ExecuteScript(js);
        }
    }
}