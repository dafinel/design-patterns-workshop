using OpenQA.Selenium;

namespace ChainOfResponsability.Handlers
{
    public abstract class StepHandler : IStepHandler
    {
        public IWebDriver WebDriver { get; }

        protected StepHandler(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        public IStepHandler NextHandler { get; private set; }

        public void SetNext(IStepHandler nextHandler)
        {
            NextHandler = nextHandler;
        }

        public abstract void Handle();
    }
}