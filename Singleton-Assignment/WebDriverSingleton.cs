using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Singleton
{
    public class WebDriverSingleton
    {
        private static IWebDriver _webDriver;
        private static readonly object Lock = new object();

        private WebDriverSingleton()
        {
            // Empty constructor.
        }

        public static IWebDriver Instance
        {
            get
            {
                lock (Lock)
                {
                    if (_webDriver == null)
                    {
                        _webDriver = new ChromeDriver();
                    }
                    return _webDriver;
                }
            }
        }
    }
}