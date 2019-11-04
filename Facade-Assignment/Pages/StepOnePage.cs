using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Facade.Pages
{
    public class StepOnePage
    {
        private readonly IWebDriver _webDriver;
        private IWebElement _firstName;
        private IWebElement _lastName;
        private IWebElement _address;
        private IWebElement _next;

        public StepOnePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void Load()
        {
            var wait = new WebDriverWait(_webDriver,
                System.TimeSpan.FromSeconds(15));
            wait.Until(driver =>
                _firstName = driver.FindElement(By.XPath("//*[@id=\"step-1\"]/div/div/div[1]/input")));
            wait.Until(driver =>
                _lastName = driver.FindElement(By.XPath("//*[@id=\"step-1\"]/div/div/div[2]/input")));
            wait.Until(driver =>
                _address = driver.FindElement(By.XPath("//*[@id=\"step-1\"]/div/div/div[3]/textarea")));
            wait.Until(driver =>
                _next = driver.FindElement(By.XPath("//*[@id=\"step-1\"]/div/div/button")));
        }

        public void Fill()
        {
            _firstName.SendKeys("First Name");
            _lastName.SendKeys("Last Name");
            _address.SendKeys("Str. Palat 3C UBC 4 et. 5, Iasi");
        }

        public void Next()
        {
            _next.Click();
        }
    }
}