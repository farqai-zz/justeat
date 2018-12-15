using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JustEat.Utilities;
using JustEatAutomation.PageObjects.Pages;
using JustEatAutomation.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace JustEat.Specflow.StepDefinitions
{
    [Binding]
    public sealed class FindRestaurantsSteps : DriverSetting
    {

        private IWebDriver _webDriver;
        private HomePage _homePage;
        private RestaurantsPage _restaurantsPage;
        private RestaurantSignUpPage _restaurantSignUpPage;

        #region Given
        [Given(@"I want food in ""(.*)""")]
        public void GivenIWantFoodIn(string p0)
        {
            _webDriver = GetWebDriver();
            _homePage = new HomePage(_webDriver);
            _homePage.InsertPostcode(p0);
        }

        [Given(@"I want to sign up to a restaurant")]
        public void GivenIWantToSignUpToARestaurant()
        {
            _webDriver = GetWebDriver();
            _homePage = new HomePage(_webDriver);
            _homePage.GoToRestaurantSignUpForm();
        }

        [Given(@"I want to login")]
        public void GivenIWantToLogin()
        {
            ScenarioContext.Current.Pending();
        }


        #endregion

        #region When

        [When(@"I search for restaurants")]
        public void WhenISearchForRestaurants()
        {
           _homePage.SearchOnPostCode();
        }

        [When(@"I provide my '(.*)' and '(.*)' and '(.*)' and '(.*)' and '(.*)' and '(.*)' and '(.*)' and '(.*)' and '(.*)' and '(.*)' and '(.*)'")]
        public void WhenIProvideMyAndAndAndAndAndAndAndAndAndAnd(string p0, string p1, string p2, string p3, string p4, string p5, string p6, string p7, string p8, string p9, string p10)
        {
           _restaurantSignUpPage = new RestaurantSignUpPage(_webDriver);
           _restaurantSignUpPage.FillWizardForm(p4,p7,p2,p3);
           _restaurantSignUpPage.SubmitWizardForm();
        }

        [When(@"I provide my test@testme\.com and test(.*)!A")]
        public void WhenIProvideMyTestTestme_ComAndTestA(int p0)
        {
            ScenarioContext.Current.Pending();
        }


        #endregion

        #region Then

        [Then(@"I should see some restaurants in AR(.*)AA")]
        public void ThenIShouldSeeSomeRestaurantsInARAA(string p0)
        {
            _restaurantsPage = new RestaurantsPage(_webDriver);
            var restaurants = _restaurantsPage.GetListOfRestaurants();
            Assert.That(restaurants.Count > 0);
        }

        [Then(@"I have successfully registered my restaurant")]
        public void ThenIHaveSuccessfullyRegisteredMyRestaurant()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I have logged in successfully")]
        public void ThenIHaveLoggedInSuccessfully()
        {
            ScenarioContext.Current.Pending();
        }


        #endregion
    }

    
}
