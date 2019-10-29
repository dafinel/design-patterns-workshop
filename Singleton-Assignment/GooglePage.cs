using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Singleton
{
    public class GooglePage
    {
        private readonly IWebDriver _webDriver;

        public GooglePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        private IWebElement _seachOnInput;

        public void Load()
        {
            _webDriver.Navigate().GoToUrl("https://www.google.ro/?gws_rd=ssl");
            var wait = new WebDriverWait(_webDriver,
                System.TimeSpan.FromSeconds(15));
            wait.Until(driver =>
                _seachOnInput = driver.FindElement(By.XPath("//*[@id=\"tsf\"]/div[2]/div[1]/div[1]/div/div[2]/input")));
        }

        public void SearchOn(string text)
        {
            _seachOnInput.SendKeys(text);
            _seachOnInput.SendKeys(Keys.Enter);
        }
    }
}