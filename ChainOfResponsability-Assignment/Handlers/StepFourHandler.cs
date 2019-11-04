using ChainOfResponsability.Pages;
using OpenQA.Selenium;

namespace ChainOfResponsability.Handlers
{
    public class StepFourHandler: StepHandler
    {
        public StepFourHandler(IWebDriver webDriver) : base(webDriver)
        {
        }

        public override void Handle()
        {
            var page = new StepFourPage(WebDriver);
            page.Handle();
        }
    }
}