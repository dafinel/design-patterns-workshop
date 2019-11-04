using ChainOfResponsability.Pages;
using OpenQA.Selenium;

namespace ChainOfResponsability.Handlers
{
    public class StepTwoHandler : StepHandler
    {
        private readonly bool _checkIsEmployee;

        public StepTwoHandler(IWebDriver webDriver, bool checkIsEmployee) : base(webDriver)
        {
            _checkIsEmployee = checkIsEmployee;
        }

        public override void Handle()
        {
            var page = new StepTwoPage(WebDriver);
            page.Handle();

            if (_checkIsEmployee)
            {
                this.SetNext(new StepThreeHandler(WebDriver));
            }
            else
            {
                this.SetNext(new StepFourHandler(WebDriver));
            }
            NextHandler.Handle();
        }
    }
}