using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ChainOfResponsability.Pages
{
    public class StepFourPage
    {
        private readonly IWebDriver _webDriver;
        private IWebElement _submit;

        public StepFourPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void Handle()
        {
            Load();
            Next();
        }

        private void Load()
        {
            var wait = new WebDriverWait(_webDriver,
                System.TimeSpan.FromSeconds(15));
            wait.Until(driver =>
                _submit = driver.FindElement(By.XPath("//*[@id=\"step-4\"]/div/div/button")));
        }

        private void Next()
        {
            _submit.Click();
        }
    }
}