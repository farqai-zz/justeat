using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace JustEatAutomation.Utilities
{
    public abstract class DriverSetting
    {
        protected IWebDriver GetWebDriver()
        {
            var webDriver = (WebDriverConfig)ScenarioContext.Current["webDriver"];
            return webDriver.InitLocalDriver();
        }
    }
}