using System.Configuration;
using OpenQA.Selenium;

namespace Proxy
{
    public class PaymentPageProxy : IPaymentPage
    {
        private readonly IWebDriver _webDriver;

        private readonly PaymentPage _paymentPage;

        public PaymentPageProxy(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            _paymentPage = new PaymentPage(webDriver);
        }

        public void Fill()
        {
            _paymentPage.Fill();
        }

        public void Submit()
        {
            var environment = ConfigurationManager.AppSettings["environment"];

            if (environment == "production")
            {
                var successfulUrl = ConfigurationManager.AppSettings["successfulPaymentUrl"];
                _webDriver.Navigate().GoToUrl(successfulUrl);
            }
            else
            {
                _paymentPage.Submit();
            }
        }
    }
}