using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ChainOfResponsability.Pages
{
    public class StepOnePage
    {
        private readonly IWebDriver _webDriver;
        private readonly bool _checkIsEmployee;
        private IWebElement _firstName;
        private IWebElement _lastName;
        private IWebElement _isEmployee;
        private IWebElement _next;

        public StepOnePage(IWebDriver webDriver, bool checkIsEmployee)
        {
            _webDriver = webDriver;
            _checkIsEmployee = checkIsEmployee;
        }

        public void Handle()
        {
            Load();
            Fill();
            Next();
        }

        private void Load()
        {
            var wait = new WebDriverWait(_webDriver,
                System.TimeSpan.FromSeconds(15));
            wait.Until(driver =>
                _firstName = driver.FindElement(By.XPath("//*[@id=\"step-1\"]/div/div/div[1]/input")));
            wait.Until(driver =>
                _lastName = driver.FindElement(By.XPath("//*[@id=\"step-1\"]/div/div/div[2]/input")));
            wait.Until(driver =>
                _isEmployee = driver.FindElement(By.Id("isEmployee")));
            wait.Until(driver =>
                _next = driver.FindElement(By.XPath("//*[@id=\"step-1\"]/div/div/button")));
        }

        private void Fill()
        {
            _firstName.SendKeys("First Name");
            _lastName.SendKeys("Last Name");
            if (_checkIsEmployee)
            {
                _isEmployee.Click();
            }
        }

        private void Next()
        {
            _next.Click();
        }
    }
}