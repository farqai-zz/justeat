using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JustEat.Utilities;
using JustEatAutomation.PageObjects.Pages;
using JustEatAutomation.Utilities;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace JustEat.Specflow.StepDefinitions
{
    [Binding]
    public sealed class FindRestaurantsSteps : DriverSetting
    {
        private HomePage _homePage;
        private IWebDriver _webDriver;

        #region Given
        [Given(@"I want food in ""(.*)""")]
        public void GivenIWantFoodIn(string p0)
        {
            _webDriver = GetWebDriver();
            _homePage = new HomePage(_webDriver);
            _homePage.InsertPostcode(p0);
        }

        #endregion

        #region When

        [When(@"I search for restaurants")]
        public void WhenISearchForRestaurants()
        {
            ScenarioContext.Current.Pending();
        }

        #endregion

        #region Then

        [Then(@"I should see some restaurants in ""(.*)""")]
        public void ThenIShouldSeeSomeRestaurantsIn(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        #endregion
    }
}
