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
        private RestaurantsListPage _restaurantsListPage;
        private RestaurantSignUpWizardPage _restaurantSignUpWizardPage;
        private RestaurantSignUpPage _restaurantSignUpPage;
        private LoginPage _loginPage;

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
            _webDriver = GetWebDriver();
            _homePage = new HomePage(_webDriver);
            _homePage.GoToLoginPage();
            _loginPage = new LoginPage(_webDriver);
        }


        #endregion

        #region When

        [When(@"I search for restaurants")]
        public void WhenISearchForRestaurants()
        {
           _homePage.SearchOnPostCode();
        }

        [When(@"I provide my '(.*)' and '(.*)' and '(.*)' and '(.*)' and '(.*)' and '(.*)' and '(.*)' and '(.*)' and '(.*)' and '(.*)' and '(.*)'")]
        public void WhenIProvideMyAndAndAndAndAndAndAndAndAndAnd(string firstName, string lastName, string mobile, string email, string restaurant, string street, string city, string postCode, string cuisine, string status, string drivers)
        {
           _restaurantSignUpWizardPage = new RestaurantSignUpWizardPage(_webDriver);
           _restaurantSignUpWizardPage.FillWizardForm(restaurant,postCode,mobile,email);
           _restaurantSignUpWizardPage.SubmitWizardForm();
           _restaurantSignUpPage = new RestaurantSignUpPage(_webDriver);
           _restaurantSignUpPage.FillForm(firstName,lastName,street,city,postCode);
           _restaurantSignUpPage.SelectCuisine(cuisine);
           _restaurantSignUpPage.SelectFulfillment(status);
           _restaurantSignUpPage.SubmitForm();
        }

        [When(@"I provide my '(.*)' and '(.*)'")]
        public void WhenIProvideMyAnd(string email, string password)
        {
            _loginPage.FillLoginForm(email,password);
            _loginPage.Login();
        }

        #endregion

        #region Then

        [Then(@"I should see some restaurants in AR(.*)AA")]
        public void ThenIShouldSeeSomeRestaurantsInARAA(string p0)
        {
            _restaurantsListPage = new RestaurantsListPage(_webDriver);
            var restaurants = _restaurantsListPage.GetListOfRestaurants();
            Assert.That(restaurants.Count > 0,"No restaurants found for this post code.");
        }

        [Then(@"I have successfully registered my restaurant")]
        public void ThenIHaveSuccessfullyRegisteredMyRestaurant()
        {
           Assert.That(_restaurantSignUpPage.Title().Equals("Thank you for getting in touch!"), "Unable to register restaurant.");
        }
        
        [Then(@"I have been I cannot be logged in")]
        public void ThenIHaveBeenICannotBeLoggedIn()
        {
            Assert.That(_loginPage.HasLoggedIn().Equals(true), "User was able to login");
        }

        #endregion
    }


}
