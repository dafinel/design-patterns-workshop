using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Proxy
{
    public class PaymentPage
    {
        private IWebElement _cardNumber;
        private IWebElement _expirationDate;
        private IWebElement _cvc;
        private IWebElement _submitButton;

        public PaymentPage(IWebDriver webDriver)
        {
            var wait = new WebDriverWait(webDriver, System.TimeSpan.FromSeconds(15));
            wait.Until(driver => _cardNumber = driver.FindElement(By.Name("cardNumber")));
            wait.Until(driver => _expirationDate = driver.FindElement(By.Name("cardExpiry")));
            wait.Until(driver => _cvc = driver.FindElement(By.Name("cardCVC")));
            wait.Until(driver => _submitButton = driver.FindElement(By.XPath("//*[@id=\"payment-form\"]/div[3]/div/button")));
        }

        public void Fill()
        {
            _cardNumber.SendKeys("4242424242424242");
            _expirationDate.SendKeys("10/24");
            _cvc.SendKeys("769");
        }

        public void Submit()
        {
            _submitButton.Click();
        }
    }
}