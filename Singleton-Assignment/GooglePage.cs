using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Singleton
{
    public class GooglePage
    {
        private IWebElement _seachOnInput;

        public void Load()
        {
            WebDriver.Instance.Navigate().GoToUrl("https://www.google.ro/?gws_rd=ssl");
            var wait = new WebDriverWait(WebDriver.Instance,
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