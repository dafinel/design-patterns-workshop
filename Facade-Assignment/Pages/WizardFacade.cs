using OpenQA.Selenium;

namespace Facade.Pages
{
    public class WizardFacade
    {
        private readonly StepOnePage _step1;
        private readonly StepTwoPage _step2;
        private readonly StepThreePage _step3;

        public WizardFacade(IWebDriver webDriver)
        {
           _step1 = new StepOnePage(webDriver);
           _step2 = new StepTwoPage(webDriver);
           _step3 = new StepThreePage(webDriver);
        }

        public void Fill()
        {
            _step1.Load();
            _step1.Fill();
            _step1.Next();

            _step2.Load();
            _step2.Fill();
            _step2.Next();

            _step3.Load();
            _step3.Next();
        }
    }
}