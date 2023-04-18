using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System.Configuration;

namespace Singleton_Assignment
{
    public class DriverFactory
    {
        public static IWebDriver GetDriver()
        {
            var type = ConfigurationManager.AppSettings["driver"];
            if (type == "edge")
            {
                return new EdgeDriver();
            }
            else if (type == "chrome")
            {
                return new ChromeDriver();
            }

            return null;
        }
    }
}