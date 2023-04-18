using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Singleton
{
    public class GooglePage
    {
        private IWebElement _seachOnInput;

        public void Load()
        {
            _webDriver.Navigate().GoToUrl("https://www.google.ro");
            var wait = new WebDriverWait(_webDriver,
                System.TimeSpan.FromSeconds(15));

            wait.Until(driver =>
            {
               var button = driver.FindElement(By.Id("L2AGLb"));
               button.Click();
               return true;
            });
            wait.Until(driver =>
                _seachOnInput = driver.FindElement(By.XPath("//*[@id=\"APjFqb\"]")));
        }

        public void SearchOn(string text)
        {
            _seachOnInput.SendKeys(text);
            _seachOnInput.Submit();

        }
    }
}