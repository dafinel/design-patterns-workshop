using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Singleton
{
    public class GoogleSeachResultPage
    {
        private readonly IWebDriver _webDriver;

        public GoogleSeachResultPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public string FirstSearchTitle { get; set; }

        public void Load()
        {
            var wait = new WebDriverWait(_webDriver,
                System.TimeSpan.FromSeconds(15));
            wait.Until(driver =>
                FirstSearchTitle= driver.FindElement(By.XPath("//*[@id=\"rso\"]/div/div/div[1]/div/div/div[1]/a/h3")).Text);
        }
    }
}