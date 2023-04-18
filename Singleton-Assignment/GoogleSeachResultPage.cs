using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Singleton
{
    public class GoogleSeachResultPage
    {
        public string FirstSearchTitle { get; set; }

        public void Load()
        {
            var wait = new WebDriverWait(WebDriver.Instance,
                System.TimeSpan.FromSeconds(15));
            wait.Until(driver =>
                FirstSearchTitle= driver.FindElement(By.XPath("//*[@id=\"rso\"]/div[1]/div/div/div/div/div/div/div[1]/a/h3")).Text);
        }
    }
}