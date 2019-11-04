using ChainOfResponsability.Pages;
using OpenQA.Selenium;

namespace ChainOfResponsability.Handlers
{
    public class StepThreeHandler: StepHandler
    {
        public StepThreeHandler(IWebDriver webDriver) : base(webDriver)
        {
        }

        public override void Handle()
        {
            var page = new StepThreePage(WebDriver);
            page.Handle();

            this.SetNext(new StepFourHandler(WebDriver));
            NextHandler.Handle();
        }
    }
}