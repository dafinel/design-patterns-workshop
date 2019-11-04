using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Facade.Pages
{
    public class StepThreePage
    {
        private readonly IWebDriver _webDriver;
        private IWebElement _submit;

        public StepThreePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void Load()
        {
            var wait = new WebDriverWait(_webDriver,
                System.TimeSpan.FromSeconds(15));
            wait.Until(driver =>
                _submit = driver.FindElement(By.XPath("//*[@id=\"step-3\"]/div/div/button")));
        }

        public void Next()
        {
            _submit.Click();
        }
    }
}