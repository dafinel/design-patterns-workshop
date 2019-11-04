using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ChainOfResponsability.Pages
{
    public class StepTwoPage
    {
        private readonly IWebDriver _webDriver;
        private IWebElement _line1;
        private IWebElement _line2;
        private IWebElement _city;
        private IWebElement _country;
        private IWebElement _next;

        public StepTwoPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
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
                _line1 = driver.FindElement(By.XPath("//*[@id=\"step-2\"]/div/div/div[1]/input")));
            wait.Until(driver =>
                _line2 = driver.FindElement(By.XPath("//*[@id=\"step-2\"]/div/div/div[2]/input")));
            wait.Until(driver =>
                _city = driver.FindElement(By.XPath("//*[@id=\"step-2\"]/div/div/div[3]/input")));
            wait.Until(driver =>
                _country = driver.FindElement(By.XPath("//*[@id=\"step-2\"]/div/div/div[4]/input")));
            wait.Until(driver =>
                _next = driver.FindElement(By.XPath("//*[@id=\"btn-step-2\"]")));
        }

        private void Fill()
        {
            _line1.SendKeys("Str. Palat 3C");
            _line2.SendKeys("UBC 4");
            _city.SendKeys("Iasi");
            _country.SendKeys("Romania");
        }

        private void Next()
        {
            _next.Click();
        }
    }
}