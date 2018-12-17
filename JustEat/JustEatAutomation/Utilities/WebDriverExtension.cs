using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace JustEatAutomation.Utilities
{
    public class WebDriverExtension
    {
        private readonly IWebDriver _webDriver;

        public WebDriverExtension(IWebDriver _driver)
        {
            this._webDriver = _driver;
        }
        public void ScrollToView(IWebElement element)
        {
            if (element.Location.Y > 200)
            {
                ScrollTo(0, element.Location.Y - 100);
            }

        }
        public void ScrollTo(int xPosition = 0, int yPosition = 0)
        {
            var js = $"window.scrollTo({xPosition}, {yPosition})";
            ((IJavaScriptExecutor)_webDriver).ExecuteScript(js);
        }

        public void WaitForElementToDisplay(IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(5));
            wait.Until(driver => element.Displayed);
        }

        public void CheckPageIsLoaded(IWebDriver driver)
        {
            while (true)
            {
                bool ajaxIsComplete = (bool)(driver as IJavaScriptExecutor).ExecuteScript("return jQuery.active == 0");
                if (ajaxIsComplete)
                    return;
                Thread.Sleep(100);
            }
        }

        public bool IsElementPresent(By by)
        {
            try
            {
                _webDriver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void WaitForPresence(IWebElement element, int timeoutSeconds = 20)
        {
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(timeoutSeconds))
            {
                PollingInterval = TimeSpan.FromMilliseconds(3000)
            };
            wait.IgnoreExceptionTypes(typeof(Exception));
            wait.Until(webDriver => element.Displayed);
        }
    }
}