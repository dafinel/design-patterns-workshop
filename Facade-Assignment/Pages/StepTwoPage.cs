using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Facade.Pages
{
    public class StepTwoPage
    {
        private readonly IWebDriver _webDriver;
        private IWebElement _companyName;
        private IWebElement _address;
        private IWebElement _next;

        public StepTwoPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void Load()
        {
            var wait = new WebDriverWait(_webDriver,
                System.TimeSpan.FromSeconds(15));
            wait.Until(driver =>
                _companyName = driver.FindElement(By.XPath("//*[@id=\"step-2\"]/div/div/div[1]/input")));
            wait.Until(driver =>
                _address = driver.FindElement(By.XPath("//*[@id=\"step-2\"]/div/div/div[2]/input")));
            wait.Until(driver =>
                _next = driver.FindElement(By.XPath("//*[@id=\"step-2\"]/div/div/button")));
        }

        public void Fill()
        {
            _companyName.SendKeys("Centric It Solutions");
            _address.SendKeys("Str. Palat 3C UBC 4 et. 5, Iasi");
        }

        public void Next()
        {
            _next.Click();
        }
    }
}