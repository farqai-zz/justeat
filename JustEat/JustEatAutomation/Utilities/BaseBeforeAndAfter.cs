using JustEatAutomation.Utilities;
using TechTalk.SpecFlow;

namespace JustEat.Utilities
{
   [Binding]
   public class BaseBeforeAndAfter
   {
       private WebDriverConfig _webDriver;

        [BeforeScenario]
        public void BeforeScenario()
        {
            _webDriver = new WebDriverConfig(ScenarioContext.Current);
            ScenarioContext.Current["webDriver"] = _webDriver;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _webDriver.CleanUp();
        }
    }
}