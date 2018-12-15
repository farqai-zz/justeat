using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace JustEatAutomation.PageObjects.Pages
{
    public class RestaurantsPage
    {
        private readonly IWebDriver _webDriver;
        private readonly By _restaurantsList = By.CssSelector("a[href*='/menu']");

        public RestaurantsPage(IWebDriver driver)
        {
            this._webDriver = driver;
        }

        public IReadOnlyCollection<IWebElement> GetListOfRestaurants()
        {
            return _webDriver.FindElements(_restaurantsList);
        }
    }
}
