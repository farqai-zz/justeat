using JustEatAutomation.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace JustEatAutomation.PageObjects.Pages
{
   public class SignUpPage
   {
       private readonly IWebDriver _webDriver;
       private readonly WebDriverExtension _extension;
       private readonly By _firstName = By.Id("first_name");
       private readonly By _surName = By.Id("last_name");
       private readonly By _phoneNumber = By.Id("phone");
       private readonly By _email = By.Id("email");
       private readonly By _restaurantName = By.Id("company");
       private readonly By _addressOne= By.Id("street");
       private readonly By _addressTwo = By.Id("city");
       private readonly By _postCode = By.Id("zip");
       private readonly By _cuisine = By.Id("cuisine");
       private readonly By _status = By.Id("deliveryStatus");
       private readonly By _drivers = By.Id("drivers");
       private readonly By _nextSteps = By.CssSelector("input[value='Submit']");
       private readonly By _titleText = By.TagName("h1");

       public SignUpPage(IWebDriver driver)
       {
           _webDriver = driver;
           _extension = new WebDriverExtension(_webDriver);
       }

       public void FillForm(string firstName, string surName, string mobile, string email, string restaurant, string street, string city, string postCode)
       {
           _extension.JavaScriptWaitUntilPageIsLoaded();
           _webDriver.FindElement(_firstName).SendKeys(firstName);
           _webDriver.FindElement(_surName).SendKeys(surName);
           _webDriver.FindElement(_phoneNumber).SendKeys(mobile);
           _webDriver.FindElement(_email).SendKeys(email);
           _webDriver.FindElement(_restaurantName).SendKeys(restaurant);
           _webDriver.FindElement(_addressOne).SendKeys(street);
           _webDriver.FindElement(_addressTwo).SendKeys(city);
           _webDriver.FindElement(_postCode).SendKeys(postCode);
        }

       public void SelectCuisine(string cuisine)
       {
           var selectedCuisine = new SelectElement(_webDriver.FindElement(_cuisine));
           selectedCuisine.SelectByValue(cuisine);
       }

       public void SelectFulfillment(string fulfillment)
       {
           var selectedCuisine = new SelectElement(_webDriver.FindElement(_status));
           selectedCuisine.SelectByValue(GetCorrectStatus(fulfillment));
       }

       public void SelectDrivers(string drivers)
       {
           var selectedCuisine = new SelectElement(_webDriver.FindElement(_drivers));
           selectedCuisine.SelectByValue(drivers);
       }

       public void SubmitForm()
       {
           _webDriver.FindElement(_nextSteps).Click();
        }

       public string Title()
       {
           return _webDriver.FindElement(_titleText).Text;
       }

       private static string GetCorrectStatus(string status)
       {
           return status == "collectionOnly" ? "Collection Only (No Delivery)" : string.Empty;
       }

       public void WaitForSuccessPage()
       {
           _extension.WaitForPresence(_webDriver.FindElement(_titleText));
       }
    }
}