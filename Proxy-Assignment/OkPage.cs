using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Proxy
{
    public class OkPage
    {
        private IWebElement _message;

        public OkPage(IWebDriver webDriver)
        {
            var wait = new WebDriverWait(webDriver, System.TimeSpan.FromSeconds(15));
            wait.Until(driver => _message = driver.FindElement(By.XPath("/html/body/div[1]/div/h1")));
        }

        public bool Is(string message)
        {
            return _message.Text == message;
        }

    }
}