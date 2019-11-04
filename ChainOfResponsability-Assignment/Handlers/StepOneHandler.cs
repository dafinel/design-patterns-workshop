using ChainOfResponsability.Pages;
using OpenQA.Selenium;

namespace ChainOfResponsability.Handlers
{
    public class StepOneHandler : StepHandler
    {
        private readonly bool _checkIsEmployee;

        public StepOneHandler(IWebDriver webDriver, bool checkIsEmployee) : base(webDriver)
        {
            _checkIsEmployee = checkIsEmployee;
        }
        public override void Handle()
        {
            var page = new StepOnePage(WebDriver, _checkIsEmployee);
            page.Handle();

            this.SetNext(new StepTwoHandler(WebDriver, _checkIsEmployee));
            NextHandler.Handle();
        }
    }
}