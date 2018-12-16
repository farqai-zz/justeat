using System.Collections.Generic;
using OpenQA.Selenium;

namespace JustEatAutomation.PageObjects.Pages
{
    public class RestaurantsListPage
    {
        private readonly IWebDriver _webDriver;
        private readonly By _restaurantsList = By.CssSelector("a[href*='/menu']");

        public RestaurantsListPage(IWebDriver driver)
        {
            this._webDriver = driver;
        }

        public IReadOnlyCollection<IWebElement> GetListOfRestaurants()
        {
            return _webDriver.FindElements(_restaurantsList);
        }
    }
}
